using LinqToDB;
using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.ConexaoComBanco;

namespace Cod3rsGrowth.Infra.Repositorios
{
    public class RepositorioVenda : IRepositorioVenda
    {
        private MeuContextoDeDados _conexao;

        public RepositorioVenda(MeuContextoDeDados meuContextoDeDados)
        {
            _conexao = meuContextoDeDados;
        }

        public List<Venda> ObterTodos(FiltroVenda filtro)
        {
            var query = FiltroParaBusca(filtro);
            var vendasFiltradas = query.ToList();

            return vendasFiltradas;
        }

        public Venda ObterPorId(int IdDeBusca)
        {
            var query = from p in _conexao.Venda
                        where p.Id == IdDeBusca
                        select p;

            var resultado = query.FirstOrDefault()
                ?? throw new Exception($"Venda com ID {IdDeBusca} não encontrado.");

            return resultado;
        }

        public Venda Criar(Venda venda)
        {
            int idDaVendaNoBanco = _conexao.InsertWithInt32Identity(venda);
            return ObterPorId(idDaVendaNoBanco);
        }

        public Venda Editar(Venda vendaAtualizada)
        {
            var vendaDesejada = ObterPorId(vendaAtualizada.Id);

            vendaDesejada.Cpf = vendaAtualizada.Cpf;
            vendaDesejada.Pago = vendaAtualizada.Pago;
            vendaDesejada.Nome = vendaAtualizada.Nome;
            vendaDesejada.Email = vendaAtualizada.Email;
            vendaDesejada.Telefone = vendaAtualizada.Telefone;
            vendaDesejada.ValorTotal = vendaAtualizada.ValorTotal;
            vendaDesejada.DataDeCompra = vendaAtualizada.DataDeCompra;
            vendaDesejada.IdDoCarroVendido = vendaAtualizada.IdDoCarroVendido;

            _conexao.Update(vendaDesejada);
            return vendaAtualizada;
        }

        public void Remover(int Id)
        {
            _conexao.Venda
                .Where(venda => venda.Id == Id)
                .Delete();
        }

        private IQueryable<Venda> FiltroParaBusca(FiltroVenda filtroVenda)
        {
            IQueryable<Venda> query = _conexao.Venda;

            if (filtroVenda is null) return query;

            if (filtroVenda.Nome != null)
                query = query.Where(d => d.Nome.Contains(filtroVenda.Nome));

            if (filtroVenda.Cpf != null)
                query = query.Where(d => d.Cpf == filtroVenda.Cpf);

            if (!string.IsNullOrEmpty(filtroVenda.DataDeCompraInicial))
            {
                DateTime dataInicial;
                if (DateTime.TryParse(filtroVenda.DataDeCompraInicial, out dataInicial))
                {
                    query = query.Where(d => d.DataDeCompra.Date >= dataInicial.Date);
                }
            }

            if (!string.IsNullOrEmpty(filtroVenda.DataDeCompraFinal))
            {
                DateTime dataFinal;
                if (DateTime.TryParse(filtroVenda.DataDeCompraFinal, out dataFinal))
                {
                    query = query.Where(d => d.DataDeCompra.Date <= dataFinal.Date);
                }
            }

            if (filtroVenda.Telefone != null)
                query = query.Where(d => d.Telefone == filtroVenda.Telefone);

            return query;
        }
    }
}
