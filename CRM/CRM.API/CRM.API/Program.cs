using CRM.Infrastructure.Data.Extensions;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddRouting(config=> config.LowercaseUrls = true);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Services Extensions 
builder.Services.AddDataContext(builder.Configuration);
#endregion Services Extensions 


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
