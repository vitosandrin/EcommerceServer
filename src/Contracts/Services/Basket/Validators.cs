﻿using FluentValidation;

namespace Contracts.Services.Basket;

public class Validators
{
    public class StoreBasketCommandValidator : AbstractValidator<Command.StoreBasket>
    {
        public StoreBasketCommandValidator()
        {
            RuleFor(x => x.Cart).NotNull().WithMessage("Cart can not be null");
            RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("UserName is requited");
        }
    }

    public class DeleteBasketCommandValidator : AbstractValidator<Command.DeleteBasket>
    {
        public DeleteBasketCommandValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is requited");
        }
    }


}
