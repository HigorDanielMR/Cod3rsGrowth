using Xunit;
using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Dominio.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Testes.ConfiguracaoAmbienteTeste;
using Cod3rsGrowth.Dominio.Enums;

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
                Id = 2,
                Nome = "Higor",
                Cpf = "13213213132",
                Email = "lashlkhla@kjhkash.com",
                Telefone = "511321212131",
                ItensVendidos = new List<Carro>
                {
                    new Carro
                    {
                        Id = 2,
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
            var Id1 = 291;
            var Id2 = 762;
            //act
            var venda1 = new Venda
            {
                Id = 291,
                Nome = "Higor",
                Cpf = "651651616",
                DataDeCompra = DateTime.Now,
                Email = "51313153@6323.com",
                ItensVendidos = new List<Carro>
                {
                    new Carro
                    {
                        Id = 762,
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
            var venda2 = new Venda
            {
                Id = 762,
                Nome = "Daniel",
                Cpf = "848941651615",
                DataDeCompra = DateTime.Now,
                Email = "ahshlahs@asa.com",
                ItensVendidos= new List<Carro>
                {
                    new Carro
                    {
                        Id = 291,
                        Modelo = "Golf GTI",
                        Cor = Cores.Branco,
                        Flex= true,
                        ValorDoVeiculo = 100,
                        Marca = Marcas.Volkswagem
                    }
                },
                Pago = true,
                Telefone = "01209091212",
                ValorTotal = 100
            };
            _servicoVenda.Criar(venda1);
            _servicoVenda.Criar(venda2);

            var resultado1 = _servicoVenda.ObterVendaPorId(Id1);
            var resultado2 = _servicoVenda.ObterVendaPorId(Id2);

            //asset
            Assert.Equal(venda1, resultado1);
            Assert.Equal(venda2, resultado2);
        }
    }
}
