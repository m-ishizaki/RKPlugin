using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

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
        ).FirstOrDefault(   );
        return methodInfo?.Invoke(null, [services]);
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
        methodInfo = methodInfo.MakeGenericMethod(typeof(TOptions));
        return methodInfo?.Invoke(null, [services]);
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
        methodInfo = methodInfo.MakeGenericMethod(typeof(TOptions));
        return methodInfo?.Invoke(null, [services, name]);
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
        ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TOptions));
        return methodInfo?.Invoke(null, [services, name]);
    }

    public static object? AddOptionsWithValidateOnStart<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)] TOptions, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TValidateOptions>(this object? services, string? name = null) where TOptions : class where TValidateOptions : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddOptionsWithValidateOnStart)
            && x.GetGenericArguments().Length == 2
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(name)
        ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TOptions), typeof(TValidateOptions));
        return methodInfo?.Invoke(null, [services, name]);
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
        methodInfo = methodInfo.MakeGenericMethod(typeof(TOptions));
        return methodInfo?.Invoke(null, [services, configureOptions]);
    }

    public static object? Configure<TOptions>(this object? services, string? name, Action<TOptions> configureOptions) where TOptions : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(Configure)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 3
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(name)
            && x.GetParameters()[2].Name == nameof(configureOptions)
        ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TOptions));
        return methodInfo?.Invoke(null, [services, name, configureOptions]);
    }

    public static object? ConfigureAll<TOptions>(this object? services, Action<TOptions> configureOptions) where TOptions : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(ConfigureAll)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(configureOptions)
        ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TOptions));
        return methodInfo?.Invoke(null, [services, configureOptions]);
    }

    public static object? ConfigureOptions<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TConfigureOptions>(this object? services) where TConfigureOptions : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(ConfigureOptions)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(services)
        ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TConfigureOptions));
        return methodInfo?.Invoke(null, [services]);
    }

    public static object? ConfigureOptions(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type configureType)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(ConfigureOptions)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(configureType)
        ).FirstOrDefault();
        return methodInfo?.Invoke(null, [services, configureType]);
    }

    public static object? ConfigureOptions(this object? services, object configureInstance)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(ConfigureOptions)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(configureInstance)
        ).FirstOrDefault();
        return methodInfo?.Invoke(null, [services, configureInstance]);
    }

    public static object? PostConfigure<TOptions>(this object? services, Action<TOptions> configureOptions) where TOptions : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(PostConfigure)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(configureOptions)
        ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TOptions));
        return methodInfo?.Invoke(null, [services, configureOptions]);
    }

    public static object? PostConfigure<TOptions>(this object? services, string? name, Action<TOptions> configureOptions) where TOptions : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(PostConfigure)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 3
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(name)
            && x.GetParameters()[2].Name == nameof(configureOptions)
        ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TOptions));
        return methodInfo?.Invoke(null, [services, name,configureOptions]);
    }

    public static object? PostConfigureAll<TOptions>(this object? services, Action<TOptions> configureOptions) where TOptions : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(PostConfigureAll)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(configureOptions)
        ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TOptions));
        return methodInfo?.Invoke(null, [services, configureOptions]);
    }
}