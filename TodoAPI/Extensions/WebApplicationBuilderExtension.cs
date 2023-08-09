
using System.Reflection;
using Domain.MappingProfile;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace TodoAPI.Extensions
{
    internal static class WebApplicationBuilderExtension
	{
        internal static WebApplicationBuilder RegisterDependencyServices(this WebApplicationBuilder builder, Assembly applicationAssembly)
        {
            var services = builder.Services;
            services
                .AddDbContext(builder)
                .AddAutoMapper(typeof(TodoProfile))
                .AddSwaggerGen()
                .RegisterRepositories()
                .RegisterService()
                .AddCorsPolicies()
                .AddControllers();
            return builder;
        }
    }
}

