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

        public Carro ObterCarroPorId(int IdDeBusca)
        {
            Carro IdDoItem = new Carro();
            foreach(var item in _repositorioCarro)
            {
                if (IdDeBusca == item.Id)
                {
                    IdDoItem = item;
                    return IdDoItem;
                }
            }
            return IdDoItem;
        }

        public void Criar(Carro carro)
        {
            _repositorioCarro.Add(carro);
        }
    }
}
