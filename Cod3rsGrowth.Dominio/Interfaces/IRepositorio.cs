using Cod3rsGrowth.Dominio.Entities;

namespace Cod3rsGrowth.Dominio.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> ObterTodos(T objeto);
        T Criar(T objeto);
        T ObterPorId(int IdDoItem);
        T Editar(T objeto);
        void Remover(int IdDeRemocao);
    }
}
