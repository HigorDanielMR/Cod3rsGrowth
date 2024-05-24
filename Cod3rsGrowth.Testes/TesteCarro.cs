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
        private List<Carro> _listaMock;

        public TesteCarro()
        {
            CarregarServico();
            _listaMock = InicializarDadosMock();
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
            var carrosDoBanco = _servicoCarro.ObterTodos();
            //asset
            Assert.NotNull(carrosDoBanco);
            Assert.IsType<List<Carro>>(carrosDoBanco);
        }

        [Fact]
        public void ObterTodos_ComDadosDisponiveis_DeveRetornarUmaListaDeCarro()
        {
            //arrange
            //act
            var carrosDoBanco = _servicoCarro.ObterTodos();
            //asset
            Assert.NotNull(carrosDoBanco);
            Assert.Equivalent(_listaMock, carrosDoBanco);
        }

        [Fact]
        public void ObterPorId_ComIdExistente_DeveRetornarCarroEsperado()
        {
            //arrange
            var IdDeBusca = 1;
            //act
            var carroMock = _listaMock[0];
            var carroDoBanco = _servicoCarro.ObterPorId(IdDeBusca);
            //asset
            Assert.Equivalent(carroMock, carroDoBanco);
        }

        [Fact]
        public void ObterPorId_ComIdExistente_DeveRetornarObjetoDoTipoCarro()
        {
            //arrange
            var IdDeBusca = 2;
            //act
            var carroDoTipoEsperado = _servicoCarro.ObterPorId(IdDeBusca);
            //asset
            Assert.IsType<Carro>(carroDoTipoEsperado);
        }

        [Fact]
        public void ObterPorId_ComIdInexistente_DeveLancarExcecaoObjetoNaoEncontrado()
        {
            //arrange
            var IdDeBusca = 212;
            //act
            var exception = Assert.Throws<Exception>(() => _servicoCarro.ObterPorId(IdDeBusca));
            //asset
            Assert.Equal($"O carro com ID {IdDeBusca} não foi encontrado", exception.Message);
        }
    }
}
