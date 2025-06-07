using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginAutoActivationCaller
{
    public static object? ActivateSingleton<TService>(this object? services) where TService : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(ActivateSingleton)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 0
        ).FirstOrDefault();
        var method = methodInfo.MakeGenericMethod(typeof(TService));
        return method?.Invoke(services, []);
    }

    public static object? ActivateSingleton(this object? services, Type serviceType)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(ActivateSingleton)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(serviceType)
        ).FirstOrDefault();
        var method = methodInfo;
        return method?.Invoke(services, [serviceType]);
    }

    public static object? AddActivatedSingleton<TService, TImplementation>(this object? services, Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddActivatedSingleton)
            && x.GetGenericArguments().Length == 2
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetGenericArguments()[1].Name == nameof(TImplementation)
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        var method = methodInfo.MakeGenericMethod(typeof(TService), typeof(TImplementation));
        return method?.Invoke(services, [implementationFactory]);
    }

    public static object? AddActivatedSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services) where TService : class where TImplementation : class, TService
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddActivatedSingleton)
            && x.GetGenericArguments().Length == 2
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetGenericArguments()[1].Name == nameof(TImplementation)
            && x.GetParameters().Length == 0
        ).FirstOrDefault();
        var method = methodInfo.MakeGenericMethod(typeof(TService), typeof(TImplementation));
        return method?.Invoke(services, []);
    }

    public static object? AddActivatedSingleton<TService>(this object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddActivatedSingleton)
            && x.GetGenericArguments().Length == 1
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        var method = methodInfo.MakeGenericMethod(typeof(TService));
        return method?.Invoke(services, [implementationFactory]);
    }

    public static object? AddActivatedSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services) where TService : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddActivatedSingleton)
            && x.GetGenericArguments().Length == 1
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetParameters().Length == 0
        ).FirstOrDefault();
        var method = methodInfo.MakeGenericMethod(typeof(TService));
        return method?.Invoke(services, []);
    }

    public static object? AddActivatedSingleton(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddActivatedSingleton)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(serviceType)
        ).FirstOrDefault();
        var method = methodInfo;
        return method?.Invoke(services, [serviceType]);
    }

    public static object? AddActivatedSingleton(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType, Func<IServiceProvider, object> implementationFactory)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddActivatedSingleton)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(serviceType)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        var method = methodInfo;
        return method?.Invoke(services, [serviceType,implementationFactory]);
    }

    public static object? AddActivatedSingleton(this object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddActivatedSingleton)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(serviceType)
            && x.GetParameters()[1].Name == nameof(implementationType)
        ).FirstOrDefault();
        var method = methodInfo;
        return method?.Invoke(services, [serviceType, implementationType]);
    }

    public static void TryAddActivatedSingleton(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddActivatedSingleton)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(serviceType)
        ).FirstOrDefault();
        var method = methodInfo;
        method?.Invoke(services, [serviceType]);
    }

    public static void TryAddActivatedSingleton(this object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddActivatedSingleton)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(serviceType)
            && x.GetParameters()[1].Name == nameof(implementationType)
        ).FirstOrDefault();
        var method = methodInfo;
        method?.Invoke(services, [serviceType,implementationType]);
    }

    public static void TryAddActivatedSingleton(this object? services, Type serviceType, Func<IServiceProvider, object> implementationFactory)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddActivatedSingleton)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(serviceType)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        var method = methodInfo;
        method?.Invoke(services, [serviceType, implementationFactory]);
    }

    public static void TryAddActivatedSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services) where TService : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddActivatedSingleton)
            && x.GetGenericArguments().Length == 1
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetParameters().Length == 0
        ).FirstOrDefault();
        var method = methodInfo.MakeGenericMethod(typeof(TService));
        method?.Invoke(services, []);
    }

    public static void TryAddActivatedSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services) where TService : class where TImplementation : class, TService
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddActivatedSingleton)
            && x.GetGenericArguments().Length == 2
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetGenericArguments()[1].Name == nameof(TImplementation)
            && x.GetParameters().Length == 0
        ).FirstOrDefault();
        var method = methodInfo.MakeGenericMethod(typeof(TService), typeof(TImplementation));
        method?.Invoke(services, []);
    }

    public static void TryAddActivatedSingleton<TService>(this object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddActivatedSingleton)
            && x.GetGenericArguments().Length == 1
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        var method = methodInfo.MakeGenericMethod(typeof(TService));
        method?.Invoke(services, [implementationFactory]);
    }

    private static void TryAddAndActivate<TService>(this object? services, object? descriptor) where TService : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddAndActivate)
            && x.GetGenericArguments().Length == 1
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(descriptor)
        ).FirstOrDefault();
        var method = methodInfo.MakeGenericMethod(typeof(TService));
        method?.Invoke(services, [descriptor]);
    }

    private static void TryAddAndActivate(this object? services, object? descriptor)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddAndActivate)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(descriptor)
        ).FirstOrDefault();
        var method = methodInfo;
        method?.Invoke(services, [descriptor]);
    }

    public static object? ActivateKeyedSingleton<TService>(this object? services, object? serviceKey) where TService : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(ActivateKeyedSingleton)
            && x.GetGenericArguments().Length == 1
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(serviceKey)
        ).FirstOrDefault();
        var method = methodInfo.MakeGenericMethod(typeof(TService));
        return method?.Invoke(services, [serviceKey]);
    }

    public static object? ActivateKeyedSingleton(this object? services, Type serviceType, object? serviceKey)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(ActivateKeyedSingleton)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(serviceType)
            && x.GetParameters()[1].Name == nameof(serviceKey)
        ).FirstOrDefault();
        var method = methodInfo;
        return method?.Invoke(services, [serviceType, serviceKey]);
    }

    public static object? AddActivatedKeyedSingleton<TService, TImplementation>(this object? services, object? serviceKey, Func<IServiceProvider, object?, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddActivatedKeyedSingleton)
            && x.GetGenericArguments().Length == 2
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetGenericArguments()[1].Name == nameof(TImplementation)
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(serviceKey)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        var method = methodInfo.MakeGenericMethod(typeof(TService), typeof(TImplementation));
        return method?.Invoke(services, [serviceKey,implementationFactory]);
    }

    public static object? AddActivatedKeyedSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services, object? serviceKey) where TService : class where TImplementation : class, TService
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddActivatedKeyedSingleton)
            && x.GetGenericArguments().Length == 2
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetGenericArguments()[1].Name == nameof(TImplementation)
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(serviceKey)
        ).FirstOrDefault();
        var method = methodInfo.MakeGenericMethod(typeof(TService), typeof(TImplementation));
        return method?.Invoke(services, [serviceKey]);
    }

    public static object? AddActivatedKeyedSingleton<TService>(this object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddActivatedKeyedSingleton)
            && x.GetGenericArguments().Length == 1
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(serviceKey)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        var method = methodInfo.MakeGenericMethod(typeof(TService));
        return method?.Invoke(services, [serviceKey, implementationFactory]);
    }

    public static object? AddActivatedKeyedSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services, object? serviceKey) where TService : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddActivatedKeyedSingleton)
            && x.GetGenericArguments().Length == 1
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(serviceKey)
        ).FirstOrDefault();
        var method = methodInfo.MakeGenericMethod(typeof(TService));
        return method?.Invoke(services, [serviceKey]);
    }

    public static object? AddActivatedKeyedSingleton(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType, object? serviceKey)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddActivatedKeyedSingleton)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(serviceType)
            && x.GetParameters()[1].Name == nameof(serviceKey)
        ).FirstOrDefault();
        var method = methodInfo;
        return method?.Invoke(services, [serviceType, serviceKey]);
    }

    public static object? AddActivatedKeyedSingleton(this object? services, Type serviceType, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddActivatedKeyedSingleton)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 3
            && x.GetParameters()[0].Name == nameof(serviceType)
            && x.GetParameters()[1].Name == nameof(serviceKey)
            && x.GetParameters()[2].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        var method = methodInfo;
        return method?.Invoke(services, [serviceType, serviceKey, implementationFactory]);
    }

    public static object? AddActivatedKeyedSingleton(this object? services, Type serviceType, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddActivatedKeyedSingleton)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 3
            && x.GetParameters()[0].Name == nameof(serviceType)
            && x.GetParameters()[1].Name == nameof(serviceKey)
            && x.GetParameters()[2].Name == nameof(implementationType)
        ).FirstOrDefault();
        var method = methodInfo;
        return method?.Invoke(services, [serviceType, serviceKey, implementationType]);
    }

    public static void TryAddActivatedKeyedSingleton(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType, object? serviceKey)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddActivatedKeyedSingleton)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(serviceType)
            && x.GetParameters()[1].Name == nameof(serviceKey)
        ).FirstOrDefault();
        var method = methodInfo;
        method?.Invoke(services, [serviceType, serviceKey]);
    }

    public static void TryAddActivatedKeyedSingleton(this object? services, Type serviceType, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddActivatedKeyedSingleton)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 3
            && x.GetParameters()[0].Name == nameof(serviceType)
            && x.GetParameters()[1].Name == nameof(serviceKey)
            && x.GetParameters()[2].Name == nameof(implementationType)
        ).FirstOrDefault();
        var method = methodInfo;
        method?.Invoke(services, [serviceType, serviceKey, implementationType]);
    }

    public static void TryAddActivatedKeyedSingleton(this object? services, Type serviceType, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddActivatedKeyedSingleton)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 3
            && x.GetParameters()[0].Name == nameof(serviceType)
            && x.GetParameters()[1].Name == nameof(serviceKey)
            && x.GetParameters()[2].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        var method = methodInfo;
        method?.Invoke(services, [serviceType, serviceKey, implementationFactory]);
    }

    public static void TryAddActivatedKeyedSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services, object? serviceKey) where TService : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddActivatedKeyedSingleton)
            && x.GetGenericArguments().Length == 1
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(serviceKey)
        ).FirstOrDefault();
        var method = methodInfo.MakeGenericMethod(typeof(TService));
        method?.Invoke(services, [serviceKey]);
    }

    public static void TryAddActivatedKeyedSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services, object? serviceKey) where TService : class where TImplementation : class, TService
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddActivatedKeyedSingleton)
            && x.GetGenericArguments().Length == 2
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetGenericArguments()[1].Name == nameof(TImplementation)
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(serviceKey)
        ).FirstOrDefault();
        var method = methodInfo.MakeGenericMethod(typeof(TService), typeof(TImplementation));
        method?.Invoke(services, [serviceKey]);
    }

    public static void TryAddActivatedKeyedSingleton<TService>(this object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddActivatedKeyedSingleton)
            && x.GetGenericArguments().Length == 1
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(serviceKey)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        var method = methodInfo.MakeGenericMethod(typeof(TService));
        method?.Invoke(services, [serviceKey, implementationFactory]);
    }

    private static void TryAddAndActivateKeyed<TService>(this object? services, object? descriptor) where TService : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddAndActivateKeyed)
            && x.GetGenericArguments().Length == 1
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(descriptor)
        ).FirstOrDefault();
        var method = methodInfo.MakeGenericMethod(typeof(TService));
         method?.Invoke(services, [descriptor]);
    }

    private static void TryAddAndActivateKeyed(this object? services, object? descriptor)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddAndActivateKeyed)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(descriptor)
        ).FirstOrDefault();
        var method = methodInfo;
        method?.Invoke(services, [descriptor]);
    }
}
