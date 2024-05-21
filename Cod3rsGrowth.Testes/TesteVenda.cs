using Xunit;
using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Dominio.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Testes.ConfiguracaoAmbienteTeste;

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
        public void ObterTodosVaiNoBancoDeDadosEDeveRetornarTipoDaLista()
        {
            //arrange

            //act
            var vendas = _servicoVenda.ObterTodos();

            //asset
            Assert.NotNull(vendas);
            Assert.IsType<List<Venda>>(vendas);
        }

        [Fact]
        public void ObterTodosVaiNoBancoDeDadosEDeveRetornarListaComDados()
        {
            //arrange

            //act
            var novavenda = new Venda
            {
                Nome = "Higor",
                DataDeCompra = DateTime.Now,
                ValorTotal = 100
            };
            _servicoVenda.Criar(novavenda);
            var vendas = _servicoVenda.ObterTodos().FirstOrDefault();

            //asset
            Assert.NotNull(vendas);
            Assert.Equivalent(novavenda, vendas);
        }
    }
}
