using FluentValidation;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Servicos.Validadores;
using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Servicos.Servicos
{
    public class ServicoCarro
    {
        private readonly RepositorioCarro _repositorioCarro;
        private ValidacoesCarro _validadorCarro;
        public ServicoCarro(RepositorioCarro repositorioCarro, ValidacoesCarro validadorCarro)
        {
            _repositorioCarro = repositorioCarro;
            _validadorCarro = validadorCarro;
        }

        public List<Carro> ObterTodos(FiltroCarro carro)
        {
            return _repositorioCarro.ObterTodos(carro);
        }

        public Carro ObterPorId(int IdDoItem)
        {
            return _repositorioCarro.ObterPorId(IdDoItem);
        }

        public Carro Criar(Carro carro)
        {
            var resultado = _validadorCarro.Validate(carro);
            if (!resultado.IsValid)
            {
                var erros = string.Join(Environment.NewLine, resultado.Errors.Select(x => x.ErrorMessage));
                throw new ValidationException(erros);
            }
            return _repositorioCarro.Criar(carro);
        }

        public Carro Editar(Carro carro)
        {
            var resultado = _validadorCarro.Validate(carro);
            if (!resultado.IsValid)
            {
                var erros = string.Join(Environment.NewLine, resultado.Errors.Select(x => x.ErrorMessage));
                throw new ValidationException(erros);
            }
            return _repositorioCarro.Editar(carro);
        }

        public void Remover(int IdDeRemocao)
        {
            _repositorioCarro.Remover(IdDeRemocao);
        }
    }
}
