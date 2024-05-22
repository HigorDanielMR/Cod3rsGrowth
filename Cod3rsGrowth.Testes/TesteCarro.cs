using Xunit;
using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Testes.ConfiguracaoAmbienteTeste;
using System.ComponentModel.DataAnnotations;

namespace Cod3rsGrowth.Testes
{

    public class TesteCarro : TesteBase
    {
        private IServicoCarro _servicoCarro;

        public TesteCarro()
        {
             CarregarServico();
        }

        private void CarregarServico()
        {
            _servicoCarro = ServiceProvider.GetService<IServicoCarro>()
                ?? throw new Exception($"Erro ao obter servico [{nameof(IServicoCarro)}]");
        }

        [Fact]
        public void ObterTodos_ComDadosDisponiveis_DeveRetornarListaComTipoCarro()
        {
            //arrange

            //act
            var carros = _servicoCarro.ObterTodos();

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
            _servicoCarro.Criar(novocarro);
            var carros = _servicoCarro.ObterTodos();

            List<Carro> listaTesteMock = new List<Carro>();
            listaTesteMock.Add(novocarro);

            //asset
            Assert.NotNull(carros);
            Assert.Equivalent(listaTesteMock, carros);
        }

        [Fact]
        public void ObterPorId_ComDadosDisponiveis_DeveRetornarOCarroConformeOId()
        {

            //arrange
            var Id1 = 291;
            var Id2 = 762;
            //act
            var carro1 = new Carro
            {
                Id = 291,
                Modelo = "Golf GTI",
                Cor = Cores.Branco,
                Flex= true,
                ValorDoVeiculo = 100,
                Marca = Marcas.Volkswagem
            };
            var carro2 = new Carro
            {
                Id = 762,
                Modelo = "Civic",
                Cor = Cores.Preto,
                Flex = true,
                ValorDoVeiculo = 100,
                Marca = Marcas.Honda
            };
            _servicoCarro.Criar(carro1);
            _servicoCarro.Criar(carro2);

            var resultado1 = _servicoCarro.ObterCarroPorId(Id1);
            var resultado2 = _servicoCarro.ObterCarroPorId(Id2);

            //asset
            Assert.Equal(carro1, resultado1);
            Assert.Equal(carro2, resultado2);
        }
    }
}
