using Contracts.DataTransferObjects;

namespace Contracts.Services.Basket;

public class Http
{
    public class Request
    {
        public record GetBasket(string Username);
        public record StoreBasket(ShoppingCart Cart);
        public record DeleteBasket(string UserName);
    }

    public class Response
    {
        public record GetBasket(ShoppingCart Cart);
        public record StoreBasket(ShoppingCart Cart);
        public record DeleteBasket(bool IsSuccess);
    }
}
