using BaseProject.Data.Repository;
using BaseProject.Domain.Interfaces.Repository;
using BaseProject.Domain.Interfaces.Service;
using BaseProject.Service.Produto;
using Microsoft.Extensions.DependencyInjection;

namespace BaseProject.CrossCutting.IoC.DependencyInjection
{
    public static class ProdutoDependencyInjection
    {
        public static void AddProdutoDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
        }
    }
}
