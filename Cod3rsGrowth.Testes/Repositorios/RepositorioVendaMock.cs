using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Repositorios;

namespace Cod3rsGrowth.Testes
{
    public class RepositorioVendaMock : IRepositorioVenda
    {
        private List<Venda> _repositorioVenda = ListaSingleton.Instance.RepositorioVenda;

        public List<Venda> ObterTodos()
        {
            return _repositorioVenda;
        }

        public Venda ObterVendaPorId(int IdDeBusca)
        {
            Venda IdDoItem = new Venda();
            foreach (var item in _repositorioVenda)
            {
                if (IdDeBusca == item.Id)
                {
                    IdDoItem = item;
                    return IdDoItem;
                }
            }
            return IdDoItem;
        }

        public void Criar(Venda venda)
        {
            _repositorioVenda.Add(venda);
        }
    }
}
