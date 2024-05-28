using Xunit;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Dominio.Interfaces;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Testes.ConfiguracaoAmbienteTeste;
using Cod3rsGrowth.Dominio.Services;

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
                    Id = 1,
                    Nome = "Higor",
                    Cpf = "714.696.331-40",
                    Email = "51313153@6323.com",
                    ItensVendidos = new List<Carro>
                    {
                        new Carro
                        {
                            Id = 23,
                            Modelo = "Golf GTI",
                            Cor = Cores.Branco,
                            Flex= true,
                            ValorDoVeiculo = 100,
                            Marca = Marcas.Volkswagem
                        }
                    },
                    Pago = true,
                    Telefone = "65651651651",
                    ValorTotal = 100
                },
                new Venda
                {
                    Id = 2,
                    Nome = "Daniel",
                    Cpf = "124.454.878-77",
                    Email = "ahshlahs@asa.com",
                    ItensVendidos = new List<Carro>
                    {
                        new Carro
                        {
                            Id = 777,
                            Modelo = "Civic",
                            Cor = Cores.Preto,
                            Flex = true,
                            ValorDoVeiculo = 100,
                            Marca = Marcas.Honda
                        }
                    },
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
            var IdDeBusca = 2;
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
        [InlineData("C")]
        [InlineData("h1go0r")]
        [InlineData("      ")]
        public void CriarComFluentValidator_CriandoAVenda_DeveRetornarExceptionEsperadaParaNome(string nome)
        {
            //arrange

            var novaVenda = new Venda
            {
                Nome = nome,
                Cpf = "888.999.333-22",
                Email = "51313153@6323.com",
                ItensVendidos = new List<Carro>
                {
                    new Carro
                    {
                        Id = 23,
                        Modelo = "Golf GTI",
                        Cor = Cores.Branco,
                        Flex= true,
                        ValorDoVeiculo = 100,
                        Marca = Marcas.Volkswagem
                    }
                },
                Pago = true,
                Telefone = "62983052721",
                ValorTotal = 100
            };
            //act
            //asset
            var exception = Assert.Throws<ValidationException>(() => _servicoVenda.Criar(novaVenda));
        }

        [Theory]
        [InlineData("     ")]
        [InlineData("542522654")]
        [InlineData("111.111.111-11")]
        [InlineData("aaa.aaa.sss-jj")]
        public void CriarComFluentValidator_CriandoOCarro_DeveRetornarExceptionEsperadaParaCpf(string cpf)
        {
            //arrange
            var novaVenda = new Venda
            {
                Nome = "Higor",
                Email = "higordaniel@gmail.com",
                Cpf = cpf,
                ItensVendidos = new List<Carro>
                {
                    new Carro
                    {
                        Id = 23,
                        Modelo = "Golf GTI",
                        Cor = Cores.Branco,
                        Flex= true,
                        ValorDoVeiculo = 100,
                        Marca = Marcas.Volkswagem
                    }
                },
                Pago = true,
                Telefone = "65651651651",
                ValorTotal = 100
            };
            //act
            //asset
            var exception = Assert.Throws<ValidationException>(() => _servicoVenda.Criar(novaVenda));

        }

        [Theory]
        [InlineData("kakkhskhaksgmail.com")]
        [InlineData("    ")]
        public void CriarComFluentValidator_CriandoOCarro_DeveRetornarExceptionEsperadaParaEmail(string email)
        {
            //arrange
            var novaVenda = new Venda
            {
                Nome = "Higor",
                Cpf = "714.696.331-40",
                Email = email,
                ItensVendidos = new List<Carro>
                {
                    new Carro
                    {
                        Id = 23,
                        Modelo = "Golf GTI",
                        Cor = Cores.Branco,
                        Flex= true,
                        ValorDoVeiculo = 100,
                        Marca = Marcas.Volkswagem
                    }
                },
                Pago = true,
                Telefone = "65651651651",
                ValorTotal = 100
            };
            //act
            //asset
            var exception = Assert.Throws<ValidationException>(() => _servicoVenda.Criar(novaVenda));
        }

        [Theory]
        [InlineData("616512")]
        [InlineData("    ")]
        public void CriarComFluentValidator_CriandoOCarro_DeveRetornarExceptionEsperadaParaTelefone(string telefone)
        {
            //arrange
            var novaVenda = new Venda
            {
                Nome = "Higor",
                Cpf = "651.687.998-74",
                Email = "51313153@6323.com",
                ItensVendidos = new List<Carro>
                {
                    new Carro
                    {
                        Id = 23,
                        Modelo = "Golf GTI",
                        Cor = Cores.Branco,
                        Flex= true,
                        ValorDoVeiculo = 100,
                        Marca = Marcas.Volkswagem
                    }
                },
                Telefone = telefone,
                Pago = true,
                ValorTotal = 100
            };
            //act
            //asset
            var exception = Assert.Throws<ValidationException>(() => _servicoVenda.Criar(novaVenda));
        }

        [Fact]
        public void CriarComFluentValidator_CriandoOCarro_DeveRetornarExceptionEsperadaParaItensVendidos()
        {
            //arrange
            var novaVenda = new Venda
            {
                Nome = "Higor",
                Cpf = "111.111.111-11",
                Email = "513131536323.com",
                ItensVendidos = new List<Carro>
                {
                    new Carro
                    {
                        Cor = Cores.Branco,
                        Flex= true,
                        ValorDoVeiculo = 100,
                        Marca = Marcas.Volkswagem
                    }
                },
                Pago = true,
                Telefone = "(65)65161651",
                ValorTotal = 100
            };
            //act
            //asset
            var exception = Assert.Throws<ValidationException>(() => _servicoVenda.Criar(novaVenda));

            Assert.Equivalent("Formato CPF inválido. Formato de e-mail inválido. Formato de telefone inválido. Campo modelo não preenchido. ", exception.Message);
        }

        [Fact]
        public void CriarComFluentValidator_CriandoOCarro_DeveRetornarVendaEsperado()
        {
            //arrange
            var novaVenda = new Venda
            {
                Id = _servicoVenda.ObterNovoId(),
                Nome = "Higor",
                Cpf = "213.344.567-98",
                Email = "higordaniel@.com",
                ItensVendidos = new List<Carro>
                {
                    new Carro
                    {
                        Id = _servicoVenda.ObterNovoId(),
                        Modelo = "C180",
                        Cor = Cores.Branco,
                        Flex = true,
                        Marca = Marcas.Bmw,
                        ValorDoVeiculo = 100
                    }
                },
                Pago = true,
                Telefone = "(65)65161-1651",
                ValorTotal = 100
            };
            //act
            _servicoVenda.Criar(novaVenda);
            var vendaEsperada = _servicoVenda.ObterTodos().Last();

            //asset
            Assert.Equivalent(novaVenda, vendaEsperada);
        }
    }
}
