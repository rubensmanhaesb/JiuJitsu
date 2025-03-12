using MediatR;


namespace CRM.Application.Handlers.Notifications
{
    public class PessoaJuridicaNotificationHandler : INotificationHandler<PessoaJuridicaNotification>
    {
        public Task Handle(PessoaJuridicaNotification notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
