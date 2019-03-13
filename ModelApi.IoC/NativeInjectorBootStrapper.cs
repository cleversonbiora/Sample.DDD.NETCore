using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ModelApi.Domain.Interfaces.Infra;
using ModelApi.Domain.Interfaces.Service;
using ModelApi.Infra;
using ModelApi.Infra.Repositories;
using ModelApi.Service.Services;
using System.Data;

namespace ModelApi.IoC
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
