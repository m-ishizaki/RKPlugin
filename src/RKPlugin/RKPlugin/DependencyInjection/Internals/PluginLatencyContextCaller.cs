using System;
using System.Linq;
using System.Reflection;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginLatencyContextCaller
{
    public static object? AddLatencyContext(this object? services)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x =>
                x.Name == nameof(AddLatencyContext)
                && x.GetGenericArguments().Length == 0
                && x.GetParameters().Length == 0
            ).FirstOrDefault();
        return methodInfo?.Invoke(services, Array.Empty<object>());
    }

    public static object? AddLatencyContext(this object? services, Action<object?> configure)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x =>
                x.Name == nameof(AddLatencyContext)
                && x.GetGenericArguments().Length == 0
                && x.GetParameters().Length == 1
                && x.GetParameters()[0].Name == nameof(configure)
                && x.GetParameters()[0].ParameterType.GenericTypeArguments.Length == 1
            ).FirstOrDefault();
        return methodInfo?.Invoke(services, new object[] { configure });
    }

    public static object? AddLatencyContext(this object? services, object? section)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x =>
                x.Name == nameof(AddLatencyContext)
                && x.GetGenericArguments().Length == 0
                && x.GetParameters().Length == 1
                && x.GetParameters()[0].Name == nameof(section)
                && x.GetParameters()[0].ParameterType.GenericTypeArguments.Length == 0
            ).FirstOrDefault();
        return methodInfo?.Invoke(services, new object[] { section });
    }
}
