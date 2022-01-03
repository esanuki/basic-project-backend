using BaseProject.Core.Service.Interface;
using BaseProject.Domain.Interop.ViewModels.Usuario;
using BaseProject.Domain.Models;
using System.Threading.Tasks;

namespace BaseProject.Domain.Interfaces.Service
{
    public interface IUsuarioService : IService<Usuario>
    {
        Task Adicionar(UsuarioCreateViewModel viewModel);
        Task Alterar(UsuarioUpdateViewModel viewModel);
    }
}
