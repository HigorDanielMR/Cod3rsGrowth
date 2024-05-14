using Cod3rsGrowth.Dominio.Enums;

namespace Cod3rsGrowth.Dominio.Entities
{
    class Carro
    {
        public string Modelo { get; set; }
        public int ID { get; set; }
        public decimal ValorDoVeiculo { get; set; }
        public bool Disponivel { get; set; }
        public Cores Cor { get; set; }
    }
}
