using Autofac;
using DesafioTotvs.Application.Queries;
using DesafioTotvs.Domain.Repositories;
using DesafioTotvs.Infrastructure.EntityFramework.Repositories;

namespace DesafioTotvs.Application.AutoFac
{
    public class DesafioTotvsModule: Module
  {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<VehicleRepository>()
                .As<IVehicleRepository>()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<VehicleQueries>()
              .As<IVehicleQueries>()
              .InstancePerLifetimeScope();
        }
    }
}