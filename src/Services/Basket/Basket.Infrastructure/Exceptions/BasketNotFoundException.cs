using Contracts.Exceptions;

namespace Basket.Infrastructure.Exceptions;

public class BasketNotFoundException : NotFoundException
{
    public BasketNotFoundException(string userName) : base("Basket", userName)
    {

    }
}