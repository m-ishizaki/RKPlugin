using System;
using System.Linq;
using System.Reflection;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginAutoActivationCaller
{
    public static object? ActivateSingleton<TService>(this object? services) where TService : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(x =>
                x.Name == nameof(ActivateSingleton)
                && x.GetGenericArguments().Length == 1
                && x.GetParameters().Length == 0
            );
        var genericMethod = methodInfo?.MakeGenericMethod(typeof(TService));
        return genericMethod?.Invoke(services, Array.Empty<object>());
    }

    public static object? ActivateSingleton(this object? services, Type serviceType)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(x =>
                x.Name == nameof(ActivateSingleton)
                && x.GetGenericArguments().Length == 0
                && x.GetParameters().Length == 1
                && x.GetParameters()[0].ParameterType == typeof(Type)
            );
        return methodInfo?.Invoke(services, new object[] { serviceType });
    }

    public static object? AddActivatedSingleton<TService, TImplementation>(this object? services, Func<IServiceProvider, TImplementation> implementationFactory)
        where TService : class
        where TImplementation : class, TService
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(x =>
                x.Name == nameof(AddActivatedSingleton)
                && x.GetGenericArguments().Length == 2
                && x.GetParameters().Length == 1
                && x.GetParameters()[0].ParameterType == typeof(Func<IServiceProvider, TImplementation>)
            );
        var genericMethod = methodInfo?.MakeGenericMethod(typeof(TService), typeof(TImplementation));
        return genericMethod?.Invoke(services, new object[] { implementationFactory });
    }

    public static object? AddActivatedSingleton<TService>(this object? services, Func<IServiceProvider, TService> implementationFactory)
        where TService : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(x =>
                x.Name == nameof(AddActivatedSingleton)
                && x.GetGenericArguments().Length == 1
                && x.GetParameters().Length == 1
                && x.GetParameters()[0].ParameterType == typeof(Func<IServiceProvider, TService>)
            );
        var genericMethod = methodInfo?.MakeGenericMethod(typeof(TService));
        return genericMethod?.Invoke(services, new object[] { implementationFactory });
    }

    public static object? AddActivatedSingleton(this object? services, Type serviceType, Func<IServiceProvider, object> implementationFactory)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(x =>
                x.Name == nameof(AddActivatedSingleton)
                && x.GetGenericArguments().Length == 0
                && x.GetParameters().Length == 2
                && x.GetParameters()[0].ParameterType == typeof(Type)
                && x.GetParameters()[1].ParameterType == typeof(Func<IServiceProvider, object>)
            );
        return methodInfo?.Invoke(services, new object[] { serviceType, implementationFactory });
    }
}
