using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModelApi.Application.Secuity;
using ModelApi.Domain.AutoMapper;
using ModelApi.IoC;
using Newtonsoft.Json;
using AutoMapper;
using ModelApi.Application.Middleware;
using ModelApi.CrossCutting;
using Swashbuckle.AspNetCore.Swagger;

namespace ModelApi.Application
{
    public class Startup
    {
        private IHostingEnvironment enviroment;
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
               .AddEnvironmentVariables();

            enviroment = env;

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConnectionStrings.ModelApiConnection = Configuration.GetConnectionString("ModelApiConnection");
            services.AddMvc(config =>
            {
                //var policy = new AuthorizationPolicyBuilder()
                //                 .RequireAuthenticatedUser()
                //                 .Build();
                //config.Filters.Add(new AuthorizeFilter(policy));
            })
            .AddJsonOptions(options =>
            {
                options.SerializerSettings.Formatting = Formatting.Indented;
            });

            services.AddAuthorization(options =>
            {
                options.UseAuthorizationOptions();
            });

            Mapper.Initialize(cfg =>
            {
                cfg.ValidateInlineMaps = false;
            });

            services.AddAutoMapper(typeof(Startup).Assembly);
            AutoMapperConfiguration.RegisterMappings();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = $"ModelApi API {enviroment.EnvironmentName}", Version = "v1", Description = "Projeto ModelApi" });
            });

            services.AddOptions();

            services.AddCors(o => o.AddPolicy("Cors", builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));
            // Registrar todos os IoC
            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true,
                    ReactHotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseResponseExceptionHandler();
            
            app.UseStaticFiles();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });


        }

        private static void RegisterServices(IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
