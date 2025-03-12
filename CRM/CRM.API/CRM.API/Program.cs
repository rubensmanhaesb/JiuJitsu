using CRM.Infrastructure.Data.Extensions;
using CRM.Domain.Extensions;
using CRM.Application.Extensions;
using RMB.Responses.Middlewares.Controllers;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddRouting(config=> config.LowercaseUrls = true);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Services Extensions 
builder.Services.AddDataContext(builder.Configuration);
builder.Services.AddDomainServices();
builder.Services.AddApplicationServices();
#endregion Services Extensions 


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region Middlewares
app.UseMiddleware<ResponseMiddleware>();
#endregion

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
