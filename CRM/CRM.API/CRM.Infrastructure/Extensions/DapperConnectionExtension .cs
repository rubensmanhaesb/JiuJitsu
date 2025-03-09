using CRM.Infrastructure.Data.Context;
using Microsoft.Data.SqlClient;
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
    public static class DapperConnectionExtension
    {

        public static IServiceCollection AddDatabaseConnection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(provider =>
                new SqlConnection(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }

    }
}
