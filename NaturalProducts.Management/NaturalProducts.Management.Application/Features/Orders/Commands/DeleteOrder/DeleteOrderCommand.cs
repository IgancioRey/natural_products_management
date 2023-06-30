using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalProducts.Management.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommand :IRequest
    {
        public string OrderId { get; set; }
    }
}
