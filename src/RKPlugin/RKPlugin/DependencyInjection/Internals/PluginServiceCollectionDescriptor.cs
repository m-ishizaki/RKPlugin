using System.Diagnostics.CodeAnalysis;
using System.Security.AccessControl;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

public static class PluginServiceCollectionDescriptor
{
    static readonly string BaseType = "Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionDescriptorExtensions,Microsoft.Extensions.DependencyInjection.Abstractions";

    public static object? Add(this object? collection, object? descriptor)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(Add)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(collection)
            && x.GetParameters()[1].Name == nameof(descriptor)
        ).FirstOrDefault();
        return methodInfo?.Invoke(null, [collection, descriptor]);
    }

    public static object? Add(this object? collection, IEnumerable<object?> descriptors)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(Add)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo;
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static object? RemoveAll(this object? collection, Type serviceType)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(RemoveAll)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo;
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static object? RemoveAll<T>(this object? collection)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(RemoveAll)
            && x.GetGenericArguments().Length == 1
            && x.GetGenericArguments()[0].Name == nameof(T)
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo;
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static object? RemoveAllKeyed<T>(this object? collection, object? serviceKey)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(RemoveAllKeyed)
            && x.GetGenericArguments().Length == 1
            && x.GetGenericArguments()[0].Name == nameof(T)
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo;
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static object? RemoveAllKeyed(this object? collection, Type serviceType, object? serviceKey)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(RemoveAllKeyed)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo;
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static object? Replace(this object? collection, object? descriptor)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(Replace)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo;
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static void TryAdd(this object? collection, object? descriptor)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(TryAdd)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo;
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static void TryAdd(this object? collection, IEnumerable<object?> descriptors)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(TryAdd)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo;
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static void TryAddEnumerable(this object? services, object? descriptor)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(TryAddEnumerable)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo;
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static void TryAddEnumerable(this object? services, IEnumerable<object?> descriptors)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(TryAddEnumerable)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo;
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static void TryAddKeyedScoped<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection, object? serviceKey) where TService : class where TImplementation : class, TService
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(TryAddKeyedScoped)
            && x.GetGenericArguments().Length == 2
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetGenericArguments()[1].Name == nameof(TImplementation)
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TService), typeof(TImplementation));
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static void TryAddKeyedScoped<TService>(this object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(TryAddKeyedScoped)
            && x.GetGenericArguments().Length == 1
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TService));
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static void TryAddKeyedScoped<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection, object? serviceKey) where TService : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(TryAddKeyedScoped)
            && x.GetGenericArguments().Length == 1
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TService));
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static void TryAddKeyedScoped(this object? collection, Type service, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(TryAddKeyedScoped)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo;
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static void TryAddKeyedScoped(this object? collection, Type service, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(TryAddKeyedScoped)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo;
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static void TryAddKeyedScoped(this object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service, object? serviceKey)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(TryAddKeyedScoped)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo;
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static void TryAddKeyedSingleton<TService>(this object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(TryAddKeyedSingleton)
            && x.GetGenericArguments().Length == 1
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TService));
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static void TryAddKeyedSingleton<TService>(this object? collection, object? serviceKey, TService instance) where TService : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(TryAddKeyedSingleton)
            && x.GetGenericArguments().Length == 1
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TService));
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static void TryAddKeyedSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection, object? serviceKey) where TService : class where TImplementation : class, TService
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(TryAddKeyedSingleton)
            && x.GetGenericArguments().Length == 2
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetGenericArguments()[1].Name == nameof(TImplementation)
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TService), typeof(TImplementation));
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static void TryAddKeyedSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection, object? serviceKey) where TService : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(TryAddKeyedSingleton)
            && x.GetGenericArguments().Length == 1
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TService));
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static void TryAddKeyedSingleton(this object? collection, Type service, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(TryAddKeyedSingleton)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo;
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static void TryAddKeyedSingleton(this object? collection, Type service, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(TryAddKeyedSingleton)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo;
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static void TryAddKeyedSingleton(this object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service, object? serviceKey)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(TryAddKeyedSingleton)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo;
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static void TryAddKeyedTransient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection, object? serviceKey) where TService : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(TryAddKeyedTransient)
            && x.GetGenericArguments().Length == 1
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TService));
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static void TryAddKeyedTransient<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection, object? serviceKey) where TService : class where TImplementation : class, TService
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(TryAddKeyedTransient)
            && x.GetGenericArguments().Length == 2
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetGenericArguments()[1].Name == nameof(TImplementation)
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TService), typeof(TImplementation));
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static void TryAddKeyedTransient(this object? collection, Type service, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(TryAddKeyedTransient)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo;
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static void TryAddKeyedTransient(this object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service, object? serviceKey)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(TryAddKeyedTransient)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo;
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static void TryAddKeyedTransient<TService>(this object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(TryAddKeyedTransient)
            && x.GetGenericArguments().Length == 1
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TService));
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static void TryAddKeyedTransient(this object? collection, Type service, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(TryAddKeyedTransient)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo;
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static void TryAddScoped(this object? collection, Type service, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(TryAddScoped)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo;
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static void TryAddScoped(this object? collection, Type service, Func<IServiceProvider, object> implementationFactory)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(TryAddScoped)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo;
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static void TryAddScoped<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection) where TService : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(TryAddScoped)
            && x.GetGenericArguments().Length == 1
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TService));
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static void TryAddScoped<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection) where TService : class where TImplementation : class, TService
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(TryAddScoped)
            && x.GetGenericArguments().Length == 2
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetGenericArguments()[1].Name == nameof(TImplementation)
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TService), typeof(TImplementation));
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static void TryAddScoped<TService>(this object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(TryAddScoped)
            && x.GetGenericArguments().Length == 1
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TService));
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static void TryAddScoped(this object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(TryAddScoped)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo;
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static void TryAddSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection) where TService : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(TryAddSingleton)
            && x.GetGenericArguments().Length == 1
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TService));
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static void TryAddSingleton<TService>(this object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(TryAddSingleton)
            && x.GetGenericArguments().Length == 1
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TService));
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static void TryAddSingleton<TService>(this object? collection, TService instance) where TService : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(TryAddSingleton)
            && x.GetGenericArguments().Length == 1
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TService));
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static void TryAddSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection) where TService : class where TImplementation : class, TService
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(TryAddSingleton)
            && x.GetGenericArguments().Length == 2
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetGenericArguments()[1].Name == nameof(TImplementation)
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TService), typeof(TImplementation));
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static void TryAddSingleton(this object? collection, Type service, Func<IServiceProvider, object> implementationFactory)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(TryAddSingleton)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo;
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static void TryAddSingleton(this object? collection, Type service, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(TryAddSingleton)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo;
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static void TryAddSingleton(this object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(TryAddSingleton)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo;
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static void TryAddTransient(this object? collection, Type service, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(TryAddTransient)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo;
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static void TryAddTransient(this object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(TryAddTransient)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo;
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static void TryAddTransient<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection) where TService : class where TImplementation : class, TService
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(TryAddTransient)
            && x.GetGenericArguments().Length == 2
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetGenericArguments()[1].Name == nameof(TImplementation)
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TService), typeof(TImplementation));
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static void TryAddTransient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection) where TService : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(TryAddTransient)
            && x.GetGenericArguments().Length == 1
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TService));
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static void TryAddTransient<TService>(this object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(TryAddTransient)
            && x.GetGenericArguments().Length == 1
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo.MakeGenericMethod(typeof(TService));
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }

    public static void TryAddTransient(this object? collection, Type service, Func<IServiceProvider, object> implementationFactory)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(TryAddTransient)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        methodInfo = methodInfo;
        return methodInfo?.Invoke(null, [services, implementationFactory]);
    }
}