using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginServiceCollectionServiceCaller
{
    public static object? AddTransient(
        this object? services,
        Type serviceType,
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddTransient)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(serviceType)
            && x.GetParameters()[1].Name == nameof(implementationType)
        ).FirstOrDefault();
        var method = methodInfo;
        return method?.Invoke(services, [serviceType, implementationType]);
    }

    public static object? AddTransient(
        this object? services,
        Type serviceType,
        Func<IServiceProvider, object> implementationFactory)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddTransient)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(serviceType)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        var method = methodInfo;
        return method?.Invoke(services, [serviceType, implementationFactory]);
    }

    public static object? AddTransient<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services)
        where TService : class
        where TImplementation : class, TService
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddTransient)
            && x.GetGenericArguments().Length == 2
            && x.GetParameters().Length == 0
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetGenericArguments()[1].Name == nameof(TImplementation)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TService), typeof(TImplementation));
        return method?.Invoke(services, []);
    }

    public static object? AddTransient(
        this object? services,
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddTransient)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(serviceType)
        ).FirstOrDefault();
        var method = methodInfo;
        return method?.Invoke(services, [serviceType]);
    }

    public static object? AddTransient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services)
        where TService : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddTransient)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 0
            && x.GetGenericArguments()[0].Name == nameof(TService)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TService));
        return method?.Invoke(services, []);
    }

    public static object? AddTransient<TService>(
        this object? services,
        Func<IServiceProvider, TService> implementationFactory)
        where TService : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddTransient)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(implementationFactory)
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetParameters()[0].ParameterType.GenericTypeArguments.Length == 2
            && x.GetParameters()[0].ParameterType.GenericTypeArguments[0].Name == nameof(IServiceProvider)
            && x.GetParameters()[0].ParameterType.GenericTypeArguments[1].Name == nameof(TService)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TService));
        return method?.Invoke(services, [implementationFactory]);
    }

    public static object? AddTransient<TService, TImplementation>(
        this object? services,
        Func<IServiceProvider, TImplementation> implementationFactory)
        where TService : class
        where TImplementation : class, TService
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddTransient)
            && x.GetGenericArguments().Length == 2
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(implementationFactory)
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetGenericArguments()[1].Name == nameof(TImplementation)
            && x.GetParameters()[0].ParameterType.GenericTypeArguments.Length == 2
            && x.GetParameters()[0].ParameterType.GenericTypeArguments[0].Name == nameof(IServiceProvider)
            && x.GetParameters()[0].ParameterType.GenericTypeArguments[1].Name == nameof(TImplementation)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TService), typeof(TImplementation));
        return method?.Invoke(services, [implementationFactory]);
    }

    public static object? AddScoped(
        this object? services,
        Type serviceType,
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddScoped)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(serviceType)
            && x.GetParameters()[1].Name == nameof(implementationType)
        ).FirstOrDefault();
        var method = methodInfo;
        return method?.Invoke(services, [serviceType, implementationType]);
    }

    public static object? AddScoped(
        this object? services,
        Type serviceType,
        Func<IServiceProvider, object> implementationFactory)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddScoped)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(serviceType)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        var method = methodInfo;
        return method?.Invoke(services, [serviceType, implementationFactory]);
    }

    public static object? AddScoped<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services)
        where TService : class
        where TImplementation : class, TService
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddScoped)
            && x.GetGenericArguments().Length == 2
            && x.GetParameters().Length == 0
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetGenericArguments()[1].Name == nameof(TImplementation)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TService), typeof(TImplementation));
        return method?.Invoke(services, []);
    }

    public static object? AddScoped(
        this object? services,
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddScoped)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(serviceType)
        ).FirstOrDefault();
        var method = methodInfo;
        return method?.Invoke(services, [serviceType]);
    }

    public static object? AddScoped<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services)
        where TService : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddScoped)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 0
            && x.GetGenericArguments()[0].Name == nameof(TService)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TService));
        return method?.Invoke(services, []);
    }

    public static object? AddScoped<TService>(object? services, Func<IServiceProvider, TService> implementationFactory)
        where TService : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddScoped)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(implementationFactory)
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetParameters()[0].ParameterType.GenericTypeArguments.Length == 2
            && x.GetParameters()[0].ParameterType.GenericTypeArguments[0].Name == nameof(IServiceProvider)
            && x.GetParameters()[0].ParameterType.GenericTypeArguments[1].Name == nameof(TService)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TService));
        return method?.Invoke(services, [implementationFactory]);
    }

    public static object? AddScoped<TService, TImplementation>(
        this object? services,
        Func<IServiceProvider, TImplementation> implementationFactory)
        where TService : class
        where TImplementation : class, TService
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddScoped)
            && x.GetGenericArguments().Length == 2
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(implementationFactory)
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetGenericArguments()[1].Name == nameof(TImplementation)
            && x.GetParameters()[0].ParameterType.GenericTypeArguments.Length == 2
            && x.GetParameters()[0].ParameterType.GenericTypeArguments[0].Name == nameof(IServiceProvider)
            && x.GetParameters()[0].ParameterType.GenericTypeArguments[1].Name == nameof(TImplementation)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TService), typeof(TImplementation));
        return method?.Invoke(services, [implementationFactory]);
    }

    public static object? AddSingleton(
        this object? services,
        Type serviceType,
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddSingleton)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(serviceType)
            && x.GetParameters()[1].Name == nameof(implementationType)
        ).FirstOrDefault();
        var method = methodInfo;
        return method?.Invoke(services, [serviceType, implementationType]);
    }

    public static object? AddSingleton(
        this object? services,
        Type serviceType,
        Func<IServiceProvider, object> implementationFactory)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddSingleton)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(serviceType)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        var method = methodInfo;
        return method?.Invoke(services, [serviceType, implementationFactory]);
    }

    public static object? AddSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services)
        where TService : class
        where TImplementation : class, TService
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddSingleton)
            && x.GetGenericArguments().Length == 2
            && x.GetParameters().Length == 0
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetGenericArguments()[1].Name == nameof(TImplementation)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TService), typeof(TImplementation));
        return method?.Invoke(services, []);
    }

    public static object? AddSingleton(
        this object? services,
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddSingleton)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(serviceType)
        ).FirstOrDefault();
        var method = methodInfo;
        return method?.Invoke(services, [serviceType]);
    }

    public static object? AddSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services)
        where TService : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddSingleton)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 0
            && x.GetGenericArguments()[0].Name == nameof(TService)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TService));
        return method?.Invoke(services, []);
    }

    public static object? AddSingleton<TService>(
        this object? services,
        Func<IServiceProvider, TService> implementationFactory)
        where TService : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddSingleton)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(implementationFactory)
            && x.GetGenericArguments()[0].Name == nameof(TService)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TService));
        return method?.Invoke(services, [implementationFactory]);
    }

    public static object? AddSingleton<TService, TImplementation>(
        this object? services,
        Func<IServiceProvider, TImplementation> implementationFactory)
        where TService : class
        where TImplementation : class, TService
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddSingleton)
            && x.GetGenericArguments().Length == 2
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(implementationFactory)
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetGenericArguments()[1].Name == nameof(TImplementation)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TService), typeof(TImplementation));
        return method?.Invoke(services, [implementationFactory]);
    }

    public static object? AddSingleton(
        this object? services,
        Type serviceType,
        object implementationInstance)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddSingleton)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(serviceType)
            && x.GetParameters()[1].Name == nameof(implementationInstance)
        ).FirstOrDefault();
        var method = methodInfo;
        return method?.Invoke(services, [serviceType, implementationInstance]);
    }

    public static object? AddSingleton<TService>(
        this object? services,
        TService implementationInstance)
        where TService : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddSingleton)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(implementationInstance)
            && x.GetGenericArguments()[0].Name == nameof(TService)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TService));
        return method?.Invoke(services, [implementationInstance]);
    }
}
