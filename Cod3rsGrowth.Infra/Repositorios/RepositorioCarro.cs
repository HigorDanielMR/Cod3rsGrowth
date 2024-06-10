using LinqToDB;
using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.MeuContextoDeDado;

namespace Cod3rsGrowth.Infra.Repositorios
{
    class RepositorioCarro : IRepositorio<Carro>
    {
        private MeuDataContext _db;

        public RepositorioCarro(MeuDataContext meuDataContext)
        {
            _db = meuDataContext;
        }

        public List<Carro> ObterTodos(Carro carro)
        {
            IQueryable<Carro> carros = Filtro(_db.Carros.ToList(), carro);
            var query = carros;
            return query.ToList();
        }

        public Carro ObterPorId(int IdDeBusca)
        {
            return ObterPorId(IdDeBusca);
        }

        public Carro Criar(Carro carro)
        {
            int idDoCarroNoBnco = _db.InsertWithInt32Identity(carro);
            return ObterPorId(idDoCarroNoBnco);
        }

        public Carro Editar(Carro carroAtualizado)
        {
            var carroDesejado = _db.Carros.FirstOrDefault(carro => carro.Id == carroAtualizado.Id);

            if (carroDesejado != null)
            {
                carroDesejado.Modelo = carroAtualizado.Modelo;
                carroDesejado.Cor = carroAtualizado.Cor;
                carroDesejado.Flex = carroAtualizado.Flex;
                carroDesejado.Marca = carroAtualizado.Marca;
                carroDesejado.ValorDoVeiculo = carroAtualizado.ValorDoVeiculo;

                _db.Update(carroAtualizado);
            }
            else
            {
                throw new Exception($"Carro com ID {carroAtualizado.Id} não encontrado.");
            }
            return carroAtualizado;
        }
        public void Remover(int Id)
        {
            _db.Carros
                .Where(carro => carro.Id == Id)
                .Delete();
        }

        private static IQueryable<Carro> Filtro(List<Carro> carros, Carro carro)
        {
            var query = carros.AsQueryable();

            if (carro.Modelo != null)
                query = query.Where(d => d.Modelo == carro.Modelo);

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
