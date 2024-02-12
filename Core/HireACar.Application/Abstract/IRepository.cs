using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HireACar.Domain.Entities;

namespace HireACar.Application.Abstract
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> Query();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
    }
}
