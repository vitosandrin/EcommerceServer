using Contracts.Abstractions.CQRS;
namespace Contracts.Services.Catalog;

public class Command
{
    public record CreateProduct(string Name, string Description, List<string> Category, long Price) : ICommand<Result.CreateProduct>;
    public record UpdateProduct(int Id, string Name, List<string> Category, string Description, long Price);
    public record DeleteProductById(int Id);
    public record GetProductById(int Id);
    public record GetProducts;

    public class Result
    {
        public record CreateProduct(int Id);
    }
}
