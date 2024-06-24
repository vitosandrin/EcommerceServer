using Catalog.Domain.Abstractions;
using Contracts.Abstractions.CQRS;
using Contracts.DataTransferObjects;
using Contracts.Services.Catalog;
namespace Catalog.Application.Products.Commands;

internal class CreateProductCommandHandler(IProductRepository repository) : ICommandHandler<Command.CreateProduct, Command.Result.CreateProduct>
{
    private readonly IProductRepository _repository = repository;
    public async Task<Command.Result.CreateProduct> Handle(Command.CreateProduct command, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            Price = command.Price
        };

        var result = await _repository.CreateProduct(product, cancellationToken);

        return new Command.Result.CreateProduct(result);
    }
}
