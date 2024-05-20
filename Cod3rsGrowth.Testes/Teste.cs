using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Testes.ConfiguracaoAmbienteTeste;
using Microsoft.Extensions.DependencyInjection;
using Xunit;


public class Teste : TesteBase
{
    private readonly IServicoCarro _servicoCarro;

    public Teste()
    {
        _servicoCarro = ServiceProvider.GetService<IServicoCarro>()
            ?? throw new Exception($"Erro ao obter servico [{nameof(IServicoCarro)}]");
    }

    [Fact]
    public void ObterTodos_deve_retornar_lista_vazia()
    {
        //arrange

        //act
        var carros = _servicoCarro.ObterTodos();

        //asset
        Assert.NotNull(carros);
        Assert.Equal(0, carros?.Count);
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

        _servicoCarro.Criar(carro);

        //act
        var carros = _servicoCarro.ObterTodos();

        //asset
        Assert.NotNull(carros);
        Assert.Equal(1, carros?.Count);
    }
}
