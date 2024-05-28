using FluentValidation;
using Cod3rsGrowth.Dominio.Entities;
using System.Text.RegularExpressions;

namespace Cod3rsGrowth.Servicos.Validadores
{
    public class ValidacoesVenda : AbstractValidator<Venda>
    {
        public ValidacoesVenda()
        {
            RuleFor(venda => venda.Nome)
                .NotEmpty().WithMessage("Campo nome não preenchido.")
                .Length(3, 50).WithMessage("O nome deve ter entre 2 a 50 caracteres.")
                .Matches("^[a-zA-ZÀ-ú ]+$").WithMessage("O nome não pode conter números.");

            RuleFor(venda => venda.Cpf)
                .NotEmpty().WithMessage("Campo cpf não preenchido")
                .Must(ValidarCpf).WithMessage("Formato CPF inválido.");

            RuleFor(venda => venda.Email)
                .NotEmpty().WithMessage("Campo e-mail não preenchido.")
                .EmailAddress().WithMessage("Formato de e-mail inválido.");

            RuleFor(venda => venda.Telefone)
                .NotEmpty().WithMessage("Campo telefone não preenchido.")
                .Must(ValidarTelefone).WithMessage("Formato de telefone inválido.");

            RuleForEach(venda => venda.ItensVendidos)
                .SetValidator(new ValidacoesCarro());
        }

        private bool ValidarCpf(string cpf)
        {
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            if (cpf.Distinct().Count() == 1)
            {
                return false;
            }

            if (cpf.Length != 11)
            {
                return false;
            }

            if (new string(cpf[0], cpf.Length) == cpf)
            {
                return false;
            }
            return cpf.EndsWith(cpf);
        }
        private bool ValidarTelefone(string telefone)
        {
            var regex = new Regex(@"\(?([0-9]{2})\)?[-. ]?([0-9]{5})[-. ]?([0-9]{4})");

            return regex.IsMatch(telefone);
        }
    }
}
