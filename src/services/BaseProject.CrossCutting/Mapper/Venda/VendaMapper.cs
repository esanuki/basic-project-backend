using AutoMapper;
using BaseProject.Domain.Interop.Dtos.Venda;
using BaseProject.Domain.Interop.ViewModels.Venda;

namespace BaseProject.CrossCutting.Mapper.Venda
{
    public class VendaMapper : Profile
    {
        public VendaMapper()
        {
            CreateMap<VendaViewModel, Domain.Models.Venda>().ReverseMap();
            CreateMap<Domain.Models.Venda, VendaDto>().ReverseMap();
            CreateMap<Domain.Models.Venda, VendaListDto>()
                .ForMember(dest => dest.Cliente, src => src.MapFrom(v => v.Cliente.Nome))
                .ForMember(dest => dest.TotalVenda, src => src.MapFrom(v => v.ValorTotal));

            CreateMap<VendaItemViewModel, Domain.Models.VendaItem>().ReverseMap();
            CreateMap<Domain.Models.VendaItem, VendaItemDto>().ReverseMap();

            
        }
    }
}
