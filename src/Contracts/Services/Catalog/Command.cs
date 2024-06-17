using MediatR;

namespace Contracts.Services.Catalog;

public class Command
{
    public record CreateProduct(string Name, string Description, List<string> Category, long Price) : IRequest<Result.CreateProduct>;
    public record UpdateProduct(int Id, string Name, List<string> Category, string Description, long Price) : IRequest<int>;
    public record DeleteProductById(int Id) : IRequest<int>;
    public record GetProductById(int Id) : IRequest<int>;
    public record GetProducts : IRequest<int>;

    public class Result
    {
        public record CreateProduct(int Id);
    }
}
