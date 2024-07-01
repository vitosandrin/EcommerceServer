using Contracts.Abstractions.CQRS;
using Contracts.Services.Ordering;
using Ordering.Infrastructure.Abstractions;

namespace Ordering.Application.Orders.Commands;
public class CreateOrderHandler(IApplicationDbContext dbContext)
    : ICommandHandler<Command.CreateOrder, Command.Result.CreateOrder>
{
    private readonly IApplicationDbContext _dbContext = dbContext;
    public Task<Command.Result.CreateOrder> Handle(Command.CreateOrder request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}