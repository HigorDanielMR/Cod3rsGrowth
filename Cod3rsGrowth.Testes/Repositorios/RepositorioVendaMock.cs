using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Repositorios;
using Cod3rsGrowth.Testes.Excessoes;

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
            var resultadoDabusca = _repositorioVenda.Find(objeto => objeto.Id == IdDeBusca);
            if (resultadoDabusca == null)
            {
                throw new MinhasExcessoes("Id não encontrado");
            }
            else
            {
                return resultadoDabusca;
            }
        }

        public void Criar(Venda venda)
        {
            _repositorioVenda.Add(venda);
        }
    }
}
