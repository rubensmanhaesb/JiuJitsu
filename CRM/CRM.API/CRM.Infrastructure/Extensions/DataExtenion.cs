using CRM.Domain.Interfaces.Repositories;
using CRM.Infrastructure.Data.Context;
using CRM.Infrastructure.Repositories;
//using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Infrastructure.Data.Extensions
{
    public static  class DataExtenion
    {
        public static IServiceCollection AddDataContext(this IServiceCollection services, IConfiguration configuration)
        {
            //para o dapper
          //  services.AddSingleton(provider =>
          //      new SqlConnection(configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContextFactory<DataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
