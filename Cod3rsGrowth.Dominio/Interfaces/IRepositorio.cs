namespace Cod3rsGrowth.Dominio.Interfaces
{
    public interface IRepositorio<T, TFiltro> where TFiltro : IFiltro
    {
        List<T> ObterTodos(TFiltro filtro);
        T Criar(T objeto);
        T ObterPorId(int IdDoItem);
        T Editar(T objeto);
        void Remover(int IdDeRemocao);
    }
}
