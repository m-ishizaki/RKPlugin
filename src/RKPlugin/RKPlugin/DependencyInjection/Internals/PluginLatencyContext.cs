﻿namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginLatencyContext
{
    static readonly string BaseType = "Microsoft.Extensions.DependencyInjection.LatencyContextExtensions,Microsoft.Extensions.Telemetry";

    public static object? AddLatencyContext(this object? services)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddLatencyContext)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(services)
        ).FirstOrDefault();
        var method = methodInfo;
        var result = method?.Invoke(null, [services]);
        return result;
    }

    public static object? AddLatencyContext(this object? services, Action<object?> configure)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddLatencyContext)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(configure)
        ).FirstOrDefault();
        var method = methodInfo;
        var result = method?.Invoke(null, [services, configure]);
        return result;
    }

    public static object? AddLatencyContext(this object? services, object? section)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddLatencyContext)
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
