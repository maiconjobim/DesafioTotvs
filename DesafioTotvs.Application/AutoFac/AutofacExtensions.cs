using Autofac;

namespace DesafioTotvs.Application.AutoFac
{
    public static class AutofacExtensions
    {
        public static void AddAutofacModules(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule(new DesafioTotvsModule());

            containerBuilder.RegisterModule(new MediatorModule("DesafioTotvs.Application"
                ,"DesafioTotvs.Domain", 
                "DesafioTotvs.Infrastructure"));
        }
    }
}