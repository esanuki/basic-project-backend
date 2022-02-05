using AutoMapper;
using BaseProject.CrossCutting.Mapper.Cliente;
using BaseProject.CrossCutting.Mapper.Produto;
using BaseProject.CrossCutting.Mapper.Usuario;
using BaseProject.CrossCutting.Mapper.Venda;
using Microsoft.Extensions.DependencyInjection;

namespace BaseProject.CrossCutting.Mapper
{
    public static class MapperInjection
    {
        public static void AddAutoMapperConfig(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UsuarioMapper());
                cfg.AddProfile(new ClienteMapper());
                cfg.AddProfile(new EnderecoMapper());
                cfg.AddProfile(new ProdutoMapper());
                cfg.AddProfile(new VendaMapper());
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
