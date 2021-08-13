using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using MediatR.Extensions.Autofac.DependencyInjection;

namespace DesafioTotvs.Application.AutoFac
{
    public static class AutofacExtensions
    {
        public static void AddAutofacModules(this ContainerBuilder containerBuilder)
        {
            var assemblies = new string[]{"DesafioTotvs.Application"
                ,"DesafioTotvs.Domain", 
                "DesafioTotvs.Infrastructure"};

            containerBuilder.RegisterMediatR(assemblies.Select(Assembly.Load).ToList());
            
            containerBuilder.RegisterModule(new DesafioTotvsModule());

            containerBuilder.RegisterModule(new MediatorModule(assemblies));
        }
    }
}