using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Dominio.Interfaces;

namespace Cod3rsGrowth.Infra.Repositorios
{
    class RepositorioVenda : IRepositorio<Venda>
    {
        public List<Venda> ObterTodos()
        {
            return ObterTodos();
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
