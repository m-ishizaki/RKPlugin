using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using static System.Collections.Specialized.BitVector32;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginObjectPoolServiceCollectionCaller
{
    public static object? AddPooled<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services, Action<object?>? configure = null) where TService : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x =>
            x.Name == nameof(AddPooled)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(configure)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TService));
        var result = method?.Invoke(services, [configure]);
        return result;
    }


    public static object? AddPooled<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services, Action<object?>? configure = null) where TService : class where TImplementation : class, TService
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x =>
                x.Name == nameof(AddPooled)
                && x.GetGenericArguments().Length == 2
                && x.GetParameters().Length == 1
                && x.GetParameters()[0].Name == nameof(configure)
            ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TService), typeof(TImplementation));
        var result = method?.Invoke(services, [configure]);
        return result;
    }


    public static object? ConfigurePool<TService>(this object? services, Action<object?> configure) where TService : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x =>
                x.Name == nameof(ConfigurePool)
                && x.GetGenericArguments().Length == 1
                && x.GetParameters().Length == 1
                && x.GetParameters()[0].Name == nameof(configure)
            ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TService));
        var result = method?.Invoke(services, [configure]);
        return result;
    }


    public static object? ConfigurePools(this object? services, object? section)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x =>
                x.Name == nameof(ConfigurePools)
                && x.GetGenericArguments().Length == 0
                && x.GetParameters().Length == 1
                && x.GetParameters()[0].Name == nameof(section)
            ).FirstOrDefault();
        var method = methodInfo;
        var result = method?.Invoke(services, [section]);
        return result;
    }
}
