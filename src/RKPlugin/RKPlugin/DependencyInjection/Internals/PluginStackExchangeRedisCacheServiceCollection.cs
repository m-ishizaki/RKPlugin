using System;
using System.Collections.Generic;
using System.Linq;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginStackExchangeRedisCacheServiceCollection
{
    static readonly string BaseType = "Microsoft.Extensions.DependencyInjection.StackExchangeRedisCacheServiceCollectionExtensions,Microsoft.Extensions.Caching.StackExchangeRedis";

    public static object? AddStackExchangeRedisCache(this object? services, object? section)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddStackExchangeRedisCache)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == "services"
            && x.GetParameters()[1].Name == "section"
        ).FirstOrDefault();
        var method = methodInfo;
        var result = method?.Invoke(null, [services, section]);
        return result;
    }

    public static object? AddStackExchangeRedisCache(this object? services, Action<object?> configure)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddStackExchangeRedisCache)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == "services"
            && x.GetParameters()[1].Name == "configure"
        ).FirstOrDefault();
        var method = methodInfo;
        var result = method?.Invoke(null, [services, configure]);
        return result;
    }
}