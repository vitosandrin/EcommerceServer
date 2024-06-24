using Contracts.Exceptions;

namespace Catalog.Infrastructure.Exceptions;

public class ProductNotFoundException(Guid Id) : NotFoundException("Product", Id)
{
}