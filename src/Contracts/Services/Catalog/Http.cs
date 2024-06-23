using Contracts.DataTransferObjects;

namespace Contracts.Services.Catalog;

public class Http
{
    public class Request
    {
        public record CreateProduct(string Name, List<string> Category, string Description, decimal Price);
        public record GetAllProducts(int? PageNumber = 1, int? PageSize = 10);
        public record GetProductById(Guid Id);
        public record GetProductByCategory(string Category);
        public record DeleteProductById(Guid Id);
        public record UpdateProduct(Guid Id, string Name, List<string> Category, string Description, long Price);
    }
    public class Response
    {
        public record CreateProduct(Guid Id);
        public record GetAllProducts(IEnumerable<Product> Products);
        public record GetProductById(Product Product);
        public record GetProductsByCategory(IEnumerable<Product> Products);
        public record DeleteProductById(bool IsSuccess);
        public record UpdateProduct(bool IsSuccess);
    }
}
