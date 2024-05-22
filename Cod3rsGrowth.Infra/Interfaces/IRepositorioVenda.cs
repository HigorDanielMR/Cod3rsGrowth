using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Infra.Repositorios;

namespace Cod3rsGrowth.Infra.Interfaces
{
    public interface IRepositorioVenda
    {
        List<Venda> ObterTodos();
        void Criar(Venda venda);
        Venda ObterVendaPorId(int id);
    }
}
