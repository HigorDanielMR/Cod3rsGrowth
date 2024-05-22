using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.Interfaces;

namespace Cod3rsGrowth.Dominio.Services
{
    public class ServicoVenda : IServicoVenda
    {
        private readonly IRepositorioVenda RepositorioVenda;
        public ServicoVenda(IRepositorioVenda repositorioVenda)
        {
            RepositorioVenda = repositorioVenda;
        }

        public List<Venda> ObterTodos()
        {
            return RepositorioVenda.ObterTodos();
        }

        public Venda ObterVendaPorId(int id)
        {
            return RepositorioVenda.ObterVendaPorId(id);
        }

        public void Criar(Venda venda)
        {
            RepositorioVenda.Criar(venda);
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
