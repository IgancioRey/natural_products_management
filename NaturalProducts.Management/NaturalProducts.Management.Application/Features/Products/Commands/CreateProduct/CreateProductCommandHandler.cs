using AutoMapper;
using MediatR;
using MongoDB.Bson;
using NaturalProducts.Management.Application.Contracts.Persistence;
using NaturalProducts.Management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalProducts.Management.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, string>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var @product = _mapper.Map<Product>(request);

            var validator = new CreateProductCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.Errors.Count > 0) 
            {
                throw new Exceptions.ValidationException(validatorResult);
            }

            @product = await _productRepository.AddAsync(@product);

            return product.ProductId;
        }
    }
}
