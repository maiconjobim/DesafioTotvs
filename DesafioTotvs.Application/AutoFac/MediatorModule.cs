using System;
using System.Reflection;
using Autofac;
using Module = Autofac.Module;
using MediatR;
using DesafioTotvs.Application.Behaviours;
using FluentValidation;

namespace DesafioTotvs.Application.AutoFac
{
    public class MediatorModule : Module
    {
        private readonly string[] _assembliesNames;

        public MediatorModule(params string[] assembliesNames)
        {
            _assembliesNames = assembliesNames;
        }

        protected override void Load(ContainerBuilder builder)
        {
            foreach (var assemblyName in _assembliesNames)
            {
                var assembly = AppDomain.CurrentDomain.Load(assemblyName);

                LoadModules(builder, assembly);
            }
            
            // builder.RegisterGeneric(typeof(LoggingBehaviour<,>)).As(typeof(IPipelineBehavior<,>));

            builder.RegisterGeneric(typeof(ValidationBehaviour<,>)).As(typeof(IPipelineBehavior<,>));

            // builder.RegisterGeneric(typeof(TransactionalBehaviour<,>)).As(typeof(IPipelineBehavior<,>));
        }

        private static void LoadModules(ContainerBuilder builder, Assembly assembly)
        {
            AssemblyScanner.FindValidatorsInAssembly(assembly)
                .ForEach(scannedAssembly => builder.RegisterType(scannedAssembly.ValidatorType).As(scannedAssembly.InterfaceType).InstancePerLifetimeScope());
                
        }
    }
}