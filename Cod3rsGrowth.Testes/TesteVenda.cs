using Xunit;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Dominio.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Testes.ConfiguracaoAmbienteTeste;

namespace Cod3rsGrowth.Testes
{

    public class TesteVenda : TesteBase
    {
        private IServicoVenda _servicoVenda;

        public TesteVenda()
        {
            CarregarServico();
        }

        private void CarregarServico()
        {
            _servicoVenda = ServiceProvider.GetService<IServicoVenda>()
               ?? throw new Exception($"Erro ao obter servico [{nameof(IServicoVenda)}]");
        }

        [Fact]
        public void ObterTodos_ComDadosDisponiveis_DeveRetornarListaComTipoVenda()
        {
            //arrange

            //act
            var vendas = _servicoVenda.ObterTodos();

            //asset
            Assert.NotNull(vendas);
            Assert.IsType<List<Venda>>(vendas);
        }

        [Fact]
        public void ObterTodos_ComDadosDisponiveis_DeveRetornarUmaListaDeVendas()
        {
            //arrange

            //act
            var novavenda = new Venda
            {
                Id = 0,
                Nome = "Higor",
                Cpf = "13213213132",
                Email = "lashlkhla@kjhkash.com",
                Telefone = "511321212131",
                ItensVendidos = new List<Carro>
                {
                    new Carro
                    {
                        Id = 6,
                        Modelo = "Civic",
                        Flex = true,
                        ValorDoVeiculo = 100,
                        Cor = Dominio.Enums.Cores.Prata,
                        Marca = Dominio.Enums.Marcas.Mercedes
                    }
                },
                Pago = true,
                DataDeCompra = DateTime.Now,
                ValorTotal = 100
            };
            _servicoVenda.Criar(novavenda);
            var vendas = _servicoVenda.ObterTodos();

            List<Venda> listaTesteMock = new List<Venda>();
            listaTesteMock.Add(novavenda);

            //asset
            Assert.NotNull(vendas);
            Assert.Equivalent(listaTesteMock, vendas);
        }

        [Fact]
        public void ObterPorId_ComDadosDisponiveis_DeveRetornarAVendaConformeOId()
        {

            //arrange
            var IdBusca1 = 7;
            var IdBusca2 = 8;
            //act
            var venda1 = new Venda
            {
                Id = 7,
                Nome = "Higor",
                Cpf = "651651616",
                DataDeCompra = DateTime.Now,
                Email = "51313153@6323.com",
                ItensVendidos = new List<Carro>
                {
                    new Carro
                    {
                        Id = 11,
                        Modelo = "Golf GTI",
                        Cor = Cores.Branco,
                        Flex = true,
                        ValorDoVeiculo = 100,
                        Marca = Marcas.Volkswagem
                    }
                },
                Pago = true,
                Telefone = "65651651651",
                ValorTotal = 100
            };
            var venda2 = new Venda
            {
                Id = 8,
                Nome = "Daniel",
                Cpf = "848941651615",
                DataDeCompra = DateTime.Now,
                Email = "ahshlahs@asa.com",
                ItensVendidos = new List<Carro>
                {
                    new Carro
                    {
                        Id = 12,
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
            };
            _servicoVenda.Criar(venda1);
            _servicoVenda.Criar(venda2);

            var resultado1 = _servicoVenda.ObterVendaPorId(IdBusca1);
            var resultado2 = _servicoVenda.ObterVendaPorId(IdBusca2);

            //asset
            Assert.NotNull(resultado1);
            Assert.NotNull(resultado2);

            Assert.Equal(venda1, resultado1);
            Assert.Equal(venda2, resultado2);
        }

        [Fact]
        public void ObterPorId_ComDadosDisponiveis_DeveRetornarOTipoDoObjetoVenda()
        {

            //arrange
            var Id1 = 181;
            //act
            var venda1 = new Venda
            {
                Id = 181,
                Nome = "Higor",
                Cpf = "651651616",
                DataDeCompra = DateTime.Now,
                Email = "51313153@6323.com",
                ItensVendidos = new List<Carro>
                {
                    new Carro
                    {
                        Id = 222,
                        Modelo = "Civic",
                        Cor = Cores.Preto,
                        Flex = true,
                        ValorDoVeiculo = 100,
                        Marca = Marcas.Honda
                    }
                },
                Pago = true,
                Telefone = "65651651651",
                ValorTotal = 100
            };
            _servicoVenda.Criar(venda1);

            var resultadoDaBusca = _servicoVenda.ObterVendaPorId(Id1);

            Assert.IsType<Venda>(resultadoDaBusca);
        }

        [Fact]
        public void ObterPorId_ComDadosDisponiveis_DeveRetornarExcessaoPorIdNaoEncontrado()
        {

            //arrange
            var Id1 = 765;
            var Id2 = 76;
            //act
            var venda1 = new Venda
            {
                Id = 92,
                Nome = "Higor",
                Cpf = "651651616",
                DataDeCompra = DateTime.Now,
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
            };
            var venda2 = new Venda
            {
                Id = 838,
                Nome = "Daniel",
                Cpf = "848941651615",
                DataDeCompra = DateTime.Now,
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
            };
            _servicoVenda.Criar(venda1);
            _servicoVenda.Criar(venda2);

            var exception = Assert.Throws<Exception>(() => _servicoVenda.ObterVendaPorId(Id1));
            var exception2 = Assert.Throws<Exception>(() => _servicoVenda.ObterVendaPorId(Id2));

            //asset
            Assert.Equal("Id não encontrado.", exception.Message);
            Assert.Equal("Id não encontrado.", exception2.Message);
        }
    }
}
