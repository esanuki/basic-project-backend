using BaseProject.Core.Data;
using BaseProject.Data.Context;
using BaseProject.Domain.Interfaces.Repository;
using BaseProject.Domain.Models;

namespace BaseProject.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(BaseProjectContext context) : base(context)
        {
        }
    }
}
