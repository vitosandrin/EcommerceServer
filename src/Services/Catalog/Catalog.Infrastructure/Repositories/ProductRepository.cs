using Catalog.Domain.Abstractions;
using Catalog.Infrastructure.Exceptions;
using Contracts.DataTransferObjects;
using Marten;
using Marten.Pagination;

namespace Catalog.Infrastructure.Repositories;

public class ProductRepository(IDocumentSession session) : IProductRepository
{
    private readonly IDocumentSession _session = session;
    public async Task<IEnumerable<Product>> GetAllProductsPaginated(int PageNumber, int PageSize, CancellationToken cancellationToken)
    {
        return await _session.Query<Product>()
                           .ToPagedListAsync(PageNumber, PageSize, cancellationToken);
    }

    public async Task<Product> GetProductById(Guid Id, CancellationToken cancellationToken)
    {
        var product = await _session.LoadAsync<Product>(Id, cancellationToken);

        if (product is null)
            throw new ProductNotFoundException(Id);

        return product;
    }

    public async Task<IEnumerable<Product>> GetProductByCategory(string Category, CancellationToken cancellationToken)
    {
        return await _session.Query<Product>()
                   .Where(p => p.Category.Contains(Category))
                   .ToListAsync(cancellationToken);
    }

    public async Task<Guid> CreateProduct(Product Product, CancellationToken cancellationToken)
    {
        _session.Store(Product);
        await _session.SaveChangesAsync(cancellationToken);
        return Product.Id;
    }

    public async Task<bool> UpdateProduct(Product Product, CancellationToken cancellationToken)
    {
        var product = await _session.LoadAsync<Product>(Product.Id, cancellationToken);

        if (product is null)
            throw new ProductNotFoundException(Product.Id);

        product.Name = Product.Name;
        product.Category = Product.Category;
        product.Description = Product.Description;
        product.Price = Product.Price;

        _session.Update(product);
        await _session.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> DeleteProduct(Guid Id, CancellationToken cancellationToken)
    {
        var product = await _session.LoadAsync<Product>(Id, cancellationToken);

        if (product is null)
            throw new ProductNotFoundException(Id);

        _session.Delete<Product>(Id);

        await _session.SaveChangesAsync(cancellationToken);
        return true;
    }
}
