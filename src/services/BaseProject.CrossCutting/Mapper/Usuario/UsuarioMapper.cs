using AutoMapper;
using BaseProject.Domain.Interop.Dtos.Usuario;
using BaseProject.Domain.Interop.ViewModels.Usuario;

namespace BaseProject.CrossCutting.Mapper.Usuario
{
    public class UsuarioMapper : Profile
    {
        public UsuarioMapper()
        {
            CreateMap<UsuarioCreateViewModel, Domain.Models.Usuario>();
            CreateMap<UsuarioUpdateViewModel, Domain.Models.Usuario>();
            CreateMap<Domain.Models.Usuario, UsuarioDto>().ReverseMap();
        }
    }
}
