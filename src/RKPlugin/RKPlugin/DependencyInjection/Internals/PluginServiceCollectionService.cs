using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginServiceCollectionService
{
    static readonly string BaseType = "Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions,Microsoft.Extensions.DependencyInjection.Abstractions";

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

    // キャッシュしたいが、キーの名前をきちんとつけるより実装を増やすことを優先する
    /*
    public static object? AddScoped<TService>(object? services, Func<IServiceProvider, TService> implementationFactory)
        where TService : class
    {
        const string MethodName = "AddScoped<T1>(object, Func<IServiceProvider, TService>)";
        var method = TypeInitializer.Method(BaseType, MethodName,
            type =>
            {
                var methodInfo = type?.GetMethods().Where(x =>
                    x.Name == nameof(AddScoped)
                    && x.GetGenericArguments().Length == 1
                    && x.GetParameters().Length == 2
                    && x.GetParameters()[1].Name == nameof(implementationFactory)
                ).FirstOrDefault();
                var method = methodInfo?.MakeGenericMethod([typeof(TService)]);
                return method;
            });
        return method?.Invoke(null, [services, implementationFactory]);
    }
    */
    public static object? AddScoped<TService>(object? services, Func<IServiceProvider, TService> implementationFactory)
        where TService : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddScoped)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 2
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod([typeof(TService)]);
        var result = method?.Invoke(null, [services, implementationFactory]);
        return result;
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
