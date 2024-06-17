using Contracts.Abstractions.CQRS;
using Contracts.DataTransferObjects;
using Contracts.Services.Catalog;

namespace Catalog.Application.Products.Commands;

internal class CreateProductCommandHandler : ICommandHandler<Command.CreateProduct, Command.Result.CreateProduct>
{
    public async Task<Command.Result.CreateProduct> Handle(Command.CreateProduct command, CancellationToken cancellationToken)
    {
        var product = new Product(command.Name, command.Category, command.Description, command.Price);

        Console.WriteLine($"Product {product.Name} created");

        return new Command.Result.CreateProduct(1);
    }
}
