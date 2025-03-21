using RMB.Core.Logs.Middleware;
using RMB.Core.Validation.Middleware;
using RMB.Responses.Middlewares.Controllers;
using Scalar.AspNetCore;

namespace CRM.API.Extensions
{
    public static class MiddlewarePipeline
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
            app.UseMiddleware<ValidationExceptionMiddleware>();
            #endregion

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
        }
    }
}
