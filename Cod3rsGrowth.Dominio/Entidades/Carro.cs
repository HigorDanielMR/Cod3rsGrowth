using LinqToDB.Mapping;
using Cod3rsGrowth.Dominio.Enums;

namespace Cod3rsGrowth.Dominio.Entidades
{
    [Table("Carro")]
    public class Carro
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }
        [Column("Marca"), NotNull]
        public Marcas Marca { get; set; }
        [Column("Modelo"), NotNull]
        public string Modelo { get; set; }
        [Column("Cor"), NotNull]
        public Cores Cor { get; set; }
        [Column("ValorDoVeiculo"), NotNull]
        public decimal ValorDoVeiculo { get; set; }
        [Column("Flex"), NotNull]
        public bool Flex { get; set; }
    }
}
