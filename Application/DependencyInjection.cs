using Application.Contracts;
using Application.Contracts.Handlers;
using Application.Handlers;
using Application.Repositories;
using Application.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationSettings(this IServiceCollection services)
    {
        return services
            .AddConnectionStringsSettings();
    }

    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
    {
        return services
            .AddScoped<IUsersRepository, UsersRepository>()
            .AddScoped<IFindUserByEmailAddressHandler, FindUserByEmailAddressHandler>()
            .AddScoped<ICreateNewUserHandler, CreateNewUserHandler>();
    }

    private static IServiceCollection AddConnectionStringsSettings(this IServiceCollection services)
    {
        services
            .AddOptions<ConnectionStrings>()
            .BindConfiguration(ConnectionStrings.SectionPath)
            .ValidateOnStart();

        services
            .TryAddSingleton<IConnectionStrings>(sp => sp.GetRequiredService<IOptions<ConnectionStrings>>().Value);

        return services;
    }
}