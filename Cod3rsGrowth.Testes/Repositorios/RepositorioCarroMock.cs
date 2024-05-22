using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Repositorios;

namespace Cod3rsGrowth.Testes
{
    public class RepositorioCarroMock : IRepositorioCarro
    {
        private List<Carro> _repositorioCarro = ListaSingleton.Instance.RepositorioCarro;

        public List<Carro> ObterTodos()
        {
            return _repositorioCarro;
        }

        public Carro ObterCarroPorId(int id)
        {
            int i = 0;
            for (i = 0; i < _repositorioCarro.Count; i++)
            {
                if (_repositorioCarro[i].Id == id)
                {
                    break;
                }
            }
            return _repositorioCarro[i];
        }

        public void Criar(Carro carro)
        {
            _repositorioCarro.Add(carro);
        }
    }
}
