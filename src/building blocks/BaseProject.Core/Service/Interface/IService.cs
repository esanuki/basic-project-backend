using BaseProject.Core.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseProject.Core.Service.Interface
{
    public interface IService<T> where T : BaseModel
    {
        Task<IEnumerable<Dto>> ObterTodos<Dto>();
        Task<Dto> Selecionar<Dto>(decimal id);
        Task Adicionar<ViewModel>(ViewModel viewModel);
        Task Alterar<ViewModel>(ViewModel viewModel);
        Task Remover(decimal id);
    }
}
