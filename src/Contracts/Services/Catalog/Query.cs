using Contracts.Abstractions.CQRS;
using Contracts.DataTransferObjects;

namespace Contracts.Services.Catalog;

public class Query
{
    public record GetAllProducts(int? PageNumber = 1, int? PageSize = 10) : IQuery<Result.GetAllProducts>;
    public record GetProductById(Guid Id) : IQuery<Result.GetProductById>;
    public record GetProductsByCategory(string Category) : IQuery<Result.GetProductsByCategory>;

    public class Result
    {
        public record GetAllProducts(IEnumerable<Product> Products);
        public record GetProductById(Product Product);
        public record GetProductsByCategory(IEnumerable<Product> Products);

    }
}
