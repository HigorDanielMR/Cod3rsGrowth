using Xunit;
using FluentValidation;
using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Dominio.Services;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Testes.ConfiguracaoAmbienteTeste;

namespace Cod3rsGrowth.Testes
{
    public class TesteVenda : TesteBase
    {
        private ServicoVenda _servicoVenda;
        private List<Venda> _listaMock;
        public TesteVenda()
        {
            CarregarServico();
            _servicoVenda.ObterTodos().Clear();
            _listaMock = InicializarDadosMock();
        }
        private void CarregarServico()
        {
            _servicoVenda = ServiceProvider.GetService<ServicoVenda>()
               ?? throw new Exception($"Erro ao obter servico [{nameof(ServicoVenda)}]");
        }
        private List<Venda> InicializarDadosMock()
        {
            List<Venda> listaDeVendas = new List<Venda> 
            {
                new()
                {
                    Nome = "higor",
                    Cpf = "714.696.331-40",
                    Email = "51313153@6323.com",
                    Pago = true,
                    Telefone = "65651651651",
                    ValorTotal = 100
                },
                new()
                {
                    Nome = "Daniel",
                    Cpf = "124.454.878-77",
                    Email = "ahshlahs@asa.com",
                    Pago = true,
                    Telefone = "01209091212",
                    ValorTotal = 100
                },
                new()
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
            foreach (var venda in listaDeVendas)
            {
                _servicoVenda.Criar(venda);
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
            Assert.IsType<List<Venda>>(vendasDoBanco);
        }

        [Fact]
        public void ObterTodos_ComDadosDisponiveis_DeveRetornarUmaListaDeVendas()
        {
            //arrange
            //act
            var vendasDoBanco = _servicoVenda.ObterTodos();
            //asset
            Assert.Equivalent(_listaMock, vendasDoBanco);
        }

        [Fact]
        public void ObterPorId_ComIdExistente_DeveRetornarVendaEsperada()
        {
            //arrange
            var idBusca = 1;
            var vendaMock = _listaMock.FirstOrDefault();
            //act
            var vendaDoBanco = _servicoVenda.ObterPorId(idBusca);
            //asset
            Assert.Equivalent(vendaMock, vendaDoBanco);
        }

        [Fact]
        public void ObterPorId_ComIdExistente_DeveRetornarObjetoDoTipoVenda()
        {
            //arrange
            var idDeBusca = 1;
            var vendaMock = _listaMock.FirstOrDefault();
            //act
            var vendaDoTipoEsperado = _servicoVenda.ObterPorId(idDeBusca);
            //asset
            Assert.IsType<Venda>(vendaDoTipoEsperado);
        }

        [Fact]
        public void ObterPorId_ComIdInexistente_DeveLancarExcecaoObjetoNaoEncontrado()
        {
            //arrange
            var idDeBusca = 765;
            //act
            var excessao = Assert.Throws<Exception>(() => _servicoVenda.ObterPorId(idDeBusca));
            //asset
            Assert.Equal($"A venda com ID {idDeBusca} não foi encontrada", excessao.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("       ")]
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
            var excessao = Assert.Throws<ValidationException>(() => _servicoVenda.Criar(novaVenda));
            //asset
            Assert.Equal("Campo nome não preenchido.", excessao.Message);
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
            var excessao = Assert.Throws<ValidationException>(() => _servicoVenda.Criar(novaVenda));
            //asset
            Assert.Equal("O nome deve ter no máximo 100 caracteres.", excessao.Message);
        }

        [Theory]
        [InlineData("h1go0r")]
        [InlineData("🐱‍👤🐱‍👤🐱‍👤🐱‍👤")]
        [InlineData("!@#$%¨&*()_`{}^:>|")]
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
            var excessao = Assert.Throws<ValidationException>(() => _servicoVenda.Criar(novaVenda));
            //asset
            Assert.Equal("O nome deve conter apenas letras.", excessao.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("       ")]
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
            var excessao = Assert.Throws<ValidationException>(() => _servicoVenda.Criar(novaVenda));
            //asset
            Assert.Equal("Campo cpf não preenchido.", excessao.Message);
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
            var excessao = Assert.Throws<ValidationException>(() => _servicoVenda.Criar(novaVenda));
            //asset
            Assert.Equal("Formato CPF inválido.", excessao.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("       ")]
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
            var excessao = Assert.Throws<ValidationException>(() => _servicoVenda.Criar(novaVenda));
            //asset
            Assert.Equal("Campo e-mail não preenchido.", excessao.Message);
        }

        [Theory]
        [InlineData("@gmail")]
        [InlineData("hashas.br")]
        [InlineData("@gmail.com")]
        [InlineData("@gmail.com.br")]
        [InlineData("gmail.com.br@")]
        [InlineData("kakkhskhaksgmail.com")]
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
            var excessao = Assert.Throws<ValidationException>(() => _servicoVenda.Criar(novaVenda));
            //asset
            Assert.Equal("Formato de e-mail inválido.", excessao.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("    ")]
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
            var exception = Assert.Throws<ValidationException>(() => _servicoVenda.Criar(novaVenda));
            //asset
            Assert.Equal("Campo telefone não preenchido.", exception.Message);
        }

        [Theory]
        [InlineData("616512")]
        [InlineData("989802-1488")]
        [InlineData("(98)98021488")]
        [InlineData("(98)9802-1488")]
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
            var excessao = Assert.Throws<ValidationException>(() => _servicoVenda.Criar(novaVenda));
            //asset
            Assert.Equal("Formato de telefone inválido.", excessao.Message);
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
            var vendaEsperada = _servicoVenda.Criar(novaVenda);
            //asset
            Assert.Equal(novaVenda, vendaEsperada);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("       ")]
        public void Editar_ComNomeVazio_DeveRetornarExcecaoEsperada(string nome)
        {
            //arrange
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
            //act
            var excessao = Assert.Throws<ValidationException>(() => _servicoVenda.Editar(novaVenda));
            //asset
            Assert.Equal("Campo nome não preenchido.", excessao.Message);
        }

        [Fact]
        public void Editar_ComNomeExcedendoValorMaximo_DeveRetornarExcecaoEsperada()
        {
            //arrange
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
            //act
            var excessao = Assert.Throws<ValidationException>(() => _servicoVenda.Editar(novaVenda));
            //asset
            Assert.Equal("O nome deve ter no máximo 100 caracteres.", excessao.Message);
        }

        [Theory]
        [InlineData("h1go0r")]
        [InlineData("🐱‍👤🐱‍👤🐱‍👤🐱‍👤")]
        [InlineData("!@#$%¨&*()_`{}^:>|")]
        public void Editar_ComNomeInvalido_DeveRetornarExcecaoEsperada(string nome)
        {
            //arrange
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
            //act
            var excessao = Assert.Throws<ValidationException>(() => _servicoVenda.Editar(novaVenda));
            //asset
            Assert.Equal("O nome deve conter apenas letras.", excessao.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("       ")]
        public void Editar_ComCpfVazio_DeveRetornarExcecaoEsperada(string cpf)
        {
            //arrange
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
            //act
            var excessao = Assert.Throws<ValidationException>(() => _servicoVenda.Editar(novaVenda));
            //asset
            Assert.Equal("Campo cpf não preenchido.", excessao.Message);
        }

        [Theory]
        [InlineData("542522654")]
        [InlineData("111.111.111-11")]
        [InlineData("aaa.aaa.sss-jj")]
        public void Editar_ComCpfInvalido_DeveRetornarExcecaoEsperada(string cpf)
        {
            //arrange
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
            //act
            var excessao = Assert.Throws<ValidationException>(() => _servicoVenda.Editar(novaVenda));
            //asset
            Assert.Equal("Formato CPF inválido.", excessao.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("       ")]
        public void Editar_ComEmailVazio_DeveRetornarExcecaoEsperada(string email)
        {
            //arrange
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
            //act
            var excessao = Assert.Throws<ValidationException>(() => _servicoVenda.Editar(novaVenda));
            //asset
            Assert.Equal("Campo e-mail não preenchido.", excessao.Message);
        }

        [Theory]
        [InlineData("@gmail")]
        [InlineData("hashas.br")]
        [InlineData("@gmail.com")]
        [InlineData("@gmail.com.br")]
        [InlineData("gmail.com.br@")]
        [InlineData("kakkhskhaksgmail.com")]
        public void Editar_ComEmailInvalido_DeveRetornarExcecaoEsperada(string email)
        {
            //arrange
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
            //act
            var excessao = Assert.Throws<ValidationException>(() => _servicoVenda.Editar(novaVenda));
            //asset
            Assert.Equal("Formato de e-mail inválido.", excessao.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("    ")]
        public void Editar_ComTelefoneVazio_DeveRetornarExcecaoEsperada(string telefone)
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
                Telefone = telefone,
                ValorTotal = 100
            };
            //act
            var excessao = Assert.Throws<ValidationException>(() => _servicoVenda.Editar(novaVenda));
            //asset
            Assert.Equal("Campo telefone não preenchido.", excessao.Message);
        }

        [Theory]
        [InlineData("616512")]
        [InlineData("989802-1488")]
        [InlineData("(98)98021488")]
        [InlineData("(98)9802-1488")]
        public void Editar_ComTelefoneInvalido_DeveRetornarExcecaoEsperada(string telefone)
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
                Telefone = telefone,
                ValorTotal = 100
            };
            //act
            var excessao = Assert.Throws<ValidationException>(() => _servicoVenda.Editar(novaVenda));
            //asset
            Assert.Equal("Formato de telefone inválido.", excessao.Message);
        }

        [Fact]
        public void Editar_ComDataDeCompraInvalida_DeveRetornarExcecaoEsperada()
        {
            //arrange
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
            //act
            var excessao = Assert.Throws<ValidationException>(() => _servicoVenda.Editar(novaVenda));
            //asset
            Assert.Equal("Uma venda concluida não pode ter a data alterada.", excessao.Message);
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

        [Fact]
        public void Remover_ComDadosValidosNoBanco_DeveRemoverComSucesso()
        {
            //arrange
            var vendaDesejada = _listaMock.FirstOrDefault();
            //act
            _servicoVenda.Remover(vendaDesejada.Id);
            var excessao = Assert.Throws<Exception>(() => _servicoVenda.Remover(vendaDesejada.Id));
            //asset
            Assert.Equal($"A venda com ID {vendaDesejada.Id} não foi encontrada", excessao.Message);
        }
    }
}
