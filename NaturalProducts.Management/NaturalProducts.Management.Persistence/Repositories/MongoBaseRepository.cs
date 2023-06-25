using MongoDB.Bson;
using MongoDB.Driver;
using NaturalProducts.Management.Application.Contracts.Persistence;
using NaturalProducts.Management.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalProducts.Management.Persistence.Repositories
{
    public class MongoRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly IMongoCollection<T> _collection;
        private readonly string _collectionName;

        public MongoRepository(MongoDbContext dbContext)
        {
            _collectionName = typeof(T).Name.ToLower();
            _collection = dbContext.GetCollection<T>(_collectionName);
        }

        public virtual async Task<T?> GetByIdAsync(string id)
        {
            var objectId = ObjectId.Parse(id);
            var filter = Builders<T>.Filter.Eq("_id", objectId);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            if (entity is AuditableEntity auditableEntity)
            {
                auditableEntity.OnCreating();
            }

            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task UpdateAsync(string id, T entity)
        {
            if (entity is AuditableEntity auditableEntity)
            {
                auditableEntity.OnUpdating();
            }
            var objectId = ObjectId.Parse(id);
            var filter = Builders<T>.Filter.Eq("_id", objectId);
            await _collection.ReplaceOneAsync(filter, entity);
        }

        public async Task DeleteAsync(string id)
        {
            var objectId = ObjectId.Parse(id);
            var filter = Builders<T>.Filter.Eq("_id", objectId);
            await _collection.DeleteOneAsync(filter);
        }

        public Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size)
        {
            throw new NotImplementedException();
        }
    }
}
