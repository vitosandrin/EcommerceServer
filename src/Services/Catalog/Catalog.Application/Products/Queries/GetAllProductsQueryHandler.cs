using Contracts.Abstractions.CQRS;
using Contracts.DataTransferObjects;
using Contracts.Services.Catalog;
using Marten;
using Marten.Pagination;

namespace Catalog.Application.Products.Queries;

internal class GetAllProductsQueryHandler(IDocumentSession session) : IQueryHandler<Query.GetAllProducts, Query.Result.GetAllProducts>
{
    public async Task<Query.Result.GetAllProducts> Handle(Query.GetAllProducts query, CancellationToken cancellationToken)
    {
        var products = await session.Query<Product>()
                    .ToPagedListAsync(query.PageNumber ?? 1, query.PageSize ?? 10, cancellationToken);
        return new Query.Result.GetAllProducts(products);
    }
}
