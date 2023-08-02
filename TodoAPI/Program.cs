
using TodoAPI;
using TodoAPI.Extensions;

await Startup
    .CreateBuilder(args)
    .RegisterDependencyServices(typeof(Startup).Assembly)
    .Build()
    .ConfigureWebApp()
    .RunAsync()
    .ConfigureAwait(false);

