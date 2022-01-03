using BaseProject.Core.Data;
using BaseProject.Data.Context;
using BaseProject.Domain.Interfaces.Repository;
using BaseProject.Domain.Models;

namespace BaseProject.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(BaseProjectContext context) : base(context)
        {
        }
    }
}
