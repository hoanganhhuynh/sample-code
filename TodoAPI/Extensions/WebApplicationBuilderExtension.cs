
using System.Reflection;
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
                .AddAutoMapper(applicationAssembly)
                .AddSwaggerGen()
                .RegisterRepositories()
                .RegisterService()
                .AddControllers();
            return builder;
        }
    }
}

