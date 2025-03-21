using CRM.Domain.Entities;
using CRM.Domain.Interfaces.Repositories;
using CRM.Domain.Interfaces.Services;
using CRM.Domain.Validation.PessoaJuridica;
using FluentValidation;
using RMB.Abstractions.Domains;
using RMB.Abstractions.Entities;
using RMB.Core.Domains;
using RMB.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public override async Task<PessoaJuridica> AddAsync(PessoaJuridica entity)
        {
            await (new PessoaJuridicaAddValidation(_unitOfWork)).ValidateAndThrowAsync(entity);
            return await base.AddAsync(entity);
        }
        public override async Task<PessoaJuridica> UpdateAsync(PessoaJuridica entity)
        {
            await (new PessoaJuridicaUpdateValidation(_unitOfWork)).ValidateAndThrowAsync(entity);
            return await base.UpdateAsync(entity);
        }
        public override async Task<PessoaJuridica> DeleteAsync(PessoaJuridica entity)
        {
            await (new PessoaJuridicaDeleteValidation(_unitOfWork)).ValidateAndThrowAsync(entity);
            return await base.DeleteAsync(entity);
        }

    }
}
