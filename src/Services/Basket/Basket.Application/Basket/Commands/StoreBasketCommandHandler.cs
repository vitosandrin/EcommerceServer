using Basket.Domain.Abstractions;
using Contracts.Abstractions.CQRS;
using Contracts.Services.Basket;

namespace Basket.Application.Basket.Commands;

internal class StoreBasketCommandHandler(IBasketRepository repository) : ICommandHandler<Command.StoreBasket, Command.Result.StoreBasket>
{
    private readonly IBasketRepository _basketRepository = repository;
    public async Task<Command.Result.StoreBasket> Handle(Command.StoreBasket command, CancellationToken cancellationToken)
    {
        await _basketRepository.StoreBasket(command.Cart, cancellationToken);

        return new Command.Result.StoreBasket(command.Cart.UserName);
    }
}
