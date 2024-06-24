using Contracts.Abstractions.CQRS;
using Contracts.DataTransferObjects;
using Contracts.Services.Basket;

namespace Basket.Application.Basket.Queries;

internal class GetBasketQueryHandler : IQueryHandler<Query.GetBasket, Query.Result.GetBasket>
{
    public async Task<Query.Result.GetBasket> Handle(Query.GetBasket query, CancellationToken cancellationToken)
    {
        return new Query.Result.GetBasket(new ShoppingCart());
    }
}
