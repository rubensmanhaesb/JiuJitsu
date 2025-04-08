using AutoMapper;
using CRM.Application.Commands;
using CRM.Application.Dtos.PessoaJuridica;
using CRM.Application.Handlers.Notifications;
using CRM.Domain.Entities;
using CRM.Domain.Interfaces.Services;
using MediatR;
using RMB.Abstractions.Handlers.Notifications;

namespace CRM.Application.Handlers.Requests
{
    public class PessoaJuridicaUpdateRequestHandler : IRequestHandler<PessoaJuridicaUpdateCommand, PessoaJuridicaDto>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IPessoaJuridicaDomainService _pessoaJuridicaDomainService;

        public PessoaJuridicaUpdateRequestHandler(IMediator mediator, IMapper mapper, IPessoaJuridicaDomainService pessoaJuridicaDomainService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _pessoaJuridicaDomainService = pessoaJuridicaDomainService;
        }

        public async Task<PessoaJuridicaDto> Handle(PessoaJuridicaUpdateCommand request, CancellationToken cancellationToken)
        {
            var pessoaJuridica = _mapper.Map<PessoaJuridica>(request);

            var pessoaJuridicaResponse = await _pessoaJuridicaDomainService.UpdateAsync(pessoaJuridica, cancellationToken);

            var pessoaJuridicaDto = _mapper.Map<PessoaJuridicaDto>(pessoaJuridicaResponse);

            await _mediator.Publish(new PessoaJuridicaNotification
            {
                PessoaJuridicaDto = pessoaJuridicaDto,
                Action = NotificationAction.Updated
            }, cancellationToken);

            return pessoaJuridicaDto;
        }
    }
}
