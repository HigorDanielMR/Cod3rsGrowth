using Xunit;
using Cod3rsGrowth.Dominio.Entities;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Testes.ConfiguracaoAmbienteTeste;
using Cod3rsGrowth.Dominio.Services;
using FluentValidation;

namespace Cod3rsGrowth.Testes
{
    public class TesteVenda : TesteBase
    {
        private ServicoVenda _servicoVenda;
        private List<Venda> _listaMock;

        public TesteVenda()
        {
            CarregarServico();
            _listaMock = InicializarDadosMock();
        }

        private void CarregarServico()
        {
            _servicoVenda = ServiceProvider.GetService<ServicoVenda>()
               ?? throw new Exception($"Erro ao obter servico [{nameof(ServicoVenda)}]");
        
        }
        private List<Venda> InicializarDadosMock()
        {
            List<Venda> listaDeVendas = new List<Venda> {
                new Venda
                {
                    Nome = "higor",
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
                },
                new Venda
                {
                    Nome = "Higor Daniel",
                    Cpf = "124.454.878-77",
                    Email = "ahshlahs@asa.com",
                    DataDeCompra = new DateTime(2024, 5, 10),
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
            var IdBusca = 1;
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
            var IdDeBusca = 1;
            //act
            var veenda = _listaMock.FirstOrDefault();
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
        public void Criar_ComNomeInvalido_DeveRetornarExcecaoEsperada(string nome)
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
        [InlineData("gmail.com.br@")]
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
            var vendaEsperada = _servicoVenda.Criar(novaVenda); ;

            //asset
            Assert.Equal(novaVenda, vendaEsperada);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("       ")]
        [InlineData("")]
        public void Editar_ComNomeVazio_DeveRetornarExcecaoEsperada(string nome)
        {
            //arrange
            //act
            var novaVenda = new Venda
            {
                Id = 3,
                Nome = nome,
                Cpf = "213.344.567-90",
                Email = "higordaniel@gmail.com",
                DataDeCompra = new DateTime(2024, 5, 10),
                Pago = true,
                Telefone = "(65)65161-1651",
                ValorTotal = 100
            };

            var exception = Assert.Throws<ValidationException>(() => _servicoVenda.Editar(novaVenda));
            //asset
            Assert.Equal("Campo nome não preenchido.", exception.Message);
        }


        [Fact]
        public void Editar_ComNomeExcedendoValorMaximo_DeveRetornarExcecaoEsperada()
        {
            //arrange
            //act
            var novaVenda = new Venda
            {
                Id = 3,
                Nome = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                Cpf = "213.344.567-90",
                Email = "higordaniel@gmail.com",
                DataDeCompra = new DateTime(2024, 5, 10),
                Pago = true,
                Telefone = "(65)65161-1651",
                ValorTotal = 100
            };
            //asset
            var exception = Assert.Throws<ValidationException>(() => _servicoVenda.Editar(novaVenda));
            Assert.Equal("O nome deve ter no máximo 100 caracteres.", exception.Message);
        }

        [Theory]
        [InlineData("h1go0r")]
        [InlineData("!@#$%¨&*()_`{}^:>|")]
        [InlineData("🐱‍👤🐱‍👤🐱‍👤🐱‍👤")]
        public void Editar_ComNomeInvalido_DeveRetornarExcecaoEsperada(string nome)
        {
            //arrange
            //act
            var novaVenda = new Venda
            {
                Id = 3,
                Nome = nome,
                Cpf = "213.344.567-90",
                Email = "higordaniel@gmail.com",
                DataDeCompra = new DateTime(2024, 5, 10),
                Pago = true,
                Telefone = "(65)65161-1651",
                ValorTotal = 100
            };
            //asset
            var exception = Assert.Throws<ValidationException>(() => _servicoVenda.Editar(novaVenda));
            Assert.Equal("O nome deve conter apenas letras.", exception.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("       ")]
        [InlineData("")]
        public void Editar_ComCpfVazio_DeveRetornarExcecaoEsperada(string cpf)
        {
            //arrange
            //act
            var novaVenda = new Venda
            {
                Id = 3,
                Nome = "higor",
                Cpf = cpf,
                Email = "higordaniel@gmail.com",
                DataDeCompra = new DateTime(2024, 5, 10),
                Pago = true,
                Telefone = "(65)65161-1651",
                ValorTotal = 100
            };
            //asset
            var exception = Assert.Throws<ValidationException>(() => _servicoVenda.Editar(novaVenda));
            Assert.Equal("Campo cpf não preenchido.", exception.Message);
        }

        [Theory]
        [InlineData("542522654")]
        [InlineData("111.111.111-11")]
        [InlineData("aaa.aaa.sss-jj")]
        public void Editar_ComCpfInvalido_DeveRetornarExcecaoEsperada(string cpf)
        {
            //arrange
            //act
            var novaVenda = new Venda
            {
                Id = 3,
                Nome = "higor",
                Cpf = cpf,
                Email = "higordaniel@gmail.com",
                DataDeCompra = new DateTime(2024, 5, 10),
                Pago = true,
                Telefone = "(65)65161-1651",
                ValorTotal = 100
            };
            //asset
            var exception = Assert.Throws<ValidationException>(() => _servicoVenda.Editar(novaVenda));
            Assert.Equal("Formato CPF inválido.", exception.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("       ")]
        [InlineData("")]
        public void Editar_ComEmailVazio_DeveRetornarExcecaoEsperada(string email)
        {
            //arrange
            //act
            var novaVenda = new Venda
            {
                Id = 3,
                Nome = "higor",
                Cpf = "213.344.567-90",
                Email = email,
                DataDeCompra = new DateTime(2024, 5, 10),
                Pago = true,
                Telefone = "(65)65161-1651",
                ValorTotal = 100
            };
            //asset
            var exception = Assert.Throws<ValidationException>(() => _servicoVenda.Editar(novaVenda));
            Assert.Equal("Campo e-mail não preenchido.", exception.Message);
        }

        [Theory]
        [InlineData("kakkhskhaksgmail.com")]
        [InlineData("@gmail.com")]
        [InlineData("@gmail")]
        [InlineData("hashas.br")]
        [InlineData("@gmail.com.br")]
        [InlineData("gmail.com.br@")]
        public void Editar_ComEmailInvalido_DeveRetornarExcecaoEsperada(string email)
        {
            //arrange
            //act
            var novaVenda = new Venda
            {
                Id = 3,
                Nome = "higor",
                Cpf = "213.344.567-90",
                Email = email,
                DataDeCompra = new DateTime(2024, 5, 10),
                Pago = true,
                Telefone = "(65)65161-1651",
                ValorTotal = 100
            };
            //asset
            var exception = Assert.Throws<ValidationException>(() => _servicoVenda.Editar(novaVenda));
            Assert.Equal("Formato de e-mail inválido.", exception.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("    ")]
        [InlineData("")]
        public void Editar_ComTelefoneVazio_DeveRetornarExcecaoEsperada(string telefone)
        {
            //arrange
            //act
            var novaVenda = new Venda
            {
                Id = 3,
                Nome = "higor",
                Cpf = "213.344.567-90",
                Email = "higordaniel@gmail.com",
                DataDeCompra = new DateTime(2024, 5, 10),
                Pago = true,
                Telefone = telefone,
                ValorTotal = 100
            };
            //asset
            var exception = Assert.Throws<ValidationException>(() => _servicoVenda.Editar(novaVenda));
            Assert.Equal("Campo telefone não preenchido.", exception.Message);
        }

        [Theory]
        [InlineData("616512")]
        [InlineData("(98)9802-1488")]
        [InlineData("(98)98021488")]
        [InlineData("989802-1488")]
        public void Editar_ComTelefoneInvalido_DeveRetornarExcecaoEsperada(string telefone)
        {
            //arrange
            //act
            var novaVenda = new Venda
            {
                Id = 3,
                Nome = "higor",
                Cpf = "213.344.567-90",
                Email = "higordaniel@gmail.com",
                DataDeCompra = new DateTime(2024, 5, 10),
                Pago = true,
                Telefone = telefone,
                ValorTotal = 100
            };
            //asset
            var exception = Assert.Throws<ValidationException>(() => _servicoVenda.Editar(novaVenda));
            Assert.Equal("Formato de telefone inválido.", exception.Message);
        }

        [Fact]
        public void Editar_ComDataDeCompraInvalida_DeveRetornarExcecaoEsperada()
        {
            //arrange
            //act
            var novaVenda = new Venda
            {
                Id = 2,
                Nome = "higor",
                Cpf = "213.344.567-90",
                Email = "higordaniel@gmail.com",
                DataDeCompra = new DateTime(2023, 05, 20),
                Pago = true,
                Telefone = "(65)65161-1651",
                ValorTotal = 100
            };
            //asset
            var exception = Assert.Throws<ValidationException>(() => _servicoVenda.Editar(novaVenda));
            Assert.Equal("Uma venda concluida não pode ter a data alterada.", exception.Message);
        }

        [Fact]
        public void Editar_ComDadosValidos_DeveEditarComSucesso()
        {
            //arrange
            var novaVenda = new Venda
            {
                Id = 3,
                Nome = "higor",
                Cpf = "213.344.567-90",
                Email = "higordaniel@gmail.com",
                DataDeCompra = new DateTime(2024, 5, 10),
                Pago = true,
                Telefone = "(65)65161-1651",
                ValorTotal = 100
            };

            //act
            var vendaDoBanco = _servicoVenda.Editar(novaVenda);

            //asset
            Assert.Equivalent(novaVenda, vendaDoBanco);
        }
    }
}
