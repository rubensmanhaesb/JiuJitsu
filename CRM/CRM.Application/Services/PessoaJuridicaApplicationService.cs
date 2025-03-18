using AutoMapper;
using CRM.Application.Commands;
using CRM.Application.Dtos.PessoaJuridica;
using CRM.Application.Interfaces;
using CRM.Domain.Entities;
using CRM.Domain.Interfaces.Services;
using MediatR;
using RMB.Core.UseCases;
using RMB.Core.Domains;

namespace CRM.Application.Services
{
    public class PessoaJuridicaApplicationService : BaseMediatorApplication<PessoaJuridicaCreateCommand, PessoaJuridicaUpdateCommand, PessoaJuridicaDeleteCommand, PessoaJuridicaDto, PessoaJuridica>,
        IPessoaJuridicaApplicationService
    {
        public PessoaJuridicaApplicationService(IPessoaJuridicaDomainService  baseDomain, IMediator mediator, IMapper mapper) : base((BaseDomain<PessoaJuridica>) baseDomain, mediator, mapper)
        {
        }


    }

}
    
