namespace Cod3rsGrowth.Dominio.Entities
{
    class Car
    {
        public string Modelo { get; set; }
        public int ID { get; set; }
        public DateTime DataDeCompra { get; set; }
        public decimal ValorDoVeiculo { get; set; }
        public bool Disponivel { get; set; }
        public Enum Cores { get; set; }
    }
}
