using Catalog.Domain.Abstractions;
using Contracts.Abstractions.CQRS;
using Contracts.DataTransferObjects;
using Contracts.Services.Catalog;

namespace Catalog.Application.Products.Commands;

internal class UpdateProductCommandHandler(IProductRepository repository) : ICommandHandler<Command.UpdateProduct, Command.Result.UpdateProduct>
{
    private readonly IProductRepository _repository = repository;
    public async Task<Command.Result.UpdateProduct> Handle(Command.UpdateProduct command, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Id = command.Id,
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            Price = command.Price
        };

        var result = await _repository.UpdateProduct(product, cancellationToken);

        return new Command.Result.UpdateProduct(result);
    }
}
