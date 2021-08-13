using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace DesafioTotvs.Api.Extentions
{
    public static class ApiExtentions
    {
        public static IServiceCollection ConfigureSwaggerGen(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "DesafioTotvs.Api", Version = "v1" });
            });

            return serviceCollection;
        }
    }
}