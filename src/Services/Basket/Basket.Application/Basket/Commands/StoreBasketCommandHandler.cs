using Contracts.Abstractions.CQRS;
using Contracts.Services.Basket;

namespace Basket.Application.Basket.Commands;

internal class StoreBasketCommandHandler : ICommandHandler<Command.StoreBasket, Command.Result.StoreBasket>
{
    public async Task<Command.Result.StoreBasket> Handle(Command.StoreBasket command, CancellationToken cancellationToken)
    {
        return new Command.Result.StoreBasket(true);
    }
}
