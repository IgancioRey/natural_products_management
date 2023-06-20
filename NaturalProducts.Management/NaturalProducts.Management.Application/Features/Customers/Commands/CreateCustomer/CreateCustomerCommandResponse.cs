using NaturalProducts.Management.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalProducts.Management.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandResponse: BaseResponse
    {
        public CreateCustomerCommandResponse() { }

        public CreateCustomerDto Customer { get; set; } = default!;
    }
}
