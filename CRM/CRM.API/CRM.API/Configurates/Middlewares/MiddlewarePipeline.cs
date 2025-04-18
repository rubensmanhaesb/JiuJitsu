﻿using CRM.API.Extensions;
using RMB.Core.Logs.Middleware;
using Scalar.AspNetCore;

namespace CRM.API.Configurates.Middlewares
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
            #endregion

            #region App Extensions
            app.UseCorsConfig(); //precisa ser chamado antes mapcontrollers
            #endregion App Extensions

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
        }
    }
}
