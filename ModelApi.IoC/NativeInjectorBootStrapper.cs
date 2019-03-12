using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ModelApi.Domain.Interfaces.Service;
using ModelApi.Service.Services;

namespace ModelApi.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {

            //Sample
            services.AddTransient<ISampleService, SampleService>();
            //services.AddTransient<IAtributoService, AtributoService>();
            //services.AddTransient<IAtributoRepository, AtributoRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
        }
    }
}
