using CRM.Application.Handlers.Notifications;
using CRM.Application.Interfaces;
using CRM.Application.Services;
using Microsoft.Extensions.DependencyInjection;


namespace CRM.Application.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

            });
           
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddTransient<IPessoaJuridicaApplicationService, PessoaJuridicaApplicationService>();
            


            return services;
        }

    }
}
