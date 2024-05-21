using Xunit;
using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Dominio.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Testes.ConfiguracaoAmbienteTeste;
using Cod3rsGrowth.Dominio.Services;
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
        public void ObterTodos_deve_retornar_o_tipo_da_lista()
        {
            //arrange

            //act
            var carros = _servicoCarro.ObterTodos();

            //asset
            Assert.NotNull(carros);
            Assert.IsType<List<Carro>>(carros);
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
        public void ObterTodos_deve_retornar_lista_com_dados()
        {
            //arrange

            //act
            var carros = _servicoCarro.ObterTodos();
            var novocarro = new Carro
            {
                Modelo = "Civic",
                Marca = Marcas.Honda,
                ValorDoVeiculo = 100
            };
            carros.Add(novocarro);

            //asset
            Assert.NotNull(carros);
            Assert.Equivalent(novocarro.Modelo, carros[0].Modelo);
            Assert.Equivalent(novocarro.Marca, carros[0].Marca);
            Assert.Equivalent(novocarro.ValorDoVeiculo, carros[0].ValorDoVeiculo);
        }
    }
}
