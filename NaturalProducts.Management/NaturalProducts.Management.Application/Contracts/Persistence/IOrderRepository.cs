using NaturalProducts.Management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalProducts.Management.Application.Contracts.Persistence
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
        Task<bool> IsOrderCustomerAndDateUnique(string customerId, DateTime orderDate);

        Task<List<Order>> GetOrdersBetweenDates(DateTime? dateFrom, DateTime? dateTo);
    }
}
