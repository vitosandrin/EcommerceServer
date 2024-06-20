using Contracts.Abstractions.CQRS;
using Contracts.DataTransferObjects;
using Contracts.Services.Catalog;
using Marten;

namespace Catalog.Application.Products.Queries;

internal class GetAllProductsQueryHandler(IDocumentSession session) : IQueryHandler<Query.GetAllProducts, Query.Result.GetAllProducts>
{
    public async Task<Query.Result.GetAllProducts> Handle(Query.GetAllProducts query, CancellationToken cancellationToken)
    {
        //TODO: ERROR AmbiguousDocumentTypeAliasesException (BECAUSE USING Product Contract AND Product Entity MAPPING TO SAME ALIAS)
        var products = await session.Query<Product>().ToListAsync(cancellationToken);

        return new Query.Result.GetAllProducts(products);
    }
}
