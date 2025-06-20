﻿using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Extensions.DependencyInjection.Extensions;

public static class ServiceCollectionDescriptorExtensions
{
    public static List<string> Invoked = new List<string>();

    static object? Add(string name)
    {
        Invoked.Add(name);
        return null;
    }

    public static object? Add(this object? collection, object? descriptor)
        => Add("public static object? Add(this object? collection, object? descriptor)");

    public static object? Add(this object? collection, IEnumerable<object?> descriptors)
        => Add("public static object? Add(this object? collection, IEnumerable<object?> descriptors)");

    public static object? RemoveAll(this object? collection, Type serviceType)
        => Add("public static object? RemoveAll(this object? collection, Type serviceType)");

    public static object? RemoveAll<T>(this object? collection)
        => Add("public static object? RemoveAll<T>(this object? collection)");

    public static object? RemoveAllKeyed<T>(this object? collection, object? serviceKey)
        => Add("public static object? RemoveAllKeyed<T>(this object? collection, object? serviceKey)");

    public static object? RemoveAllKeyed(this object? collection, Type serviceType, object? serviceKey)
        => Add("public static object? RemoveAllKeyed(this object? collection, Type serviceType, object? serviceKey)");

    public static object? Replace(this object? collection, object? descriptor)
        => Add("public static object? Replace(this object? collection, object? descriptor)");

    public static void TryAdd(this object? collection, object? descriptor)
        => Add("public static void TryAdd(this object? collection, object? descriptor)");

    public static void TryAdd(this object? collection, IEnumerable<object?> descriptors)
        => Add("public static void TryAdd(this object? collection, IEnumerable<object?> descriptors)");

    public static void TryAddEnumerable(this object? services, object? descriptor)
        => Add("public static void TryAddEnumerable(this object? services, object? descriptor)");

    public static void TryAddEnumerable(this object? services, IEnumerable<object?> descriptors)
        => Add("public static void TryAddEnumerable(this object? services, IEnumerable<object?> descriptors)");

    public static void TryAddKeyedScoped<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection, object? serviceKey) where TService : class where TImplementation : class, TService
        => Add("public static void TryAddKeyedScoped<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection, object? serviceKey) where TService : class where TImplementation : class, TService");

    public static void TryAddKeyedScoped<TService>(this object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class
        => Add("public static void TryAddKeyedScoped<TService>(this object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class");

    public static void TryAddKeyedScoped<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection, object? serviceKey) where TService : class
        => Add("public static void TryAddKeyedScoped<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection, object? serviceKey) where TService : class");

    public static void TryAddKeyedScoped(this object? collection, Type service, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory)
        => Add("public static void TryAddKeyedScoped(this object? collection, Type service, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory)");

    public static void TryAddKeyedScoped(this object? collection, Type service, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
        => Add("public static void TryAddKeyedScoped(this object? collection, Type service, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)");

    public static void TryAddKeyedScoped(this object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service, object? serviceKey)
        => Add("public static void TryAddKeyedScoped(this object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service, object? serviceKey)");

    public static void TryAddKeyedSingleton<TService>(this object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class
        => Add("public static void TryAddKeyedSingleton<TService>(this object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class");

    public static void TryAddKeyedSingleton<TService>(this object? collection, object? serviceKey, TService instance) where TService : class
        => Add("public static void TryAddKeyedSingleton<TService>(this object? collection, object? serviceKey, TService instance) where TService : class");

    public static void TryAddKeyedSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection, object? serviceKey) where TService : class where TImplementation : class, TService
        => Add("public static void TryAddKeyedSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection, object? serviceKey) where TService : class where TImplementation : class, TService");

    public static void TryAddKeyedSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection, object? serviceKey) where TService : class
        => Add("public static void TryAddKeyedSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection, object? serviceKey) where TService : class");

    public static void TryAddKeyedSingleton(this object? collection, Type service, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory)
        => Add("public static void TryAddKeyedSingleton(this object? collection, Type service, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory)");

    public static void TryAddKeyedSingleton(this object? collection, Type service, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
        => Add("public static void TryAddKeyedSingleton(this object? collection, Type service, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)");

    public static void TryAddKeyedSingleton(this object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service, object? serviceKey)
        => Add("public static void TryAddKeyedSingleton(this object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service, object? serviceKey)");

    public static void TryAddKeyedTransient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection, object? serviceKey) where TService : class
        => Add("public static void TryAddKeyedTransient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection, object? serviceKey) where TService : class");

    public static void TryAddKeyedTransient<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection, object? serviceKey) where TService : class where TImplementation : class, TService
        => Add("public static void TryAddKeyedTransient<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection, object? serviceKey) where TService : class where TImplementation : class, TService");

    public static void TryAddKeyedTransient(this object? collection, Type service, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
        => Add("public static void TryAddKeyedTransient(this object? collection, Type service, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)");

    public static void TryAddKeyedTransient(this object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service, object? serviceKey)
        => Add("public static void TryAddKeyedTransient(this object? collection, [DynamicallyAccessedMemberTypes.PublicConstructors)] Type service, object? serviceKey)");

    public static void TryAddKeyedTransient<TService>(this object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class
        => Add("public static void TryAddKeyedTransient<TService>(this object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class");

    public static void TryAddKeyedTransient(this object? collection, Type service, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory)
        => Add("public static void TryAddKeyedTransient(this object? collection, Type service, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory)");

    public static void TryAddScoped(this object? collection, Type service, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
        => Add("public static void TryAddScoped(this object? collection, Type service, [DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)");

    public static void TryAddScoped(this object? collection, Type service, Func<IServiceProvider, object> implementationFactory)
        => Add("public static void TryAddScoped(this object? collection, Type service, Func<IServiceProvider, object> implementationFactory)");

    public static void TryAddScoped<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection) where TService : class
        => Add("public static void TryAddScoped<[DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection) where TService : class");

    public static void TryAddScoped<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection) where TService : class where TImplementation : class, TService
        => Add("public static void TryAddScoped<TService, [DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection) where TService : class where TImplementation : class, TService");

    public static void TryAddScoped<TService>(this object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class
        => Add("public static void TryAddScoped<TService>(this object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class");

    public static void TryAddScoped(this object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service)
        => Add("public static void TryAddScoped(this object? collection, [DynamicallyAccessedMemberTypes.PublicConstructors)] Type service)");

    public static void TryAddSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection) where TService : class
        => Add("public static void TryAddSingleton<[DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection) where TService : class");

    public static void TryAddSingleton<TService>(this object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class
        => Add("public static void TryAddSingleton<TService>(this object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class");

    public static void TryAddSingleton<TService>(this object? collection, TService instance) where TService : class
        => Add("public static void TryAddSingleton<TService>(this object? collection, TService instance) where TService : class");

    public static void TryAddSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection) where TService : class where TImplementation : class, TService
        => Add("public static void TryAddSingleton<TService, [DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection) where TService : class where TImplementation : class, TService");

    public static void TryAddSingleton(this object? collection, Type service, Func<IServiceProvider, object> implementationFactory)
        => Add("public static void TryAddSingleton(this object? collection, Type service, Func<IServiceProvider, object> implementationFactory)");

    public static void TryAddSingleton(this object? collection, Type service, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
        => Add("public static void TryAddSingleton(this object? collection, Type service, [DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)");

    public static void TryAddSingleton(this object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service)
        => Add("public static void TryAddSingleton(this object? collection, [DynamicallyAccessedMemberTypes.PublicConstructors)] Type service)");

    public static void TryAddTransient(this object? collection, Type service, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
        => Add("public static void TryAddTransient(this object? collection, Type service, [DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)");

    public static void TryAddTransient(this object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service)
        => Add("public static void TryAddTransient(this object? collection, [DynamicallyAccessedMemberTypes.PublicConstructors)] Type service)");

    public static void TryAddTransient<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection) where TService : class where TImplementation : class, TService
        => Add("public static void TryAddTransient<TService, [DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection) where TService : class where TImplementation : class, TService");

    public static void TryAddTransient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection) where TService : class
        => Add("public static void TryAddTransient<[DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection) where TService : class");

    public static void TryAddTransient<TService>(this object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class
        => Add("public static void TryAddTransient<TService>(this object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class");

    public static void TryAddTransient(this object? collection, Type service, Func<IServiceProvider, object> implementationFactory)
        => Add("public static void TryAddTransient(this object? collection, Type service, Func<IServiceProvider, object> implementationFactory)");
}