using FluentValidation;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Servicos.Validadores;

namespace Cod3rsGrowth.Dominio.Services
{
    public class ServicoCarro
    {
        private readonly IRepositorioCarro _repositorioCarro;
        private ValidacoesCarro _validadorCarro;
        public ServicoCarro(IRepositorioCarro repositorioCarro, ValidacoesCarro validadorCarro)
        {
            _repositorioCarro = repositorioCarro;
            _validadorCarro = validadorCarro;
        }

        public List<Carro> ObterTodos()
        {
            return _repositorioCarro.ObterTodos();
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

        public bool Remover(int IdDeRemocao)
        {
            return _repositorioCarro.Remover(IdDeRemocao);
        }
    }
}
