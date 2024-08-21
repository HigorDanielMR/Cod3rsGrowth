using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Interfaces;

namespace Cod3rsGrowth.Dominio.Entidades
{
    public class FiltroCarro : IFiltro
    {
        public Marcas? Marca { get; set; }
        public string? Modelo { get; set; }
        public Cores? Cor { get; set; }
        public bool? Flex { get; set; }
    }
}
