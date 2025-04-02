using CRM.Domain.Interfaces.Repositories;
using FluentValidation;
using RMB.Core.Validation.Helpers;
using Empresa = CRM.Domain.Entities.PessoaJuridica;

namespace CRM.Domain.Validations.PessoaJuridica
{
    public class PessoaJuridicaBaseValidation : AbstractValidator<Empresa>
    {
        private readonly IUnitOfWork _unitOfWork;

        public PessoaJuridicaBaseValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IRuleBuilderOptions<Empresa, string> ValidateRazaoSocial()
            => RuleFor(c => c.RazaoSocial)
                .NotEmpty().WithMessage("A razão social é obrigatória.")
                .Length(2, 100).WithMessage("A razão social deve ter entre {MinLength} e {MaxLength} caracteres.");

        public IRuleBuilderOptions<Empresa, string> ValidateNomeFantasia()
            => RuleFor(c => c.NomeFantasia)
                .NotEmpty().WithMessage("O nome fantasia é obrigatório.")
                .Length(2, 100).WithMessage("O nome fantasia deve ter entre {MinLength} e {MaxLength} caracteres.");
        
        public IRuleBuilderOptions<Empresa, string> ValidateEmail()
            => RuleFor(c => c.Email)
                .NotEmpty().WithMessage("O e-mail é obrigatório.")
                .EmailAddress().WithMessage("O e-mail informado não é válido.")
                .MustAsync((entity, _, token) => IsUniqueEmailAsync(entity.Id, entity.Email, token));
        
        public IRuleBuilderOptions<Empresa, string> ValidateCNPJ()
            => RuleFor(c => c.Cnpj)
                .NotEmpty().WithMessage("O CNPJ é obrigatório.")
                .Must(CNPJValidation.Validation).WithMessage("O CNPJ informado não é válido.")
                .MustAsync((entity, _, token) => IsUniqueCnpjAsync(entity.Id, entity.Cnpj, token))
                .WithMessage("O CNPJ informado já está cadastrado.");
        
        public IRuleBuilderOptions<Empresa, Guid> ValidateId()
            => RuleFor(c => c.Id)
                .NotEmpty().WithMessage("Id não informado.");

        public IRuleBuilderOptions<Empresa, Guid> ValidateIdIsUnique()
            => RuleFor(c => c.Id)
                .MustAsync(IsExistsIdAsync).WithMessage("Id informado não está cadastrado.");

        private async Task<bool> IsExistsIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var existente = await _unitOfWork.PessoaJuridicaRepository
                .GetByIdAsync(id, cancellationToken);
            
            return existente is not null;
        }

        private async Task<bool> IsUniqueCnpjAsync(Guid id, string cnpj, CancellationToken cancellationToken)
        {
            var existente = await _unitOfWork.PessoaJuridicaRepository
                .GetOneByAsync(p => p.Cnpj == cnpj && p.Id != id, cancellationToken);
            return existente is null;
        }

        private async Task<bool> IsUniqueEmailAsync(Guid id, string email, CancellationToken cancellationToken)
        {
            var existente = await _unitOfWork.PessoaJuridicaRepository
                .GetOneByAsync(p => p.Email == email && p.Id != id, cancellationToken);
            return existente is null;
        }
    }

}
