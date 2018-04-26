using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeApplianceStoreAPI.Models;
using HomeApplianceStoreAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace HomeApplianceStoreAPI
{
    public class Startup
    {
      
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
 

            services.AddScoped(typeof(StorageService<>));
            services.AddTransient<EventGridService>();
            services.Configure<EventGridOptions>(x => Configuration.GetSection("EventGrid").Bind(x));
            services.AddMemoryCache();
            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Home Appliance Store", Version = "v1" });
                c.IncludeXmlComments("HomeApplianceStoreAPI.xml");

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger(opt =>
            {
                // Add host needed by Azure
                opt.PreSerializeFilters.Add((swaggerDoc, httpRequest) =>
                {
                    swaggerDoc.Host = httpRequest.Host.Value;
                });

            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Home Appliance Store API");
            });

            app.UseMvc();
        }
    }
}
