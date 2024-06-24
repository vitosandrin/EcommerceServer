using Catalog.Domain.Abstractions;
using Contracts.Abstractions.CQRS;
using Contracts.Services.Catalog;

namespace Catalog.Application.Products.Queries;

internal class GetAllProductsQueryHandler(IProductRepository repository) : IQueryHandler<Query.GetAllProducts, Query.Result.GetAllProducts>
{
    private readonly IProductRepository _repository = repository;
    public async Task<Query.Result.GetAllProducts> Handle(Query.GetAllProducts query, CancellationToken cancellationToken)
    {
        var products = await _repository.GetAllProductsPaginated(query.PageNumber ?? 1, query.PageSize ?? 10, cancellationToken);
        return new Query.Result.GetAllProducts(products);
    }
}
