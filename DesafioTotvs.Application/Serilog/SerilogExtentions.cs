using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace DesafioTotvs.Application.Serilog
{
    public static class SerilogExtentions
    {
        public static IServiceCollection ConfigureSerilog(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo
                .Console()
                .Enrich
                .FromLogContext()
                .MinimumLevel
                .Information()
                .CreateLogger();

            serviceCollection.AddSingleton(Log.Logger);

            return serviceCollection;
        }
    }
}