using BaseProject.Domain.Interop.Dtos.Login;
using System.Threading.Tasks;

namespace BaseProject.Domain.Interfaces.Service
{
    public interface ILoginService
    {
        Task<object> ObterPorLogin(LoginViewModel login);
    }
}
