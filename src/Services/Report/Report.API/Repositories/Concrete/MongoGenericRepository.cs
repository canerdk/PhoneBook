using MongoDB.Driver;
using Report.API.Entities;
using Report.API.Repositories.Abstract;
using System.Linq.Expressions;

namespace Report.API.Repositories.Concrete
{
    public class MongoGenericRepository<T> : IMongoGenericRepository<T> where T : MongoEntity
    {
        protected readonly IMongoCollection<T> _collection;

        public MongoGenericRepository(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            _collection = database.GetCollection<T>(typeof(T).Name.ToLowerInvariant());
        }

        public async Task<T> AddAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<T> DeleteAsync(string id)
        {
            return await _collection.FindOneAndDeleteAsync(x => x.Id == id);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            return predicate == null
                ? _collection.AsQueryable()
                : _collection.AsQueryable().Where(predicate);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _collection.Find(predicate).FirstOrDefaultAsync();
        }

        public async Task<T> UpdateAsync(string id, T entity)
        {
            return await _collection.FindOneAndReplaceAsync(x => x.Id == id, entity);
        }
    }
}
