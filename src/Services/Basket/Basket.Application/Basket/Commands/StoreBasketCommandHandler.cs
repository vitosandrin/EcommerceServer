using Basket.Domain.Abstractions;
using Contracts.Abstractions.CQRS;
using Contracts.DataTransferObjects;
using Contracts.Services.Basket;
using Discount.gRPC;

namespace Basket.Application.Basket.Commands;

internal class StoreBasketCommandHandler
    (IBasketRepository repository,
     DiscountProtoService.DiscountProtoServiceClient proto)
    : ICommandHandler<Command.StoreBasket, Command.Result.StoreBasket>
{
    private readonly IBasketRepository _basketRepository = repository;
    private readonly DiscountProtoService.DiscountProtoServiceClient _proto = proto;
    public async Task<Command.Result.StoreBasket> Handle(Command.StoreBasket command, CancellationToken cancellationToken)
    {
        await DeductDiscount(command.Cart, cancellationToken);

        var basket = await _basketRepository.StoreBasket(command.Cart, cancellationToken);

        return new Command.Result.StoreBasket(basket);
    }

    private async Task DeductDiscount(ShoppingCart cart, CancellationToken cancellationToken)
    {
        foreach (var item in cart.Items)
        {
            var coupon = await _proto.GetDiscountAsync(new GetDiscountRequest { ProductName = item.ProductName }, cancellationToken: cancellationToken);
            item.Price -= coupon.Amount;
            item.Discount = coupon.Amount;
        }
    }
}