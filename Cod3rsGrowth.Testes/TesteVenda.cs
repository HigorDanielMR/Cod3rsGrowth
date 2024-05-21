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
        public void Criar_deve_salvar_Venda_dentro_do_banco()
        {
            var venda = new Venda()
            {
                Nome = "Higor",
                Cpf = "0808916812868971",
                Email = "jhlkajshlhasl@",
                Telefone = "09029097102012",
                DataDeCompra = DateTime.Now,
                ValorTotal = 12000
            };
            _servicoVenda.Criar(venda);

            //act
            var vendas = _servicoVenda.ObterTodos();

            //asset
            Assert.NotNull(vendas);
            Assert.Equal(1, vendas?.Count);
        }
    }
}
