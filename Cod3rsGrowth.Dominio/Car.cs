namespace Cod3rsGrowth.Dominio
{
    class Car
    {
        public string Modelo { get; set; }
        public int ID { get; set; }
        public DateTime DataDeRetirada { get; set; }
        public DateTime DataDeEntrega { get; set; }
        public double ValorDoAluguel { get; set; }
        public Enum Cores { get; set; }
    }
}
