using FluentValidation;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Servicos.Validadores;

namespace Cod3rsGrowth.Dominio.Services
{
    public class ServicoCarro : IServicoCarro
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

        public void Criar(Carro carro)
        {
            var resultado = _validadorCarro.Validate(carro);
            var erros = "";
            if (!resultado.IsValid)
            {
                foreach (var falhas in resultado.Errors)
                {
                    erros += falhas.ErrorMessage + " ";
                }
                throw new ValidationException(erros);
            }
            _repositorioCarro.Criar(carro);
        }
        public int ObterNovoId()
        {
            var id = _repositorioCarro.ObterTodos().Last().Id + 1;

            return id;
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
