using AutoMapper;
using CRM.Application.Commands;
using CRM.Application.Dtos.PessoaJuridica;
using CRM.Domain.Entities;
using CRM.Domain.Interfaces.Services;
using MediatR;

namespace CRM.Application.Handlers.Requests
{
    public class PessoaJuridicaCreateRequestHandler : IRequestHandler<PessoaJuridicaCreateCommand, PessoaJuridicaDto>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IPessoaJuridicaDomainService _pessoaJuridicaDomainService;

        public PessoaJuridicaCreateRequestHandler(IMediator mediator, IMapper mapper, IPessoaJuridicaDomainService pessoaJuridicaDomainService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _pessoaJuridicaDomainService = pessoaJuridicaDomainService;
        }

        public async Task<PessoaJuridicaDto> Handle(PessoaJuridicaCreateCommand request, CancellationToken cancellationToken)
        {
            var pessoaJuridica = _mapper.Map<PessoaJuridica>(request);
            var pessoaJuridicaResponse =  await _pessoaJuridicaDomainService.AddAsync(pessoaJuridica);

            var pessoaJuridicaDto = _mapper.Map<PessoaJuridicaDto>(pessoaJuridicaResponse);

            return pessoaJuridicaDto;
        }
    }
}
