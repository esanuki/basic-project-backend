using BaseProject.Core.Service.Interface;
using BaseProject.Domain.Interop.Dtos.Venda;
using BaseProject.Domain.Interop.ViewModels.Venda;
using BaseProject.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseProject.Domain.Interfaces.Service
{
    public interface IVendaService : IService<Venda>
    {
        Task<IEnumerable<VendaListDto>> ObterTodos();
        Task<VendaDto> Selecionar(decimal id);
        Task Adicionar(VendaViewModel viewModel);
        Task Alterar(VendaViewModel viewModel);
    }
}
