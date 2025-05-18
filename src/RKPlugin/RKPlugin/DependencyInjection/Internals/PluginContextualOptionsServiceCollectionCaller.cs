using System;
using System.Linq;
using System.Reflection;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginContextualOptionsServiceCollectionCaller
{
    public static object? AddContextualOptions(this object? services)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(x =>
                x.Name == nameof(AddContextualOptions)
                && x.GetGenericArguments().Length == 0
                && x.GetParameters().Length == 0
            );
        return methodInfo?.Invoke(services, Array.Empty<object>());
    }

    public static object? Configure<TOptions>(this object? services, Func<object?, object?, object?> loadOptions) where TOptions : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(x =>
                x.Name == nameof(Configure)
                && x.GetGenericArguments().Length == 1
                && x.GetParameters().Length == 1
                && x.GetParameters()[0].ParameterType == typeof(Func<object?, object?, object?>)
            );
        var genericMethod = methodInfo?.MakeGenericMethod(typeof(TOptions));
        return genericMethod?.Invoke(services, new object[] { loadOptions });
    }

    public static object? Configure<TOptions>(this object? services, string? name, Func<object?, object?, object?> loadOptions) where TOptions : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(x =>
                x.Name == nameof(Configure)
                && x.GetGenericArguments().Length == 1
                && x.GetParameters().Length == 2
                && x.GetParameters()[0].ParameterType == typeof(string)
                && x.GetParameters()[1].ParameterType == typeof(Func<object?, object?, object?>)
            );
        var genericMethod = methodInfo?.MakeGenericMethod(typeof(TOptions));
        return genericMethod?.Invoke(services, new object[] { name, loadOptions });
    }

    public static object? ConfigureAll<TOptions>(this object? services, Func<object?, object?, object?> loadOptions) where TOptions : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(x =>
                x.Name == nameof(ConfigureAll)
                && x.GetGenericArguments().Length == 1
                && x.GetParameters().Length == 1
                && x.GetParameters()[0].ParameterType == typeof(Func<object?, object?, object?>)
            );
        var genericMethod = methodInfo?.MakeGenericMethod(typeof(TOptions));
        return genericMethod?.Invoke(services, new object[] { loadOptions });
    }
}
