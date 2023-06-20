using Amazon.Runtime.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System.Diagnostics;

namespace NaturalProducts.Management.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<CreateCustomerCommandResponse>
    {
        public string CustomerId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public string Observation { get; set; } = string.Empty;
    }
}
