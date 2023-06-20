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
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductCommandResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var createProductCommandResponse = new CreateProductCommandResponse();     

            var validator = new CreateProductCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.Errors.Count > 0) 
            {
                createProductCommandResponse.Success = false;
                createProductCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validatorResult.Errors)
                {
                    createProductCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }                
            }

            if (createProductCommandResponse.Success)
            {
                var @product = _mapper.Map<Product>(request);
                @product = await _productRepository.AddAsync(@product);
                createProductCommandResponse.Product = _mapper.Map<CreateProductDto>(product);
            }


            return createProductCommandResponse;
        }
    }
}
