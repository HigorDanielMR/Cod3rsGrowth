using Xunit;
using FluentValidation;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Entities;
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
            var carroMock = _listaMock.FirstOrDefault();
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

        [Theory]
        [InlineData("a")]
        [InlineData(" ")]
        public void CriarComFluentValidator_CriandoOCarro_DeveRetornarExceptionEsperadaParaModelo(string nome)
        {
            //arrange
            var novoCarro = new Carro
            {
                Modelo = nome,
                Cor = Cores.Branco,
                Flex = true,
                Marca = Marcas.Bmw,
                ValorDoVeiculo = 1000
            };
            //act
            //asset
            var exception = Assert.Throws<ValidationException>(() => _servicoCarro.Criar(novoCarro));
        }

        [Theory]
        [InlineData(null)]
        public void CriarComFluentValidator_CriandoOCarro_DeveRetornarExceptionEsperadaParaCor(Cores cor)
        {
            //arrange
            var novoCarro = new Carro
            {
                Modelo = "C180",
                Flex = true,
                Marca = Marcas.Bmw,
                Cor = cor,
                ValorDoVeiculo = 1000
            };
            //act
            //asset
            var exception = Assert.Throws<ValidationException>(() => _servicoCarro.Criar(novoCarro));
        }

        [Theory]
        [InlineData(null)]
        public void CriarComFluentValidator_CriandoOCarro_DeveRetornarExceptionEsperadaParaFlex(bool flex)
        {
            //arrange
            var novoCarro = new Carro
            {
                Modelo = "C180",
                Cor = Cores.Branco,
                Marca = Marcas.Bmw,
                Flex = flex,
                ValorDoVeiculo = 1000
            };
            //act
            //asset
            var exception = Assert.Throws<ValidationException>(() => _servicoCarro.Criar(novoCarro));
        }

        [Theory]
        [InlineData(null)]
        public void CriarComFluentValidator_CriandoOCarro_DeveRetornarExceptionEsperadaParaMarca(Marcas marca)
        {
            //arrange
            var novoCarro = new Carro
            {
                Modelo = "C180",
                Cor = Cores.Grafite,
                Marca = marca,
                Flex = true,
                ValorDoVeiculo = 1000
            };
            //act
            //asset
            var exception = Assert.Throws<ValidationException>(() => _servicoCarro.Criar(novoCarro));
        }

        [Theory]
        [InlineData(null)]
        [InlineData(-11111)]
        public void CriarComFluentValidator_CriandoOCarro_DeveRetornarExceptionEsperadaParaValorDoVeiculo(decimal valor)
        {
            //arrange
            var novoCarro = new Carro
            {
                Modelo = "C180",
                Cor = Cores.Branco,
                Flex = true,
                Marca = Marcas.Bmw,
                ValorDoVeiculo = valor
            };
            //act
            var exception = Assert.Throws<ValidationException>(() => _servicoCarro.Criar(novoCarro));

        }

        [Fact]
        public void CriarComFluentValidator_CriandoOCarro_DeveRetornarVeiculoEsperado()
        {
            //arrange
            var novoCarro = new Carro
            {
                Id = _servicoCarro.ObterNovoId(),
                Modelo = "C180",
                Cor = Cores.Branco,
                Flex = true,
                Marca = Marcas.Bmw,
                ValorDoVeiculo = 100
            };
            //act
            _servicoCarro.Criar(novoCarro);
            var carroEsperado = _servicoCarro.ObterTodos().Last();

            //asset
            Assert.Equivalent(novoCarro, carroEsperado);
        }
    }
}
