using System;
using System.Linq;
using System.Reflection;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginMemoryCacheServiceCollectionCaller
{
    public static object? AddDistributedMemoryCache(this object? services)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x =>
                x.Name == nameof(AddDistributedMemoryCache)
                && x.GetGenericArguments().Length == 0
                && x.GetParameters().Length == 0
            ).FirstOrDefault();
        return methodInfo?.Invoke(services, Array.Empty<object>());
    }

    public static object? AddDistributedMemoryCache(this object? services, Action<object?> setupAction)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x =>
                x.Name == nameof(AddDistributedMemoryCache)
                && x.GetGenericArguments().Length == 0
                && x.GetParameters().Length == 1
                && x.GetParameters()[0].Name == nameof(setupAction)
                && x.GetParameters()[0].ParameterType.GenericTypeArguments.Length == 1
            ).FirstOrDefault();
        return methodInfo?.Invoke(services, new object[] { setupAction });
    }

    public static object? AddMemoryCache(this object? services)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x =>
                x.Name == nameof(AddMemoryCache)
                && x.GetGenericArguments().Length == 0
                && x.GetParameters().Length == 0
            ).FirstOrDefault();
        return methodInfo?.Invoke(services, Array.Empty<object>());
    }

    public static object? AddMemoryCache(this object? services, Action<object?> setupAction)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x =>
                x.Name == nameof(AddMemoryCache)
                && x.GetGenericArguments().Length == 0
                && x.GetParameters().Length == 1
                && x.GetParameters()[0].Name == nameof(setupAction)
                && x.GetParameters()[0].ParameterType.GenericTypeArguments.Length == 1
            ).FirstOrDefault();
        return methodInfo?.Invoke(services, new object[] { setupAction