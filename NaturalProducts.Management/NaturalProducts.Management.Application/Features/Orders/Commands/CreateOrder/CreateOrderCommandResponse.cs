using NaturalProducts.Management.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalProducts.Management.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandResponse : BaseResponse
    {
        public CreateOrderCommandResponse() { }

        public CreateOrderDto Order { get; set; } = default!;
    }
}
