using CRM.Domain.MongoDB.Interfaces.Services;
using CRM.Domain.MongoDB.Services;

using Microsoft.Extensions.DependencyInjection;

namespace CRM.Domain.MongoDB.Extensions
{
    public static class DomainMongoDBExtension
    {
        public static IServiceCollection AddDomainMongoDb(this IServiceCollection services)
        {

            services.AddTransient<IPessoaJuridicaMongoDBServices, PessoaJuridicaMongoDBServices>();

            return services;
        }
    }
}
