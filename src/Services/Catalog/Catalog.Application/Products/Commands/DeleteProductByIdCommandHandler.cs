using Catalog.Domain.Abstractions;
using Contracts.Abstractions.CQRS;
using Contracts.Services.Catalog;

namespace Catalog.Application.Products.Commands;

internal class DeleteProductByIdCommandHandler(IProductRepository repository) : ICommandHandler<Command.DeleteProductById, Command.Result.DeleteProductById>
{
    private readonly IProductRepository _repository = repository;
    public async Task<Command.Result.DeleteProductById> Handle(Command.DeleteProductById command, CancellationToken cancellationToken)
    {
        var result = await _repository.DeleteProduct(command.Id, cancellationToken);

        return new Command.Result.DeleteProductById(result);
    }
}
