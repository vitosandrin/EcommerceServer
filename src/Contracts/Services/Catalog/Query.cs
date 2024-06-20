using Contracts.Abstractions.CQRS;
using Contracts.DataTransferObjects;

namespace Contracts.Services.Catalog;

public class Query
{
    public record GetAllProducts() : IQuery<Result.GetAllProducts>;
    public record GetProductById(Guid Id) : IQuery<Result.GetProductById>;

    public class Result
    {
        public record GetAllProducts(IEnumerable<Product> Products);
        public record GetProductById(Product Product);
    }
}
