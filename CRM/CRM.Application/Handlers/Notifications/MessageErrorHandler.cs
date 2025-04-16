using RMB.Abstractions.Infrastructure.Messages.Entities;
using RMB.Abstractions.Infrastructure.Messages.Exceptions;
using RMB.Abstractions.Infrastructure.Messages.Interfaces;
using Serilog;

namespace CRM.Application.Handlers.Notifications
{
    /// <summary>
    /// Handles background message processing errors by subscribing to the OnError event.
    /// </summary>
    public class MessageErrorHandler
    {

        public MessageErrorHandler(IMessageErrorEventPublisher messageErrorEventPublisher)
        {

            messageErrorEventPublisher.OnError += HandleError;
        }

        private void HandleError(object? sender, Exception exception)
        {
            MessageFailure? messageFailure = null;
            EmailConfirmationMessage? emailConfirmationMessage = null;

            if (exception is MessagesException msgEx )
            {
                emailConfirmationMessage = msgEx.EmailConfirmationMessage;
                messageFailure = msgEx.MessageFailure;
                Log.Error(msgEx.MessageFailure.OriginalFailureMessage);
            }
            else
                Log.Error(exception.Message);

            // Aqui você pode adicionar mais ações: salvar no banco, enviar para fila de erro, etc.
        }
    }
}
