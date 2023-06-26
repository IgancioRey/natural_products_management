using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MongoDB.Driver.Linq;
using NaturalProducts.Management.Application.Contracts.Persistence;
using NaturalProducts.Management.Application.Exceptions;
using NaturalProducts.Management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NaturalProducts.Management.Application.Features.Orders.Queries.GetOrdersList
{
    public class GetOrdersListQueryHandler : IRequestHandler<GetOrdersListQuery, List<OrderListVm>>
    {
        private readonly IOrderRepository _orderRepository;        
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Customer> _customerRepository;

        public GetOrdersListQueryHandler(IOrderRepository orderRepository, IMapper mapper, IAsyncRepository<Customer> customerRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<List<OrderListVm>> Handle(GetOrdersListQuery request, CancellationToken cancellationToken)
        {
            var allOrders = await _orderRepository.GetOrdersBetweenDates(request.DateFrom, request.DateTo);

            foreach (var order in allOrders)
            {
                var customer = await _customerRepository.GetByIdAsync(order.CustomerId);
                if (customer == null)
                {
                    throw new NotFoundException(nameof(Customer), order.CustomerId);
                }
                order.Customer = _mapper.Map<Customer>(customer);
            }

            return _mapper.Map<List<OrderListVm>>(allOrders);
        }
    }
}
