using System.Diagnostics.CodeAnalysis;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

public static class PluginServiceCollectionDescriptor
{
    public static object? Add(this object? collection, object? descriptor) => null;

    public static object? Add(this object? collection, IEnumerable<object?> descriptors) => null;

    public static object? RemoveAll(this object? collection, Type serviceType) => null;

    public static object? RemoveAll<T>(this object? collection) => null;

    public static object? RemoveAllKeyed<T>(this object? collection, object? serviceKey) => null;

    public static object? RemoveAllKeyed(this object? collection, Type serviceType, object? serviceKey) => null;

    public static object? Replace(this object? collection, object? descriptor) => null;

    public static void TryAdd(this object? collection, object? descriptor) {}

    public static void TryAdd(this object? collection, IEnumerable<object?> descriptors) { }

    public static void TryAddEnumerable(this object? services, object? descriptor) { }

    public static void TryAddEnumerable(this object? services, IEnumerable<object?> descriptors) { }

    public static void TryAddKeyedScoped<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection, object? serviceKey) where TService : class where TImplementation : class, TService { }

    public static void TryAddKeyedScoped<TService>(this object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class { }

    public static void TryAddKeyedScoped<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection, object? serviceKey) where TService : class { }

    public static void TryAddKeyedScoped(this object? collection, Type service, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory) { }

    public static void TryAddKeyedScoped(this object? collection, Type service, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) { }

    public static void TryAddKeyedScoped(this object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service, object? serviceKey) { }

    public static void TryAddKeyedSingleton<TService>(this object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class { }

    public static void TryAddKeyedSingleton<TService>(this object? collection, object? serviceKey, TService instance) where TService : class { }

    public static void TryAddKeyedSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection, object? serviceKey) where TService : class where TImplementation : class, TService { }

    public static void TryAddKeyedSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection, object? serviceKey) where TService : class { }

    public static void TryAddKeyedSingleton(this object? collection, Type service, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory) { }

    public static void TryAddKeyedSingleton(this object? collection, Type service, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) { }

    public static void TryAddKeyedSingleton(this object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service, object? serviceKey) { }

    public static void TryAddKeyedTransient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection, object? serviceKey) where TService : class { }

    public static void TryAddKeyedTransient<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection, object? serviceKey) where TService : class where TImplementation : class, TService { }

    public static void TryAddKeyedTransient(this object? collection, Type service, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) { }

    public static void TryAddKeyedTransient(this object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service, object? serviceKey) { }

    public static void TryAddKeyedTransient<TService>(this object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class { }

    public static void TryAddKeyedTransient(this object? collection, Type service, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory) { }

    public static void TryAddScoped(this object? collection, Type service, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) { }

    public static void TryAddScoped(this object? collection, Type service, Func<IServiceProvider, object> implementationFactory) { }

    public static void TryAddScoped<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection) where TService : class { }

    public static void TryAddScoped<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection) where TService : class where TImplementation : class, TService { }

    public static void TryAddScoped<TService>(this object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class { }

    public static void TryAddScoped(this object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service) { }

    public static void TryAddSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection) where TService : class { }

    public static void TryAddSingleton<TService>(this object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class { }

    public static void TryAddSingleton<TService>(this object? collection, TService instance) where TService : class { }

    public static void TryAddSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection) where TService : class where TImplementation : class, TService { }

    public static void TryAddSingleton(this object? collection, Type service, Func<IServiceProvider, object> implementationFactory) { }

    public static void TryAddSingleton(this object? collection, Type service, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) { }

    public static void TryAddSingleton(this object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service) { }

    public static void TryAddTransient(this object? collection, Type service, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) { }

    public static void TryAddTransient(this object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service) { }

    public static void TryAddTransient<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection) where TService : class where TImplementation : class, TService { }

    public static void TryAddTransient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection) where TService : class { }

    public static void TryAddTransient<TService>(this object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class { }

    public static void TryAddTransient(this object? collection, Type service, Func<IServiceProvider, object> implementationFactory) { }
}