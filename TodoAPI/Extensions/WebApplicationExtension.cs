using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TodoAPI.Middleware;

namespace TodoAPI.Extensions;

internal static class WebApplicationExtension
{
    internal static WebApplication ConfigureWebApp(this WebApplication web)
    {
        web
            .UseMiddlewares()
            .UseWithEnrichingCors();
        return web;
    }
    
    private static IApplicationBuilder UseMiddlewares(this IApplicationBuilder applicationBuilder)
        => applicationBuilder
            .UseMiddleware<ApiKeyMiddleware>()
            .UseMiddleware<ExceptionHandlerMiddleware>()
            .UseSwagger()
            .UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API");
                c.RoutePrefix = string.Empty; //Configures swagger to load at application root
            })
            .UseHttpsRedirection()
            .UseRouting()
            .UseAuthorization()
            .UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

    private static WebApplication UseWithEnrichingCors(this IApplicationBuilder applicationBuilder)
    {
        applicationBuilder.UseCors();

        return (WebApplication)applicationBuilder;
    }
}