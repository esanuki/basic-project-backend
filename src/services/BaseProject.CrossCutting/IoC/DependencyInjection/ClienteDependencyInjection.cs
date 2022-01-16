using BaseProject.Data.Repository;
using BaseProject.Domain.Interfaces.Repository;
using BaseProject.Domain.Interfaces.Service;
using BaseProject.Service.Cliente;
using Microsoft.Extensions.DependencyInjection;

namespace BaseProject.CrossCutting.IoC.DependencyInjection
{
    public static class ClienteDependencyInjection
    {
        public static void AddClienteDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
        }
    }
}
