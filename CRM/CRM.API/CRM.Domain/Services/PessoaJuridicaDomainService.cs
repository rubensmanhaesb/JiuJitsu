using CRM.Domain.Entities;
using CRM.Domain.Interfaces.Repositories;
using CRM.Domain.Interfaces.Services;
using CRM.Domain.Validations.PessoaJuridica;
using FluentValidation;
using RMB.Core.Domains;
using RMB.Core.Repositories;

namespace CRM.Domain.Services
{
    public class PessoaJuridicaDomainService : BaseDomain<PessoaJuridica>, IPessoaJuridicaDomainService 
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPessoaJuridicaRepository _pessoaJuridicaRepository;

        public PessoaJuridicaDomainService(IUnitOfWork unitOfWork ): this(unitOfWork.PessoaJuridicaRepository)
        {
            _unitOfWork = unitOfWork;
        }
        private PessoaJuridicaDomainService(IPessoaJuridicaRepository repository) : base((BaseRepository<PessoaJuridica>)repository) 
        {
            _pessoaJuridicaRepository = repository;
        }

        public override async Task<PessoaJuridica> AddAsync(PessoaJuridica entity, CancellationToken cancellationToken)
        {
            await (new PessoaJuridicaAddValidation(_unitOfWork)).ValidateAndThrowAsync(entity);
            return await base.AddAsync(entity, cancellationToken);
        }
        public override async Task<PessoaJuridica> UpdateAsync(PessoaJuridica entity, CancellationToken cancellationToken)
        {
            await (new PessoaJuridicaUpdateValidation(_unitOfWork)).ValidateAndThrowAsync(entity);
            return await base.UpdateAsync(entity, cancellationToken);
        }
        public override async Task<PessoaJuridica> DeleteAsync(PessoaJuridica entity, CancellationToken cancellationToken)
        {
            await (new PessoaJuridicaDeleteValidation(_unitOfWork)).ValidateAndThrowAsync(entity);
            return await base.DeleteAsync(entity, cancellationToken);
        }

    }
}
