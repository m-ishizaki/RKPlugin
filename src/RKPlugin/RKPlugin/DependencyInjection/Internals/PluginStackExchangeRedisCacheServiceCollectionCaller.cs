using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginStackExchangeRedisCacheServiceCollectionCaller
{
    public static object? AddStackExchangeRedisCache(this object? services, object? section)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x =>
                x.Name == nameof(AddStackExchangeRedisCache)
                && x.GetGenericArguments().Length == 0
                && x.GetParameters().Length == 1
                && x.GetParameters()[0].Name == nameof(section)
            ).FirstOrDefault();
        var method = methodInfo;
        return method?.Invoke(services, new[] { section });
    }

    public static object? AddStackExchangeRedisCache(this object? services, Action<object?> configure)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x =>
                x.Name == nameof(AddStackExchangeRedisCache)
                && x.GetGenericArguments().Length == 0
                && x.GetParameters().Length == 1
                && x.GetParameters()[0].Name == nameof(configure)
                && x.GetParameters()[0].ParameterType.IsGenericType
            ).FirstOrDefault();
        var method = methodInfo;
        return method?.Invoke(services, new object[] { configure });
    }
}
