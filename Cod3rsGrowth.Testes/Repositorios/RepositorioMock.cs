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
            Carro carro = new()
            {
                Id = 1,
                Marca = Marcas.Honda,
                Modelo = "Civic",
                Cor = Cores.Grafite,
                ValorDoVeiculo = 100000,
                Flex = true
            };
            Singleton.RepositorioCarro.Add(carro);

            Venda venda = new()
            {
                Id = 1,
                Nome = "Civic",
                Cpf = "8181818",
                Email = "email",
                Telefone = "919191919",
                DataDeCompra = DateTime.Now,
                ValorTotal = 1000000,
                Pago = true
            };
            Singleton.RepositorioVenda.Add(venda);
        }

        public ListaSingleton ObterTodos()
        {
            return Singleton;
        }
    }
}
