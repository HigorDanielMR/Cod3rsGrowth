using LinqToDB;
using LinqToDB.Data;
using Cod3rsGrowth.Dominio.Entities;

namespace Cod3rsGrowth.Infra.MeuContextoDeDado
{
    public class MeuDataContext : DataConnection
    {
        public MeuDataContext() : base("MeuBancoDeDados") { }

        public ITable<Carro> Carros => this.GetTable<Carro>();
        public ITable<Venda> Vendas => this.GetTable<Venda>();
    }
}
