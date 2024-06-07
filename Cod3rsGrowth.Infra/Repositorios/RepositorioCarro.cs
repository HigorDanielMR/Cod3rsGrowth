using LinqToDB;
using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.MeuContextoDeDado;
using Cod3rsGrowth.Infra.Interfaces;

namespace Cod3rsGrowth.Infra.Repositorios
{
    class RepositorioCarro : IRepositorio<Carro>
    {
        private MeuDataContext _db;

        public RepositorioCarro(MeuDataContext meuDataContext)
        {
           _db = meuDataContext;
        }

        public List<Carro> ObterTodos()
        {
            var query = from p in _db.Carros
                        where p.Id > 0
                        select p;

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
            return carroAtualizado;
        }
        public void Remover(int Id)
        {
        }
    }
}
