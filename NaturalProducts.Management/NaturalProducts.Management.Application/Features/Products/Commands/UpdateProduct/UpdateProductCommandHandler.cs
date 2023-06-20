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

namespace NaturalProducts.Management.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IAsyncRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IAsyncRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productToUpdate = await _productRepository.GetByIdAsync(request.ProductId);
            if (productToUpdate == null)
            {
                throw new NotFoundException(nameof(Product), request.ProductId);
            }

            var validator = new UpdateProductCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }

            _mapper.Map(request, productToUpdate, typeof(UpdateProductCommand), typeof(Product));

            await _productRepository.UpdateAsync(request.ProductId, productToUpdate);

            return Unit.Value;
        }
    }
}
