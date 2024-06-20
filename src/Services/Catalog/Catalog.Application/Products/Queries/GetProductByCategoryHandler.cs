using Contracts.Abstractions.CQRS;
using Contracts.Services.Catalog;
using Contracts.DataTransferObjects;

using Marten;

namespace Catalog.Application.Products.Queries;

internal class GetProductByCategoryHandler(IDocumentSession session) : IQueryHandler<Query.GetProductsByCategory, Query.Result.GetProductsByCategory>
{
    public async Task<Query.Result.GetProductsByCategory> Handle(Query.GetProductsByCategory query, CancellationToken cancellationToken)
    {
        var products = await session.Query<Product>()
                   .Where(p => p.Category.Contains(query.Category))
                   .ToListAsync(cancellationToken);

        return new Query.Result.GetProductsByCategory(products);
    }
}
