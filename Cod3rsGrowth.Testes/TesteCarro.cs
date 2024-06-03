using Xunit;
using FluentValidation;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Entities;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Testes.ConfiguracaoAmbienteTeste;
using Cod3rsGrowth.Dominio.Services;

namespace Cod3rsGrowth.Testes
{

    public class TesteCarro : TesteBase
    {
        private ServicoCarro _servicoCarro;
        private List<Carro> _listaMock;

        public TesteCarro()
        {
            CarregarServico();
            _listaMock = InicializarDadosMock();
        }

        private void CarregarServico()
        {
            _servicoCarro = ServiceProvider.GetService<ServicoCarro>()
                ?? throw new Exception($"Erro ao obter servico [{nameof(ServicoCarro)}]");
        }

        private List<Carro> InicializarDadosMock()
        {
            List<Carro> listaDeCarros = new List<Carro>
            {
                new Carro
                {
                    Modelo = "Golf GTI",
                    Cor = Cores.Branco,
                    Flex = true,
                    ValorDoVeiculo = 100,
                    Marca = Marcas.Volkswagem
                },
                new Carro
                {
                    Modelo = "Civic",
                    Cor = Cores.Preto,
                    Flex = true,
                    ValorDoVeiculo = 100,
                    Marca = Marcas.Honda
                },
                new Carro
                {
                    Modelo = "Gol",
                    Cor = Cores.Preto,
                    Flex = true,
                    ValorDoVeiculo = 100,
                    Marca = Marcas.Volkswagem
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
            var IdDeBusca = 0;
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
        [InlineData(null)]
        [InlineData("       ")]
        [InlineData("")]
        public void Criar_ComModeloVazio_DeveRetornarExcecaoEsperada(string nome)
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
            Assert.Equivalent("Campo modelo não preenchido.", exception.Message);
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

        [Fact]
        public void Criar_ComValorDoVeiculoInvalido_DeveRetornarExcecaoEsperada()
        {
            //arrange
            var novoCarro = new Carro
            {
                Modelo = "C180",
                Cor = Cores.Branco,
                Flex = true,
                Marca = Marcas.Bmw,
                ValorDoVeiculo = -11111
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
                Cor = Cores.Grafite,
                Marca = Marcas.Bmw,
                ValorDoVeiculo = -11
            };
            //act
            var exception = Assert.Throws<ValidationException>(() => _servicoCarro.Criar(novoCarro));
            Assert.Equal("Modelo inválido, precisa ter no mínimo 2 caracteres e no maximo 50 caracteres. O valor do veiculo deve ser maior que zero. ", exception.Message);
        }

        [Fact]
        public void Criar_ComDadosValidos_DeveCriarComSucesso()
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
            
            var carroEsperado = _servicoCarro.Criar(novoCarro);

            //asset
            Assert.Equal(novoCarro, carroEsperado);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("      ")]
        public void Editar_ComModeloVazio_DeveRetornarExcessaoEsperada(string modelo)
        {
            //arrange
            var novoCarro = new Carro
            {
                Id = 2,
                Modelo = modelo,
                Cor = Cores.Branco,
                Flex = true,
                Marca = Marcas.Bmw,
                ValorDoVeiculo = 111
            };

            //act

            var exception = Assert.Throws<ValidationException>(() => _servicoCarro.Editar(novoCarro));
            //asset
            Assert.Equal("Campo modelo não preenchido.", exception.Message);
        }

        [Theory]
        [InlineData("a")]
        [InlineData("Aetherion Eclipse XR 9000 Supercharged Hybrid Sport Coupe")]
        public void Editar_ComModeloInvalido_DeveRetornarExcessaoEsperada(string modelo)
        {
            //arrange
            //act
            var novoCarro = new Carro
            {
                Id = 2,
                Modelo = modelo,
                Cor = Cores.Branco,
                Flex = true,
                Marca = Marcas.Bmw,
                ValorDoVeiculo = 111
            };


            var exception = Assert.Throws<ValidationException>(() => _servicoCarro.Editar(novoCarro));
            //asset
            Assert.Equal("Modelo inválido, precisa ter no mínimo 2 caracteres e no maximo 50 caracteres.", exception.Message);
        }

        [Fact]
        public void Editar_ComValorDoVeiculoInvalido_DeveRetornarExcesaoEsperada()
        {
            //arrange
            //act
            var novoCarro = new Carro
            {
                Id = 2,
                Modelo = "C180",
                Cor = Cores.Branco,
                Flex = true,
                Marca = Marcas.Bmw,
                ValorDoVeiculo = -111
            };

            var exception = Assert.Throws<ValidationException>(() => _servicoCarro.Editar(novoCarro));
            //Assert
            Assert.Equal("O valor do veiculo deve ser maior que zero.", exception.Message);
        }

        [Fact]
        public void Editar_ComDadosValidos_DeveEditarComSucesso()
        {
            //arrange
            //act
            var novoCarro = new Carro
            {
                Id = 2,
                Modelo = "C180",
                Cor = Cores.Branco,
                Flex = true,
                Marca = Marcas.Bmw,
                ValorDoVeiculo = 10000
            };
            var carroDoBanco = _servicoCarro.Editar(novoCarro);

            //asset
            Assert.Equal(novoCarro, carroDoBanco);
        }
    }
}
