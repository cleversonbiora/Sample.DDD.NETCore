using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using TemplateDDD.Domain.Interfaces.Infra;
using TemplateDDD.Domain.Interfaces.Service;
using TemplateDDD.Infra;
using TemplateDDD.Infra.Repositories;
using TemplateDDD.Service.Services;
using System.Data;

namespace TemplateDDD.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {

            //Sample
            services.AddTransient<ISampleService, SampleService>();
            services.AddTransient<ISampleRepository, SampleRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
        }
    }
}
