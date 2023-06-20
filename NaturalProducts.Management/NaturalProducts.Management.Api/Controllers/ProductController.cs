using MediatR;
using Microsoft.AspNetCore.Mvc;
using NaturalProducts.Management.Application.Features.Products.Commands.CreateProduct;
using NaturalProducts.Management.Application.Features.Products.Commands.DeleteProduct;
using NaturalProducts.Management.Application.Features.Products.Commands.UpdateProduct;
using NaturalProducts.Management.Application.Features.Products.Queries.GetProductsList;

namespace NaturalProducts.Management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ProductListVm>>> GetAllProducts()
        {
            var dtos = await _mediator.Send(new GetProductsListQuery());
            return Ok(dtos);
        }

        [HttpPost(Name ="AddProduct")]
        public async Task<ActionResult<CreateProductCommandResponse>> Create
            ([FromBody] CreateProductCommand createProductCommand)
        {
            var response = await _mediator.Send(createProductCommand);

            return Ok(response);
        }

        [HttpPut(Name ="UpdateProduct")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateProductCommand updateProductCommand)
        {
            await _mediator.Send(updateProductCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteProduct")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(string id)
        {
            var deleteProductCommand = new DeleteProductCommand() { ProductId = id };
            await _mediator.Send(deleteProductCommand);

            return NoContent();
        }
    }
}
