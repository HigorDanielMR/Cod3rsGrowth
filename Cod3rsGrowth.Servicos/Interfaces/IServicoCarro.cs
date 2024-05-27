using Cod3rsGrowth.Dominio.Entities;

namespace Cod3rsGrowth.Dominio.Interfaces
{
    public interface IServicoCarro
    {
        List<Carro> ObterTodos();
        void Criar(Carro carro);
        Carro ObterPorId(int IdDoItem);
        int ObterNovoId();
        void EditarCarro();
        void RemoverCarro();
    }
}
