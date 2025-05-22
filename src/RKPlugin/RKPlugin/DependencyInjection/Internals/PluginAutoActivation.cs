using System;
using System.Linq;
using System.Diagnostics.CodeAnalysis;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginAutoActivation
{
    static readonly string BaseType = "Microsoft.Extensions.DependencyInjection.AutoActivationExtensions,Microsoft.Extensions.DependencyInjection.AutoActivation";

    public static object? ActivateSingleton<TService>(this object? services) 
        where TService : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(ActivateSingleton)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(services)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TService));
        var result = method?.Invoke(null, [services]);
        return result;
    }

    public static object? ActivateSingleton(this object? services, Type serviceType)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(ActivateSingleton)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(serviceType)
        ).FirstOrDefault();
        var method = methodInfo;
        var result = method?.Invoke(null, [services, serviceType]);
        return result;
    }

    public static object? AddActivatedSingleton<TService, TImplementation>(
        this object? services,
        Func<IServiceProvider, TImplementation> implementationFactory) 
        where TService : class 
        where TImplementation : class, TService
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddActivatedSingleton)
            && x.GetGenericArguments().Length == 2
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TService), typeof(TImplementation));
        var result = method?.Invoke(null, [services, implementationFactory]);
        return result;
    }

    public static object? AddActivatedSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(
        this object? services) 
        where TService : class 
        where TImplementation : class, TService
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddActivatedSingleton)
            && x.GetGenericArguments().Length == 2
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(services)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TService), typeof(TImplementation));
        var result = method?.Invoke(null, [services]);
        return result;
    }

    public static object? AddActivatedSingleton<TService>(
        this object? services,
        Func<IServiceProvider, TService> implementationFactory) 
        where TService : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddActivatedSingleton)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TService));
        var result = method?.Invoke(null, [services, implementationFactory]);
        return result;
    }

    public static object? AddActivatedSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(
        this object? services) 
        where TService : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddActivatedSingleton)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(services)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TService));
        var result = method?.Invoke(null, [services]);
        return result;
    }

    public static object? AddActivatedSingleton(
        this object? services, 
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddActivatedSingleton)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(serviceType)
        ).FirstOrDefault();
        var method = methodInfo;
        var result = method?.Invoke(null, [services, serviceType]);
        return result;
    }

    // Add additional methods following the same pattern...
}
