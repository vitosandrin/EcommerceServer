using Contracts.DataTransferObjects;

namespace Contracts.Services.Basket;

public class Http
{
    public class Request
    {
        public record GetBasket(string Username);
    }

    public class Response
    {
        public record GetBasket(ShoppingCart Cart);

    }
}
