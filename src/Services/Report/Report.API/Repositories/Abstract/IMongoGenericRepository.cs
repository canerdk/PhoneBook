using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Report.API.Entities;
using System.Linq.Expressions;

namespace Report.API.Repositories.Abstract
{
    public interface IMongoGenericRepository<T> where T : MongoEntity
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(string id, T entity);
        Task<T> DeleteAsync(string id);
    }
}
