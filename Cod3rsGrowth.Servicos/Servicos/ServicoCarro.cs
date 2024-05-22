using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.Interfaces;

namespace Cod3rsGrowth.Dominio.Services
{
    public class ServicoCarro : IServicoCarro
    {
        private readonly IRepositorioCarro _repositorioCarro;
        public ServicoCarro(IRepositorioCarro repositorioCarro)
        {
            _repositorioCarro = repositorioCarro;
        }

        public List<Carro> ObterTodos()
        {
            return _repositorioCarro.ObterTodos();
        }

        public void ObterCarroPorId()
        {
            return;
        }

        public void Criar(Carro carro)
        {
            _repositorioCarro.Criar(carro);
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
