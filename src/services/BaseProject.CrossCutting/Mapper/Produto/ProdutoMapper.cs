using AutoMapper;
using BaseProject.Domain.Interop.Dtos.Produto;
using BaseProject.Domain.Interop.ViewModels.Produto;

namespace BaseProject.CrossCutting.Mapper.Produto
{
    public class ProdutoMapper : Profile
    {
        public ProdutoMapper()
        {
            CreateMap<ProdutoViewModel, Domain.Models.Produto>().ReverseMap();
            CreateMap<Domain.Models.Produto, ProdutoDto>().ReverseMap();
        }
    }
}
