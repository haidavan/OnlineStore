using Store.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Persistence.EntityTypesConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(product => product.Id);
        builder.HasIndex(product => product.Id).IsUnique();
        builder.Property(product => product.Article).HasMaxLength(9).IsFixedLength();
        builder.Property(product=> product.Name).HasMaxLength(50);
        builder.Property(product=>product.Description).HasMaxLength(500);        
    }
}