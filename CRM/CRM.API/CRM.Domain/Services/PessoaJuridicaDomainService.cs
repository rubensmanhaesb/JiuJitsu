using CRM.Domain.Entities;
using CRM.Domain.Interfaces.Repositories;
using CRM.Domain.Interfaces.Services;
using FluentValidation;
using RMB.Abstractions.Domains;
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
        private readonly IValidator<PessoaJuridica> _validator;

        public PessoaJuridicaDomainService(
            IUnitOfWork unitOfWork, 
            IValidator<PessoaJuridica> validator
            ): this(unitOfWork.PessoaJuridicaRepository!)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }
        private PessoaJuridicaDomainService(IPessoaJuridicaRepository repository) : base((BaseRepository<PessoaJuridica>)repository) 
        {
            _pessoaJuridicaRepository = repository;
        }
    }
}
