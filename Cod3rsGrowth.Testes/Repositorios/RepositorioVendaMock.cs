using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Repositorios;
using System.ComponentModel.DataAnnotations;

namespace Cod3rsGrowth.Testes
{
    public class RepositorioVendaMock : IRepositorioVenda
    {
        private List<Venda> _repositorioVenda = ListaSingleton.Instance.RepositorioVenda;
        private int _novoId = 0;

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

        public Venda Editar(Venda venda)
        {
            var vendaDoBanco = ObterPorId(venda.Id);
            var indexDesejado = _repositorioVenda.FindIndex(vendaX => vendaX.Id == venda.Id);

            vendaDoBanco.Nome = venda.Nome
                ?? throw new ValidationException();
            vendaDoBanco.Email = venda.Email
                ?? throw new ValidationException();
            vendaDoBanco.Cpf = venda.Cpf
                ?? throw new ValidationException();
            vendaDoBanco.Telefone = venda.Telefone
                ?? throw new ValidationException();

            vendaDoBanco = venda;
            _repositorioVenda[indexDesejado] = venda;
            return _repositorioVenda[indexDesejado];
        }
    }
}
