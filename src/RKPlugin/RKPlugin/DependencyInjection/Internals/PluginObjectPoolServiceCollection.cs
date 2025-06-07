using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginObjectPoolServiceCollection
{
    static readonly string BaseType = "Microsoft.Extensions.DependencyInjection.ObjectPoolServiceCollectionExtensions,Microsoft.Extensions.ObjectPool.DependencyInjection";

    public static object? AddPooled<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services, Action<object?>? configure = null) where TService : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddPooled)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(configure)
            && x.GetParameters()[1].HasDefaultValue
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TService));
        var result = method?.Invoke(null, [services, configure]);
        return result;
    }

    public static object? AddPooled<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services, Action<object?>? configure = null) 
        where TService : class 
        where TImplementation : class, TService
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddPooled)
            && x.GetGenericArguments().Length == 2
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(configure)
            && x.GetParameters()[1].HasDefaultValue
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TService), typeof(TImplementation));
        var result = method?.Invoke(null, [services, configure]);
        return result;
    }

    public static object? ConfigurePool<TService>(this object? services, Action<object?> configure) where TService : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(ConfigurePool)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(configure)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TService));
        var result = method?.Invoke(null, [services, configure]);
        return result;
    }

    public static object? ConfigurePools(this object? services, object? section)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(ConfigurePools)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(section)
        ).FirstOrDefault();
        var method = methodInfo;
        var result = method?.Invoke(null, [services, section]);
        return result;
    }
}
