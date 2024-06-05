using Xunit;
using FluentValidation;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Services;
using Cod3rsGrowth.Dominio.Entities;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Testes.ConfiguracaoAmbienteTeste;

namespace Cod3rsGrowth.Testes
{
    public class TesteCarro : TesteBase
    {
        private ServicoCarro _servicoCarro;
        private List<Carro> _listaMock;

        public TesteCarro()
        {
            CarregarServico();
            _servicoCarro.ObterTodos().Clear();
            _listaMock = InicializandoDadosMock();
        }

        private void CarregarServico()
        {
            _servicoCarro = ServiceProvider.GetService<ServicoCarro>()
                ?? throw new Exception($"Erro ao obter servico [{nameof(ServicoCarro)}]");
        }

        private List<Carro> InicializandoDadosMock()
        {
            List<Carro> listaDeCarros = new List<Carro>
            {
                new()
                {
                    Modelo = "Golf GTI",
                    Cor = Cores.Branco,
                    Flex = true,
                    ValorDoVeiculo = 100,
                    Marca = Marcas.Volkswagem
                },
                new()
                {
                    Modelo = "Civic",
                    Cor = Cores.Preto,
                    Flex = true,
                    ValorDoVeiculo = 100,
                    Marca = Marcas.Honda
                },
                new()
                {
                    Modelo = "Gol",
                    Cor = Cores.Preto,
                    Flex = true,
                    ValorDoVeiculo = 100,
                    Marca = Marcas.Volkswagem
                }
            };
            foreach (var carro in listaDeCarros)
            {
                _servicoCarro.Criar(carro);
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
            Assert.IsType<List<Carro>>(carrosDoBanco);
        }

        [Fact]
        public void ObterTodos_ComDadosDisponiveis_DeveRetornarUmaListaDeCarro()
        {
            //arrange
            //act
            var carrosDoBanco = _servicoCarro.ObterTodos();
            //asset
            Assert.Equivalent(_listaMock, carrosDoBanco);
        }

        [Fact]
        public void ObterPorId_ComIdExistente_DeveRetornarCarroEsperado()
        {
            //arrange
            var idDeBusca = 1;
            var carroMock = _listaMock.FirstOrDefault();
            //act
            var carroDoBanco = _servicoCarro.ObterPorId(idDeBusca);
            //asset
            Assert.Equivalent(carroMock, carroDoBanco);
        }

        [Fact]
        public void ObterPorId_ComIdExistente_DeveRetornarObjetoDoTipoCarro()
        {
            //arrange
            var idDeBusca = 1;
            //act
            var carroDoTipoEsperado = _servicoCarro.ObterPorId(idDeBusca);
            //asset
            Assert.IsType<Carro>(carroDoTipoEsperado);
        }

        [Fact]
        public void ObterPorId_ComIdInexistente_DeveLancarExcecaoObjetoNaoEncontrado()
        {
            //arrange
            var idDeBusca = 212;
            //act
            var excessao = Assert.Throws<Exception>(() => _servicoCarro.ObterPorId(idDeBusca));
            //asset
            Assert.Equal($"O carro com ID {idDeBusca} não foi encontrado", excessao.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("       ")]
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
            var excessao = Assert.Throws<ValidationException>(() => _servicoCarro.Criar(novoCarro));
            //asset
            Assert.Equivalent("Campo modelo não preenchido.", excessao.Message);
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
            var excessao = Assert.Throws<ValidationException>(() => _servicoCarro.Criar(novoCarro));
            //asset
            Assert.Equal("Modelo inválido, precisa ter no mínimo 2 caracteres e no maximo 50 caracteres.", excessao.Message);
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
            var excessao = Assert.Throws<ValidationException>(() => _servicoCarro.Criar(novoCarro));
            //asset
            Assert.Equal("O valor do veiculo deve ser maior que zero.", excessao.Message);
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
        [InlineData("")]
        [InlineData(null)]
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
            var excessao = Assert.Throws<ValidationException>(() => _servicoCarro.Editar(novoCarro));
            //asset
            Assert.Equal("Campo modelo não preenchido.", excessao.Message);
        }

        [Theory]
        [InlineData("a")]
        [InlineData("Aetherion Eclipse XR 9000 Supercharged Hybrid Sport Coupe")]
        public void Editar_ComModeloInvalido_DeveRetornarExcessaoEsperada(string modelo)
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
            var excessao = Assert.Throws<ValidationException>(() => _servicoCarro.Editar(novoCarro));
            //asset
            Assert.Equal("Modelo inválido, precisa ter no mínimo 2 caracteres e no maximo 50 caracteres.", excessao.Message);
        }

        [Fact]
        public void Editar_ComValorDoVeiculoInvalido_DeveRetornarExcesaoEsperada()
        {
            //arrange
            var novoCarro = new Carro
            {
                Id = 2,
                Modelo = "C180",
                Cor = Cores.Branco,
                Flex = true,
                Marca = Marcas.Bmw,
                ValorDoVeiculo = -111
            };
            //act
            var excessao = Assert.Throws<ValidationException>(() => _servicoCarro.Editar(novoCarro));
            //Assert
            Assert.Equal("O valor do veiculo deve ser maior que zero.", excessao.Message);
        }

        [Fact]
        public void Editar_ComDadosValidos_DeveEditarComSucesso()
        {
            //arrange
            var novoCarro = new Carro
            {
                Id = 2,
                Modelo = "C180",
                Cor = Cores.Branco,
                Flex = true,
                Marca = Marcas.Bmw,
                ValorDoVeiculo = 10000
            };
            //act
            var carroDoBanco = _servicoCarro.Editar(novoCarro);
            //asset
            Assert.Equivalent(novoCarro, carroDoBanco);
        }

        [Fact]
        public void Remover_ComDadosValidosNoBanco_DeveRemoverComSucesso()
        {
            //arrange
            var carroDesejado = _listaMock.FirstOrDefault();
            //act
            _servicoCarro.Remover(carroDesejado.Id);
            var excessao = Assert.Throws<Exception>(() => _servicoCarro.Remover(carroDesejado.Id));
            //asset
            Assert.Equal($"O carro com ID {carroDesejado.Id} não foi encontrado", excessao.Message);
        }
    }
}
