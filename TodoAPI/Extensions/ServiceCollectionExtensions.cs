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
using Microsoft.Net.Http.Headers;

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
            services.AddScoped<ITodoRepository, TodoRepository>();
            services.AddScoped<IPeopleRepository, PeopleRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            return services;
        }

        internal static IServiceCollection RegisterService(this IServiceCollection services)
        {   
            services.AddTransient<ITodoService, TodoService>();
            services.AddTransient<IPeopleService, PeopleService>();
            services.AddTransient<ICountryService, CountryService>();
            return services;
        }

        internal static IServiceCollection AddCorsPolicies(this IServiceCollection serviceCollection)
        => serviceCollection.AddCors(options => options.AddDefaultPolicy(
            policy => {
                
                policy
                    //.WithOrigins("https://localhost:5001/", "https://localhost:7200/")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true) // allow any origin
                    .AllowCredentials();
            })
        );
    }
}

