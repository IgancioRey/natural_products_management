using MediatR;
using Microsoft.AspNetCore.Mvc;
using NaturalProducts.Management.Application.Features.Orders.Commands.CreateOrder;

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
    }
}
