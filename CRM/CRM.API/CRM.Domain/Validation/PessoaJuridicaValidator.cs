using CRM.Domain.Entities;
using FluentValidation;
using RMB.Core.Validation;


namespace CRM.Domain.Validators
{
    public class PessoaJuridicaValidator : AbstractValidator<PessoaJuridica>
    {
        public PessoaJuridicaValidator()
        {
            ConfigureRules();
        }

        private void ConfigureRules()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("O id é obrigatório.")
                .Must(id => id != Guid.Empty).WithMessage("O id não pode ser igual ao valor padrão.");

            RuleFor(c => c.RazaoSocial)
                .NotEmpty().WithMessage("A razão social é obrigatória.")
                .Length(2, 100).WithMessage("A razão social deve ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(c => c.NomeFantasia)
                .NotEmpty().WithMessage("O nome fantasia é obrigatório.")
                .Length(2, 100).WithMessage("O nome fantasia deve ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("O e-mail é obrigatório.")
                .EmailAddress().WithMessage("O e-mail informado não é válido.");

            RuleFor(c => c.Cnpj)
                .NotEmpty().WithMessage("O CNPJ é obrigatório.")
                .Must(CNPJValidation.ValidarCNPJ).WithMessage("O CNPJ informado não é válido.");
        }

    }
}
