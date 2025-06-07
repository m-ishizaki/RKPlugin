using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginOptionsServiceCollectionCaller
{
    public static object? AddOptions(this object? services)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x =>
                x.Name == nameof(AddOptions)
                && x.GetGenericArguments().Length == 0
                && x.GetParameters().Length == 0
            ).FirstOrDefault();
        return methodInfo?.Invoke(services, []);
    }

    public static object? AddOptions<TOptions>(this object? services) where TOptions : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x =>
                x.Name == nameof(AddOptions)
                && x.GetGenericArguments().Length == 1
                && x.GetParameters().Length == 0
            ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TOptions));
        return methodInfo?.Invoke(services,[]);
    }

    public static object? AddOptions<TOptions>(this object? services, string? name) where TOptions : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x =>
                x.Name == nameof(AddOptions)
                && x.GetGenericArguments().Length == 1
                && x.GetParameters().Length == 1
                && x.GetParameters()[0].Name == nameof(name)
            ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TOptions));
        return methodInfo?.Invoke(services,[name]);
    }

    public static object? AddOptionsWithValidateOnStart<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)] TOptions>(this object? services, string? name = null) where TOptions : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x =>
                x.Name == nameof(AddOptionsWithValidateOnStart)
                && x.GetGenericArguments().Length == 1
                && x.GetParameters().Length == 1
                && x.GetParameters()[0].Name == nameof(name)
            ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TOptions));
        return methodInfo?.Invoke(services, [name]);
    }

    public static object? AddOptionsWithValidateOnStart<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)] TOptions, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TValidateOptions>(this object? services, string? name = null) where TOptions : class where TValidateOptions : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x =>
                x.Name == nameof(AddOptionsWithValidateOnStart)
                && x.GetGenericArguments().Length == 2
                && x.GetParameters().Length == 1
                && x.GetParameters()[0].Name == nameof(name)
            ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TOptions), typeof(TValidateOptions));
        return methodInfo?.Invoke(services, [name]);
    }

    public static object? Configure<TOptions>(this object? services, Action<TOptions> configureOptions) where TOptions : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x =>
                x.Name == nameof(Configure)
                && x.GetGenericArguments().Length == 1
                && x.GetParameters().Length == 1
                && x.GetParameters()[0].Name == nameof(configureOptions)
            ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TOptions));
        return methodInfo?.Invoke(services, [configureOptions]);
    }

    public static object? Configure<TOptions>(this object? services, string? name, Action<TOptions> configureOptions) where TOptions : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x =>
                x.Name == nameof(Configure)
                && x.GetGenericArguments().Length == 1
                && x.GetParameters().Length == 2
                && x.GetParameters()[0].Name == nameof(name)
                && x.GetParameters()[1].Name == nameof(configureOptions)
            ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TOptions));
        return methodInfo?.Invoke(services, [name, configureOptions]);
    }

    public static object? ConfigureAll<TOptions>(this object? services, Action<TOptions> configureOptions) where TOptions : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x =>
                x.Name == nameof(ConfigureAll)
                && x.GetGenericArguments().Length == 1
                && x.GetParameters().Length == 1
                && x.GetParameters()[0].Name == nameof(configureOptions)
            ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TOptions));
        return methodInfo?.Invoke(services, [configureOptions]);
    }

    public static object? ConfigureOptions<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TConfigureOptions>(this object? services) where TConfigureOptions : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x =>
                x.Name == nameof(ConfigureOptions)
                && x.GetGenericArguments().Length == 1
                && x.GetParameters().Length == 0
            ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TConfigureOptions));
        return methodInfo?.Invoke(services, []);
    }

    public static object? ConfigureOptions(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type configureType)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x =>
                x.Name == nameof(ConfigureOptions)
                && x.GetGenericArguments().Length == 0
                && x.GetParameters().Length == 1
                && x.GetParameters()[0].Name == nameof(configureType)
            ).FirstOrDefault();
        return methodInfo?.Invoke(services, [configureType]);
    }

    public static object? ConfigureOptions(this object? services, object configureInstance)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x =>
                x.Name == nameof(ConfigureOptions)
                && x.GetGenericArguments().Length == 0
                && x.GetParameters().Length == 1
                && x.GetParameters()[0].Name == nameof(configureInstance)
            ).FirstOrDefault();
        return methodInfo?.Invoke(services, [configureInstance]);
    }

    public static object? PostConfigure<TOptions>(this object? services, Action<TOptions> configureOptions) where TOptions : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x =>
                x.Name == nameof(PostConfigure)
                && x.GetGenericArguments().Length == 1
                && x.GetParameters().Length == 1
                && x.GetParameters()[0].Name == nameof(configureOptions)
            ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TOptions));
        return methodInfo?.Invoke(services, [configureOptions]);
    }

    public static object? PostConfigure<TOptions>(this object? services, string? name, Action<TOptions> configureOptions) where TOptions : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x =>
                x.Name == nameof(PostConfigure)
                && x.GetGenericArguments().Length == 1
                && x.GetParameters().Length == 2
                && x.GetParameters()[0].Name == nameof(name)
                && x.GetParameters()[1].Name == nameof(configureOptions)
            ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TOptions));
        return methodInfo?.Invoke(services, [name, configureOptions]);
    }

    public static object? PostConfigureAll<TOptions>(this object? services, Action<TOptions> configureOptions) where TOptions : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x =>
                x.Name == nameof(PostConfigureAll)
                && x.GetGenericArguments().Length == 1
                && x.GetParameters().Length == 1
                && x.GetParameters()[0].Name == nameof(configureOptions)
            ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TOptions));
        return methodInfo?.Invoke(services, [configureOptions]);
    }
}
