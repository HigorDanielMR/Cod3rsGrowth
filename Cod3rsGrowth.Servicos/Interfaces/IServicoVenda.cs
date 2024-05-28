using Cod3rsGrowth.Dominio.Entities;

namespace Cod3rsGrowth.Dominio.Interfaces
{
    public interface IServicoVenda
    {
        List<Venda> ObterTodos();
        void Criar(Venda venda);
        Venda ObterPorId(int IdDoItem);
        void EditarVenda();
        void RemoverVenda();
    }
}
