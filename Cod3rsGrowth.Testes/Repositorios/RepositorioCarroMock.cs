using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Repositorios;

namespace Cod3rsGrowth.Testes
{
    public class RepositorioCarroMock : IRepositorioCarro
    {
        public RepositorioCarroMock()
        {
        }

        public List<Carro> RepositorioCarro = ListaSingleton.Instance.RepositorioCarro;

        public List<Carro> ObterTodos()
        {
            return RepositorioCarro;
        }

        public void Criar(Carro carro)
        {
            RepositorioCarro.Add(carro);
        }
    }
}
