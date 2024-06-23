using Contracts.Abstractions.CQRS;
using Contracts.DataTransferObjects;
using Contracts.Exceptions;
using Contracts.Services.Catalog;
using Marten;

namespace Catalog.Application.Products.Commands;

internal class UpdateProductCommandHandler(IDocumentSession session) : ICommandHandler<Command.UpdateProduct, Command.Result.UpdateProduct>
{
    public async Task<Command.Result.UpdateProduct> Handle(Command.UpdateProduct command, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(command.Id, cancellationToken);

        if (product is null)
            throw new NotFoundException($"Product with id {command.Id} not found.");

        var productToUpdate = new Product()
        {
            Id = command.Id,
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            Price = command.Price
        };

        session.Update<Product>(productToUpdate);
        await session.SaveChangesAsync(cancellationToken);

        return new Command.Result.UpdateProduct(true);
    }
}
