using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace App.Api.Configurations
{
    public static class SwaggerConfig
    {
        private const string version = "1.0.0";
        private const string title = "API Lanche Rápido";

        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = version,
                    Title = title,
                    Description = "API desenvolvida para um sistema de autoatendimento de fast food",
                });

                c.EnableAnnotations();
            });
        }
    }
}
