using Application.Contracts;
using Infrastructure.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddStorage(this IServiceCollection services)
    {
        services
            .AddDbContext<StorageContext>();

        services
            .TryAddScoped<IStorageContext>(sp => sp.GetRequiredService<StorageContext>());

        return services;
    }
}