using Microsoft.EntityFrameworkCore.Query;
using PhoneBook.Domain.Common;
using System.Linq.Expressions;

namespace PhoneBook.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : EntityBase, new()
    {
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
    }
}
