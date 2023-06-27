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

namespace NaturalProducts.Management.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IAsyncRepository<Order> _orderRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public UpdateOrderCommandHandler(IAsyncRepository<Order> orderRepository, ICustomerRepository customerRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var orderToUpdate = await _orderRepository.GetByIdAsync(request.CustomerId);
            if (orderToUpdate == null)
            {
                throw new NotFoundException(nameof(Order), request.OrderId);
            }

            var validator = new UpdateOrderCommandValidator(_customerRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }

            _mapper.Map(request, orderToUpdate, typeof(UpdateOrderCommand), typeof(Order));

            await _orderRepository.UpdateAsync(request.OrderId, orderToUpdate);

            return Unit.Value;
        }
    }
}
