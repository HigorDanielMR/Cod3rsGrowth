using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.Interfaces;

namespace Cod3rsGrowth.Dominio.Services
{
    public class ServicoVenda : IServicoVenda
    {
        private readonly IRepositorioVenda _repositorioVenda;
        public ServicoVenda(IRepositorioVenda repositorioVenda)
        {
            _repositorioVenda = repositorioVenda;
        }

        public List<Venda> ObterTodos()
        {
            return _repositorioVenda.ObterTodos();
        }

        public Venda ObterVendaPorId(int IdDoItem)
        {
            return _repositorioVenda.ObterVendaPorId(IdDoItem);
        }

        public void Criar(Venda venda)
        {
            _repositorioVenda.Criar(venda);
        }

        public void EditarVenda()
        {
            return;
        }

        public void RemoverVenda()
        {
            return;
        }
    }
}
