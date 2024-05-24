using Domain.Interfaces;
using Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infra
{
    public static class DataBaseModuleDependency
    {
        public static void AddDataBaseModule(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClientesRepository>();
            services.AddScoped<IFakeCheckoutRepository, FakeCheckoutRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IProdutosRepository, ProdutosRepository>();
        }
    }
}

