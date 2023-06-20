using AutoMapper;
using MediatR;
using NaturalProducts.Management.Application.Contracts.Persistence;
using NaturalProducts.Management.Application.Features.Products.Commands.CreateProduct;
using NaturalProducts.Management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalProducts.Management.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerCommandResponse>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var createCustomerCommandResponse = new CreateCustomerCommandResponse();            

            var validator = new CreateCustomerCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.Errors.Count > 0)
            {
                createCustomerCommandResponse.Success = false;
                createCustomerCommandResponse.ValidationErrors = new List<string>();                
                foreach (var error in validatorResult.Errors)
                {
                    createCustomerCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (createCustomerCommandResponse.Success)
            {
                var @customer = _mapper.Map<Customer>(request);
                @customer = await _customerRepository.AddAsync(@customer);
                createCustomerCommandResponse.Customer = _mapper.Map<CreateCustomerDto>(customer);
            }
            
            return createCustomerCommandResponse;
        }
    }
}
