using CRM.Infrastructure.Data.Extensions;
using CRM.Domain.Extensions;
using CRM.Application.Extensions;
using RMB.Responses.Middlewares.Controllers;
using CRM.Infrastructure.Storage.Extensions;
using CRM.Domain.MongoDB.Extensions;
using Scalar.AspNetCore;
using RMB.Responses.Extensions.Logs;
using RMB.Responses.Extensions;
using Serilog;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddRouting(config=> config.LowercaseUrls = true);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Services Extensions 
builder.Services.AddDataContext(builder.Configuration);
builder.Services.AddDomainServices();
builder.Services.AddApplicationServices();
builder.Services.AddMongoDb(builder.Configuration);
builder.Services.AddDomainMongoDb();
builder.Logging.AddCustomLogging("DelaRiva");
#endregion Services Extensions 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapScalarApiReference();
}

#region Middlewares
app.UseMiddleware<ResponseMiddleware>();
//app.UseMiddleware<ExceptionMiddleware>();
#endregion

Log.Information("Middlewares carregados!");


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();



app.Run();
