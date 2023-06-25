using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalProducts.Management.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderDto
    {
        public string OrderId { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public string CustomerId { get; set; } = string.Empty;

    }
}
