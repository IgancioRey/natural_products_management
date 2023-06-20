using AutoMapper;
using MediatR;
using NaturalProducts.Management.Application.Contracts.Persistence;
using NaturalProducts.Management.Application.Exceptions;
using NaturalProducts.Management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalProducts.Management.Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly IAsyncRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;

        public UpdateCustomerCommandHandler(IAsyncRepository<Customer> customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerToUpdate = await _customerRepository.GetByIdAsync(request.CustomerId);
            if (customerToUpdate == null)
            {
                throw new NotFoundException(nameof(Customer), request.CustomerId); 
            }

            _mapper.Map(request, customerToUpdate, typeof(UpdateCustomerCommand),typeof(Customer));

            await _customerRepository.UpdateAsync(customerToUpdate.CustomerId, customerToUpdate);

            return Unit.Value;
        }
    }
}
