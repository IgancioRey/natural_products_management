using MediatR;
using Microsoft.AspNetCore.Mvc;
using NaturalProducts.Management.Application.Features.Orders.Commands.CreateOrder;
using NaturalProducts.Management.Application.Features.Orders.Commands.DeleteOrder;
using NaturalProducts.Management.Application.Features.Orders.Commands.UpdateOrder;
using NaturalProducts.Management.Application.Features.Orders.Queries.GetOrdersList;

namespace NaturalProducts.Management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "AddOrder")]
        public async Task<ActionResult<CreateOrderCommandResponse>> Create([FromBody] CreateOrderCommand createOrderCommand)
        {
            var response = await _mediator.Send(createOrderCommand);

            return Ok(response);
        }

        [HttpGet("getorderslist", Name = "GetOrdersBetweenDates")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]

        public async Task<ActionResult<OrderListVm>> GetOrdersBetweenDates(DateTime? dateFrom, DateTime? dateTo)
        {
            var getOrdersBetweenDates = new GetOrdersListQuery() { DateFrom = dateFrom, DateTo = dateTo };
            var dtos = await _mediator.Send(getOrdersBetweenDates);

            return Ok(dtos);
        }

        [HttpPut(Name = "UpdateOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateOrderCommand updateOrderCommand)
        {
            await _mediator.Send(updateOrderCommand);

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(string id)
        {
            var deleteOrderCommand = new DeleteOrderCommand() { OrderId = id };
            await _mediator.Send(deleteOrderCommand);

            return NoContent();
        }
    }
}
