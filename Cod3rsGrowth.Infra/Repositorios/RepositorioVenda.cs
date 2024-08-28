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
                ?? throw new Exception($"Venda com ID {IdDeBusca} não encontrada.");

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

            _conexao.Update(vendaAtualizada);
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

            if (!string.IsNullOrEmpty(filtroVenda.Nome))
                query = query.Where(d => d.Nome.Contains(filtroVenda.Nome));

            if (!string.IsNullOrEmpty(filtroVenda.Cpf))
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

            if (filtroVenda.Email != null)
                query = query.Where(d => d.Email.Contains(filtroVenda.Email));

            if (filtroVenda.IdDoCarroVendido != null)
                query = query.Where(d => d.IdDoCarroVendido == filtroVenda.IdDoCarroVendido);

            if (!string.IsNullOrEmpty(filtroVenda.Telefone))
                query = query.Where(d => d.Telefone == filtroVenda.Telefone);

            return query;
        }
    }
}
