namespace Contracts.Abstractions;

public interface IUnityOfWork
{
    Task CommitAsync();
}
