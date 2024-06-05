using Cod3rsGrowth.Dominio.Entities;

namespace Cod3rsGrowth.Infra.Interfaces
{
    public interface IRepositorioVenda
    {
        List<Venda> ObterTodos();
        Venda Criar(Venda venda);
        Venda ObterPorId(int IdDoItem);
        Venda Editar(Venda venda);
        void Remover(Venda venda);
    }
}
