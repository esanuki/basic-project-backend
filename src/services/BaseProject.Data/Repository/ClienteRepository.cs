using BaseProject.Core.Data;
using BaseProject.Data.Context;
using BaseProject.Domain.Interfaces.Repository;
using BaseProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BaseProject.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(BaseProjectContext context) : base(context)
        {
        }

        public async Task<Cliente> SelecionarComEndereco(decimal id)
        {
            return await _dataSet
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id.Equals(id));
        }
    }
}
