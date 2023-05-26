using PhoneBook.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : EntityBase, new()
    {
        Task<T> GetAsync(Expression<Func<T, bool>> predicate,
                                        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                        string includeString = null);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null,
                                       Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                       List<Expression<Func<T, object>>> includes = null);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
    }
}
