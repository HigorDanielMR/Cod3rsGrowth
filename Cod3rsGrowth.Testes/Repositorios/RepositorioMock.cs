using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Repositorios;

namespace Cod3rsGrowth.Testes
{
    public class RepositorioMock : IRepositorio
    {
        public ListaSingleton Singleton = ListaSingleton.Instance;

        public RepositorioMock()
        {
            Carro carro = new Carro();
            carro.ValorDoVeiculo = 100000;
            Singleton.RepositorioCarro.Add(carro);

            Venda venda = new Venda();
            venda.ValorTotal = 100000;
            Singleton.RepositorioVenda.Add(venda);
        }

        public ListaSingleton ObterTodos()
        {
            return Singleton;
        }
    }
}
