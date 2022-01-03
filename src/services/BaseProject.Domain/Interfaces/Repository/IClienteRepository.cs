using BaseProject.Core.Data.Interfaces;
using BaseProject.Domain.Models;
using System.Threading.Tasks;

namespace BaseProject.Domain.Interfaces.Repository
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<Cliente> SelecionarComEndereco(decimal id);
    }
}
