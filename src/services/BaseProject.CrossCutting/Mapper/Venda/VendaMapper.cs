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

            CreateMap<VendaItemViewModel, Domain.Models.VendaItem>().ReverseMap();
            CreateMap<Domain.Models.VendaItem, VendaItemDto>().ReverseMap();
        }
    }
}
