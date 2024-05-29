using Cod3rsGrowth.Dominio.Enums;

namespace Cod3rsGrowth.Dominio.Entities
{
    public class Carro
    {
        public int Id { get; set; }
        public Marcas Marca { get; set; }
        public string Modelo { get; set; }
        public Cores Cor { get; set; }
        public decimal ValorDoVeiculo { get; set; }
        public bool Flex { get; set; }

    }
}
