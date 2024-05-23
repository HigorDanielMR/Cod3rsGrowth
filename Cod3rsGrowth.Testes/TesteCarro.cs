using Xunit;
using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Testes.ConfiguracaoAmbienteTeste;
using Cod3rsGrowth.Dominio.Services;

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
                Id = 0,
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
        public void ObterPorId_ComIdExistente_DeveRetornarCarroEsperado()
        {

            //arrange
            var Id1 = 1;
            var Id2 = 2;
            //act
            var carro1 = new Carro
            {
                Id = 1,
                Modelo = "Golf GTI",
                Cor = Cores.Branco,
                Flex= true,
                ValorDoVeiculo = 100,
                Marca = Marcas.Volkswagem
            };
            var carro2 = new Carro
            {
                Id = 2,
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

        [Fact]
        public void ObterPorId_ComIdExistente_DeveRetornarObjetoDoTipoCarro()
        {

            //arrange
            var Id1 = 3;
            //act
            var carro1 = new Carro
            {
                Id = 3,
                Modelo = "Golf GTI",
                Cor = Cores.Branco,
                Flex = true,
                ValorDoVeiculo = 100,
                Marca = Marcas.Volkswagem
            };
            _servicoCarro.Criar(carro1);

            var resultadoDaBusca = _servicoCarro.ObterCarroPorId(Id1);

            Assert.IsType<Carro>(resultadoDaBusca);
        }

        [Fact]
        public void ObterPorId_ComIdInexistente_DeveLancarExcecaoObjetoNaoEncontrado()
        {

            //arrange
            var Id1 = 212;
            var Id2 = 555;
            //act
            var carro1 = new Carro
            {
                Id = 4,
                Modelo = "Golf GTI",
                Cor = Cores.Branco,
                Flex = true,
                ValorDoVeiculo = 100,
                Marca = Marcas.Volkswagem
            };
            var carro2 = new Carro
            {
                Id = 5,
                Modelo = "Civic",
                Cor = Cores.Preto,
                Flex = true,
                ValorDoVeiculo = 100,
                Marca = Marcas.Honda
            };
            
            _servicoCarro.Criar(carro1);
            _servicoCarro.Criar(carro2);
            var exception = Assert.Throws<Exception>(() => _servicoCarro.ObterCarroPorId(Id1));
            var exception2 = Assert.Throws<Exception>(() => _servicoCarro.ObterCarroPorId(Id2));

            //asset
            Assert.Equal($"O carro com ID {Id1} não foi encontrado", exception.Message);
            Assert.Equal($"O carro com ID {Id2} não foi encontrado", exception2.Message);
        }
    }
}
