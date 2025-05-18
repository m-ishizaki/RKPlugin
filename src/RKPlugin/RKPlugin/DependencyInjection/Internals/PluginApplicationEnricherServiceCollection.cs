using System;
using System.Collections.Generic;
using System.Text;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginApplicationEnricherServiceCollection
{
    static readonly string BaseType = "Microsoft.Extensions.DependencyInjection.ApplicationEnricherServiceCollectionExtensions,Microsoft.Extensions.Telemetry";

    public static object? AddServiceLogEnricher(this object? services)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddServiceLogEnricher)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(services)
        ).FirstOrDefault();
        var method = methodInfo;
        var result = method?.Invoke(null, [services]);
        return result;
    }

    public static object? AddServiceLogEnricher(this object? services, Action<object?> configure)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddServiceLogEnricher)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(configure)
        ).FirstOrDefault();
        var method = methodInfo;
        var result = method?.Invoke(null, [services, configure]);
        return result;
    }

    public static object? AddServiceLogEnricher_(this object? services, object? section)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddServiceLogEnricher)
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
