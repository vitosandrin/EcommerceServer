using Contracts.Abstractions.CQRS;
using Contracts.Services.Catalog;
using Catalog.Domain.Abstractions;

namespace Catalog.Application.Products.Queries;

internal class GetProductByIdQueryHandler(IProductRepository repository) : IQueryHandler<Query.GetProductById, Query.Result.GetProductById>
{
    private readonly IProductRepository _repository = repository;
    public async Task<Query.Result.GetProductById> Handle(Query.GetProductById query, CancellationToken cancellationToken)
    {
        var product = await _repository.GetProductById(query.Id, cancellationToken);

        return new Query.Result.GetProductById(product);
    }
}
