using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Repositorios;

namespace Cod3rsGrowth.Testes
{
    public class RepositorioVendaMock : IRepositorioVenda
    {
        public List<Venda> RepositorioVenda = ListaSingleton.Instance.RepositorioVenda;

        public List<Venda> ObterTodos()
        {
            return RepositorioVenda;
        }

        public Venda ObterVendaPorId(int id)
        {
            int i = 0;
            for (i = 0; i < RepositorioVenda.Count; i++)
            {
                if (RepositorioVenda[i].Id == id)
                {
                    break;
                }
            }
            return RepositorioVenda[i];
        }

        public void Criar(Venda venda)
        {
            RepositorioVenda.Add(venda);
        }
    }
}
