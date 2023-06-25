using AutoMapper;
using MediatR;
using NaturalProducts.Management.Application.Contracts.Persistence;
using NaturalProducts.Management.Domain.Entities;

namespace NaturalProducts.Management.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderCommandResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, 
            ICustomerRepository customerRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var createOrderCommandResponse = new CreateOrderCommandResponse();

            var validator = new CreateOrderCommandValidator(_customerRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createOrderCommandResponse.Success = false;
                createOrderCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createOrderCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (createOrderCommandResponse.Success)
            {
                var order = _mapper.Map<Order>(request);
                order = await _orderRepository.AddAsync(order);

                createOrderCommandResponse.Order = _mapper.Map<CreateOrderDto>(order);
            }

            return createOrderCommandResponse;
        }
    }
}
