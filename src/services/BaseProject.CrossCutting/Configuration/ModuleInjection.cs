using BaseProject.Core.Application.Configuration;
using BaseProject.CrossCutting.Configuration.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BaseProject.CrossCutting.Configuration
{
    public static class ModuleInjection
    {
        public static void AddModuleInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.ResolveDependenciesCore();
            services.AddJwtConfiguration(configuration);

            services.AddUsuarioDependencyInjection();
            services.AddClienteDependencyInjection();
            services.AddProdutoDependencyInjection();
        }
    }
}
