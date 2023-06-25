using MediatR;
using NaturalProducts.Management.Application.Features.Customers.Commands.CreateCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalProducts.Management.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<CreateOrderCommandResponse>
    {
        public DateTime OrderDate { get; set; }
        public string CustomerId { get; set; } = string.Empty;
        public decimal PaidAmount { get; set; }
        public bool Paid { get; set; }
        public bool Withdrawn { get; set; }

    }
}
