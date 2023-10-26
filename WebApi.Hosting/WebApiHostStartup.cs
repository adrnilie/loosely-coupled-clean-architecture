using Application;
using Infrastructure;

namespace WebApi.Hosting;

internal static class WebApiHostStartup
{
    public static IServiceCollection AddSettings(this IServiceCollection services)
    {
        return services
            .AddApplicationSettings();
    }

    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        return services
            .AddApplicationDependencies();
    }

    public static IServiceCollection AddPorts(this IServiceCollection services)
    {
        return services
            .AddStorage();
    }
}