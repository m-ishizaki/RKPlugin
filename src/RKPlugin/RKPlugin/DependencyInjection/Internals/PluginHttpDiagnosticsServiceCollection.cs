using System;
using System.Linq;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginHttpDiagnosticsServiceCollection
{
    static readonly string BaseType = "Microsoft.Extensions.DependencyInjection.HttpDiagnosticsServiceCollectionExtensions,Microsoft.Extensions.Http.Diagnostics";

    public static object? AddDownstreamDependencyMetadata(this object? services, object? downstreamDependencyMetadata)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddDownstreamDependencyMetadata)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(downstreamDependencyMetadata)
        ).FirstOrDefault();
        var method = methodInfo;
        var result = method?.Invoke(null, [services, downstreamDependencyMetadata]);
        return result;
    }

    public static object? AddDownstreamDependencyMetadata<T>(this object? services) where T : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddDownstreamDependencyMetadata)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(services)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(T));
        var result = method?.Invoke(null, [services]);
        return result;
    }
}
