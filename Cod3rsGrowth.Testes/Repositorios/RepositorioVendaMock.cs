using Cod3rsGrowth.Dominio.Entities;
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
            return _repositorioVenda.Find(objeto => objeto.Id == IdDeBusca)
                ?? throw new Exception($"A venda com ID {IdDeBusca} não foi encontrado");
        }

        public void Criar(Venda venda)
        {
            _repositorioVenda.Add(venda);
        }
    }
}
