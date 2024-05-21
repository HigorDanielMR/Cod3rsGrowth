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

    }
}
