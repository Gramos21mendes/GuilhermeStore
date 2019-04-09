using GuilhermeStore.Domain.StoreContext.Handlers;
using GuilhermeStore.Domain.StoreContext.Repositories;
using GuilhermeStore.Domain.StoreContext.Services;
using GuilhermeStore.Infra.StoreContext.DataContexts;
using GuilhermeStore.Infra.StoreContext.Repositories;
using GuilhermeStore.Infra.StoreContext.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Elmah.Io.AspNetCore;
using System;

namespace GuilhermeStore.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //middleware
            services.AddMvc();

            services.AddResponseCompression();

            services.AddScoped<GuilhermeDataContext, GuilhermeDataContext>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<CustomerHandler, CustomerHandler>();

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Info { Title = "Guilherme Store", Version = "v1" });
            });

            //Nova Config Elmah Io
            services.AddElmahIo(options =>
            {
                options.ApiKey = "9ac3f651a7d845458993938a6f3e337a";
                options.LogId = new Guid("9e498956-862b-49df-8dfd-9c29b688c9d6");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();


            // app.Run(async (context) =>
            // {
            //     await context.Response.WriteAsync("Hello World!");
            // });

            app.UseMvc();
            app.UseResponseCompression();

            app.UseSwagger();

            //swagger json
            //swagger INTERFACE 
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Guilherme Store - V1");
            });

            //Config Antiga Elmah Io OBSOLETA
            // app.UseElmahIo("API_KEY", new Guid("LOG_ID"));

            //Nova Config Elmah Io
            app.UseElmahIo();
        }
    }
}
