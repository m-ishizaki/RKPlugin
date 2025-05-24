using System;
using System.Linq;
using System.Diagnostics.CodeAnalysis;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginAutoActivation
{
    static readonly string BaseType = "Microsoft.Extensions.DependencyInjection.AutoActivationExtensions,Microsoft.Extensions.DependencyInjection.AutoActivation";

    public static object? ActivateSingleton<TService>(this object? services) where TService : class => null;

    public static object? ActivateSingleton(this object? services, Type serviceType) => null;

    public static object? AddActivatedSingleton<TService, TImplementation>(this object? services, Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService => null;

    public static object? AddActivatedSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services) where TService : class where TImplementation : class, TService => null;

    public static object? AddActivatedSingleton<TService>(this object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class => null;

    public static object? AddActivatedSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services) where TService : class => null;

    public static object? AddActivatedSingleton(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType) => null;

    public static object? AddActivatedSingleton(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType, Func<IServiceProvider, object> implementationFactory) => null;

    public static object? AddActivatedSingleton(this object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) => null;

    public static void TryAddActivatedSingleton(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType) {}

    public static void TryAddActivatedSingleton(this object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) { }

    public static void TryAddActivatedSingleton(this object? services, Type serviceType, Func<IServiceProvider, object> implementationFactory) { }

    public static void TryAddActivatedSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services) where TService : class { }

    public static void TryAddActivatedSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services) where TService : class where TImplementation : class, TService { }

    public static void TryAddActivatedSingleton<TService>(this object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class { }

    private static void TryAddAndActivate<TService>(this object? services, object? descriptor) where TService : class { }

    private static void TryAddAndActivate(this object? services, object? descriptor) { }

    public static object? ActivateKeyedSingleton<TService>(this object? services, object? serviceKey) where TService : class => null;

    public static object? ActivateKeyedSingleton(this object? services, Type serviceType, object? serviceKey) => null;

    public static object? AddActivatedKeyedSingleton<TService, TImplementation>(this object? services, object? serviceKey, Func<IServiceProvider, object?, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService => null;

    public static object? AddActivatedKeyedSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services, object? serviceKey) where TService : class where TImplementation : class, TService => null;

    public static object? AddActivatedKeyedSingleton<TService>(this object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class => null;

    public static object? AddActivatedKeyedSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services, object? serviceKey) where TService : class => null;

    public static object? AddActivatedKeyedSingleton(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType, object? serviceKey) => null;

    public static object? AddActivatedKeyedSingleton(this object? services, Type serviceType, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory) => null;

    public static object? AddActivatedKeyedSingleton(this object? services, Type serviceType, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) => null;

    public static void TryAddActivatedKeyedSingleton(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType, object? serviceKey) { }

    public static void TryAddActivatedKeyedSingleton(this object? services, Type serviceType, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) { }

    public static void TryAddActivatedKeyedSingleton(this object? services, Type serviceType, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory) { }

    public static void TryAddActivatedKeyedSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services, object? serviceKey) where TService : class { }

    public static void TryAddActivatedKeyedSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services, object? serviceKey) where TService : class where TImplementation : class, TService { }

    public static void TryAddActivatedKeyedSingleton<TService>(this object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class { }

    private static void TryAddAndActivateKeyed<TService>(this object? services, object? descriptor) where TService : class { }

    private static void TryAddAndActivateKeyed(this object? services, object? descriptor) { }
}
