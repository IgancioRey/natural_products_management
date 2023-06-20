using MediatR;
using Microsoft.AspNetCore.Mvc;
using NaturalProducts.Management.Application.Features.Customers.Commands.CreateCustomer;
using NaturalProducts.Management.Application.Features.Customers.Commands.DeleteCustomer;
using NaturalProducts.Management.Application.Features.Customers.Commands.UpdateCustomer;
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

        [HttpPut(Name = "UpdateCustomer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateCustomerCommand updateCustomer)
        {
            await _mediator.Send(updateCustomer);

            return NoContent();
        }

        [HttpDelete("{id}", Name ="DeleteCustomer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(string id)
        {
            var deleteCustomerCommand = new DeleteCustomerCommand() { CustomerId = id };
            await _mediator.Send(deleteCustomerCommand);

            return NoContent();
        }
    }
}
