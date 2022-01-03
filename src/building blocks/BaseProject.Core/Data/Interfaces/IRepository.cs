using BaseProject.Core.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseProject.Core.Data.Interfaces
{
    public interface IRepository<T> where T : BaseModel
    {
        Task<IEnumerable<T>> ObterTodos();
        Task<IQueryable<T>> ObterTodosQueryable();
        Task<T> Selecionar(decimal id);
        Task Adicionar(T entity);
        Task Alterar(T entity);
        Task Remover(decimal id);
    }
}
