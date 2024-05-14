namespace Cod3rsGrowth.Dominio.Entities
{
    class Venda
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public List<Carro> ItensVendidos { get; set; }
        public DateTime DataDeCompra { get; set; }
        public decimal ValorTotal { get; set; }
        public bool Pago { get; set; }
    }
}
