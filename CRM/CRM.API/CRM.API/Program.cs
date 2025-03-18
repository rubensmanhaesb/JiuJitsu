using CRM.Infrastructure.Data.Extensions;
using CRM.Domain.Extensions;
using CRM.Application.Extensions;
using CRM.Infrastructure.Storage.Extensions;
using CRM.Domain.MongoDB.Extensions;
using Scalar.AspNetCore;
using Serilog;

using RMB.Responses.Middlewares.Controllers;
using RMB.Core.Extensions;
using RMB.Core.Logs.Extensions;
using RMB.Core.Logs.Middleware;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddRouting(config=> config.LowercaseUrls = true);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Services Extensions 
builder.Services.AddCoreExtensions();
builder.Services.AddDataContext(builder.Configuration);
builder.Services.AddDomainServices();
builder.Services.AddApplicationServices();
builder.Services.AddMongoDb(builder.Configuration);
builder.Services.AddDomainMongoDb();
#endregion Services Extensions 

#region Logging
builder.Logging.AddCustomLogging("DelaRiva");
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapScalarApiReference();
}

#region Middlewares
app.UseMiddleware<CorrelationIdMiddleware>();
app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<ResponseMiddleware>();
//app.UseMiddleware<ExceptionMiddleware>();
#endregion

Log.Information("Middlewares carregados!");


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();



app.Run();
