using Xunit;
using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Testes.ConfiguracaoAmbienteTeste;

namespace Cod3rsGrowth.Testes
{

    public class TesteCarro : TesteBase
    {
        private readonly IServicoCarro CarregarServico;

        public TesteCarro()
        {
            CarregarServico = ServiceProvider.GetService<IServicoCarro>()
                ?? throw new Exception($"Erro ao obter servico [{nameof(IServicoCarro)}]");
        }

        [Fact]
        public void ObterTodos_ComDadosDisponiveis_DeveRetornarListaComTipoCarro()
        {
            //arrange

            //act
            var carros = CarregarServico.ObterTodos();

            //asset
            Assert.NotNull(carros);
            Assert.IsType<List<Carro>>(carros);
        }

        [Fact]
        public void ObterTodos_ComDadosDisponiveis_DeveRetornarUmaListaDeCarro()
        {
            //arrange

            //act
            var novocarro = new Carro
            {
                Id = 2,
                Modelo = "Civic",
                Marca = Marcas.Honda,
                ValorDoVeiculo = 100,
                Cor = Cores.Branco,
                Flex = true
            };
            CarregarServico.Criar(novocarro);
            var carros = CarregarServico.ObterTodos();

            List<Carro> listaTesteMock = new List<Carro>();
            listaTesteMock.Add(novocarro);

            //asset
            Assert.NotNull(carros);
            Assert.Equivalent(listaTesteMock, carros);
        }
    }
}
