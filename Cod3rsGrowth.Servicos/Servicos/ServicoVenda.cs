using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Servicos.Validadores;
using FluentValidation.Validators;
using System.ComponentModel.DataAnnotations;

namespace Cod3rsGrowth.Dominio.Services
{
    public class ServicoVenda : IServicoVenda
    {
        private readonly IRepositorioVenda _repositorioVenda;
        private ValidacoesVenda _validadorVenda;
        public ServicoVenda(IRepositorioVenda repositorioVenda, ValidacoesVenda validacaoVenda)
        {
            _repositorioVenda = repositorioVenda;
            _validadorVenda = validacaoVenda;
        }

        public List<Venda> ObterTodos()
        {
            return _repositorioVenda.ObterTodos();
        }

        public Venda ObterPorId(int IdDoItem)
        {
            return _repositorioVenda.ObterPorId(IdDoItem);
        }

        public void Criar(Venda venda)
        {
            var resultado = _validadorVenda.Validate(venda);
            var erros = "";
            if (!resultado.IsValid)
            {
                foreach(var falhas in resultado.Errors)
                {
                    erros += falhas.ErrorMessage + " ";
                }
                throw new ValidationException(erros);
            }
            _repositorioVenda.Criar(venda);
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
