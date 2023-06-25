using NaturalProducts.Management.Application.Contracts.Persistence;
using NaturalProducts.Management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
