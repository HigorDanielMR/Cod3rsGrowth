using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;

namespace Cod3rsGrowth.Infra.Interfaces
{
    public interface IRepositorioVenda : IRepositorio<Venda>
    {
        List<Venda> ObterTodos(Venda venda);
        Venda Criar(Venda venda);
        Venda ObterPorId(int IdDoItem);
        Venda Editar(Venda venda);
        void Remover(int IdDeRemocao);
    }
}
