using System;
using System.Linq;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginServiceCollectionContainerBuilder
{
    static readonly string BaseType = "Microsoft.Extensions.DependencyInjection.ServiceCollectionContainerBuilderExtensions,Microsoft.Extensions.DependencyInjection";

    public static object? BuildServiceProvider(this object? services)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(BuildServiceProvider)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(services)
        ).FirstOrDefault();
        var method = methodInfo;
        var result = method?.Invoke(null, [services]);
        return result;
    }

    public static object? BuildServiceProvider(this object? services, object? options)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(BuildServiceProvider)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(options)
        ).FirstOrDefault();
        var method = methodInfo;
        var result = method?.Invoke(null, [services, options]);
        return result;
    }

    public static object? BuildServiceProvider(this object? services, bool validateScopes)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(BuildServiceProvider)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(validateScopes)
        ).FirstOrDefault();
        var method = methodInfo;
        var result = method?.Invoke(null, [services, validateScopes]);
        return result;
    }
}
