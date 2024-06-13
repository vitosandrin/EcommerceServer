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
            new Product
            {
                Name = "Produto 1",
                Description = "Description1",
                Price = 100
            },
            new Product
            {
                Name = "Produto 2",
                Description = "Description2",
                Price = 2232
            }
        );
    }
}
