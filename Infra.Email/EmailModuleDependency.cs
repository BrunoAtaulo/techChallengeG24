using Infra.Email.Operations;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Email
{
    public static class EmailModuleDependency
    {
        public static void AddEmailModule(this IServiceCollection services)
        {
            services.AddTransient<IEmailAdapter, EmailManager>();
        }
    }
}
