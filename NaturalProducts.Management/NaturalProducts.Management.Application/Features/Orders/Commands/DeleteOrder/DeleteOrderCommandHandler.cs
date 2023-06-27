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

namespace NaturalProducts.Management.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private IAsyncRepository<Order> _orderRepository;
        private IMapper _mapper;

        public DeleteOrderCommandHandler(IAsyncRepository<Order> orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var orderToDelete = await _orderRepository.GetByIdAsync(request.OrderId);

            if(orderToDelete == null)
            {
                throw new NotFoundException(nameof(Order), request.OrderId);
            }

            await _orderRepository.DeleteAsync(orderToDelete.OrderId);

            return Unit.Value;
        }
    }
}
