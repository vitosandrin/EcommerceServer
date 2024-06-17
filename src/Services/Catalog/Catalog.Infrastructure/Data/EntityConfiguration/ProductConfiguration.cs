using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Contracts.DataTransferObjects;

namespace Catalog.Infrastructure.Data.EntityConfiguration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(product => product.Id);
        builder.Property(product => product.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(product => product.Description)
            .IsRequired()
            .HasMaxLength(500);
        builder.Property(product => product.Price)
            .IsRequired();

        builder.HasData(
            new Product(1, "product0", "description0", 10),
            new Product(2, "product1", "description1", 123)
        );
    }
}
