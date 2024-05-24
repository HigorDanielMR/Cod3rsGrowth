using Xunit;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Dominio.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Testes.ConfiguracaoAmbienteTeste;

namespace Cod3rsGrowth.Testes
{

    public class TesteVenda : TesteBase
    {
        private IServicoVenda _servicoVenda;
        private List<Venda> _listaMock;

        public TesteVenda()
        {
            CarregarServico();
            _listaMock = InicializarDadosMock();
        }

        private void CarregarServico()
        {
            _servicoVenda = ServiceProvider.GetService<IServicoVenda>()
               ?? throw new Exception($"Erro ao obter servico [{nameof(IServicoVenda)}]");
        }
        private List<Venda> InicializarDadosMock()
        {
            List<Venda> listaDeVendas = new List<Venda> {
                new Venda
                {
                    Id = 1,
                    Nome = "Higor",
                    Cpf = "651651616",
                    Email = "51313153@6323.com",
                    ItensVendidos = new List<Carro>
                    {
                        new Carro
                        {
                            Id = 23,
                            Modelo = "Golf GTI",
                            Cor = Cores.Branco,
                            Flex= true,
                            ValorDoVeiculo = 100,
                            Marca = Marcas.Volkswagem
                        }
                    },
                    Pago = true,
                    Telefone = "65651651651",
                    ValorTotal = 100
                },
                new Venda
                {
                    Id = 2,
                    Nome = "Daniel",
                    Cpf = "848941651615",
                    Email = "ahshlahs@asa.com",
                    ItensVendidos = new List<Carro>
                    {
                        new Carro
                        {
                            Id = 777,
                            Modelo = "Civic",
                            Cor = Cores.Preto,
                            Flex = true,
                            ValorDoVeiculo = 100,
                            Marca = Marcas.Honda
                        }
                    },
                    Pago = true,
                    Telefone = "01209091212",
                    ValorTotal = 100
                }
            };

            foreach (var item in listaDeVendas)
            {
                _servicoVenda.Criar(item);
            }

            return listaDeVendas;
        }

        [Fact]
        public void ObterTodos_ComDadosDisponiveis_DeveRetornarListaComTipoVenda()
        {
            //arrange
            //act
            var vendasDoBanco = _servicoVenda.ObterTodos();
            //asset
            Assert.NotNull(vendasDoBanco);
            Assert.IsType<List<Venda>>(vendasDoBanco);
        }

        [Fact]
        public void ObterTodos_ComDadosDisponiveis_DeveRetornarUmaListaDeVendas()
        {
            //arrange
            //act
            var vendasDoBanco = _servicoVenda.ObterTodos();
            //asset
            Assert.NotNull(vendasDoBanco);
            Assert.Equivalent(_listaMock, vendasDoBanco);
        }

        [Fact]
        public void ObterPorId_ComIdExistente_DeveRetornarVendaEsperada()
        {
            //arrange
            var IdBusca = 1;
            //act
            var vendaMock = _listaMock[0];
            var vendaDoBanco = _servicoVenda.ObterPorId(IdBusca);
            //asset
            Assert.NotNull(vendaDoBanco);
            Assert.Equivalent(vendaMock, vendaDoBanco);
        }

        [Fact]
        public void ObterPorId_ComIdExistente_DeveRetornarObjetoDoTipoVenda()
        {
            //arrange
            var IdDeBusca = 2;
            //act
            _listaMock.FirstOrDefault();
            var vendaDoTipoEsperado = _servicoVenda.ObterPorId(IdDeBusca);
            //asset
            Assert.IsType<Venda>(vendaDoTipoEsperado);
        }

        [Fact]
        public void ObterPorId_ComIdInexistente_DeveLancarExcecaoObjetoNaoEncontrado()
        {
            //arrange
            var IdDeBusca = 765;
            //act
            var exception = Assert.Throws<Exception>(() => _servicoVenda.ObterPorId(IdDeBusca));
            //asset
            Assert.Equal($"A venda com ID {IdDeBusca} não foi encontrada", exception.Message);
        }
    }
}
