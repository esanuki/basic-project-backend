using AutoMapper;
using BaseProject.Domain.Interop.Dtos.Cliente;
using BaseProject.Domain.Interop.ViewModels.Cliente;

namespace BaseProject.CrossCutting.Mapper.Cliente
{
    public class EnderecoMapper : Profile
    {
        public EnderecoMapper()
        {
            CreateMap<EnderecoViewModel, Domain.Models.Endereco>().ReverseMap();
            CreateMap<Domain.Models.Endereco, EnderecoDto>().ReverseMap();
        }
    }
}
