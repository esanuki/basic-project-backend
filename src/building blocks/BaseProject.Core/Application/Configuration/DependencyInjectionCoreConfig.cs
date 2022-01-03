using BaseProject.Core.Domain.Interfaces;
using BaseProject.Core.Service;
using Microsoft.Extensions.DependencyInjection;

namespace BaseProject.Core.Application.Configuration
{
    public static class DependencyInjectionCoreConfig
    {
        public static void ResolveDependenciesCore(this IServiceCollection services)
        {
            services.AddScoped<INotificador, Notificador>();
        }
    }
}
