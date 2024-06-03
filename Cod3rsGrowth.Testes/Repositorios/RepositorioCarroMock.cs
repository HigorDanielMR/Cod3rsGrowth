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

        public Carro Criar(Carro carro)
        {
            carro.Id = _novoId;
            _novoId++;
            _repositorioCarro.Add(carro);
            return carro;
        }

        public Carro Editar(Carro carro)
        {
            var carroDoBanco = ObterPorId(carro.Id);
            var indexDesejado = _repositorioCarro.FindIndex(carroD => carroD.Id == carro.Id);

            carroDoBanco.Modelo = carro.Modelo
                ?? throw new ValidationException();

            carroDoBanco = carro;
            _repositorioCarro[indexDesejado] = carro;
            return _repositorioCarro[indexDesejado];
        }
    }
}
