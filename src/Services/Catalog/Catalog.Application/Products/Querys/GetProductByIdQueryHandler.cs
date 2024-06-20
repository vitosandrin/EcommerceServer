using Contracts.Abstractions.CQRS;
using Contracts.Exceptions;
using Contracts.Services.Catalog;
using Contracts.DataTransferObjects;

using Marten;

namespace Catalog.Application.Products.Querys;

internal class GetProductByIdQueryHandler(IDocumentSession session) : IQueryHandler<Query.GetProductById, Query.Result.GetProductById>
{
    public async Task<Query.Result.GetProductById> Handle(Query.GetProductById query, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(query.Id, cancellationToken);

        if (product is null)
            throw new NotFoundException($"Product with id {query.Id} not found.");

        return new Query.Result.GetProductById(product);
    }
}
