using FluentValidation;
using System.Text.RegularExpressions;
using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;

namespace Cod3rsGrowth.Servicos.Validadores
{
    public class ValidacoesVenda : AbstractValidator<Venda>
    {   
        private readonly IRepositorioVenda _repositorio;
        public ValidacoesVenda(IRepositorioVenda repositorio)
        {
            _repositorio = repositorio;

            RuleFor(venda => venda.Nome)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Campo nome não preenchido.")
                .MaximumLength(100).WithMessage("O nome deve ter no máximo 100 caracteres.")
                .Matches("^[a-zA-ZÀ-ú ]+$").WithMessage("O nome deve conter apenas letras.");

            RuleFor(venda => venda.Cpf)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Campo cpf não preenchido.")
                .Must(ValidarCpf).WithMessage("Formato CPF inválido.");

            RuleFor(venda => venda.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Campo e-mail não preenchido.")
                .EmailAddress().WithMessage("Formato de e-mail inválido.");

            RuleFor(venda => venda.Telefone)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Campo telefone não preenchido.")
                .Must(ValidarTelefone).WithMessage("Formato de telefone inválido.");

            RuleFor(venda => venda)
                .Must(ValidaDataDeComprarCriar).WithMessage("Data de compra inválida.");

            RuleSet("Editar", () =>
            {
                RuleFor(venda => venda)
                    .Must(ValidarDataDeCompra)
                    .WithMessage("Uma venda concluida não pode ter a data alterada.");
            });
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

        private bool ValidaDataDeComprarCriar(Venda venda)
        {
            return venda.DataDeCompra <= DateTime.Now ? true : false;
        }

        private bool ValidarDataDeCompra(Venda venda)
        {
            var vendaDobanco = _repositorio.ObterPorId(venda.Id);
            return venda.DataDeCompra == vendaDobanco.DataDeCompra ? true : false;
        }
    }
}
