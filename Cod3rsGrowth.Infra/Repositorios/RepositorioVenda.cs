using LinqToDB;
using LinqToDB.Data;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Entidades;

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
                .UseSqlServer(@"Data Source=INVENT020\SQLEXPRESS;Initial Catalog=Cod3rsGrowthBD;Persist Security Info=True;User ID=sa;Password=sap@123;Trust Server Certificate=True"));

            TabelaVenda = _connection.GetTable<Venda>();
        }
        public List<Venda> ObterTodos(FiltroVenda filtro)
        {
            return TabelaVenda.ToList();
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
            return ObterPorId(venda.Id);

        }

        public Venda Editar(Venda vendaAtualizada)
        {
            var vendaDesejada = TabelaVenda.FirstOrDefault(venda => venda.Id == vendaAtualizada.Id);
            if (vendaDesejada != null)
            {
                vendaDesejada.Nome = vendaAtualizada.Nome;
                vendaDesejada.Cpf = vendaAtualizada.Cpf;
                vendaDesejada.Email = vendaAtualizada.Email;
                vendaDesejada.DataDeCompra = vendaAtualizada.DataDeCompra;
                vendaDesejada.Pago = vendaAtualizada.Pago;
                vendaDesejada.Telefone = vendaAtualizada.Telefone;
                vendaDesejada.ValorTotal = vendaAtualizada.ValorTotal;

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

        private static IQueryable<Venda> Filtro(List<Venda> vendas, FiltroVenda venda)
        {
            var query = vendas.AsQueryable();

            if (venda.Nome != null)
                query = query.Where(d => d.Nome == venda.Nome);

            if (venda.Cpf != null)
                query = query.Where(d => d.Cpf == venda.Cpf);

            if (venda.DataDeCompra != null)
                query = query.Where(d => d.DataDeCompra == venda.DataDeCompra);

            if (venda.Telefone != null)
                query = query.Where(d => d.Telefone == venda.Telefone);

            if (venda.Email != null)
                query = query.Where(d => d.Email == venda.Email);

            return query;
        }
    }
}
