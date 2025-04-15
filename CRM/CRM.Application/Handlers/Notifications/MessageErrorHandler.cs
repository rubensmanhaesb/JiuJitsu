using Microsoft.Extensions.Logging;
using RMB.Abstractions.Infrastructure.Messages.Entities;
using RMB.Abstractions.Infrastructure.Messages.Exceptions;
using RMB.Abstractions.Infrastructure.Messages.Interfaces;

namespace CRM.Application.Handlers.Notifications
{
    /// <summary>
    /// Handles background message processing errors by subscribing to the OnError event.
    /// </summary>
    public class MessageErrorHandler
    {
        private readonly ILogger<MessageErrorHandler> _logger;

        public MessageErrorHandler(
            ILogger<MessageErrorHandler> logger,
            IMessageBackgroundEventPublisher publisher)
        {
            _logger = logger;

            // Subscribe to the OnError event
            publisher.OnError += HandleError;
        }

        private void HandleError(object? sender, Exception exception)
        {
            MessageFailure? messageFailure = null;
            EmailConfirmationMessage? emailConfirmationMessage = null;

            if (exception is MessagesException msgEx )
            {
                emailConfirmationMessage = msgEx.EmailConfirmationMessage;
                messageFailure = msgEx.MessageFailure;
            }

            _logger.LogError("Erro no processamento de mensagem. ");

            // Aqui você pode adicionar mais ações: salvar no banco, enviar para fila de erro, etc.
        }
    }
}
