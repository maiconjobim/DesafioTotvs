using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DesafioTotvs.Infrastructure.EntityFramework.DbContexts
{
  public class VehiclesDesignTimeDbContextFactory : IDesignTimeDbContextFactory<VehicleDbContext>
  {
    public VehicleDbContext CreateDbContext(string[] args)
    {
      var aspnetCoreEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");


      var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{aspnetCoreEnvironment}.json", optional: false
                    , reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString(nameof(VehicleDbContext));

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<VehicleDbContext>().UseSqlServer(connectionString);

            return new VehicleDbContext(dbContextOptionsBuilder.Options);
    }
  }
}