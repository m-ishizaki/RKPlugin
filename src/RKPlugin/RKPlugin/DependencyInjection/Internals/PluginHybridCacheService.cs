using System;
using System.Linq;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginHybridCacheService
{
    static readonly string BaseType = "Microsoft.Extensions.DependencyInjection.HybridCacheServiceExtensions,Microsoft.Extensions.Caching.Hybrid";

    public static object? AddHybridCache(this object? services)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddHybridCache)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(services)
        ).FirstOrDefault();
        var method = methodInfo;
        var result = method?.Invoke(null, [services]);
        return result;
    }

    public static object? AddHybridCache(this object? services, Action<object?> setupAction)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddHybridCache)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(setupAction)
        ).FirstOrDefault();
        var method = methodInfo;
        var result = method?.Invoke(null, [services, setupAction]);
        return result;
    }
}
