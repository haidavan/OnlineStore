using Microsoft.EntityFrameworkCore;
using Store.Domain;
namespace Store.Application.Interfaces;

internal interface IDbContext
{
    DbSet<Product> Products { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
