using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using RMB.Core.Logs.Middleware;
using RMB.Responses.Middlewares.Controllers;
using Scalar.AspNetCore;

namespace CRM.API.Extensions.Configurations
{
    public static class MiddlewareConfig
    {
        public static void ConfigureMiddlewares(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.MapScalarApiReference();
            }

            #region Middlewares
            app.UseMiddleware<CorrelationIdMiddleware>();
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseMiddleware<RequestResponseLoggingMiddleware>();
            app.UseMiddleware<ResponseMiddleware>();
            #endregion

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
        }
    }
}
