using BaseProject.Core.Data.Interfaces;
using BaseProject.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseProject.Core.Data
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        protected readonly DbContext _context;
        protected DbSet<T> _dataSet;
        public Repository(DbContext context)
        {
            _context = context;
            _dataSet = _context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> ObterTodos()
        {
            return await _dataSet
                .AsNoTracking()
                .ToListAsync();
        }

        public virtual async Task<IQueryable<T>> ObterTodosQueryable()
        {
            var result = _dataSet.AsNoTracking();
            return await Task.FromResult(result);
        }

        public virtual async Task<T> Selecionar(decimal id)
        {
            return await _dataSet.AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id.Equals(id));
        }

        public virtual async Task Adicionar(T entity)
        {
            try
            {
                _dataSet.Add(entity);
                await _context.SaveChangesAsync();

            } catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        public virtual async Task Alterar(T entity)
        {
            try
            {
                _dataSet.Update(entity);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public virtual async Task Remover(decimal id)
        {
            try
            {
                var entity = await _dataSet.AsNoTracking().FirstOrDefaultAsync(t => t.Id.Equals(id));

                if (entity == null) return;

                _dataSet.Remove(entity);

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
