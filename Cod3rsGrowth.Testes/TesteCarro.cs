using Xunit;
using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Dominio.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Testes.ConfiguracaoAmbienteTeste;
using Cod3rsGrowth.Dominio.Enums;

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
        public void ObterTodosVaiNoBancoDeDadosEDeveRetornarTipoDaLista()
        {
            //arrange

            //act
            var carros = _servicoCarro.ObterTodos();

            //asset
            Assert.NotNull(carros);
            Assert.IsType<List<Carro>>(carros);
        }

        [Fact]
        public void ObterTodosVaiNoBancoDeDadosEDeveRetornarListaComDados()
        {
            //arrange

            //act
            var novocarro = new Carro
            {
                Modelo = "Civic",
                Marca = Marcas.Honda,
                ValorDoVeiculo = 100
            };
            _servicoCarro.Criar(novocarro);
            var carros = _servicoCarro.ObterTodos().FirstOrDefault();

            //asset
            Assert.NotNull(carros);
            Assert.Equivalent(novocarro, carros);
        }
    }
}
