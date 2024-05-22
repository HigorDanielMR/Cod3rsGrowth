using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.Interfaces;

namespace Cod3rsGrowth.Dominio.Services
{
    public class ServicoCarro : IServicoCarro
    {
        private readonly IRepositorioCarro RepositorioCarro;
        public ServicoCarro(IRepositorioCarro repositorioCarro)
        {
            RepositorioCarro = repositorioCarro;
        }

        public List<Carro> ObterTodos()
        {
            return RepositorioCarro.ObterTodos();
        }

        public Carro ObterCarroPorId(int id)
        {
            return RepositorioCarro.ObterCarroPorId(id);
        }

        public void Criar(Carro carro)
        {
            RepositorioCarro.Criar(carro);
        }

        public void EditarCarro()
        {
            return;
        }

        public void RemoverCarro()
        {
            return;
        }
    }
}
