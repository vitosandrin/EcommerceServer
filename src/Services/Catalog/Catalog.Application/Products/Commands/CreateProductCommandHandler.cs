using Contracts.DataTransferObjects;
using Contracts.Services.Catalog;
using MediatR;

namespace Catalog.Application.Products.Commands;

internal class CreateProductCommandHandler : IRequestHandler<Command.CreateProduct, Command.Result.CreateProduct>
{
    public async Task<Command.Result.CreateProduct> Handle(Command.CreateProduct request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
