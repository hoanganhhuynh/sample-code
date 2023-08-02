using System;
using Domain.Contracts;
using Domain.Services;
using Infrastructure;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TodoAPI.Extensions
{
    internal static class ServiceCollectionExtensions
	{
        internal static IServiceCollection AddDbContext(this IServiceCollection serviceCollection, WebApplicationBuilder builder)
            => serviceCollection.AddDbContext<TodoDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("TodoDatabase"),
                    // Retry on transient connection errors∂
                    opt =>
                    {
                        opt.EnableRetryOnFailure();
                    }
                );
            });

        internal static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient<ITodoRepository, TodoRepository>();
            return services;
        }

        internal static IServiceCollection RegisterService(this IServiceCollection services)
        {   
            services.AddTransient<ITodoService, TodoService>();
            return services;
        }
    }
}

