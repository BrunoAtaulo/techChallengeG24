using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationModuleDependency
    {
        public static void AddApplicationModule(this IServiceCollection services)
        {
            services.AddTransient<IProdutosService, ProdutosService>();
            services.AddTransient<IPedidoService, PedidoService>();
            services.AddTransient<IClienteService, ClienteService>();
            

        }
    }
}
