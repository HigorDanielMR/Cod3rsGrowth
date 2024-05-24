using Cod3rsGrowth.Dominio.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Servicos.Validadores
{
    public class ValidacoesVenda : AbstractValidator<Venda>
    {
        public ValidacoesVenda()
        {
            RuleFor(venda => venda.Nome)
                .NotNull().WithMessage("Campo nome não preenchido.")
                .NotEmpty().WithMessage("Campo nome não preenchido.")
                .Length(3, 50).WithMessage("O nome deve ter entre 2 a 50 caracteres.")
                .Matches("^[a-zA-ZÀ-ú ]+$").WithMessage("O nome não pode conter números.");

            RuleFor(venda => venda.Cpf)
                .NotNull().WithMessage("Campo cpf não preenchido")
                .NotEmpty().WithMessage("Campo cpf não preenchido");

            RuleFor(venda => venda.Email)
                .NotNull().WithMessage("Campo e-mail não preenchido.")
                .NotEmpty().WithMessage("Campo e-mail não preenchido.")
                .EmailAddress().WithMessage("Formato de e-mail inválido.");

            RuleFor(venda => venda.Telefone)
                .NotNull().WithMessage("Campo telefone não preenchido.")
                .NotEmpty().WithMessage("Campo telefone não preenchido.");

            RuleForEach(venda => venda.ItensVendidos)
                .SetValidator(new ValidacoesCarro());
        }
    }
}
