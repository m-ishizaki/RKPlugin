using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginOptionsConfigurationServiceCollection
{
    static readonly string BaseType = "Microsoft.Extensions.DependencyInjection.OptionsConfigurationServiceCollectionExtensions,Microsoft.Extensions.Options.ConfigurationExtensions";

    public static object? Configure<[DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] TOptions>(this object? services, object? config) where TOptions : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(Configure)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(config)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TOptions));
        var result = method?.Invoke(null, [services, config]);
        return result;
    }

    public static object? Configure<[DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] TOptions>(this object? services, string? name, object? config) where TOptions : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(Configure)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 3
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(name)
            && x.GetParameters()[2].Name == nameof(config)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TOptions));
        var result = method?.Invoke(null, [services, name, config]);
        return result;
    }

    public static object? Configure<[DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] TOptions>(this object? services, object? config, Action<object?>? configureBinder) where TOptions : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(Configure)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 3
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(config)
            && x.GetParameters()[2].Name == nameof(configureBinder)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TOptions));
        var result = method?.Invoke(null, [services, config, configureBinder]);
        return result;
    }

    public static object? Configure<[DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] TOptions>(this object? services, string? name, object? config, Action<object?>? configureBinder) where TOptions : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(Configure)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 4
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(name)
            && x.GetParameters()[2].Name == nameof(config)
            && x.GetParameters()[3].Name == nameof(configureBinder)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TOptions));
        var result = method?.Invoke(null, [services, name, config, configureBinder]);
        return result;
    }
}
