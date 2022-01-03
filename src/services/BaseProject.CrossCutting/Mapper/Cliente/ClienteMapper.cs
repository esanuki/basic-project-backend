using AutoMapper;
using BaseProject.Domain.Interop.Dtos.Cliente;
using BaseProject.Domain.Interop.ViewModels.Cliente;

namespace BaseProject.CrossCutting.Mapper.Cliente
{
    public class ClienteMapper : Profile
    {
        public ClienteMapper()
        {
            CreateMap<ClienteCreateViewModel, Domain.Models.Cliente>();
            CreateMap<ClienteUpdateViewModel, Domain.Models.Cliente>();
            CreateMap<Domain.Models.Cliente, ClienteDto>().ReverseMap();
        }
    }
}
