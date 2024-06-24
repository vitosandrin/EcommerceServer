using Contracts.Abstractions.CQRS;
using Contracts.Services.Basket;

namespace Basket.Application.Basket.Commands;

internal class DeleteBasketCommandHandler : ICommandHandler<Command.DeleteBasket, Command.Result.DeleteBasket>
{
    public async Task<Command.Result.DeleteBasket> Handle(Command.DeleteBasket command, CancellationToken cancellationToken)
    {
        return new Command.Result.DeleteBasket(true);
    }
}
