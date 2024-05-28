using FluentValidation;
using Cod3rsGrowth.Dominio.Entities;

namespace Cod3rsGrowth.Servicos.Validadores
{
    public class ValidacoesCarro : AbstractValidator<Carro>
    {
        public ValidacoesCarro()
        {
            RuleFor(carro => carro.Modelo)
                .NotEmpty().WithMessage("Campo modelo não preenchido.")
                .Length(2, 60).WithMessage("Modelo inválido, precisa ter no mínimo 2 caracteres.");

            RuleFor(carro => carro.Marca)
                .NotEmpty().WithMessage("Campo marca não preenchido.")
                .IsInEnum().WithMessage("Essa marca é inválida.");

            RuleFor(carro => carro.Cor)
                .NotEmpty().WithMessage("Campo cor não preenchido.")
                .IsInEnum().WithMessage("Essa cor é inválido.");

            RuleFor(carro => carro.ValorDoVeiculo)
                .NotEmpty().WithMessage("Campo valor do veiculo não preenchido.")
                .GreaterThan(0).WithMessage("O valor do veiculo deve ser maior que zero.");

            RuleFor(carro => carro.Flex)
                .NotEmpty().WithMessage("Campo flex não preenchido.");
        }
    }
}
