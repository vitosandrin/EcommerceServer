using Catalog.API.Exceptions;
using Contracts.Abstractions.CQRS;
using Contracts.DataTransferObjects;
using Contracts.Services.Catalog;
using Marten;

namespace Catalog.Application.Products.Commands;

internal class UpdateProductCommandHandler(IDocumentSession session) : ICommandHandler<Command.UpdateProduct, Command.Result.UpdateProduct>
{
    public async Task<Command.Result.UpdateProduct> Handle(Command.UpdateProduct command, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(command.Id, cancellationToken);

        if (product is null)
            throw new ProductNotFoundException(command.Id);

        product.Name = command.Name;
        product.Category = command.Category;
        product.Description = command.Description;
        product.Price = command.Price;

        session.Update(product);
        await session.SaveChangesAsync(cancellationToken);

        return new Command.Result.UpdateProduct(true);
    }
}
