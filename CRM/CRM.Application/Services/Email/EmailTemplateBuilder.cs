using CRM.Application.Settings;
using Microsoft.Extensions.Options;
using RMB.Abstractions.Infrastructure.Messages.Entities;


namespace CRM.Application.Services.Email
{
    public  class EmailTemplateBuilder
    {
        private readonly EmailTemplateSettings _settings;

        public EmailTemplateBuilder(IOptionsMonitor<EmailTemplateSettings> options)
        {
            _settings = options.CurrentValue;
        }

        public string GenerateConfirmationEmailBody(EmailConfirmationMessage message)
        {
            var link = $"{_settings.ConfirmationLinkBaseUrl}";
            return @$"
            <div>
                <p>Olá{(!string.IsNullOrEmpty(message.ToName) ? $", {message.ToName}" : "")},</p>
                <p>Você se cadastrou no <strong>JiuJitsu App</strong> e precisamos confirmar o seu endereço de e-mail.</p>
                <p>Por favor, clique no link abaixo para confirmar seu cadastro:</p>
                <p>
                    <a href=""{link}"" target=""_blank"">
                        Confirmar meu e-mail
                    </a>
                </p>
                <p>Se você não realizou este cadastro, por favor ignore este e-mail.</p>
                <br/>
                <p>Equipe JiuJitsu App</p>
            </div>";
        }

    }
}
