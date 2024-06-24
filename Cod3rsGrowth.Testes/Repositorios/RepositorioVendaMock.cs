using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.Repositorios;

namespace Cod3rsGrowth.Testes.Repositorios
{
    public class RepositorioVendaMock : IRepositorioVenda
    {
        private int _novoId = 1;
        private List<Venda> _repositorioVenda = ListaSingleton.Instance.RepositorioVenda;
        public List<Venda> ObterTodos(FiltroVenda venda)
        {
            return _repositorioVenda;
        }

        public Venda ObterPorId(int IdDeBusca)
        {
            return _repositorioVenda.Find(venda => venda.Id == IdDeBusca)
                ?? throw new Exception($"A venda com ID {IdDeBusca} não foi encontrada");
        }

        public Venda Criar(Venda venda)
        {
            venda.Id = _novoId;
            _novoId++;
            _repositorioVenda.Add(venda);
            return venda;
        }

        public Venda Editar(Venda vendaAtualizada)
        {
            var vendaDesejada = ObterPorId(vendaAtualizada.Id);

            vendaDesejada.Cpf = vendaAtualizada.Cpf;
            vendaDesejada.Pago = vendaAtualizada.Pago;
            vendaDesejada.Nome = vendaAtualizada.Nome;
            vendaDesejada.Email = vendaAtualizada.Email;
            vendaDesejada.Telefone = vendaAtualizada.Telefone;
            vendaDesejada.ValorTotal = vendaAtualizada.ValorTotal;
            vendaDesejada.DataDeCompra = vendaAtualizada.DataDeCompra;

            return vendaDesejada;
        }

        public void Remover(int Id)
        {
            var vendaDesejada = _repositorioVenda.Find(c => c.Id == Id);
            if (vendaDesejada != null) _repositorioVenda.Remove(vendaDesejada);
            else throw new Exception($"A venda com ID {Id} não foi encontrada");
        }
    }
}
