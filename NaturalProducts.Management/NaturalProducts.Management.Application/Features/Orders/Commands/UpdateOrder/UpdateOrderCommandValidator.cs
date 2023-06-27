using FluentValidation;
using NaturalProducts.Management.Application.Contracts.Persistence;
using NaturalProducts.Management.Application.Features.Orders.Commands.CreateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalProducts.Management.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandValidator: AbstractValidator<UpdateOrderCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        public UpdateOrderCommandValidator(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;

            RuleFor(p => p.OrderId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.OrderDate)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(e => e)
                .MustAsync(CustomerExists)
                .WithMessage("The customer dosen't exist");

        }

        private async Task<bool> CustomerExists(UpdateOrderCommand e, CancellationToken token)
        {
            return await _customerRepository.DoesCustomerExist(e.CustomerId);
        }

    }
}
