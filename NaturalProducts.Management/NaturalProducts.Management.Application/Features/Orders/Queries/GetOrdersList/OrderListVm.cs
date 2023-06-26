using NaturalProducts.Management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalProducts.Management.Application.Features.Orders.Queries.GetOrdersList
{
    public class OrderListVm
    {
        public string OrderId { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public string CustomerId { get; set; } = string.Empty;
        public CustomerDto Customer { get; set; } = default!;
        public bool Paid { get; set; }
        public bool Withdrawn { get; set; }
    }
}
