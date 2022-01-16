using BaseProject.Core.Data;
using BaseProject.Data.Context;
using BaseProject.Domain.Interfaces.Repository;
using BaseProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BaseProject.Data.Repository
{
    public class VendaRepository : Repository<Venda>, IVendaRepository
    {
        public VendaRepository(BaseProjectContext context) : base(context)
        {
        }

        public override Task<Venda> Selecionar(decimal id)
        {
            return _dataSet
                    .Include(v => v.Cliente)
                    .Include(v => v.VendaItens)
                        .ThenInclude(vi => vi.Produto)
                    .FirstOrDefaultAsync(v => v.Id.Equals(id));
        }
    }
}
