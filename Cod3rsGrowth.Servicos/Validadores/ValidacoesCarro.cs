using FluentValidation;
using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Servicos.Validadores
{
    public class ValidacoesCarro : AbstractValidator<Carro>
    {
        public ValidacoesCarro()
        {
            RuleFor(carro => carro.Modelo)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Campo modelo não preenchido.")
                .Length(2, 50).WithMessage("Modelo inválido, precisa ter no mínimo 2 caracteres e no maximo 50 caracteres.")
                .Matches(@"[\p{L}\p{N}\p{S}]").WithMessage("Modelo, inválido só pode conter: letras, numeros e caracteres especiais.");

            RuleFor(carro => carro.Marca)
                .IsInEnum().WithMessage("Essa marca é inválida.");

            RuleFor(carro => carro.Cor)
                .IsInEnum().WithMessage("Essa cor é inválido.");

            RuleFor(carro => carro.ValorDoVeiculo)
                .GreaterThanOrEqualTo(0).WithMessage("O valor do veiculo deve ser maior que zero.");
        }
    }
}
