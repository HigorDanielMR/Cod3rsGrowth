using LinqToDB.Mapping;

namespace Cod3rsGrowth.Dominio.Entidades
{
    [Table("Venda")]
    public class Venda
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }
        [Column("Nome"), NotNull]
        public string Nome { get; set; }
        [Column("Cpf"), NotNull]
        public string Cpf { get; set; }
        [Column("Email"), NotNull]
        public string Email { get; set; }
        [Column("Telefone"), NotNull]
        public string Telefone { get; set; }
        [Column("IdDoCarroVendido"), NotNull]
        public int IdDoCarroVendido { get; set; }
        [Column("DataDeCompra"), NotNull]
        public DateTime DataDeCompra { get; set; }
        [Column("ValorTotal"), NotNull]
        public decimal ValorTotal { get; set; }
        [Column("Pago"), NotNull]
        public bool Pago { get; set; }
    }
}
