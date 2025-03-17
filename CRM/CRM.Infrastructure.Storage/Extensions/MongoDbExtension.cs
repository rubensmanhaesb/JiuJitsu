using CRM.Domain.MongoDB.Interfaces.Persistences;
using CRM.Infrastructure.Storage.Context;
using CRM.Infrastructure.Storage.Persistence;
using CRM.Infrastructure.Storage.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;


namespace CRM.Infrastructure.Storage.Extensions
{
    public static class MongoDBExtension
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services, IConfiguration configuration)
        {
            var mongodbSettings = new MongoDBSettings();

            //ler as configurações do /appsettings.json
            new ConfigureFromConfigurationOptions<MongoDBSettings>
                (configuration.GetSection("MongoDB"))
                .Configure(mongodbSettings);

            //registrando as configurações
            services.AddSingleton(mongodbSettings);

            services.AddSingleton<IMongoDBContext, MongoDBContext>();
            services.AddTransient<IPessoaJuridicaPersistence, PessoaJuridicaPersistence>();

            return services;
        }
    }
}
