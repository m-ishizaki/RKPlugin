using System;
using System.Linq;
using System.Diagnostics.CodeAnalysis;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginEnrichmentServiceCollection
{
    static readonly string BaseType = "Microsoft.Extensions.DependencyInjection.EnrichmentServiceCollectionExtensions,Microsoft.Extensions.Telemetry.Abstractions";

    public static object? AddLogEnricher<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] T>(this object? services) 
        where T : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddLogEnricher)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(services)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(T));
        var result = method?.Invoke(null, [services]);
        return result;
    }

    public static object? AddLogEnricher(this object? services, object? enricher)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddLogEnricher)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(enricher)
        ).FirstOrDefault();
        var method = methodInfo;
        var result = method?.Invoke(null, [services, enricher]);
        return result;
    }

    public static object? AddStaticLogEnricher<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] T>(this object? services) 
        where T : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddStaticLogEnricher)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(services)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(T));
        var result = method?.Invoke(null, [services]);
        return result;
    }

    public static object? AddStaticLogEnricher(this object? services, object? enricher)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddStaticLogEnricher)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(enricher)
        ).FirstOrDefault();
        var method = methodInfo;
        var result = method?.Invoke(null, [services, enricher]);
        return result;
    }
}
