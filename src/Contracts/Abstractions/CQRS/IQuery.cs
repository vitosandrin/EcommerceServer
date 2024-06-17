using MediatR;

namespace Contracts.Abstractions.CQRS;
public interface IQuery<out TResponse> : IRequest<TResponse>
    where TResponse : notnull
{
}