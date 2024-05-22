using Xunit;
using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Dominio.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Testes.ConfiguracaoAmbienteTeste;

namespace Cod3rsGrowth.Testes
{

    public class TesteVenda : TesteBase
    {
        private readonly IServicoVenda CarregarServico;

        public TesteVenda()
        {
            CarregarServico = ServiceProvider.GetService<IServicoVenda>()
               ?? throw new Exception($"Erro ao obter servico [{nameof(IServicoVenda)}]");
        }

        [Fact]
        public void ObterTodos_ComDadosDisponiveis_DeveRetornarListaComTipoVenda()
        {
            //arrange

            //act
            var vendas = CarregarServico.ObterTodos();

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
            CarregarServico.Criar(novavenda);
            var vendas = CarregarServico.ObterTodos();

            List<Venda> listaTesteMock = new List<Venda>();
            listaTesteMock.Add(novavenda);

            //asset
            Assert.NotNull(vendas);
            Assert.Equivalent(listaTesteMock, vendas);
        }
    }
}
