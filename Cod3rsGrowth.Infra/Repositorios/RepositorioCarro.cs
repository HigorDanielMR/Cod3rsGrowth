using LinqToDB;
using LinqToDB.Data;
using System.Configuration;
using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.ConexaoComBanco;

namespace Cod3rsGrowth.Infra.Repositorios
{
    public class RepositorioCarro : IRepositorioCarro
    {
        private MeuContextoDeDados _connection;

        public RepositorioCarro(MeuContextoDeDados meuContextoDeDados)
        {
            _connection = meuContextoDeDados;
        }

        public List<Carro> ObterTodos(FiltroCarro filtro)
        {
            var query = FiltroParaBusca(_connection.Carro, filtro);
            if (query == null)
            {
                return _connection.Carro.ToList();
            }
            else
            {
                var resultadoFiltro = query.ToList();
                return resultadoFiltro.ToList();
            }
        }

        public Carro ObterPorId(int IdDeBusca)
        {
            var query = from p in _connection.Carro
                        where p.Id == IdDeBusca
                        select p;

            var resultado = query.FirstOrDefault()
                ?? throw new Exception($"Carro com ID {IdDeBusca} não encontrado.");

            return resultado;
        }

        public Carro Criar(Carro carro)
        {
            var idDoCarroNoBanco = _connection.InsertWithInt32Identity(carro);
            return ObterPorId(idDoCarroNoBanco);
        }

        public Carro Editar(Carro carroAtualizado)
        {
            var carroDesejado = _connection.Carro.FirstOrDefault(carro => carro.Id == carroAtualizado.Id);

            if (carroDesejado != null)
            {
                carroDesejado.Cor = carroAtualizado.Cor;
                carroDesejado.Flex = carroAtualizado.Flex;
                carroDesejado.Marca = carroAtualizado.Marca;
                carroDesejado.Modelo = carroAtualizado.Modelo;
                carroDesejado.ValorDoVeiculo = carroAtualizado.ValorDoVeiculo;

                _connection.Update(carroAtualizado);
            }
            else
            {
                throw new Exception($"Carro com ID {carroAtualizado.Id} não encontrado.");
            }
            return carroAtualizado;

        }

        public void Remover(int Id)
        {
            _connection.Carro
                 .Where(carro => carro.Id == Id)
                 .Delete();
        }

        private static IQueryable<Carro> FiltroParaBusca(ITable<Carro> carros, FiltroCarro carro)
        {
            var query = carros.AsQueryable();

            if (carro != null)
                if (carro.Modelo != null)
                    query = query.Where(d => d.Modelo.Contains(carro.Modelo));

                if (carro.Cor != null)
                    query = query.Where(d => d.Cor == carro.Cor);

                if (carro.Marca != null)
                    query = query.Where(d => d.Marca == carro.Marca);

                if (carro.Flex != null)
                    query = query.Where(d => d.Flex == carro.Flex);

            return query;
        }

    }
}
