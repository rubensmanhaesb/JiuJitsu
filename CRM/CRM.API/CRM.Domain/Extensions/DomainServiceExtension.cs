using CRM.Domain.Entities;
using CRM.Domain.Interfaces.Services;
using CRM.Domain.Services;
using CRM.Domain.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;


namespace CRM.Domain.Extensions
{
    public static class DomainServiceExtension
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddTransient<IPessoaJuridicaDomainService, PessoaJuridicaDomainService>();
            services.AddTransient<IValidator<PessoaJuridica>, PessoaJuridicaValidator>();

            return services;
        }
    }
}
