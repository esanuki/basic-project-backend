using BaseProject.Core.Service.Interface;
using BaseProject.Domain.Interop.Dtos.Cliente;
using BaseProject.Domain.Models;
using System.Threading.Tasks;

namespace BaseProject.Domain.Interfaces.Service
{
    public interface IClienteService : IService<Cliente>
    {
        Task<ClienteDto> SelecionarComEndereco(decimal id);
    }
}
