using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Infra.Repositorios;

namespace Cod3rsGrowth.Infra.Interfaces
{
    public interface IRepositorioCarro
    {
        List<Carro> ObterTodos();
        void Criar(Carro carro);
        Carro ObterCarroPorId(int id);
    }
}
