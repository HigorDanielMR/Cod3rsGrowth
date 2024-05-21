using Xunit;
using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Dominio.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Testes.ConfiguracaoAmbienteTeste;
using Cod3rsGrowth.Dominio.Services;

namespace Cod3rsGrowth.Testes
{

    public class TesteVenda : TesteBase
    {
        private readonly IServicoVenda _servicoVenda;

        public TesteVenda()
        {
            _servicoVenda = ServiceProvider.GetService<IServicoVenda>()
                ?? throw new Exception($"Erro ao obter servico [{nameof(IServicoVenda)}]");
        }

        [Fact]
        public void ObterTodos_deve_retornar_o_tipo_da_lista()
        {
            //arrange

            //act
            var vendas = _servicoVenda.ObterTodos();

            //asset
            Assert.NotNull(vendas);
            Assert.IsType<List<Venda>>(vendas);
        }

        [Fact]
        public void ObterTodos_deve_retornar_lista_vazia()
        {
            //arrange

            //act
            var vendas = _servicoVenda.ObterTodos();

            //asset
            Assert.NotNull(vendas);
            Assert.Equal(0, vendas?.Count);
        }

        [Fact]
        public void ObterTodos_deve_retornar_lista_com_dados()
        {
            //arrange

            //act
            var vendas = _servicoVenda.ObterTodos();
            var novavenda = new Venda
            {
                Nome = "Higor",
                DataDeCompra = DateTime.Now,
                ValorTotal = 100
            };
            vendas.Add(novavenda);

            //asset
            Assert.NotNull(vendas);
            Assert.Equivalent(novavenda.Nome, vendas[0].Nome);
            Assert.Equivalent(novavenda.DataDeCompra, vendas[0].DataDeCompra);
            Assert.Equivalent(novavenda.ValorTotal, vendas[0].ValorTotal);
        }
    }
}
