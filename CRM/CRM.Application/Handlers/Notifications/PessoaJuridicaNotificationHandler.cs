using AutoMapper;
using CRM.Domain.MongoDB.Collection.Logs;
using CRM.Domain.MongoDB.Interfaces.Services;
using MediatR;
using RMB.Abstractions.Notifications;


namespace CRM.Application.Handlers.Notifications
{
    public class PessoaJuridicaNotificationHandler : INotificationHandler<PessoaJuridicaNotification>
    {
        private readonly IPessoaJuridicaMongoDBServices          _pessoaJuridicaMongoDBServices;
        private readonly IMapper _mapper;

        public PessoaJuridicaNotificationHandler(IPessoaJuridicaMongoDBServices pessoaJuridicaMongoDBServices, IMapper mapper)
        {
            _pessoaJuridicaMongoDBServices = pessoaJuridicaMongoDBServices;
            _mapper = mapper;
        }

        public async Task Handle(PessoaJuridicaNotification notification, CancellationToken cancellationToken)
        {
            var pessoaJuridicaCollection = _mapper.Map<PessoaJuridicaCollection>(notification.PessoaJuridicaDto);

            switch (notification.Action)
            {
                case NotificationAction.Created:
                    await _pessoaJuridicaMongoDBServices.InsertAsync(pessoaJuridicaCollection);
                    break;
                case NotificationAction.Updated:
                    await _pessoaJuridicaMongoDBServices.UpdateAsync(pessoaJuridicaCollection);
                    break;
                case NotificationAction.Deleted:
                    await _pessoaJuridicaMongoDBServices.DeleteAsync(pessoaJuridicaCollection.Id);
                    break;
            }
            
        }
    }
}
