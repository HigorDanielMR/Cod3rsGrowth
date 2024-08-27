using Cod3rsGrowth.Dominio.Interfaces;

namespace Cod3rsGrowth.Dominio.Entidades
{
    public class FiltroVenda : IFiltro
    {
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public string? Telefone { get; set; }
        public string? DataDeCompraInicial { get; set; }
        public string? DataDeCompraFinal { get; set; }
    }
}
