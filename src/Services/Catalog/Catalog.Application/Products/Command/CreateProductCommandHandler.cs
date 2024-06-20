using Marten;

using Contracts.Abstractions.CQRS;
using Contracts.Services.Catalog;
using Catalog.Domain.Entities;

namespace Catalog.Application.Products.Commands;

internal class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<Command.CreateProduct, Command.Result.CreateProduct>
{
    public async Task<Command.Result.CreateProduct> Handle(Command.CreateProduct command, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            Price = command.Price
        };

        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);

        return new Command.Result.CreateProduct(product.Id);
    }
}
