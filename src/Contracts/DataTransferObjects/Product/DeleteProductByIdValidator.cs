using Contracts.Services.Catalog;
using FluentValidation;

public class DeleteProductByIdCommandValidator : AbstractValidator<Command.DeleteProductById>
{
    public DeleteProductByIdCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Product ID is required");
    }
}