using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalProducts.Management.Application.Features.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest
    {
        public string CustomerId { get; set; }
    }
}
