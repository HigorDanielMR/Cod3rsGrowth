namespace Cod3rsGrowth.Dominio.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> ObterTodos();
        T Criar(T objeto);
        T ObterPorId(int IdDoItem);
        T Editar(T objeto);
        void Remover(int IdDeRemocao);
    }
}
