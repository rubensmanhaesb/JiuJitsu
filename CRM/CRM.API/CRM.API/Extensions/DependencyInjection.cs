using CRM.Infrastructure.Data.Extensions;
using CRM.Domain.Extensions;
using CRM.Application.Extensions;
using CRM.Infrastructure.Storage.Extensions;
using CRM.Domain.MongoDB.Extensions;
using RMB.Core.Extensions;

namespace CRM.API.Extensions
{
    public static class DependencyInjection
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddRouting(config => config.LowercaseUrls = true);
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            #region Services Extensions 
            services.AddCoreExtensions(configuration);
            services.AddDataContext(configuration);
            services.AddDomainServices();
            services.AddApplicationServices();
            services.AddMongoDb(configuration);
            services.AddDomainMongoDb();
            services.AddCorsConfig(configuration);
            #endregion 

        }
    }
}
