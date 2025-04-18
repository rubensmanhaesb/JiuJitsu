﻿using CRM.Application.Dtos.PessoaJuridica;
using MediatR;
using RMB.Abstractions.Handlers.Notifications;

namespace CRM.Application.Handlers.Notifications
{
    public class PessoaJuridicaNotification : INotification
    {
        public PessoaJuridicaDto? PessoaJuridicaDto { get; set; }
        public NotificationAction Action { get; set; }
    }
}
