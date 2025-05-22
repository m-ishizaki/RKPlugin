using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginOptionsServiceCollection
{
    static readonly string BaseType = "Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions,Microsoft.Extensions.Options";

    public static object? AddOptions(this object? services)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddOptions)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(services)
        ).FirstOrDefault();
        var method = methodInfo;
        var result = method?.Invoke(null, [services]);
        return result;
    }

    public static object? AddOptions<TOptions>(this object? services) where TOptions : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddOptions)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(services)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TOptions));
        var result = method?.Invoke(null, [services]);
        return result;
    }

    public static object? AddOptions<TOptions>(this object? services, string? name) where TOptions : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddOptions)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(name)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TOptions));
        var result = method?.Invoke(null, [services, name]);
        return result;
    }

    public static object? AddOptionsWithValidateOnStart<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)] TOptions>(this object? services, string? name = null) where TOptions : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddOptionsWithValidateOnStart)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(name)
            && x.GetParameters()[1].HasDefaultValue
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TOptions));
        var result = method?.Invoke(null, [services, name]);
        return result;
    }

    public static object? Configure<TOptions>(this object? services, Action<TOptions> configureOptions) where TOptions : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(Configure)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(configureOptions)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TOptions));
        var result = method?.Invoke(null, [services, configureOptions]);
        return result;
    }
}