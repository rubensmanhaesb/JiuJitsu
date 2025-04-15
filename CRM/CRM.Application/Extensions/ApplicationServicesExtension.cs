using CRM.Application.Commands;
using CRM.Application.Dtos.PessoaJuridica;
using CRM.Application.Handlers.Notifications;
using CRM.Application.Interfaces;
using CRM.Application.Services;
using CRM.Application.Services.Email;
using CRM.Application.Settings;
using CRM.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RMB.Abstractions.Application;
using RMB.Abstractions.Infrastructure.Messages.Interfaces;


namespace CRM.Application.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

            });
           
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddTransient<IPessoaJuridicaApplicationService, PessoaJuridicaApplicationService>();

            #region Email
            services.Configure<EmailTemplateSettings>(configuration.GetSection("EmailTemplate"));
            services.AddScoped<EmailTemplateBuilder>();
            services.AddSingleton<MessageErrorHandler>();
            #endregion Email

            #region Scrutor - Decorator Pessoa Jurídica
            services.AddScoped<IBaseAddApplication<PessoaJuridicaCreateCommand, PessoaJuridicaDto>, PessoaJuridicaApplicationService>();
            services.AddScoped<IBaseUpdateApplication<PessoaJuridicaUpdateCommand, PessoaJuridicaDto>, PessoaJuridicaApplicationService>();

            services.Decorate<IBaseAddApplication<PessoaJuridicaCreateCommand, PessoaJuridicaDto>, PessoaJuridicaAddUpdateEmailDecorator>();
            services.Decorate<IBaseUpdateApplication<PessoaJuridicaUpdateCommand, PessoaJuridicaDto>, PessoaJuridicaAddUpdateEmailDecorator>();
            #endregion Scrutor - Decorator Pessoa Jurídica

            return services;
        }

    }
}
