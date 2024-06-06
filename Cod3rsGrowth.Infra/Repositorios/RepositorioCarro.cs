using LinqToDB;
using LinqToDB.Common;
using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.MeuContextoDeDado;

namespace Cod3rsGrowth.Infra.Repositorios
{
    class RepositorioCarro : IRepositorio<Carro>
    {
        public List<Carro> ObterTodos()
        {
            var db = new MeuDataContext();

            var query = from p in db.Carros
                        where p.Id > 0
                        orderby p.Modelo descending
                        select p;

            return query.ToList();
        }

        public Carro ObterPorId(int IdDeBusca)
        {
            return ObterPorId(IdDeBusca);
        }

        public Carro Criar(Carro carro)
        {
            return carro;
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
