using FluentValidation;

namespace Contracts.DataTransferObjects.Product;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(product => product.Name)
            .NotNull()
            .NotEmpty();

        RuleFor(product => product.Price)
            .NotNull()
            .NotEmpty();

        RuleFor(product => product.Description)
            .NotNull()
            .NotEmpty();
    }
}