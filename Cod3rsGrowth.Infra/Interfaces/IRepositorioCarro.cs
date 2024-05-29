using Cod3rsGrowth.Dominio.Entities;

namespace Cod3rsGrowth.Infra.Interfaces
{
    public interface IRepositorioCarro
    {
        List<Carro> ObterTodos();
        void Criar(Carro carro);
        Carro ObterPorId(int IdDoItem);
        void Editar(Carro carro);
    }
}
