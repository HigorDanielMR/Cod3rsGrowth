using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Servicos.Validadores;
using System.ComponentModel.DataAnnotations;
using System.Xml;

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
            if (!resultado.IsValid)
            {
                var erros = "";
                foreach(var falhas in resultado.Errors)
                {
                    if(resultado.Errors.Count > 1)
                    {
                        erros += falhas.ErrorMessage + " ";
                    }
                    else
                    {
                        erros += falhas.ErrorMessage;
                    }
                }
                throw new ValidationException(erros);
            }
            _repositorioVenda.Criar(venda);
        }
        public void Editar(Venda venda)
        {
            var resultado = _validadorVenda.Validate(venda);
            if (!resultado.IsValid)
            {
                var erros = "";
                foreach (var falhas in resultado.Errors)
                {
                    if (resultado.Errors.Count > 1)
                    {
                        erros += falhas.ErrorMessage + " ";
                    }
                    else
                    {
                        erros += falhas.ErrorMessage;
                    }
                }
                throw new ValidationException(erros);
            }
                _repositorioVenda.Editar(venda);
        }

        public void RemoverVenda()
        {
            return;
        }
    }
}
