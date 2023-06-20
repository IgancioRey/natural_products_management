using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalProducts.Management.Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCostumerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCostumerCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();

            RuleFor(c => c.LastName).NotEmpty();

            RuleFor(c => c.MobileNumber).NotEmpty();
        }
    }
}
