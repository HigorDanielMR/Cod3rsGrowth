using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Repositorios;

namespace Cod3rsGrowth.Testes
{
    public class RepositorioCarroMock : IRepositorioCarro
    {
        private List<Carro> _repositorioCarro = ListaSingleton.Instance.RepositorioCarro;
        private int _novoId = 1;
        public List<Carro> ObterTodos()
        {
            return _repositorioCarro;
        }

        public Carro ObterPorId(int IdDeBusca)
        {
            return _repositorioCarro.Find(carro => carro.Id == IdDeBusca)
                ?? throw new Exception($"O carro com ID {IdDeBusca} não foi encontrado");
        }

        public Carro Criar(Carro carro)
        {
            carro.Id = _novoId;
            _novoId++;
            _repositorioCarro.Add(carro);
            return carro;
        }

        public Carro Editar(Carro carroAtualizado)
        {
            var carroDesejado = ObterPorId(carroAtualizado.Id);

            carroDesejado.Modelo = carroAtualizado.Modelo;
            carroDesejado.Cor = carroAtualizado.Cor;
            carroDesejado.Flex = carroAtualizado.Flex;
            carroDesejado.Marca = carroAtualizado.Marca;
            carroDesejado.ValorDoVeiculo = carroAtualizado.ValorDoVeiculo;

            return carroDesejado;
        }
        public void Remover(int Id)
        {
            var carroDesejado = _repositorioCarro.Find(c => c.Id == Id);
            if (carroDesejado != null) _repositorioCarro.Remove(carroDesejado);
            else throw new Exception($"O carro com ID {Id} não foi encontrado");
        }
    }
}
