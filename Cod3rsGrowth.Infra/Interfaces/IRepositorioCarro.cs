using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;

namespace Cod3rsGrowth.Infra.Interfaces
{
    public interface IRepositorioCarro : IRepositorio<Carro>
    {
        List<Carro> ObterTodos(Carro carro);
        Carro Criar(Carro carro);
        Carro ObterPorId(int IdDoItem);
        Carro Editar(Carro carro);
        void Remover(int IdDeRemocao);
    }
}
