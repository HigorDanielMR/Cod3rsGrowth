using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Repositorios;

namespace Cod3rsGrowth.Testes
{
    public class RepositorioCarroMock : IRepositorioCarro
    {
        private List<Carro> RepositorioCarro = ListaSingleton.Instance.RepositorioCarro;

        public List<Carro> ObterTodos()
        {
            return RepositorioCarro;
        }

        public Carro ObterCarroPorId(int id)
        {
            int i = 0;
            for (i = 0; i < RepositorioCarro.Count; i++)
            {
                if (RepositorioCarro[i].Id == id)
                {
                    break;
                }
            }
            return RepositorioCarro[i];
        }

        public void Criar(Carro carro)
        {
            RepositorioCarro.Add(carro);
        }
    }
}
