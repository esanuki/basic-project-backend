using BaseProject.Data.Repository;
using BaseProject.Domain.Interfaces.Repository;
using BaseProject.Domain.Interfaces.Service;
using BaseProject.Service.Venda;
using Microsoft.Extensions.DependencyInjection;

namespace BaseProject.CrossCutting.IoC.DependencyInjection
{
    public static class VendaDependencyInjection
    {
        public static void AddVendaDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IVendaService, VendaService>();
            services.AddScoped<IVendaRepository, VendaRepository>();
        }
    }
}
