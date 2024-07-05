using LinqToDB;
using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.ConexaoComBanco;

namespace Cod3rsGrowth.Infra.Repositorios
{
    public class RepositorioCarro : IRepositorioCarro
    {
        private MeuContextoDeDados _conexao;

        public RepositorioCarro(MeuContextoDeDados meuContextoDeDados)
        {
            _conexao = meuContextoDeDados;
        }

        public List<Carro> ObterTodos(FiltroCarro filtroCarro)
        {
            var query = FiltroParaBusca(filtroCarro);
            var carrosFiltrados = query.ToList();

            return carrosFiltrados;
        }

        public Carro ObterPorId(int IdDeBusca)
        {
            var query = from p in _conexao.Carro
                        where p.Id == IdDeBusca
                        select p;

            var resultado = query.FirstOrDefault()
                ?? throw new Exception($"Carro com ID {IdDeBusca} não encontrado.");

            return resultado;
        }

        public Carro Criar(Carro carro)
        {
            var idDoCarroNoBanco = _conexao.InsertWithInt32Identity(carro);
            return ObterPorId(idDoCarroNoBanco);
        }

        public Carro Editar(Carro carroAtualizado)
        {
            var carroDesejado = ObterPorId(carroAtualizado.Id);

            carroDesejado.Cor = carroAtualizado.Cor;
            carroDesejado.Flex = carroAtualizado.Flex;
            carroDesejado.Marca = carroAtualizado.Marca;
            carroDesejado.Modelo = carroAtualizado.Modelo;
            carroDesejado.ValorDoVeiculo = carroAtualizado.ValorDoVeiculo;

            _conexao.Update(carroAtualizado);
            return carroAtualizado;
        }

        public void Remover(int Id)
        {
            _conexao.Carro
                 .Where(carro => carro.Id == Id)
                 .Delete();
        }

        private IQueryable<Carro> FiltroParaBusca(FiltroCarro? filtroCarro)
        {
            IQueryable<Carro> query = _conexao.Carro;

            if (filtroCarro is null) return query;

            if (filtroCarro.Modelo != null)
                query = query.Where(d => d.Modelo.Contains(filtroCarro.Modelo));

            if (filtroCarro.Cor != null)
                query = query.Where(d => d.Cor == filtroCarro.Cor);

            if (filtroCarro.Marca != null)
                query = query.Where(d => d.Marca == filtroCarro.Marca);

            if (filtroCarro.Flex != null)
                query = query.Where(d => d.Flex == filtroCarro.Flex);

            return query;
        }
    }
}
