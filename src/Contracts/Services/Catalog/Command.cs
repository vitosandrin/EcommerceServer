using Contracts.Abstractions.CQRS;

namespace Contracts.Services.Catalog;
public class Command
{
    public record CreateProduct(string Name, string Description, List<string> Category, long Price) : ICommand<Result.CreateProduct>;
    public record UpdateProduct(Guid Id, string Name, List<string> Category, string Description, long Price) : ICommand<Result.UpdateProduct>;
    public record DeleteProductById(Guid Id) : ICommand<Result.DeleteProductById>;

    public class Result
    {
        public record CreateProduct(Guid Id);
        public record DeleteProductById(bool IsSuccess);
        public record UpdateProduct(bool IsSuccess);

    }
}
