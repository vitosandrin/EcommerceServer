using Contracts.Abstractions.CQRS;
using Contracts.DataTransferObjects;
namespace Contracts.Services.Basket;

public class Query
{
    public record GetBasket(string UserName) : IQuery<Result.GetBasket>;
    public class Result
    {
        public record GetBasket(ShoppingCart Cart);
    }
}
