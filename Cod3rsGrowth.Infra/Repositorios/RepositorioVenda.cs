using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.MeuContextoDeDado;

namespace Cod3rsGrowth.Infra.Repositorios
{
    class RepositorioVenda : IRepositorio<Venda>
    {
        public List<Venda> ObterTodos()
        {
            var db = new MeuDataContext();

            var query = from p in db.Vendas
                        where p.Id > 0
                        select p;

            return query.ToList();
        }

        public Venda ObterPorId(int IdDeBusca)
        {
            return ObterPorId(IdDeBusca);
        }

        public Venda Criar(Venda venda)
        {
            return venda;
        }

        public Venda Editar(Venda vendaAtualizada)
        {
            return vendaAtualizada;
        }
        public void Remover(int Id)
        {
        }
    }
}
