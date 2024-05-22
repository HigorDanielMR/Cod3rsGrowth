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

        public Venda ObterVendaPorId(int id)
        {
            int i = 0;
            for (i = 0; i < _repositorioVenda.Count; i++)
            {
                if (_repositorioVenda[i].Id == id)
                {
                    break;
                }
            }
            return _repositorioVenda[i];
        }

        public void Criar(Venda venda)
        {
            _repositorioVenda.Add(venda);
        }
    }
}
