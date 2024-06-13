namespace Contracts.Abstractions;

public interface IUnityOfWork
{
    Task<int> SaveChangesAsync();
    void BeginTransaction();
    void CommitTransaction();
    void RollbackTransaction();
}
