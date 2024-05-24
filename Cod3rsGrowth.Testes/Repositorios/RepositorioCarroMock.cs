using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Repositorios;
using Cod3rsGrowth.Servicos.Validadores;

namespace Cod3rsGrowth.Testes
{
    public class RepositorioCarroMock : IRepositorioCarro
    {
        private List<Carro> _repositorioCarro = ListaSingleton.Instance.RepositorioCarro;
        private ValidacoesCarro _resultadoDaValidacao;

        public List<Carro> ObterTodos()
        {
            return _repositorioCarro;
        }

        public Carro ObterPorId(int IdDeBusca)
        {
            return _repositorioCarro.Find(objeto => objeto.Id == IdDeBusca)
                ?? throw new Exception($"O carro com ID {IdDeBusca} não foi encontrado");
        }

        public void Criar(Carro carro)
        {
            _repositorioCarro.Add(carro);
        }
    }
}
