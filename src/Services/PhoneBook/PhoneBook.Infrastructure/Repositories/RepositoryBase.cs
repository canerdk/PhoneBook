using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using PhoneBook.Application.Contracts.Persistence;
using PhoneBook.Domain.Common;
using PhoneBook.Infrastructure.Persistence;
using System.Linq.Expressions;

namespace PhoneBook.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T : EntityBase, new()
    {
        protected readonly AppDbContext _dbContext;

        public RepositoryBase(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            var addedEntity = _dbContext.Set<T>().Add(entity);
            addedEntity.State = EntityState.Added;
            await _dbContext.SaveChangesAsync();
            return addedEntity.Entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            var deletedEntity = _dbContext.Set<T>().Remove(entity);
            deletedEntity.State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
            return deletedEntity.Entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
        {
            IQueryable<T> queryable = _dbContext.Set<T>();
            if (include != null) queryable = include(queryable);
            if (predicate != null) queryable = queryable.Where(predicate);
            if (orderBy != null) return orderBy(queryable);

            return await queryable.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
        {
            IQueryable<T> queryable = _dbContext.Set<T>();
            if (include != null) queryable = include(queryable);

            return await queryable.FirstOrDefaultAsync(predicate);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var updatedEntity = _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
            return updatedEntity.Entity;
        }
    }
}
