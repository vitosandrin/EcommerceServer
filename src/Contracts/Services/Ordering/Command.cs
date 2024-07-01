using Contracts.Abstractions.CQRS;
using Contracts.DataTransferObjects.Order;

namespace Contracts.Services.Ordering;

public class Command
{
    public record CreateOrder(Order Order)
    : ICommand<Result.CreateOrder>;

    public class Result
    {
        public record CreateOrder(Guid Id);

    }
}
