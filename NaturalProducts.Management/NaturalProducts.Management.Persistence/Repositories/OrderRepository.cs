using MongoDB.Driver;
using NaturalProducts.Management.Application.Contracts.Persistence;
using NaturalProducts.Management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NaturalProducts.Management.Persistence.Repositories
{
    public class OrderRepository : MongoRepository<Order>, IOrderRepository
    {
        public OrderRepository(MongoDbContext dbContext) : base(dbContext) { }

        public Task<bool> IsOrderCustomerAndDateUnique(string customerId, DateTime orderDate)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Order>> GetOrdersBetweenDates(DateTime? dateFrom, DateTime? dateTo) 
        {
            var filter = Builders<Order>.Filter.Empty;

            if (dateFrom != null)
            {
                var startDateFilter = Builders<Order>.Filter.Gte(x => x.OrderDate, dateFrom);
                filter &= startDateFilter;
            }

            if (dateTo != null)
            {
                var endDateFilter = Builders<Order>.Filter.Lte(x => x.OrderDate, dateTo);
                filter &= endDateFilter;
            }

            var matches = await _collection.WithReadPreference(ReadPreference.Primary)
                                  .Find(filter)
                                  .ToListAsync();

            return matches;
        }
    }
}
