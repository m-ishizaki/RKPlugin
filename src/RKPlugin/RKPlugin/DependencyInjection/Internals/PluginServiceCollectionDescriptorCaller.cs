using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

public static class PluginServiceCollectionDescriptorCaller
{
    public static object? Add(this object? collection, object? descriptor)
    {
        var type = collection!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(Add)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(descriptor)
        ).FirstOrDefault();
        return methodInfo?.Invoke(collection, [descriptor]);
    }

    public static object? Add(this object? collection, IEnumerable<object?> descriptors)
    {
        var type = collection!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(Add)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(descriptors)
        ).FirstOrDefault();
        return methodInfo?.Invoke(collection, [descriptors]);
    }

    public static object? RemoveAll(this object? collection, Type serviceType)
    {
        var type = collection!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(RemoveAll)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(serviceType)
        ).FirstOrDefault();
        return methodInfo?.Invoke(collection, [serviceType]);
    }

    public static object? RemoveAll<T>(this object? collection)
    {
        var type = collection!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(RemoveAll)
            && x.GetGenericArguments().Length == 1
            && x.GetGenericArguments()[0].Name == nameof(T)
            && x.GetParameters().Length == 0
        ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(T));
        return methodInfo?.Invoke(collection, null);
    }

    public static object? RemoveAllKeyed<T>(this object? collection, object? serviceKey)
    {
        var type = collection!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(RemoveAllKeyed)
            && x.GetGenericArguments().Length == 1
            && x.GetGenericArguments()[0].Name == nameof(T)
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(serviceKey)
        ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(T));
        return methodInfo?.Invoke(collection, [serviceKey]);
    }

    public static object? RemoveAllKeyed(this object? collection, Type serviceType, object? serviceKey)
    {
        var type = collection!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(RemoveAllKeyed)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(serviceType)
            && x.GetParameters()[1].Name == nameof(serviceKey)
        ).FirstOrDefault();
        return methodInfo?.Invoke(collection, [serviceType, serviceKey]);
    }

    public static object? Replace(this object? collection, object? descriptor)
    {
        var type = collection!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(Replace)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(descriptor)
        ).FirstOrDefault();
        return methodInfo?.Invoke(collection, [descriptor]);
    }

    public static void TryAdd(this object? collection, object? descriptor)
    {
        var type = collection!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAdd)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(descriptor)
        ).FirstOrDefault();
        methodInfo?.Invoke(collection, [descriptor]);
    }

    public static void TryAdd(this object? collection, IEnumerable<object?> descriptors)
    {
        var type = collection!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAdd)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(descriptors)
        ).FirstOrDefault();
        methodInfo?.Invoke(collection, [descriptors]);
    }

    public static void TryAddEnumerable(this object? services, object? descriptor)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddEnumerable)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(descriptor)
        ).FirstOrDefault();
        methodInfo?.Invoke(services, [descriptor]);
    }

    public static void TryAddEnumerable(this object? services, IEnumerable<object?> descriptors)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddEnumerable)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(descriptors)
        ).FirstOrDefault();
        methodInfo?.Invoke(services, [descriptors]);
    }

    public static void TryAddKeyedScoped<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection, object? serviceKey) where TService : class where TImplementation : class, TService
    {
        var type = collection!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddKeyedScoped)
            && x.GetGenericArguments().Length == 2
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetGenericArguments()[1].Name == nameof(TImplementation)
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(serviceKey)
        ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TService), typeof(TImplementation));
        methodInfo?.Invoke(collection, [serviceKey]);
    }

    public static void TryAddKeyedScoped<TService>(this object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddKeyedScoped)
            && x.GetGenericArguments().Length == 1
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(serviceKey)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo?.MakeGenericMethod(typeof(TService));
        methodInfo?.Invoke(services, [serviceKey, implementationFactory]);
    }

    public static void TryAddKeyedScoped<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection, object? serviceKey) where TService : class
    {
        var type = collection!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddKeyedScoped)
            && x.GetGenericArguments().Length == 1
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(serviceKey)
        ).FirstOrDefault();
        methodInfo = methodInfo?.MakeGenericMethod(typeof(TService));
        methodInfo?.Invoke(collection, [serviceKey]);
    }

    public static void TryAddKeyedScoped(this object? collection, Type service, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory)
    {
        var type = collection!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddKeyedScoped)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 3
            && x.GetParameters()[0].Name == nameof(service)
            && x.GetParameters()[1].Name == nameof(serviceKey)
            && x.GetParameters()[2].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo?.Invoke(collection, [service, serviceKey, implementationFactory]);
    }

    public static void TryAddKeyedScoped(this object? collection, Type service, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
    {
        var type = collection!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddKeyedScoped)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(serviceKey)
            && x.GetParameters()[1].Name == nameof(implementationType)
        ).FirstOrDefault();
        methodInfo = methodInfo;
        methodInfo?.Invoke(collection, [serviceKey, implementationType]);
    }

    public static void TryAddKeyedScoped(this object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service, object? serviceKey)
    {
        var type = collection!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddKeyedScoped)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(service)
            && x.GetParameters()[1].Name == nameof(serviceKey)
        ).FirstOrDefault();
        methodInfo = methodInfo;
        methodInfo?.Invoke(collection, [service, serviceKey]);
    }

    public static void TryAddKeyedSingleton<TService>(this object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddKeyedSingleton)
            && x.GetGenericArguments().Length == 1
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(serviceKey)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo?.MakeGenericMethod(typeof(TService));
        methodInfo?.Invoke(services, [serviceKey, implementationFactory]);
    }

    public static void TryAddKeyedSingleton<TService>(this object? collection, object? serviceKey, TService instance) where TService : class
    {
        var type = collection!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddKeyedSingleton)
            && x.GetGenericArguments().Length == 1
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(serviceKey)
            && x.GetParameters()[1].Name == nameof(instance)
        ).FirstOrDefault();
        methodInfo = methodInfo?.MakeGenericMethod(typeof(TService));
        methodInfo?.Invoke(collection, [serviceKey, instance]);
    }

    public static void TryAddKeyedSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection, object? serviceKey) where TService : class where TImplementation : class, TService
    {
        var type = collection!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddKeyedSingleton)
            && x.GetGenericArguments().Length == 2
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetGenericArguments()[1].Name == nameof(TImplementation)
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(serviceKey)
        ).FirstOrDefault();
        methodInfo = methodInfo?.MakeGenericMethod(typeof(TService), typeof(TImplementation));
        methodInfo?.Invoke(collection, [serviceKey]);
    }

    public static void TryAddKeyedSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection, object? serviceKey) where TService : class
    {
        var type = collection!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddKeyedSingleton)
            && x.GetGenericArguments().Length == 1
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(serviceKey)
        ).FirstOrDefault();
        methodInfo = methodInfo?.MakeGenericMethod(typeof(TService));
        methodInfo?.Invoke(collection, [serviceKey]);
    }

    public static void TryAddKeyedSingleton(this object? collection, Type service, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory)
    {
        var type = collection!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddKeyedSingleton)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 3
            && x.GetParameters()[0].Name == nameof(service)
            && x.GetParameters()[1].Name == nameof(serviceKey)
            && x.GetParameters()[2].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo?.Invoke(collection, [service, serviceKey, implementationFactory]);
    }

    public static void TryAddKeyedSingleton(this object? collection, Type service, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
    {
        var type = collection!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddKeyedSingleton)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 3
            && x.GetParameters()[0].Name == nameof(service)
            && x.GetParameters()[1].Name == nameof(serviceKey)
            && x.GetParameters()[2].Name == nameof(implementationType)
        ).FirstOrDefault();
        methodInfo = methodInfo;
        methodInfo?.Invoke(collection, [service, serviceKey, implementationType]);
    }

    public static void TryAddKeyedSingleton(this object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service, object? serviceKey)
    {
        var type = collection!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddKeyedSingleton)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(service)
            && x.GetParameters()[1].Name == nameof(serviceKey)
        ).FirstOrDefault();
        methodInfo = methodInfo;
        methodInfo?.Invoke(collection, [service, serviceKey]);
    }

    public static void TryAddKeyedTransient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection, object? serviceKey) where TService : class
    {
        var type = collection!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddKeyedTransient)
            && x.GetGenericArguments().Length == 1
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(serviceKey)
        ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TService));
        methodInfo?.Invoke(collection, [serviceKey]);
    }

    public static void TryAddKeyedTransient<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection, object? serviceKey) where TService : class where TImplementation : class, TService
    {
        var type = collection!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddKeyedTransient)
            && x.GetGenericArguments().Length == 2
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetGenericArguments()[1].Name == nameof(TImplementation)
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(serviceKey)
        ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TService), typeof(TImplementation));
        methodInfo?.Invoke(collection, [serviceKey]);
    }

    public static void TryAddKeyedTransient(this object? collection, Type service, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
    {
        var type = collection!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddKeyedTransient)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(service)
            && x.GetParameters()[1].Name == nameof(serviceKey)
        ).FirstOrDefault();
        methodInfo = methodInfo;
        methodInfo?.Invoke(collection, [service, serviceKey]);
    }

    public static void TryAddKeyedTransient(this object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service, object? serviceKey)
    {
        var type = collection!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddKeyedTransient)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(service)
            && x.GetParameters()[1].Name == nameof(serviceKey)
        ).FirstOrDefault();
        methodInfo = methodInfo;
        methodInfo?.Invoke(collection, [service, serviceKey]);
    }

    public static void TryAddKeyedTransient<TService>(this object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddKeyedTransient)
            && x.GetGenericArguments().Length == 1
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(serviceKey)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TService));
        methodInfo?.Invoke(services, [serviceKey, implementationFactory]);
    }

    public static void TryAddKeyedTransient(this object? collection, Type service, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory)
    {
        var type = collection!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddKeyedTransient)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 3
            && x.GetParameters()[0].Name == nameof(service)
            && x.GetParameters()[1].Name == nameof(serviceKey)
            && x.GetParameters()[2].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo;
        methodInfo?.Invoke(collection, [service, serviceKey, implementationFactory]);
    }

    public static void TryAddScoped(this object? collection, Type service, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
    {
        var type = collection!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddScoped)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(service)
            && x.GetParameters()[1].Name == nameof(implementationType)
        ).FirstOrDefault();
        methodInfo = methodInfo;
        methodInfo?.Invoke(collection, [service, implementationType]);
    }

    public static void TryAddScoped(this object? collection, Type service, Func<IServiceProvider, object> implementationFactory)
    {
        var type = collection!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddScoped)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(implementationFactory)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo;
        methodInfo?.Invoke(collection, [implementationFactory, implementationFactory]);
    }

    public static void TryAddScoped<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection) where TService : class
    {
        var type = collection!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddScoped)
            && x.GetGenericArguments().Length == 1
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetParameters().Length == 0
        ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TService));
        methodInfo?.Invoke(collection, []);
    }

    public static void TryAddScoped<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection) where TService : class where TImplementation : class, TService
    {
        var type = collection!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddScoped)
            && x.GetGenericArguments().Length == 2
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetGenericArguments()[1].Name == nameof(TImplementation)
            && x.GetParameters().Length == 0
        ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TService), typeof(TImplementation));
        methodInfo?.Invoke(collection, []);
    }

    public static void TryAddScoped<TService>(this object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddScoped)
            && x.GetGenericArguments().Length == 1
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TService));
        methodInfo?.Invoke(services, [implementationFactory]);
    }

    public static void TryAddScoped(this object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service)
    {
        var type = collection!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddScoped)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(service)
        ).FirstOrDefault();
        methodInfo = methodInfo;
        methodInfo?.Invoke(collection, [service]);
    }

    public static void TryAddSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection) where TService : class
    {
        var type = collection!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddSingleton)
            && x.GetGenericArguments().Length == 1
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetParameters().Length == 0
        ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TService));
        methodInfo?.Invoke(collection, []);
    }

    public static void TryAddSingleton<TService>(this object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddSingleton)
            && x.GetGenericArguments().Length == 1
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TService));
        methodInfo?.Invoke(services, [implementationFactory]);
    }

    public static void TryAddSingleton<TService>(this object? collection, TService instance) where TService : class
    {
        var type = collection!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddSingleton)
            && x.GetGenericArguments().Length == 1
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(instance)
        ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TService));
        methodInfo?.Invoke(collection, [instance]);
    }

    public static void TryAddSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection) where TService : class where TImplementation : class, TService
    {
        var type = collection!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddSingleton)
            && x.GetGenericArguments().Length == 2
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetGenericArguments()[1].Name == nameof(TImplementation)
            && x.GetParameters().Length == 0
        ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TService), typeof(TImplementation));
        methodInfo?.Invoke(collection, []);
    }

    public static void TryAddSingleton(this object? collection, Type service, Func<IServiceProvider, object> implementationFactory)
    {
        var type = collection!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddSingleton)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(implementationFactory)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo;
        methodInfo?.Invoke(collection, [implementationFactory, implementationFactory]);
    }

    public static void TryAddSingleton(this object? collection, Type service, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
    {
        var type = collection!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddSingleton)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(service)
            && x.GetParameters()[1].Name == nameof(implementationType)
        ).FirstOrDefault();
        methodInfo = methodInfo;
        methodInfo?.Invoke(collection, [service, implementationType]);
    }

    public static void TryAddSingleton(this object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service)
    {
        var type = collection!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddSingleton)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(service)
        ).FirstOrDefault();
        methodInfo = methodInfo;
        methodInfo?.Invoke(collection, [service]);
    }

    public static void TryAddTransient(this object? collection, Type service, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
    {
        var type = collection!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddTransient)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(service)
            && x.GetParameters()[1].Name == nameof(implementationType)
        ).FirstOrDefault();
        methodInfo = methodInfo;
        methodInfo?.Invoke(collection, [service, implementationType]);
    }

    public static void TryAddTransient(this object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service)
    {
        var type = collection!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddTransient)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(service)
        ).FirstOrDefault();
        methodInfo = methodInfo;
        methodInfo?.Invoke(collection, [service]);
    }

    public static void TryAddTransient<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection) where TService : class where TImplementation : class, TService
    {
        var type = collection!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddTransient)
            && x.GetGenericArguments().Length == 2
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetGenericArguments()[1].Name == nameof(TImplementation)
            && x.GetParameters().Length == 0
        ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TService), typeof(TImplementation));
        methodInfo?.Invoke(collection, []);
    }

    public static void TryAddTransient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection) where TService : class
    {
        var type = collection!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddTransient)
            && x.GetGenericArguments().Length == 1
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetParameters().Length == 20
        ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TService));
        methodInfo?.Invoke(collection, []);
    }

    public static void TryAddTransient<TService>(this object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddTransient)
            && x.GetGenericArguments().Length == 1
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TService));
        methodInfo?.Invoke(services, [implementationFactory]);
    }

    public static void TryAddTransient(this object? collection, Type service, Func<IServiceProvider, object> implementationFactory)
    {
        var type = collection!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(TryAddTransient)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(service)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo;
        methodInfo?.Invoke(collection, [service, implementationFactory]);
    }
}
