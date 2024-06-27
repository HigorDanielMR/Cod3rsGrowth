using FluentValidation;
using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Servicos.Validadores
{
    public class ValidacoesCarro : AbstractValidator<Carro>
    {
        public ValidacoesCarro()
        {
            var valorPadrao = 0;
            var limiteMinimoDeCaracteres = 2;
            var limiteMaximoDeCaracteres = 50;
            var regexParaLetrasNumerosECaracteresEspeciais = @"[\p{L}\p{N}\p{S}]";

            RuleFor(carro => carro.Modelo)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Campo modelo não preenchido.")
                .Length(limiteMinimoDeCaracteres, limiteMaximoDeCaracteres)
                .WithMessage("Modelo inválido, precisa ter no mínimo 2 caracteres e no maximo 50 caracteres.")
                .Matches(regexParaLetrasNumerosECaracteresEspeciais)
                .WithMessage("Modelo, inválido só pode conter: letras, numeros e caracteres especiais.");

            RuleFor(carro => carro.Marca)
                .IsInEnum()
                .WithMessage("Essa marca é inválida.");

            RuleFor(carro => carro.Cor)
                .IsInEnum()
                .WithMessage("Essa cor é inválido.");

            RuleFor(carro => carro.ValorDoVeiculo)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Campo valor do veiculo esta vazio.")
                .GreaterThanOrEqualTo(valorPadrao)
                .WithMessage("O valor do veiculo deve ser maior que zero.");
        }
    }
}
