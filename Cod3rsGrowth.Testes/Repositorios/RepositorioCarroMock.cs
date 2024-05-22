using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Repositorios;
using Cod3rsGrowth.Testes.Excessoes;

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
            var resultadoDabusca = _repositorioCarro.Find(objeto => objeto.Id == IdDeBusca);
            if (resultadoDabusca == null)
            {
                throw new MinhasExcessoes("Id não encontrado");
            }
            else
            {
                return resultadoDabusca;
            }
        }

        public void Criar(Carro carro)
        {
            _repositorioCarro.Add(carro);
        }
    }
}
