using Cod3rsGrowth.Dominio.Entities;

namespace Cod3rsGrowth.Infra.Interfaces
{
    public interface IRepositorio
    {
        List<Carro> ObterTodos();
    }
}
