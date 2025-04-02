using CRM.API.Configurates.Middlewares;
using CRM.API.Configurates.Services;
using RMB.Core.Controllers;
using RMB.Core.Logs.Extensions;
using RMB.Core.Logs.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

#region Logging
builder.Logging.AddCustomLogging("DelaRiva");
#endregion



builder.Services.AddControllers(options =>
    {
        options.Filters.Add<AutoNoContentAttribute>(); // Aplica a TODAS as controllers  
    });

builder.Services.AddRouting(config => config.LowercaseUrls = true);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

DependencyInjection.ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();



MiddlewarePipeline.ConfigureMiddlewares(app);
AppLifecycleService.ConfigureApplicationLifetime(app);



try
{
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Aplicação CRM.API parou devido a uma exceção inesperada!");
}
finally
{
    Log.CloseAndFlush();
}
