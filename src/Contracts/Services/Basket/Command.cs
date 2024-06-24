using Contracts.Abstractions.CQRS;
using Contracts.DataTransferObjects;

namespace Contracts.Services.Basket;

public class Command
{
    public record StoreBasket(ShoppingCart Cart) : ICommand<Result.StoreBasket>;
    public class Result
    {
        public record StoreBasket(bool IsSuccess);
    }
}
