using RMB.Abstractions.Infrastructure.Messages.Entities;
using RMB.Abstractions.Infrastructure.Messages.Interfaces;


namespace CRM.Application.Handlers.Notifications
{
    public class MessageSuccessfulHandler
    {
        public MessageSuccessfulHandler( IMessageSuccessEventPublisher messageSuccessEventPublisher)
        {
            messageSuccessEventPublisher.OnSuccess += HandleSuccess;
        }

        private void HandleSuccess(object? sender, EmailConfirmationMessage emailConfirmationMessage)
        {
            // Aqui você pode adicionar mais ações: salvar no banco, enviar para fila de sucesso, etc.
            // Exemplo: Log.Information($"Message with ID {messageId} processed successfully.");
        }
    }
}
