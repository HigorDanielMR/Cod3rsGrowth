using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Dominio.Interfaces;

namespace Cod3rsGrowth.Infra.Repositorios
{
    class RepositorioCarro : IRepositorio<Carro>
    {
        public List<Carro> ObterTodos()
        {
            return ObterTodos();
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
