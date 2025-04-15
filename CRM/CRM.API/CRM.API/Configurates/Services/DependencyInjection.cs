using CRM.Infrastructure.Data.Extensions;
using CRM.Domain.Extensions;
using CRM.Application.Extensions;
using CRM.Infrastructure.Storage.Extensions;
using CRM.Domain.MongoDB.Extensions;
using RMB.Core.Extensions;
using CRM.API.Extensions;
using RMB.Infrastructure.Messages.Extensions;

namespace CRM.API.Configurates.Services
{
    public static class DependencyInjection
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            #region Services Extensions 
            services.AddCoreExtensions(configuration);
            services.AddDataContext(configuration);
            services.AddDomainServices();
            services.AddApplicationServices(configuration);
            services.AddMongoDb(configuration);
            services.AddDomainMongoDb();
            services.AddCorsConfig(configuration);
            services.AddMailMessages();
            #endregion 

        }
    }
}
