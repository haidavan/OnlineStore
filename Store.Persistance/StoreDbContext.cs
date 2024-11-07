using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces;
using Store.Domain;
using Store.Persistence.EntityTypesConfigurations;

namespace Store.Persistence;

public class StoreDbContext(DbContextOptions<StoreDbContext> options) : DbContext(options), IDbContext
{
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}