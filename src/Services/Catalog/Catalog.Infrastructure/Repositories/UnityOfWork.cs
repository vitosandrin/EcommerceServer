using Catalog.Infrastructure.Context;
using Contracts.Abstractions;

namespace Catalog.Infrastructure.Repositories;

public class UnityOfWork(AppDbContext context) : IUnityOfWork
{
    private readonly AppDbContext _context = context;
    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}