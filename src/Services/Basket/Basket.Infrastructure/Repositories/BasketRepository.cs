using Basket.Infrastructure.Abstractions;
using Basket.Infrastructure.Exceptions;
using Contracts.DataTransferObjects;
using Marten;

namespace Basket.Infrastructure.Repositories;

public class BasketRepository(IDocumentSession session) : IBasketRepository
{
    private readonly IDocumentSession _session = session;
    public async Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken = default)
    {
        var basket = await _session.LoadAsync<ShoppingCart>(userName, cancellationToken);

        return basket is null ? throw new BasketNotFoundException(userName) : basket;
    }

    public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default)
    {
        _session.Store(basket);
        await _session.SaveChangesAsync(cancellationToken);
        return basket;
    }

    public async Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default)
    {
        _session.Delete<ShoppingCart>(userName);
        await _session.SaveChangesAsync(cancellationToken);
        return true;
    }
}
