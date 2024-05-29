using Xunit;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Dominio.Interfaces;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Testes.ConfiguracaoAmbienteTeste;
using Cod3rsGrowth.Dominio.Services;
using Cod3rsGrowth.Infra.Repositorios;

namespace Cod3rsGrowth.Testes
{

    public class TesteVenda : TesteBase
    {
        private IServicoVenda _servicoVenda;
        private List<Venda> _listaMock;

        public TesteVenda()
        {
            CarregarServico();
            _listaMock = InicializarDadosMock();
        }

        private void CarregarServico()
        {
            _servicoVenda = ServiceProvider.GetService<IServicoVenda>()
               ?? throw new Exception($"Erro ao obter servico [{nameof(IServicoVenda)}]");
        }
        private List<Venda> InicializarDadosMock()
        {
            List<Venda> listaDeVendas = new List<Venda> {
                new Venda
                {
                    Nome = "Higor",
                    Cpf = "714.696.331-40",
                    Email = "51313153@6323.com",
                    Pago = true,
                    Telefone = "65651651651",
                    ValorTotal = 100
                },
                new Venda
                {
                    Nome = "Daniel",
                    Cpf = "124.454.878-77",
                    Email = "ahshlahs@asa.com",
                    Pago = true,
                    Telefone = "01209091212",
                    ValorTotal = 100
                }
            };

            foreach (var item in listaDeVendas)
            {
                _servicoVenda.Criar(item);
            }

            return listaDeVendas;
        }

        [Fact]
        public void ObterTodos_ComDadosDisponiveis_DeveRetornarListaComTipoVenda()
        {
            //arrange
            //act
            var vendasDoBanco = _servicoVenda.ObterTodos();
            //asset
            Assert.NotNull(vendasDoBanco);
            Assert.IsType<List<Venda>>(vendasDoBanco);
        }

        [Fact]
        public void ObterTodos_ComDadosDisponiveis_DeveRetornarUmaListaDeVendas()
        {
            //arrange
            //act
            var vendasDoBanco = _servicoVenda.ObterTodos();
            //asset
            Assert.NotNull(vendasDoBanco);
            Assert.Equivalent(_listaMock, vendasDoBanco);
        }

        [Fact]
        public void ObterPorId_ComIdExistente_DeveRetornarVendaEsperada()
        {
            //arrange
            var IdBusca = 0;
            //act
            var vendaMock = _listaMock.FirstOrDefault();
            var vendaDoBanco = _servicoVenda.ObterPorId(IdBusca);
            //asset
            Assert.NotNull(vendaDoBanco);
            Assert.Equivalent(vendaMock, vendaDoBanco);
        }

        [Fact]
        public void ObterPorId_ComIdExistente_DeveRetornarObjetoDoTipoVenda()
        {
            //arrange
            var IdDeBusca = 0;
            //act
            _listaMock.FirstOrDefault();
            var vendaDoTipoEsperado = _servicoVenda.ObterPorId(IdDeBusca);
            //asset
            Assert.IsType<Venda>(vendaDoTipoEsperado);
        }

        [Fact]
        public void ObterPorId_ComIdInexistente_DeveLancarExcecaoObjetoNaoEncontrado()
        {
            //arrange
            var IdDeBusca = 765;
            //act
            var exception = Assert.Throws<Exception>(() => _servicoVenda.ObterPorId(IdDeBusca));
            //asset
            Assert.Equal($"A venda com ID {IdDeBusca} não foi encontrada", exception.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("       ")]
        [InlineData("")]
        public void Criar_ComNomeVazio_DeveRetornarExcecaoEsperada(string nome)
        {
            //arrange

            var novaVenda = new Venda
            {
                Nome = nome,
                Cpf = "888.999.333-22",
                Email = "51313153@6323.com",
                Pago = true,
                Telefone = "62983052721",
                ValorTotal = 100
            };
            //act
            //asset
            var exception = Assert.Throws<ValidationException>(() => _servicoVenda.Criar(novaVenda));
            Assert.Equal("Campo nome não preenchido.", exception.Message);
        }


        [Fact]
        public void Criar_ComNomeExcedendoValorMaximo_DeveRetornarExcecaoEsperada()
        {
            //arrange

            var novaVenda = new Venda
            {
                Nome = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                Cpf = "888.999.333-22",
                Email = "51313153@6323.com",
                Pago = true,
                Telefone = "62983052721",
                ValorTotal = 100
            };
            //act
            //asset
            var exception = Assert.Throws<ValidationException>(() => _servicoVenda.Criar(novaVenda));
            Assert.Equal("O nome deve ter no máximo 100 caracteres.", exception.Message);
        }

        [Theory]
        [InlineData("h1go0r")]
        [InlineData("!@#$%¨&*()_`{}^:>|")]
        [InlineData("🐱‍👤🐱‍👤🐱‍👤🐱‍👤")]
        public void Criar_ComNomeInvalido_DeveRetornarOutraExcecaoEsperada(string nome)
        {
            //arrange

            var novaVenda = new Venda
            {
                Nome = nome,
                Cpf = "888.999.333-22",
                Email = "51313153@6323.com",
                Pago = true,
                Telefone = "62983052721",
                ValorTotal = 100
            };
            //act
            //asset
            var exception = Assert.Throws<ValidationException>(() => _servicoVenda.Criar(novaVenda));
            Assert.Equal("O nome deve conter apenas letras.", exception.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("       ")]
        [InlineData("")]
        public void Criar_ComCpfVazio_DeveRetornarExcecaoEsperada(string cpf)
        {
            //arrange

            var novaVenda = new Venda
            {
                Nome = "nome",
                Cpf = cpf,
                Email = "51313153@6323.com",
                Pago = true,
                Telefone = "62983052721",
                ValorTotal = 100
            };
            //act
            //asset
            var exception = Assert.Throws<ValidationException>(() => _servicoVenda.Criar(novaVenda));
            Assert.Equal("Campo cpf não preenchido.", exception.Message);
        }

        [Theory]
        [InlineData("542522654")]
        [InlineData("111.111.111-11")]
        [InlineData("aaa.aaa.sss-jj")]
        public void Criar_ComCpfInvalido_DeveRetornarExcecaoEsperada(string cpf)
        {
            //arrange
            var novaVenda = new Venda
            {
                Nome = "Higor",
                Email = "higordaniel@gmail.com",
                Cpf = cpf,
                Pago = true,
                Telefone = "65651651651",
                ValorTotal = 100
            };
            //act
            //asset
            var exception = Assert.Throws<ValidationException>(() => _servicoVenda.Criar(novaVenda));
            Assert.Equal("Formato CPF inválido.", exception.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("       ")]
        [InlineData("")]
        public void Criar_ComEmailVazio_DeveRetornarExcecaoEsperada(string email)
        {
            //arrange

            var novaVenda = new Venda
            {
                Nome = "nome",
                Cpf = "888.999.333-22",
                Email = email,
                Pago = true,
                Telefone = "62983052721",
                ValorTotal = 100
            };
            //act
            //asset
            var exception = Assert.Throws<ValidationException>(() => _servicoVenda.Criar(novaVenda));
            Assert.Equal("Campo e-mail não preenchido.", exception.Message);
        }

        [Theory]
        [InlineData("kakkhskhaksgmail.com")]
        [InlineData("@gmail.com")]
        [InlineData("@gmail")]
        [InlineData("hashas.br")]
        [InlineData("@gmail.com.br")]
        public void Criar_ComEmailInvalido_DeveRetornarExcecaoEsperada(string email)
        {
            //arrange
            var novaVenda = new Venda
            {
                Nome = "Higor",
                Cpf = "714.696.331-40",
                Email = email,
                Pago = true,
                Telefone = "65651651651",
                ValorTotal = 100
            };
            //act
            //asset
            var exception = Assert.Throws<ValidationException>(() => _servicoVenda.Criar(novaVenda));
            Assert.Equal("Formato de e-mail inválido.", exception.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("    ")]
        [InlineData("")]
        public void Criar_ComTelefoneVazio_DeveRetornarExcecaoEsperada(string telefone)
        {
            //arrange

            var novaVenda = new Venda
            {
                Nome = "Higor",
                Cpf = "888.999.333-22",
                Email = "51313153@6323.com",
                Pago = true,
                Telefone = telefone,
                ValorTotal = 100
            };
            //act
            //asset
            var exception = Assert.Throws<ValidationException>(() => _servicoVenda.Criar(novaVenda));
            Assert.Equal("Campo telefone não preenchido.", exception.Message);
        }

        [Theory]
        [InlineData("616512")]
        [InlineData("(98)9802-1488")]
        [InlineData("(98)98021488")]
        [InlineData("989802-1488")]
        public void Criar_ComTelefoneInvalido_DeveRetornarExcecaoEsperada(string telefone)
        {
            //arrange
            var novaVenda = new Venda
            {
                Nome = "Higor",
                Cpf = "651.687.998-74",
                Email = "51313153@6323.com",
                Telefone = telefone,
                Pago = true,
                ValorTotal = 100
            };
            //act
            //asset
            var exception = Assert.Throws<ValidationException>(() => _servicoVenda.Criar(novaVenda));
            Assert.Equal("Formato de telefone inválido.", exception.Message);
        }

        
        [Fact]
        public void Criar_ComDadosValidos_DeveCriarComSucesso()
        {
            //arrange
            var novaVenda = new Venda
            {
                Nome = "Higor",
                Cpf = "213.344.567-98",
                Email = "higordaniel@gmail.com",
                Pago = true,
                Telefone = "(65)65161-1651",
                ValorTotal = 100
            };
            //act
            _servicoVenda.Criar(novaVenda);
            var vendaEsperada = _servicoVenda.ObterTodos().Last();

            //asset
            Assert.Equal(novaVenda, vendaEsperada);
        }
    }
}
