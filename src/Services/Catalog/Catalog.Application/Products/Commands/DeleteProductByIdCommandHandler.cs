using Contracts.Abstractions.CQRS;
using Contracts.DataTransferObjects;
using Contracts.Exceptions;
using Contracts.Services.Catalog;
using Marten;

namespace Catalog.Application.Products.Commands;

internal class DeleteProductByIdCommandHandler(IDocumentSession session) : ICommandHandler<Command.DeleteProductById, Command.Result.DeleteProductById>
{
    public async Task<Command.Result.DeleteProductById> Handle(Command.DeleteProductById command, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(command.Id, cancellationToken);

        if (product is null)
            throw new NotFoundException($"Product with id {command.Id} not found.");

        session.Delete<Product>(command.Id);

        await session.SaveChangesAsync(cancellationToken);

        return new Command.Result.DeleteProductById(true);
    }
}
