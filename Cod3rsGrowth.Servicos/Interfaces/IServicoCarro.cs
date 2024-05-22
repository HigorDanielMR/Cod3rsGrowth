using Cod3rsGrowth.Dominio.Entities;

namespace Cod3rsGrowth.Dominio.Interfaces
{
    public interface IServicoCarro
    {
        List<Carro> ObterTodos();
        void Criar(Carro carro);
        Carro ObterCarroPorId(int id);
        void EditarCarro();
        void RemoverCarro();
    }
}
