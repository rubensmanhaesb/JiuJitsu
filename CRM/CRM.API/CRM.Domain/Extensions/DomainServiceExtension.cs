﻿using CRM.Domain.Interfaces.Services;
using CRM.Domain.Services;
using CRM.Domain.Validations.PessoaJuridica;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;


namespace CRM.Domain.Extensions
{
    public static class DomainServiceExtension
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddTransient<IPessoaJuridicaDomainService, PessoaJuridicaDomainService>();
            services.AddValidatorsFromAssembly(typeof(PessoaJuridicaBaseValidation).Assembly);

            return services;
        }
    }
}
