using System;
using System.Diagnostics.CodeAnalysis;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

public static class PluginServiceCollectionDescriptorCaller
{
    public static object? Add(this object? collection, object? descriptor)
        => PluginServiceCollectionDescriptor.Add(collection, descriptor);

    public static object? Add(this object? collection, IEnumerable<object?> descriptors)
        => PluginServiceCollectionDescriptor.Add(collection, descriptors);

    public static object? RemoveAll(this object? collection, Type serviceType)
        => PluginServiceCollectionDescriptor.RemoveAll(collection, serviceType);

    public static object? RemoveAll<T>(this object? collection)
        => PluginServiceCollectionDescriptor.RemoveAll<T>(collection);

    public static object? RemoveAllKeyed<T>(this object? collection, object? serviceKey)
        => PluginServiceCollectionDescriptor.RemoveAllKeyed<T>(collection, serviceKey);

    public static object? RemoveAllKeyed(this object? collection, Type serviceType, object? serviceKey)
        => PluginServiceCollectionDescriptor.RemoveAllKeyed(collection, serviceType, serviceKey);

    public static object? Replace(this object? collection, object? descriptor)
        => PluginServiceCollectionDescriptor.Replace(collection, descriptor);

    public static void TryAdd(this object? collection, object? descriptor)
        => PluginServiceCollectionDescriptor.TryAdd(collection, descriptor);

    public static void TryAdd(this object? collection, IEnumerable<object?> descriptors)
        => PluginServiceCollectionDescriptor.TryAdd(collection, descriptors);

    public static void TryAddEnumerable(this object? services, object? descriptor)
        => PluginServiceCollectionDescriptor.TryAddEnumerable(services, descriptor);

    public static void TryAddEnumerable(this object? services, IEnumerable<object?> descriptors)
        => PluginServiceCollectionDescriptor.TryAddEnumerable(services, descriptors);

    public static void TryAddKeyedScoped<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection, object? serviceKey) where TService : class where TImplementation : class, TService
        => PluginServiceCollectionDescriptor.TryAddKeyedScoped<TService, TImplementation>(collection, serviceKey);

    public static void TryAddKeyedScoped<TService>(this object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class
        => PluginServiceCollectionDescriptor.TryAddKeyedScoped<TService>(services, serviceKey, implementationFactory);

    public static void TryAddKeyedScoped<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection, object? serviceKey) where TService : class
        => PluginServiceCollectionDescriptor.TryAddKeyedScoped<TService>(collection, serviceKey);

    public static void TryAddKeyedScoped(this object? collection, Type service, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory)
        => PluginServiceCollectionDescriptor.TryAddKeyedScoped(collection, service, serviceKey, implementationFactory);

    public static void TryAddKeyedScoped(this object? collection, Type service, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
        => PluginServiceCollectionDescriptor.TryAddKeyedScoped(collection, service, serviceKey, implementationType);

    public static void TryAddKeyedScoped(this object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service, object? serviceKey)
        => PluginServiceCollectionDescriptor.TryAddKeyedScoped(collection, service, serviceKey);

    public static void TryAddKeyedSingleton<TService>(this object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class
        => PluginServiceCollectionDescriptor.TryAddKeyedSingleton<TService>(services, serviceKey, implementationFactory);

    public static void TryAddKeyedSingleton<TService>(this object? collection, object? serviceKey, TService instance) where TService : class
        => PluginServiceCollectionDescriptor.TryAddKeyedSingleton<TService>(collection, serviceKey, instance);

    public static void TryAddKeyedSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection, object? serviceKey) where TService : class where TImplementation : class, TService
        => PluginServiceCollectionDescriptor.TryAddKeyedSingleton<TService, TImplementation>(collection, serviceKey);

    public static void TryAddKeyedSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection, object? serviceKey) where TService : class
        => PluginServiceCollectionDescriptor.TryAddKeyedSingleton<TService>(collection, serviceKey);

    public static void TryAddKeyedSingleton(this object? collection, Type service, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory)
        => PluginServiceCollectionDescriptor.TryAddKeyedSingleton(collection, service, serviceKey, implementationFactory);

    public static void TryAddKeyedSingleton(this object? collection, Type service, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
        => PluginServiceCollectionDescriptor.TryAddKeyedSingleton(collection, service, serviceKey, implementationType);

    public static void TryAddKeyedSingleton(this object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service, object? serviceKey)
        => PluginServiceCollectionDescriptor.TryAddKeyedSingleton(collection, service, serviceKey);

    public static void TryAddKeyedTransient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection, object? serviceKey) where TService : class
        => PluginServiceCollectionDescriptor.TryAddKeyedTransient<TService>(collection, serviceKey);

    public static void TryAddKeyedTransient<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection, object? serviceKey) where TService : class where TImplementation : class, TService
        => PluginServiceCollectionDescriptor.TryAddKeyedTransient<TService, TImplementation>(collection, serviceKey);

    public static void TryAddKeyedTransient(this object? collection, Type service, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
        => PluginServiceCollectionDescriptor.TryAddKeyedTransient(collection, service, serviceKey, implementationType);

    public static void TryAddKeyedTransient(this object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service, object? serviceKey)
        => PluginServiceCollectionDescriptor.TryAddKeyedTransient(collection, service, serviceKey);

    public static void TryAddKeyedTransient<TService>(this object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class
        => PluginServiceCollectionDescriptor.TryAddKeyedTransient<TService>(services, serviceKey, implementationFactory);

    public static void TryAddKeyedTransient(this object? collection, Type service, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory)
        => PluginServiceCollectionDescriptor.TryAddKeyedTransient(collection, service, serviceKey, implementationFactory);

    public static void TryAddScoped(this object? collection, Type service, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
        => PluginServiceCollectionDescriptor.TryAddScoped(collection, service, implementationType);

    public static void TryAddScoped(this object? collection, Type service, Func<IServiceProvider, object> implementationFactory)
        => PluginServiceCollectionDescriptor.TryAddScoped(collection, service, implementationFactory);

    public static void TryAddScoped<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection) where TService : class
        => PluginServiceCollectionDescriptor.TryAddScoped<TService>(collection);

    public static void TryAddScoped<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection) where TService : class where TImplementation : class, TService
        => PluginServiceCollectionDescriptor.TryAddScoped<TService, TImplementation>(collection);

    public static void TryAddScoped<TService>(this object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class
        => PluginServiceCollectionDescriptor.TryAddScoped<TService>(services, implementationFactory);

    public static void TryAddScoped(this object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service)
        => PluginServiceCollectionDescriptor.TryAddScoped(collection, service);

    public static void TryAddSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection) where TService : class
        => PluginServiceCollectionDescriptor.TryAddSingleton<TService>(collection);

    public static void TryAddSingleton<TService>(this object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class
        => PluginServiceCollectionDescriptor.TryAddSingleton<TService>(services, implementationFactory);

    public static void TryAddSingleton<TService>(this object? collection, TService instance) where TService : class
        => PluginServiceCollectionDescriptor.TryAddSingleton<TService>(collection, instance);

    public static void TryAddSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection) where TService : class where TImplementation : class, TService
        => PluginServiceCollectionDescriptor.TryAddSingleton<TService, TImplementation>(collection);

    public static void TryAddSingleton(this object? collection, Type service, Func<IServiceProvider, object> implementationFactory)
        => PluginServiceCollectionDescriptor.TryAddSingleton(collection, service, implementationFactory);

    public static void TryAddSingleton(this object? collection, Type service, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
        => PluginServiceCollectionDescriptor.TryAddSingleton(collection, service, implementationType);

    public static void TryAddSingleton(this object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service)
        => PluginServiceCollectionDescriptor.TryAddSingleton(collection, service);

    public static void TryAddTransient(this object? collection, Type service, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
        => PluginServiceCollectionDescriptor.TryAddTransient(collection, service, implementationType);

    public static void TryAddTransient(this object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service)
        => PluginServiceCollectionDescriptor.TryAddTransient(collection, service);

    public static void TryAddTransient<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection) where TService : class where TImplementation : class, TService
        => PluginServiceCollectionDescriptor.TryAddTransient<TService, TImplementation>(collection);

    public static void TryAddTransient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection) where TService : class
        => PluginServiceCollectionDescriptor.TryAddTransient<TService>(collection);

    public static void TryAddTransient<TService>(this object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class
        => PluginServiceCollectionDescriptor.TryAddTransient<TService>(services, implementationFactory);

    public static void TryAddTransient(this object? collection, Type service, Func<IServiceProvider, object> implementationFactory)
        => PluginServiceCollectionDescriptor.TryAddTransient(collection, service, implementationFactory);
}