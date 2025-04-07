using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
using System.IO;

namespace CRM.Infrastructure.Data.Context
{
    /// <summary>
    /// verificar se pode ser retirada do fonte
    /// </summary>
    public class DataContextFactory //: IDesignTimeDbContextFactory<DataContext>
    {
        public void CreateDbContext(string[] args)
        //public DataContext CreateDbContext(string[] args)

        {
            /*//Debugger.Launch(); //faz o debug na migration
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
            var basePath = Directory.GetCurrentDirectory();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("A ConnectionString não foi carregada corretamente.");
            }

            optionsBuilder.UseSqlServer(connectionString);
            */
            //return new DataContext(optionsBuilder.Options);
            
        }
    }
}
