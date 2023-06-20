using FluentValidation;
using NaturalProducts.Management.Application.Features.Products.Commands.CreateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalProducts.Management.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidator: AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator() 
        {
            RuleFor(c => c.Name).NotEmpty();

            RuleFor(c => c.LastName).NotEmpty();

            RuleFor(c => c.MobileNumber).NotEmpty();
        }
    }
}
