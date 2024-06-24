using Contracts.Abstractions.CQRS;
using Contracts.Services.Catalog;
using Catalog.Domain.Abstractions;

namespace Catalog.Application.Products.Queries;

internal class GetProductByCategoryHandler(IProductRepository repository) : IQueryHandler<Query.GetProductsByCategory, Query.Result.GetProductsByCategory>
{
    private readonly IProductRepository _repository = repository;
    public async Task<Query.Result.GetProductsByCategory> Handle(Query.GetProductsByCategory query, CancellationToken cancellationToken)
    {
        var products = await _repository.GetProductByCategory(query.Category, cancellationToken);

        return new Query.Result.GetProductsByCategory(products);
    }
}
