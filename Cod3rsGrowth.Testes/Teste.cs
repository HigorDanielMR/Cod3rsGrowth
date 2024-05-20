using Cod3rsGrowth.Testes;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Testes.ConfiguracaoAmbienteTeste;
using Xunit;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Repositorios;


public class Teste : TesteBase
{
    private IRepositorio _repositorioMock;
    public Teste()
    {
        _repositorioMock = ServiceProvider.GetService<IRepositorio>();
    }
    [Fact]
    public void CriarCarroECriarVenda()
    {
        var listaSingleton = _repositorioMock.ObterTodos();

        var listaCarro = listaSingleton.RepositorioCarro;
        var listaVenda = listaSingleton.RepositorioVenda;
        var pagamento = false;

        if (listaVenda[0].ValorTotal == listaCarro[0].ValorDoVeiculo)
        {
            pagamento = true;
        }

        Assert.Equal(true, pagamento);
    }
}
