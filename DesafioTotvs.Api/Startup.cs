using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using DesafioTotvs.Api.Extentions;
using DesafioTotvs.Application.AutoFac;
using DesafioTotvs.Application.AutoMapper;
using DesafioTotvs.Application.Serilog;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace DesafioTotvs.Api
{
    public class Startup
    {
        private const string ApplicationAssembly = "DesafioTotvs.Application";
        private const string DomainAssembly = "DesafioTotvs.Domain";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureContainer(ContainerBuilder container)
        {
            container.AddAutofacModules();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services
              .ConfigureSerilog(Configuration)
              .AddAutoMapperFromAssemblies(ApplicationAssembly)
              .ConfigureSwaggerGen()
              .AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DesafioTotvs.Api v1"));
            }

            app.UseCors()
              .UseHttpsRedirection()
              .UseRouting()
              .UseAuthorization()
              .UseEndpoints(endpoints =>
              {
                  endpoints.MapControllers();
              });
        }
    }
}
