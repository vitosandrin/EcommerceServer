using Contracts.Exceptions;

namespace Basket.Infrastructure.Exceptions;

public class BasketNotFoundException(string userName) : NotFoundException("Basket", userName)
{
}