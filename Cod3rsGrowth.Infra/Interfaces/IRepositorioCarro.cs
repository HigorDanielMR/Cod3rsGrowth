using Cod3rsGrowth.Dominio.Entities;

namespace Cod3rsGrowth.Infra.Interfaces
{
    public interface IRepositorioCarro
    {
        List<Carro> ObterTodos();
        Carro Criar(Carro carro);
        Carro ObterPorId(int IdDoItem);
        Carro Editar(Carro carro);
        bool Remover(int IdDeRemocao);
    }
}
