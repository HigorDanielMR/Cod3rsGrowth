using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Dominio.Interfaces;

namespace Cod3rsGrowth.Testes
{
    public class RepositorioMock : IRepositorioMock
    {
        public readonly List<Carro> carros;

        public RepositorioMock()
        {
            List<Carro> carros = new List<Carro>()
            {
            };
        }

        public List<Carro> ObterTodos()
        {
            return carros;
        }
    }
}
