using CRM.Application.Commands;
using CRM.Application.Dtos.PessoaJuridica;
using CRM.Application.Services.Email;
using CRM.Domain.Entities;
using RMB.Abstractions.Application;
using RMB.Abstractions.Infrastructure.Messages.Entities;
using RMB.Abstractions.Infrastructure.Messages.Interfaces;

namespace CRM.Application.Services
{
    public class PessoaJuridicaAddUpdateEmailDecorator :
        IBaseAddApplication<PessoaJuridicaCreateCommand, PessoaJuridicaDto>,
        IBaseUpdateApplication<PessoaJuridicaUpdateCommand, PessoaJuridicaDto>
    {
        private readonly IBaseAddApplication<PessoaJuridicaCreateCommand, PessoaJuridicaDto> _addInner;
        private readonly IBaseUpdateApplication<PessoaJuridicaUpdateCommand, PessoaJuridicaDto> _updateInner;
        private readonly IBaseQueryApplication<PessoaJuridica, PessoaJuridicaDto> _query;
        private readonly EmailTemplateBuilder _templateBuilder;
        private readonly IMessageProducer? _email;

        public PessoaJuridicaAddUpdateEmailDecorator(
            IBaseAddApplication<PessoaJuridicaCreateCommand, PessoaJuridicaDto> addInner,
            IBaseUpdateApplication<PessoaJuridicaUpdateCommand, PessoaJuridicaDto> updateInner,
            IBaseQueryApplication<PessoaJuridica, PessoaJuridicaDto> query,
            EmailTemplateBuilder templateBuilder,
            IMessageProducer? email)
        {
            _addInner = addInner;
            _updateInner = updateInner;
            _templateBuilder = templateBuilder;
            _email = email;
            _query = query;
        }

        public async Task<PessoaJuridicaDto> AddAsync(PessoaJuridicaCreateCommand command, CancellationToken cancellationToken)
        {
            var result = await _addInner.AddAsync(command, cancellationToken);

            var email = new EmailConfirmationMessage
            {
                Id = result.Id,
                ToEmail = result.Email,
                ToName = result.NomeFantasia,
                Subject = "Confirmação de Cadastro",
                Body = _templateBuilder.GenerateConfirmationEmailBody(new EmailConfirmationMessage
                {
                    ToEmail = result.Email,
                    ToName = result.NomeFantasia,
                })
            };

            await _email!.PublishEmailConfirmationAsync(email);


            return result;
        }

        public async Task<PessoaJuridicaDto> UpdateAsync(PessoaJuridicaUpdateCommand command, CancellationToken cancellationToken)
        {

            var oldEntity = await _query.GetByIdAsync((Guid) command.Id, cancellationToken);

            var result = await _updateInner.UpdateAsync(command, cancellationToken);

            if (!string.Equals(result.Email, oldEntity!.Email, StringComparison.OrdinalIgnoreCase))
            {
                var token = Guid.NewGuid().ToString();

                var email = new EmailConfirmationMessage
                {
                    Id = result.Id,
                    ToEmail = result.Email,
                    ToName = result.NomeFantasia,
                    Subject = "Confirmação de Alteração de E-mail",
                    Body = _templateBuilder.GenerateConfirmationEmailBody(new EmailConfirmationMessage
                    {
                        ToEmail = result.Email,
                        ToName = result.NomeFantasia,
                    })
                };

                await _email!.PublishEmailConfirmationAsync(email);
            }

                return result;
        }
    }

}
