using Contracts.Abstractions.CQRS;
namespace Contracts.Services.Catalog;

public class Command
{
    public record CreateProduct(string Name, string Description, List<string> Category, long Price) : ICommand<Result.CreateProduct>;
    public record UpdateProduct(Guid Id, string Name, List<string> Category, string Description, long Price);
    public record DeleteProductById(Guid Id);

    public class Result
    {
        public record CreateProduct(Guid Id);
    }
}
