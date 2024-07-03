using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.DTOs.Validators
{
    /// <summary>
    /// Validator for ProductDto.
    /// </summary>
    public class ProductValidator : AbstractValidator<ProductDTO>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductDtoValidator"/> class.
        /// </summary>
        public ProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(100).WithMessage("Product name must not exceed 100 characters.");

            RuleFor(d => d.Description)
                .NotEmpty().WithMessage("Product description is required.");

            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("Product price must be greater than zero.");

            RuleFor(q => q.Quantity)
                .GreaterThan(0).WithMessage("Product quantity must be zero or greater.");

            RuleFor(url => url.UrlImage)
                .NotEmpty().WithMessage("Product image is rquired.")
                .Must(uri => Uri.IsWellFormedUriString(uri, UriKind.Absolute)).WithMessage("Invalid URL format.");
                
        
        }  
    }
}
