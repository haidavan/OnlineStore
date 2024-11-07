using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Application.Interfaces;

namespace Store.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection
           services, IConfiguration configuration)
    {
        var connectionString = configuration["DbConnection"];
        services.AddDbContext<StoreDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
        services.AddScoped<IDbContext>(provider =>
            provider.GetService<StoreDbContext>());

        return services;
    }

}