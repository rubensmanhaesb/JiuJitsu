using AutoMapper;
using CRM.Application.Commands;
using CRM.Application.Dtos.PessoaJuridica;
using CRM.Application.Interfaces;
using CRM.Domain.Entities;
using CRM.Domain.Interfaces.Services;
using MediatR;
using RMB.Core.Application;
using RMB.Core.Domains;

namespace CRM.Application.Services
{
    /*
    public class PessoaJuridicaApplicationService : IPessoaJuridicaApplicationService
    {
        private readonly IPessoaJuridicaDomainService _pessoaJuridicaDomainService;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PessoaJuridicaApplicationService(IPessoaJuridicaDomainService pessoaJuridicaDomainService, IMediator mediator, IMapper mapper)
        {
            _pessoaJuridicaDomainService = pessoaJuridicaDomainService;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<PessoaJuridicaDto> CreateAsync(PessoaJuridicaCreateCommand command)
            => await _mediator.Send(command);
        

        public async Task<PessoaJuridicaDto> UpdateAsync(PessoaJuridicaUpdateCommand command)
            => await _mediator.Send(command);
        

        public async Task<PessoaJuridicaDto> DeleteAsync(PessoaJuridicaDeleteCommand command)
            => await _mediator.Send(command);

        public async Task<List<PessoaJuridicaDto>?> GetAllAsync()
        {
            var lista = _pessoaJuridicaDomainService.GetAllAsync().Result;
            var result = _mapper.Map<List<PessoaJuridicaDto>>(lista);

            return result;
        }

        public async Task<PessoaJuridicaDto?> GetByIdAsync(Guid id)
        {
            var pessoaJuridicaDto = await _pessoaJuridicaDomainService.GetByIdAsync(id);
            var result = _mapper.Map<PessoaJuridicaDto>(pessoaJuridicaDto);

            return result;
        }
        
    }
    */
    public class PessoaJuridicaApplicationService : BaseMediatorApplication<PessoaJuridicaCreateCommand, PessoaJuridicaUpdateCommand, PessoaJuridicaDeleteCommand, PessoaJuridicaDto, PessoaJuridica>,
        IPessoaJuridicaApplicationService
    {
        public PessoaJuridicaApplicationService(IPessoaJuridicaDomainService  baseDomain, IMediator mediator, IMapper mapper) : base((BaseDomain<PessoaJuridica>) baseDomain, mediator, mapper)
        {
        }


    }

}
    
