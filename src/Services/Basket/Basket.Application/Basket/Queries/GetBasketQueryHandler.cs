using Basket.Domain.Abstractions;
using Contracts.Abstractions.CQRS;
using Contracts.Services.Basket;

namespace Basket.Application.Basket.Queries;

internal class GetBasketQueryHandler(IBasketRepository repository) : IQueryHandler<Query.GetBasket, Query.Result.GetBasket>
{
    private readonly IBasketRepository _basketRepository = repository;
    public async Task<Query.Result.GetBasket> Handle(Query.GetBasket query, CancellationToken cancellationToken)
    {
        var basket = await _basketRepository.GetBasket(query.UserName, cancellationToken);

        return new Query.Result.GetBasket(basket);
    }
}
