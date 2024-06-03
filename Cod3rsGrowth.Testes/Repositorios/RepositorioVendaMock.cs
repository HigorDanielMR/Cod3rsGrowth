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

        public void Criar(Venda venda)
        {
            venda.Id = _novoId;
            _novoId++;
            _repositorioVenda.Add(venda);
        }

        public void Editar(Venda venda)
        {
            var listaDoBanco = ObterTodos();
            var indexDesejado = venda.Id;

            listaDoBanco[indexDesejado].Nome = venda.Nome
                ?? throw new ValidationException();
            listaDoBanco[indexDesejado].Email = venda.Email
                ?? throw new ValidationException();
            listaDoBanco[indexDesejado].Cpf = venda.Cpf
                ?? throw new ValidationException();
            listaDoBanco[indexDesejado].Telefone = venda.Telefone
                ?? throw new ValidationException();

            listaDoBanco[venda.Id] = venda;
            _repositorioVenda = listaDoBanco;
        }
    }
}
