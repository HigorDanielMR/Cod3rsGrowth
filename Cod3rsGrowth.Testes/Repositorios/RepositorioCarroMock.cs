using Cod3rsGrowth.Dominio.Entities;
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
            return _repositorioCarro.Find(objeto => objeto.Id == IdDeBusca)
                ?? throw new Exception("Id não encontrado.");
        }

        public void Criar(Carro carro)
        {
            _repositorioCarro.Add(carro);
        }
    }
}
