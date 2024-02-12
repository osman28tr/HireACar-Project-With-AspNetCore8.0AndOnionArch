using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HireACar.Application.Abstract;
using HireACar.Domain.Entities;
using HireACar.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HireACar.Persistance.Concrete.Repositories
{
    public class GenericRepository<T>:IRepository<T> where T : BaseEntity
    {
        private readonly HireACarContext _context;

        public GenericRepository(HireACarContext context)
        {
            _context = context;
        }
        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            var result = await _context.Set<T>().FirstOrDefaultAsync(predicate);
            return result ?? null;
        }

        public IQueryable<T> Query()
        {
            
            return _context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;  
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
