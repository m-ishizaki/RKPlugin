using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginObjectPoolServiceCollectionCaller
{
    public static object? AddPooled<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services, Action<object?>? configure = null) where TService : class => null;

    public static object? AddPooled<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services, Action<object?>? configure = null) where TService : class where TImplementation : class, TService => null;

    public static object? ConfigurePool<TService>(this object? services, Action<object?> configure) where TService : class => null;

    public static object? ConfigurePools(this object? services, object? section) => null;

    private static object? AddPooledInternal<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services, Action<object?>? configure) where TService : class where TImplementation : class, TService => null;

}
