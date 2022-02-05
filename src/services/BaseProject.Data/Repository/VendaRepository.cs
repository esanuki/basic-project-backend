using BaseProject.Core.Data;
using BaseProject.Data.Context;
using BaseProject.Domain.Interfaces.Repository;
using BaseProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseProject.Data.Repository
{
    public class VendaRepository : Repository<Venda>, IVendaRepository
    {
        public VendaRepository(BaseProjectContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Venda>> ObterTodos()
        {
            return await _dataSet
                .Include(v => v.Cliente)
                .OrderByDescending(v => v.DataVenda)
                .Select(v => new Venda
                {
                    Id = v.Id,
                    DataVenda = v.DataVenda,
                    Cliente = v.Cliente,
                    ValorTotal = v.ValorTotal
                })
                .ToListAsync();
        }

        public override async Task<Venda> Selecionar(decimal id)
        {
            return await _dataSet
                    .Include(v => v.Cliente)
                    .Include(v => v.VendaItens)
                        .ThenInclude(vi => vi.Produto)
                    .FirstOrDefaultAsync(v => v.Id.Equals(id));
        }

        public override async Task Remover(decimal id)
        {
            var result = await _dataSet.Include(v => v.VendaItens).FirstOrDefaultAsync(v => v.Id.Equals(id));

            _context.Remove(result);


            await _context.SaveChangesAsync();
        }
    }
}
