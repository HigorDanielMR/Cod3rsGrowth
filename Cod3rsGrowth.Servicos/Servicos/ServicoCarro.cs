using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Servicos.Validadores;
using FluentValidation;

namespace Cod3rsGrowth.Dominio.Services
{
    public class ServicoCarro : IServicoCarro
    {
        private readonly IRepositorioCarro _repositorioCarro;
        private ValidacoesCarro _validacaoCarro;
        public ServicoCarro(IRepositorioCarro repositorioCarro, ValidacoesCarro validacaoCarro)
        {
            _repositorioCarro = repositorioCarro;
            _validacaoCarro = validacaoCarro;
        }

        public List<Carro> ObterTodos()
        {
            return _repositorioCarro.ObterTodos();
        }

        public Carro ObterPorId(int IdDoItem)
        {
            return _repositorioCarro.ObterPorId(IdDoItem);
        }

        public void Criar(Carro carro)
        {
            var resultado = _validacaoCarro.Validate(carro);
            if (resultado.IsValid)
            {
                _repositorioCarro.Criar(carro);
            }
            else
            {
                foreach(var falhas in resultado.Errors)
                {
                    throw new ValidationException(falhas.ErrorMessage);
                }
            }
        }

        public void EditarCarro()
        {
            return;
        }

        public void RemoverCarro()
        {
            return;
        }
    }
}
