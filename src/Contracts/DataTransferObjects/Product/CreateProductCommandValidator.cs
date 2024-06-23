﻿using Contracts.Services.Catalog;
using FluentValidation;

namespace Contracts.DataTransferObjects;

public class CreateProductCommandValidator : AbstractValidator<Command.CreateProduct>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
    }
}