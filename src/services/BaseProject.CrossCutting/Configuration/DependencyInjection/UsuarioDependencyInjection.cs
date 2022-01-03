using BaseProject.Data.Repository;
using BaseProject.Domain.Interfaces.Repository;
using BaseProject.Domain.Interfaces.Service;
using BaseProject.Service.Login;
using BaseProject.Service.Usuario;
using Microsoft.Extensions.DependencyInjection;

namespace BaseProject.CrossCutting.Configuration.DependencyInjection
{
    public static class UsuarioDependencyInjection
    {
        public static void AddUsuarioDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            
        }
    }
}
