using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Repositorios;
using System.ComponentModel.DataAnnotations;

namespace Cod3rsGrowth.Testes
{
    public class RepositorioCarroMock : IRepositorioCarro
    {
        private List<Carro> _repositorioCarro = ListaSingleton.Instance.RepositorioCarro;
        private int _novoId = 0;

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
            carro.Id = _novoId;
            _novoId++;
            _repositorioCarro.Add(carro);
        }

        public void Editar(Carro carro)
        {
            var listaDoBanco = ObterTodos();
            var indexDesejado = carro.Id;

            listaDoBanco[indexDesejado].Modelo = carro.Modelo
                ?? throw new ValidationException();

            listaDoBanco[carro.Id] = carro;
            _repositorioCarro = listaDoBanco;
        }
    }
}
