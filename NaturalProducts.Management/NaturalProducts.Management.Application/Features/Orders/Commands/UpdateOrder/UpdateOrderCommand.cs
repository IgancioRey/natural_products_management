using MediatR;
using NaturalProducts.Management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalProducts.Management.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest
    {
        public string OrderId { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public string CustomerId { get; set; } = string.Empty;
        public decimal PaidAmount { get; set; }
        public bool Paid { get; set; }
        public bool Withdrawn { get; set; }
        public ICollection<OrderDetail>? Detail { get; set; }
    }
}
