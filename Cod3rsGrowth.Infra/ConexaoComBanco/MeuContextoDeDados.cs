using LinqToDB;
using LinqToDB.Data;
using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Infra.ConexaoComBanco
{
    public class MeuContextoDeDados : DataConnection
    {
        public MeuContextoDeDados(string stringDeConexao) : base("SqlServer", stringDeConexao) { }

        public ITable<Carro> Carro => this.GetTable<Carro>();
        public ITable<Venda> Venda => this.GetTable<Venda>();
    }
}
