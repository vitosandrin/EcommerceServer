using Microsoft.EntityFrameworkCore;

using Contracts.DataTransferObjects;
using Catalog.Infrastructure.Data.EntityConfiguration;

namespace Catalog.Infrastructure.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
    }
}