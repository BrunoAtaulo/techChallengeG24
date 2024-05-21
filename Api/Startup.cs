using App.Api.Configurations;
using Application;
using Domain.Entities.Validator;
using Infra.Context;
using Infra.DataBase.InMemory;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add<CpfValidationActionFilter>();
            })
            .ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
            });

            // Add Swagger configuration
            services.AddSwaggerConfiguration();

            services.AddDataBaseInMemoryModule();
            services.AddApplicationModule();


            services.AddEndpointsApiExplorer();


            var connectionsString = Environment.GetEnvironmentVariable("DATABASE");
            //Console.WriteLine("bd");
            //Console.WriteLine(connectionsString);
            services.AddDbContext<FiapDbContext>(options =>
            {
                options.UseSqlServer(
                    connectionsString,
                    sqlServerOptions => sqlServerOptions.EnableRetryOnFailure());
            });


        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<FiapDbContext>();
                context.Database.Migrate();
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseSwagger(config =>
            {
                config.RouteTemplate = "api/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("/api/v1/swagger.json", "API LancheRapido v1");
                config.RoutePrefix = "swagger";
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
