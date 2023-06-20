using MediatR;
using Microsoft.AspNetCore.Mvc;
using NaturalProducts.Management.Application.Features.Customers.Commands.CreateCustomer;
using NaturalProducts.Management.Application.Features.Customers.Queries.GetCustomersList;

namespace NaturalProducts.Management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllCustomers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CustomerListVm>>> GetAllCustomers()
        {
            var dtos = await _mediator.Send(new GetCustomersListQuery());

            return Ok(dtos);
        }

        [HttpPost(Name = "AddCustomer")]
        public async Task<ActionResult<CreateCustomerCommandResponse>> Create
            ([FromBody] CreateCustomerCommand createCustomer)
        {
            var response = await _mediator.Send(createCustomer);

            return Ok(response);
        }


    }
}
