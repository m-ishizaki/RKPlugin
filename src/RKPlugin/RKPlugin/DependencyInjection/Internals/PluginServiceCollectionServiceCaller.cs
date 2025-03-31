using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginServiceCollectionServiceCaller
{
    public static object? AddTransient(
    this object? services,
    Type serviceType,
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) => throw new NotImplementedException();
    public static object? AddTransient(
        this object? services,
        Type serviceType,
        Func<IServiceProvider, object> implementationFactory) => throw new NotImplementedException();
    public static object? AddTransient<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services)
        where TService : class
        where TImplementation : class, TService => throw new NotImplementedException();
    public static object? AddTransient(
        this object? services,
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType) => throw new NotImplementedException();
    public static object? AddTransient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services)
        where TService : class => throw new NotImplementedException();
    public static object? AddTransient<TService>(
        this object? services,
        Func<IServiceProvider, TService> implementationFactory)
        where TService : class => throw new NotImplementedException();
    public static object? AddTransient<TService, TImplementation>(
        this object? services,
        Func<IServiceProvider, TImplementation> implementationFactory)
        where TService : class
        where TImplementation : class, TService => throw new NotImplementedException();
    public static object? AddScoped(
        this object? services,
        Type serviceType,
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) => throw new NotImplementedException();
    public static object? AddScoped(
        this object? services,
        Type serviceType,
        Func<IServiceProvider, object> implementationFactory) => throw new NotImplementedException();
    public static object? AddScoped<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services)
        where TService : class
        where TImplementation : class, TService => throw new NotImplementedException();
    public static object? AddScoped(
        this object? services,
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType) => throw new NotImplementedException();
    public static object? AddScoped<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services)
        where TService : class => throw new NotImplementedException();

    public static object? AddScoped<TService>(object? services, Func<IServiceProvider, TService> implementationFactory)
        where TService : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddScoped)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TService));
        return method?.Invoke(services, [implementationFactory]);
    }

    public static object? AddScoped<TService, TImplementation>(
        this object? services,
        Func<IServiceProvider, TImplementation> implementationFactory)
        where TService : class
        where TImplementation : class, TService => throw new NotImplementedException();
    public static object? AddSingleton(
        this object? services,
        Type serviceType,
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) => throw new NotImplementedException();
    public static object? AddSingleton(
        this object? services,
        Type serviceType,
        Func<IServiceProvider, object> implementationFactory) => throw new NotImplementedException();
    public static object? AddSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services)
        where TService : class
        where TImplementation : class, TService => throw new NotImplementedException();
    public static object? AddSingleton(
        this object? services,
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType) => throw new NotImplementedException();
    public static object? AddSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services)
        where TService : class => throw new NotImplementedException();
    public static object? AddSingleton<TService>(
        this object? services,
        Func<IServiceProvider, TService> implementationFactory)
        where TService : class => throw new NotImplementedException();
    public static object? AddSingleton<TService, TImplementation>(
        this object? services,
        Func<IServiceProvider, TImplementation> implementationFactory)
        where TService : class
        where TImplementation : class, TService => throw new NotImplementedException();
    public static object? AddSingleton(
        this object? services,
        Type serviceType,
        object implementationInstance) => throw new NotImplementedException();
    public static object? AddSingleton<TService>(
        this object? services,
        TService implementationInstance)
        where TService : class => throw new NotImplementedException();
}
