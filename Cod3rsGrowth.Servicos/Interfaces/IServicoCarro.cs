using Cod3rsGrowth.Dominio.Entities;

namespace Cod3rsGrowth.Dominio.Interfaces
{
    public interface IServicoCarro
    {
        public List<Carro> ObterTodos();
        public void CriarCarro();
        public void ObterCarroPorId();
        public void EditarCarro();
        public void RemoverCarro();
    }
}
