using System;
using System.Linq;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginLatencyRegistryServiceCollection
{
    static readonly string BaseType = "Microsoft.Extensions.DependencyInjection.LatencyRegistryServiceCollectionExtensions,Microsoft.Extensions.Telemetry.Abstractions";

    public static object? RegisterCheckpointNames(this object? services, params string[] names)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(RegisterCheckpointNames)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].ParameterType.IsArray
        ).FirstOrDefault();
        var method = methodInfo;
        var result = method?.Invoke(null, [services, names]);
        return result;
    }

    public static object? RegisterMeasureNames(this object? services, params string[] names)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(RegisterMeasureNames)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].ParameterType.IsArray
        ).FirstOrDefault();
        var method = methodInfo;
        var result = method?.Invoke(null, [services, names]);
        return result;
    }

    public static object? RegisterTagNames(this object? services, params string[] names)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(RegisterTagNames)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].ParameterType.IsArray
        ).FirstOrDefault();
        var method = methodInfo;
        var result = method?.Invoke(null, [services, names]);
        return result;
    }
}
