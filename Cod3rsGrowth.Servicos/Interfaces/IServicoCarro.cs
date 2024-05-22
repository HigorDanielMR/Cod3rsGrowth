using Cod3rsGrowth.Dominio.Entities;

namespace Cod3rsGrowth.Dominio.Interfaces
{
    public interface IServicoCarro
    {
        List<Carro> ObterTodos();
        void Criar(Carro carro);
        void ObterCarroPorId();
        void EditarCarro();
        void RemoverCarro();
    }
}
