using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Infra.Repositorios;

namespace Cod3rsGrowth.Infra.Interfaces
{
    public interface IRepositorio
    {
        public ListaSingleton ObterTodos();
    }
}
