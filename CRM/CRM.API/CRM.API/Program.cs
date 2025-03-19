using CRM.API.Extensions.Configurations;
using RMB.Core.Logs.Extensions;
using RMB.Core.Logs.Lifecycle;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

#region Logging
builder.Logging.AddCustomLogging("DelaRiva");
#endregion

ServiceConfig.ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

MiddlewareConfig.ConfigureMiddlewares(app);

AppLifecycle.ConfigureApplicationLifetime(app);

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
