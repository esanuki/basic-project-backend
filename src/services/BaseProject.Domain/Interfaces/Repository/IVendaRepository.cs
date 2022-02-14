using BaseProject.Core.Data.Interfaces;
using BaseProject.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseProject.Domain.Interfaces.Repository
{
    public interface IVendaRepository : IRepository<Venda>
    {
        Task<IEnumerable<VendaItem>> ObterVendaItensPorVenda(decimal id);
        Task ExcluirVendaItens(IEnumerable<VendaItem> vendaItems);
    }
}
