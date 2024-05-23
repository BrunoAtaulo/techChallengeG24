﻿using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Infra.DataBase.InMemory.Repositories;
using Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.DataBase.InMemory
{
    public static class DataBaseInMemoryModuleDependency
    {
        public static void AddDataBaseInMemoryModule(this IServiceCollection services)
        {

            services.AddScoped<IClienteRepository, ClientesRepository>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IFakeCheckoutService, FakeCheckoutService>();
            services.AddScoped<IFakeCheckoutRepository, FakeCheckoutRepository>();
        }
    }
}
