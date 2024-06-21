using LinqToDB;
using LinqToDB.Data;
using System.Configuration;
using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;

namespace Cod3rsGrowth.Infra.Repositorios
{
    public class RepositorioVenda : IRepositorioVenda
    {
        private DataConnection _connection;
        protected ITable<Venda> TabelaVenda;

        public RepositorioVenda()
        {
            _connection = new DataConnection(
            new DataOptions()
                .UseSqlServer(ConfigurationManager.ConnectionStrings["ConexaoComBanco"].ConnectionString));

            TabelaVenda = _connection.GetTable<Venda>();
        }

        public List<Venda> ObterTodos(FiltroVenda filtro)
        {
            var query = FiltroParaBusca(TabelaVenda, filtro);
            if (query == null)
            {
                return TabelaVenda.ToList();
            }
            else
            {
                var resultadoFiltro = query.ToList();
                return resultadoFiltro.ToList();
            }
        }

        public Venda ObterPorId(int IdDeBusca)
        {
            var query = from p in TabelaVenda
                        where p.Id == IdDeBusca
                        select p;

            var resultado = query.FirstOrDefault()
                ?? throw new Exception($"Carro com ID {IdDeBusca} não encontrado.");

            return resultado;
        }

        public Venda Criar(Venda venda)
        {
            int idDaVendaNoBanco = _connection.InsertWithInt32Identity(venda);
            return ObterPorId(idDaVendaNoBanco);
        }

        public Venda Editar(Venda vendaAtualizada)
        {
            var vendaDesejada = TabelaVenda.FirstOrDefault(venda => venda.Id == vendaAtualizada.Id);
            if (vendaDesejada != null)
            {
                vendaDesejada.Cpf = vendaAtualizada.Cpf;
                vendaDesejada.Pago = vendaAtualizada.Pago;
                vendaDesejada.Nome = vendaAtualizada.Nome;
                vendaDesejada.Email = vendaAtualizada.Email;
                vendaDesejada.Telefone = vendaAtualizada.Telefone;
                vendaDesejada.ValorTotal = vendaAtualizada.ValorTotal;
                vendaDesejada.DataDeCompra = vendaAtualizada.DataDeCompra;

                _connection.Update(vendaDesejada);
            }
            else
            {
                throw new Exception($"Venda com ID {vendaDesejada.Id} não encontrada.");
            }
            return vendaAtualizada;
        }
        public void Remover(int Id)
        {
            TabelaVenda
                .Where(venda => venda.Id == Id)
                .Delete();
        }

        private static IQueryable<Venda> FiltroParaBusca(ITable<Venda> vendas, FiltroVenda venda)
        {
            var query = vendas.AsQueryable();
            if (venda != null)
            {
                if (venda.Nome != null)
                    query = query.Where(d => d.Nome.Contains(venda.Nome));

                if (venda.Cpf != null)
                    query = query.Where(d => d.Cpf == venda.Cpf);

                if (venda.DataDeCompra != null)
                    query = query.Where(d => d.DataDeCompra == venda.DataDeCompra);

                if (venda.Telefone != null)
                    query = query.Where(d => d.Telefone == venda.Telefone);

                if (venda.Email != null)
                    query = query.Where(d => d.Email.Contains(venda.Email));
            }

            return query;
        }
    }
}
