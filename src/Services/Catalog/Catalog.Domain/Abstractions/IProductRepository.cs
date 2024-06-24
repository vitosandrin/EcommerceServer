using Contracts.Abstractions;
using Contracts.DataTransferObjects;

namespace Catalog.Domain.Abstractions;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllProductsPaginated(int PageNumber, int PageSize, CancellationToken cancellationToken);
    Task<Product> GetProductById(Guid Id, CancellationToken cancellationToken);
    Task<IEnumerable<Product>> GetProductByCategory(string Category, CancellationToken cancellationToken);
    Task<Guid> CreateProduct(Product Product, CancellationToken cancellationToken);
    Task<bool> UpdateProduct(Product Product, CancellationToken cancellationToken);
    Task<bool> DeleteProduct(Guid Id, CancellationToken cancellationToken);
}
