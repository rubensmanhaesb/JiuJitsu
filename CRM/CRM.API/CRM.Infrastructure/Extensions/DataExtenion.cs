using CRM.Domain.Interfaces.Repositories;
using CRM.Infrastructure.Data.Context;
using CRM.Infrastructure.Repositories;
//using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CRM.Infrastructure.Data.Extensions
{
    public static  class DataExtenion
    {
        public static IServiceCollection AddDataContext(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContextFactory<DataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IDbContextFactory<DbContext>, DbContextFactoryAdapter>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
