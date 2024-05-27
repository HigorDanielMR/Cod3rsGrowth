using Cod3rsGrowth.Dominio.Entities;

namespace Cod3rsGrowth.Infra.Interfaces
{
    public interface IRepositorioVenda
    {
        List<Venda> ObterTodos();
        void Criar(Venda venda);
        Venda ObterPorId(int IdDoItem);
    }
}
