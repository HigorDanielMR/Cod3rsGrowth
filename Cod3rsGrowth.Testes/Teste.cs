using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Testes.ConfiguracaoAmbienteTeste;
using Microsoft.Extensions.DependencyInjection;
using Xunit;


public class Teste : TesteBase
{
    private readonly IServicoCarro _servicoCarro;
    private readonly IServicoVenda _servicoVenda;

    public Teste()
    {
        _servicoCarro = ServiceProvider.GetService<IServicoCarro>()
            ?? throw new Exception($"Erro ao obter servico [{nameof(IServicoCarro)}]");

        _servicoVenda = ServiceProvider.GetService<IServicoVenda>()
            ?? throw new Exception($"Erro ao obter servico [{nameof(IServicoVenda)}]");
    }

    [Fact]
    public void ObterTodos_deve_retornar_lista_vazia()
    {
        //arrange

        //act
        var carros = _servicoCarro.ObterTodos();
        var vendas = _servicoVenda.ObterTodos();

        //asset
        Assert.NotNull(carros);
        Assert.Equal(0, carros?.Count);

        Assert.NotNull(vendas);
        Assert.Equal(0, vendas?.Count);
    }

    [Fact]
    public void Criar_deve_salvar_Carro_dentro_do_banco()
    {
        //arrange
        var carro = new Carro()
        {
            Cor = Cores.Azul,
            Marca = Marcas.Honda,
            Modelo = "asdf",
            ValorDoVeiculo = 12000
        };

        var venda = new Venda()
        {
            Nome = "Higor",
            Cpf = "0808916812868971",
            Email = "jhlkajshlhasl@",
            Telefone = "09029097102012",
            DataDeCompra = DateTime.Now,
            ValorTotal = 12000
        };

        _servicoCarro.Criar(carro);
        _servicoVenda.Criar(venda);

        //act
        var carros = _servicoCarro.ObterTodos();
        var vendas = _servicoVenda.ObterTodos();

        //asset
        Assert.NotNull(carros);
        Assert.Equal(1, carros?.Count);

        Assert.NotNull(vendas);
        Assert.Equal(1, vendas?.Count);
    }
}
