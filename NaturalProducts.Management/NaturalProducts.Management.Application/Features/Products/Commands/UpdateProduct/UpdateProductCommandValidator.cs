using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalProducts.Management.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator() 
        {
            RuleFor(c => c.Name).NotEmpty();

            RuleFor(c => c.Price)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");

            RuleFor(c => c.SellingPrice)
                .Must((model, price) => price > model.Price).WithMessage("{PropertyName} must be greater than Price.");
        }
    }
}
