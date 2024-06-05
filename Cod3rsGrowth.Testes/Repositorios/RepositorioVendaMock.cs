using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Repositorios;
using System.ComponentModel.DataAnnotations;

namespace Cod3rsGrowth.Testes
{
    public class RepositorioVendaMock : IRepositorioVenda
    {
        private List<Venda> _repositorioVenda = ListaSingleton.Instance.RepositorioVenda;
        private int _novoId = 1;

        public List<Venda> ObterTodos()
        {
            return _repositorioVenda;
        }

        public Venda ObterPorId(int IdDeBusca)
        {
            return _repositorioVenda.Find(objeto => objeto.Id == IdDeBusca)
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

            vendaDesejada.Nome = vendaAtualizada.Nome;
            vendaDesejada.Cpf = vendaAtualizada.Cpf;
            vendaDesejada.Email = vendaAtualizada.Email;
            vendaDesejada.DataDeCompra = vendaAtualizada.DataDeCompra;
            vendaDesejada.Pago = vendaAtualizada.Pago;
            vendaDesejada.Telefone =  vendaAtualizada.Telefone;
            vendaDesejada.ValorTotal = vendaAtualizada.ValorTotal;

            return vendaDesejada;
        }
    }
}
