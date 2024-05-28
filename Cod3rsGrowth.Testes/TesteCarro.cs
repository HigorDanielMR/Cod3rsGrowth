using Xunit;
using FluentValidation;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Dominio.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Testes.ConfiguracaoAmbienteTeste;
using Cod3rsGrowth.Infra.Repositorios;

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
            var carroMock = _listaMock[IdDeBusca];
            var carroDoBanco = _servicoCarro.ObterPorId(IdDeBusca);
            //asset
            Assert.Equivalent(carroMock, carroDoBanco);
        }

        [Fact]
        public void ObterPorId_ComIdExistente_DeveRetornarObjetoDoTipoCarro()
        {
            //arrange
            var IdDeBusca = 1;
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
        [InlineData("Aetherion Eclipse XR 9000 Supercharged Hybrid Sport Coupe")]
        public void Criar_ComModeloInvalido_DeveRetornarExcecaoEsperada(string nome)
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
            Assert.Equal("Modelo inválido, precisa ter no mínimo 2 caracteres e no maximo 50 caracteres.", exception.Message);
        }


        [Theory]
        [InlineData(null)]
        public void Criar_ComCorInvalida_DeveRetornarExcecaoEsperada(Cores cor)
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
            Assert.Equal("Essa cor é inválido.", exception.Message);
        }


        [Theory]
        [InlineData(null)]
        public void Criar_ComMarcaInvalida_DeveRetornarExcecaoEsperada(Marcas marca)
        {
            //arrange
            var novoCarro = new Carro
            {
                Modelo = "C180",
                Cor = Cores.Grafite,
                Marca = marca,
                Flex = false,
                ValorDoVeiculo = 1000
            };
            //act
            //asset
            var exception = Assert.Throws<ValidationException>(() => _servicoCarro.Criar(novoCarro));
            Assert.Equal("Essa marca é inválida.", exception.Message);
        }

        [Theory]
        [InlineData(-11111)]
        public void Criar_ComValorDoVeiculoInvalido_DeveRetornarExcecaoEsperada(decimal valor)
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
            Assert.Equal("O valor do veiculo deve ser maior que zero.", exception.Message);
        }

        [Fact]
        public void Criar_ComValorDoVeiculoInvalidoModeloInvalidoEFlexInvalido_DeveRetornarExcecaoEsperada()
        {
            //arrange
            var novoCarro = new Carro
            {
                Modelo = "a",
                Cor = Cores.Branco,
                Marca = Marcas.Bmw,
                ValorDoVeiculo = -11
            };
            //act
            var exception = Assert.Throws<ValidationException>(() => _servicoCarro.Criar(novoCarro));
            Assert.Equal("Modelo inválido, precisa ter no mínimo 2 caracteres e no maximo 50 caracteres. O valor do veiculo deve ser maior que zero. ", exception.Message); 
        }

        [Fact]
        public void Criar_ComCarroCriado_DeveRetornarCarroEsperado()
        {
            //arrange
            var novoCarro = new Carro
            {
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
            Assert.Equal(novoCarro, carroEsperado);
        }
    }
}
