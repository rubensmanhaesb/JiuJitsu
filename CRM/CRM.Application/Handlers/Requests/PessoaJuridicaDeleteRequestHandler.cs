using AutoMapper;
using CRM.Application.Commands;
using CRM.Application.Dtos.PessoaJuridica;
using CRM.Domain.Entities;
using CRM.Domain.Interfaces.Services;
using MediatR;


namespace CRM.Application.Handlers.Requests
{
    public class PessoaJuridicaDeleteRequestHandler : IRequestHandler<PessoaJuridicaDeleteCommand, PessoaJuridicaDto>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IPessoaJuridicaDomainService _pessoaJuridicaDomainService;

        public PessoaJuridicaDeleteRequestHandler(IMediator mediator, IMapper mapper, IPessoaJuridicaDomainService pessoaJuridicaDomainService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _pessoaJuridicaDomainService = pessoaJuridicaDomainService;
        }

        public async Task<PessoaJuridicaDto> Handle(PessoaJuridicaDeleteCommand request, CancellationToken cancellationToken)
        {
            var pessoaJuridica = _mapper.Map<PessoaJuridica>(request);

            var pessoaJuridicaResponse = await _pessoaJuridicaDomainService.DeleteAsync(pessoaJuridica);

            var pessoaJuridicaDto = _mapper.Map<PessoaJuridicaDto>(pessoaJuridicaResponse);

            return pessoaJuridicaDto;

        }
    }
}
