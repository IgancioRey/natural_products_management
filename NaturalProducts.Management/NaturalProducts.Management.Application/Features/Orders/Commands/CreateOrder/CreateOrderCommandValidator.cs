using FluentValidation;
using NaturalProducts.Management.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalProducts.Management.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandValidator: AbstractValidator<CreateOrderCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        public CreateOrderCommandValidator(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;

            RuleFor(p => p.OrderDate)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(e => e)
                .MustAsync(CustomerExists)
                .WithMessage("The customer dosen't exist");
            
        }

        private async Task<bool> CustomerExists(CreateOrderCommand e, CancellationToken token)
        {
            return await _customerRepository.DoesCustomerExist(e.CustomerId);
        }
    }
}
