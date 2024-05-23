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

        private List<Carro> InicializarDadosMock()
        {
            List<Carro> listaDeCarros = new List<Carro>
            {
                new Carro
                {
                    Id = 1,
                    Modelo = "Golf GTI",
                    Cor = Cores.Branco,
                    Flex = true,
                    ValorDoVeiculo = 100,
                    Marca = Marcas.Volkswagem
                },
                new Carro
                {
                    Id = 2,
                    Modelo = "Civic",
                    Cor = Cores.Preto,
                    Flex = true,
                    ValorDoVeiculo = 100,
                    Marca = Marcas.Honda
                }
            };

            foreach (var car in listaDeCarros)
            {
                _servicoCarro.Criar(car);
            }
            return listaDeCarros;
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
            var listaTesteMock = InicializarDadosMock();
            //act
            var carros = _servicoCarro.ObterTodos();
            //asset
            Assert.NotNull(carros);
            Assert.Equivalent(listaTesteMock, carros);
        }

        [Fact]
        public void ObterPorId_ComIdExistente_DeveRetornarCarroEsperado()
        {
            //arrange
            var Id1 = 1;
            var listaMockCarro = InicializarDadosMock().FirstOrDefault();
            //act
            var carroDoBanco = _servicoCarro.ObterCarroPorId(Id1);
            //asset
            Assert.Equivalent(listaMockCarro, carroDoBanco);
        }

        [Fact]
        public void ObterPorId_ComIdExistente_DeveRetornarObjetoDoTipoCarro()
        {
            //arrange
            var Id1 = 2;
            //act
            var resultadoDaBusca = _servicoCarro.ObterCarroPorId(Id1);
            //asset
            Assert.IsType<Carro>(resultadoDaBusca);
        }

        [Fact]
        public void ObterPorId_ComIdInexistente_DeveLancarExcecaoObjetoNaoEncontrado()
        {
            //arrange
            var Id1 = 212;
            //act
            var exception = Assert.Throws<Exception>(() => _servicoCarro.ObterCarroPorId(Id1));
            //asset
            Assert.Equal($"O carro com ID {Id1} não foi encontrado", exception.Message);
        }
    }
}
