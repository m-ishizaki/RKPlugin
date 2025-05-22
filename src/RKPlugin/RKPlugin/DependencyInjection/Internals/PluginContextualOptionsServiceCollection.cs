using System;
using System.Linq;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginContextualOptionsServiceCollection
{
    static readonly string BaseType = "Microsoft.Extensions.DependencyInjection.ContextualOptionsServiceCollectionExtensions,Microsoft.Extensions.ContextualOptions";

    public static object? AddContextualOptions(this object? services)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddContextualOptions)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(services)
        ).FirstOrDefault();
        var method = methodInfo;
        var result = method?.Invoke(null, [services]);
        return result;
    }

    public static object? Configure<TOptions>(this object? services, Func<object?, object?, object?> loadOptions) 
        where TOptions : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(Configure)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(loadOptions)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TOptions));
        var result = method?.Invoke(null, [services, loadOptions]);
        return result;
    }

    public static object? Configure<TOptions>(this object? services, string? name, Func<object?, object?, object?> loadOptions) 
        where TOptions : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(Configure)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 3
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(name)
            && x.GetParameters()[2].Name == nameof(loadOptions)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TOptions));
        var result = method?.Invoke(null, [services, name, loadOptions]);
        return result;
    }

    public static object? Configure<TOptions>(this object? services, Action<object?, TOptions> configure) 
        where TOptions : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(Configure)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(configure)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TOptions));
        var result = method?.Invoke(null, [services, configure]);
        return result;
    }

    public static object? Configure<TOptions>(this object? services, string? name, Action<object?, TOptions> configure) 
        where TOptions : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(Configure)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 3
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(name)
            && x.GetParameters()[2].Name == nameof(configure)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TOptions));
        var result = method?.Invoke(null, [services, name, configure]);
        return result;
    }

    public static object? ConfigureAll<TOptions>(this object? services, Func<object?, object?, object?> loadOptions) 
        where TOptions : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(ConfigureAll)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(loadOptions)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TOptions));
        var result = method?.Invoke(null, [services, loadOptions]);
        return result;
    }

    public static object? ConfigureAll<TOptions>(this object? services, Action<object?, TOptions> configure) 
        where TOptions : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(ConfigureAll)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(configure)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TOptions));
        var result = method?.Invoke(null, [services, configure]);
        return result;
    }
}
