using FluentValidation;

namespace Contracts.Services.Catalog;

public class Validators
{
    public class CreateProductCommandValidator : AbstractValidator<Command.CreateProduct>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }

    public class DeleteProductByIdCommandValidator : AbstractValidator<Command.DeleteProductById>
    {
        public DeleteProductByIdCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Product ID is required");
        }
    }

    public class UpdateProductCommandValidator : AbstractValidator<Command.UpdateProduct>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty().WithMessage("Product ID is required");

            RuleFor(command => command.Name)
                .NotEmpty().WithMessage("Name is required")
                .Length(2, 150).WithMessage("Name must be between 2 and 150 characters");

            RuleFor(command => command.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }
}
