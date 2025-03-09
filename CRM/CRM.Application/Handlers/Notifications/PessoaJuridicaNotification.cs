using CRM.Application.Dtos.PessoaJuridica;
using CRM.Domain.Entities;
using MediatR;
using RMB.Core.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Handlers.Notifications
{
    public class PessoaJuridicaNotification : INotification
    {
        public PessoaJuridicaDto? PessoaJuridicaDto { get; set; }
        public NotificationAction Action { get; set; }
    }
}
