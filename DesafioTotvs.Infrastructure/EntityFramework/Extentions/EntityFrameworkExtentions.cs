using System;
using System.Threading.Tasks;
using DesafioTotvs.Infrastructure.EntityFramework.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioTotvs.Infrastructure.EntityFramework.Extentions
{
    public static class EntityFrameworkExtentions
    {
        public static IServiceCollection AddVehicleDbContext(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(nameof(VehicleDbContext));

            serviceCollection.AddDbContext<VehicleDbContext>(options =>
            {
                options.UseSqlServer(connectionString, sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null);

                });
            });

            return serviceCollection;
        }

        public static  IServiceProvider MigrateDbContextAsync(this IServiceProvider serviceProvider)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
                return serviceProvider;

            using var scope = serviceProvider.GetService<IServiceScopeFactory>()?.CreateScope();

            var dbContext = scope?.ServiceProvider.GetRequiredService<VehicleDbContext>();

            if (dbContext is not null)
                dbContext.Database.Migrate();

            return serviceProvider;
        }
    }
}