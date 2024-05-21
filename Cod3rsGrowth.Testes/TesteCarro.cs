using Xunit;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Dominio.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Testes.ConfiguracaoAmbienteTeste;
using Cod3rsGrowth.Dominio.Services;

namespace Cod3rsGrowth.Testes
{
    public class TesteCarro : TesteBase
    {
        private readonly IServicoCarro _servicoCarro;

        public TesteCarro()
        {
            _servicoCarro = ServiceProvider.GetService<IServicoCarro>()
                ?? throw new Exception($"Erro ao obter servico [{nameof(IServicoCarro)}]");

        }

        [Fact]
        public void ObterTodos_deve_retornar_o_tipo_da_lista()
        {
            //arrange

            //act
            var carros = _servicoCarro.ObterTodos();

            //asset
            Assert.NotNull(carros);
            Assert.IsType<List<Carro>>(carros);
        }
    }
}
