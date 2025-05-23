using System.Diagnostics.CodeAnalysis;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginServiceCollectionHostedService
{
    static readonly string BaseType = "Microsoft.Extensions.DependencyInjection.ServiceCollectionHostedServiceExtensions,Microsoft.Extensions.Hosting.Abstractions";

    public static object? AddHostedService<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] THostedService>(this object? services)
        where THostedService : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddHostedService)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == "services"
            && x.GetGenericArguments()[0].Name == "THostedService"
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod([typeof(THostedService)]);
        var result = method?.Invoke(null, [services]);
        return result;
    }

    public static object? AddHostedService<THostedService>(this object? services, Func<IServiceProvider, THostedService> implementationFactory)
        where THostedService : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddHostedService)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == "services"
            && x.GetParameters()[1].Name == "implementationFactory"
            && x.GetGenericArguments()[0].Name == "THostedService"
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod([typeof(THostedService)]);
        var result = method?.Invoke(null, [services, implementationFactory]);
        return result;
    }
}
