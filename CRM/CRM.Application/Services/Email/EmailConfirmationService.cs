using RMB.Abstractions.Infrastructure.Messages.Entities;
using RMB.Abstractions.Infrastructure.Messages.Interfaces;


namespace CRM.Application.Services.Email
{
    public class EmailConfirmationService
    {
        private readonly IMessageProducer _messageProducer;
        private readonly EmailTemplateBuilder _templateBuilder;

        public EmailConfirmationService(IMessageProducer messageProducer, EmailTemplateBuilder templateBuilder)
        {
            _messageProducer = messageProducer;
            _templateBuilder = templateBuilder;
        }

        public async Task SendAsync(string toEmail, Guid Id)
        {
            var message = new EmailConfirmationMessage
            {
                ToEmail = toEmail,
                Id = Id,
            };

            message.Body = _templateBuilder.GenerateConfirmationEmailBody(message);
            await _messageProducer.PublishEmailConfirmationAsync(message);
        }
    }

}
