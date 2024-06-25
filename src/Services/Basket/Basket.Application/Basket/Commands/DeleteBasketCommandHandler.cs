using Basket.Domain.Abstractions;
using Contracts.Abstractions.CQRS;
using Contracts.Services.Basket;

namespace Basket.Application.Basket.Commands;

internal class DeleteBasketCommandHandler(IBasketRepository repository) : ICommandHandler<Command.DeleteBasket, Command.Result.DeleteBasket>
{
    private readonly IBasketRepository _basketRepository = repository;
    public async Task<Command.Result.DeleteBasket> Handle(Command.DeleteBasket command, CancellationToken cancellationToken)
    {
        await _basketRepository.DeleteBasket(command.UserName, cancellationToken);

        return new Command.Result.DeleteBasket(true);
    }
}
