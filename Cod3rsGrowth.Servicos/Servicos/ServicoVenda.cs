using FluentValidation;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Servicos.Validadores;
using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Servicos.Servicos
{
    public class ServicoVenda
    {
        private readonly IRepositorioVenda _repositorioVenda;
        private ValidacoesVenda _validadorVenda;
        public ServicoVenda(IRepositorioVenda repositorioVenda, ValidacoesVenda validacaoVenda)
        {
            _repositorioVenda = repositorioVenda;
            _validadorVenda = validacaoVenda;
        }

        public List<Venda> ObterTodos(Venda venda)
        {
            return _repositorioVenda.ObterTodos(venda);
        }

        public Venda ObterPorId(int IdDoItem)
        {
            return _repositorioVenda.ObterPorId(IdDoItem);
        }

        public Venda Criar(Venda venda)
        {
            var resultado = _validadorVenda.Validate(venda);
            if (!resultado.IsValid)
            {
                var erros = string.Join(Environment.NewLine, resultado.Errors.Select(x => x.ErrorMessage));
                throw new ValidationException(erros);
            }
            return _repositorioVenda.Criar(venda);
        }

        public Venda Editar(Venda venda)
        {
            var resultado = _validadorVenda.Validate(venda, options => options.IncludeRuleSets("Editar").IncludeRulesNotInRuleSet());
            if (!resultado.IsValid)
            {
                var erros = string.Join(Environment.NewLine, resultado.Errors.Select(x => x.ErrorMessage));
                throw new ValidationException(erros);
            }
            return _repositorioVenda.Editar(venda);
        }

        public void Remover(int IdDeRemocao)
        {
            _repositorioVenda.Remover(IdDeRemocao);
        }
    }
}
