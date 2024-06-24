using Contracts.Abstractions.CQRS;
using Contracts.DataTransferObjects;

namespace Contracts.Services.Basket;

public class Command
{
    public record StoreBasket(ShoppingCart Cart) : ICommand<Result.StoreBasket>;
    public record DeleteBasket(string UserName) : ICommand<Result.DeleteBasket>;
    public class Result
    {
        public record StoreBasket(string UserName);
        public record DeleteBasket(bool IsSuccess);
    }
}
