using MongoDB.Bson;
using MongoDB.Driver;
using NaturalProducts.Management.Application.Contracts.Persistence;
using NaturalProducts.Management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalProducts.Management.Persistence.Repositories
{
    public class CustomerRepository : MongoRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(MongoDbContext dbContext) : base(dbContext) { }

        public Task<bool> DoesCustomerExist(string customerId)
        {
            var objectId = ObjectId.Parse(customerId);
            var filter = Builders<Customer>.Filter.Eq("_id", objectId);
            var matches = _collection.Find(filter).FirstOrDefault() != default(Customer);

            return Task.FromResult(matches);
        }
    }
}
