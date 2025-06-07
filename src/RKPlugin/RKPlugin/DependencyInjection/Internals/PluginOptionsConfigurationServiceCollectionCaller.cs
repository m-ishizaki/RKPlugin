using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Xml.Linq;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginOptionsConfigurationServiceCollectionCaller
{
    public static object? Configure<[DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] TOptions>(this object? services, object? config) where TOptions : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x =>
            x.Name == "OptionsConfigurationServiceCollection_" + nameof(Configure)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(config)
            ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TOptions));
        return method?.Invoke(services, [config]);
    }


    public static object? Configure<[DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] TOptions>(this object? services, string? name, object? config) where TOptions : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x =>
                x.Name == "OptionsConfigurationServiceCollection_" + nameof(Configure)
                && x.GetGenericArguments().Length == 1
                && x.GetParameters().Length == 2
                && x.GetParameters()[0].Name == nameof(name)
                && x.GetParameters()[1].Name == nameof(config)
            ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TOptions));
        var result = method?.Invoke(services, [name, config]);
        return result;
    }

    public static object? Configure<[DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] TOptions>(this object? services, object? config, Action<object?>? configureBinder) where TOptions : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x =>
            x.Name == "OptionsConfigurationServiceCollection_" + nameof(Configure)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(config)
            && x.GetParameters()[1].Name == nameof(configureBinder)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TOptions));
        var result = method?.Invoke(services, [config, configureBinder]);
        return result;
    }


    public static object? Configure<[DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] TOptions>(this object? services, string? name, object? config, Action<object?>? configureBinder) where TOptions : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x =>
            x.Name == "OptionsConfigurationServiceCollection_" + nameof(Configure)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 3
            && x.GetParameters()[0].Name == nameof(name)
            && x.GetParameters()[1].Name == nameof(config)
            && x.GetParameters()[2].Name == nameof(configureBinder)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TOptions));
        var result = method?.Invoke(services, [name, config, configureBinder]);
        return result;
    }
}
