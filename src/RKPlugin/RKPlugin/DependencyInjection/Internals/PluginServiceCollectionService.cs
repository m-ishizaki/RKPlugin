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
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddTransient)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 3
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(serviceType)
            && x.GetParameters()[2].Name == nameof(implementationType)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod();
        var result = method?.Invoke(null, [services, serviceType, implementationType]);
        return result;
    }

    public static object? AddTransient(
        this object? services,
        Type serviceType,
        Func<IServiceProvider, object> implementationFactory)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddTransient)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 3
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(serviceType)
            && x.GetParameters()[2].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod();
        var result = method?.Invoke(null, [services, serviceType, implementationFactory]);
        return result;
    }

    public static object? AddTransient<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services)
        where TService : class
        where TImplementation : class, TService
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddTransient)
            && x.GetGenericArguments().Length == 2
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetGenericArguments()[1].Name == nameof(TImplementation)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod([typeof(TService), typeof(TImplementation)]);
        var result = method?.Invoke(null, [services]);
        return result;
    }

    public static object? AddTransient(
        this object? services,
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddTransient)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(serviceType)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod();
        var result = method?.Invoke(null, [services, serviceType]);
        return result;
    }

    public static object? AddTransient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services)
        where TService : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddTransient)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetGenericArguments()[0].Name == nameof(TService)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod([typeof(TService)]);
        var result = method?.Invoke(null, [services]);
        return result;
    }

    public static object? AddTransient<TService>(
        this object? services,
        Func<IServiceProvider, TService> implementationFactory)
        where TService : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddTransient)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 2
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod([typeof(TService)]);
        var result = method?.Invoke(null, [services, implementationFactory]);
        return result;
    }

    public static object? AddTransient<TService, TImplementation>(
        this object? services,
        Func<IServiceProvider, TImplementation> implementationFactory)
        where TService : class
        where TImplementation : class, TService
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddTransient)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 2
            && x.GetParameters()[1].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod([typeof(TService)]);
        var result = method?.Invoke(null, [services, implementationFactory]);
        return result;
    }

    public static object? AddScoped(
        this object? services,
        Type serviceType,
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddScoped)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 3
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(serviceType)
            && x.GetParameters()[2].Name == nameof(implementationType)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod();
        var result = method?.Invoke(null, [services, serviceType, implementationType]);
        return result;
    }

    public static object? AddScoped(
        this object? services,
        Type serviceType,
        Func<IServiceProvider, object> implementationFactory)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddScoped)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 3
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(serviceType)
            && x.GetParameters()[2].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod();
        var result = method?.Invoke(null, [services, serviceType, implementationFactory]);
        return result;
    }

    public static object? AddScoped<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services)
        where TService : class
        where TImplementation : class, TService
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddScoped)
            && x.GetGenericArguments().Length == 2
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetGenericArguments()[1].Name == nameof(TImplementation)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod([typeof(TService), typeof(TImplementation)]);
        var result = method?.Invoke(null, [services]);
        return result;
    }

    public static object? AddScoped(
        this object? services,
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddScoped)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(serviceType)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod();
        var result = method?.Invoke(null, [services, serviceType]);
        return result;
    }

    public static object? AddScoped<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services)
        where TService : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddScoped)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetGenericArguments()[0].Name == nameof(TService)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod([typeof(TService)]);
        var result = method?.Invoke(null, [services]);
        return result;
    }

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
        where TImplementation : class, TService
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

    public static object? AddSingleton(
        this object? services,
        Type serviceType,
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddSingleton)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 3
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(serviceType)
            && x.GetParameters()[2].Name == nameof(implementationType)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod();
        var result = method?.Invoke(null, [services, serviceType, implementationType]);
        return result;
    }

    public static object? AddSingleton(
        this object? services,
        Type serviceType,
        Func<IServiceProvider, object> implementationFactory)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddSingleton)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 3
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(serviceType)
            && x.GetParameters()[2].Name == nameof(implementationFactory)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod();
        var result = method?.Invoke(null, [services, serviceType, implementationFactory]);
        return result;
    }

    public static object? AddSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services)
        where TService : class
        where TImplementation : class, TService
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddSingleton)
            && x.GetGenericArguments().Length == 2
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(services)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod([typeof(TService), typeof(TImplementation)]);
        var result = method?.Invoke(null, [services]);
        return result;
    }

    public static object? AddSingleton(
        this object? services,
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddSingleton)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(serviceType)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod();
        var result = method?.Invoke(null, [services, serviceType]);
        return result;
    }

    public static object? AddSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services)
        where TService : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddSingleton)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetGenericArguments()[0].Name == nameof(TService)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod([typeof(TService)]);
        var result = method?.Invoke(null, [services]);
        return result;
    }

    public static object? AddSingleton<TService>(
        this object? services,
        Func<IServiceProvider, TService> implementationFactory)
        where TService : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddSingleton)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
            && x.GetGenericArguments()[0].Name == nameof(TService)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod([typeof(TService)]);
        var result = method?.Invoke(null, [services, implementationFactory]);
        return result;
    }

    public static object? AddSingleton<TService, TImplementation>(
        this object? services,
        Func<IServiceProvider, TImplementation> implementationFactory)
        where TService : class
        where TImplementation : class, TService
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddSingleton)
            && x.GetGenericArguments().Length == 2
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationFactory)
            && x.GetGenericArguments()[0].Name == nameof(TService)
            && x.GetGenericArguments()[1].Name == nameof(TImplementation)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod([typeof(TService)]);
        var result = method?.Invoke(null, [services, implementationFactory]);
        return result;
    }

    public static object? AddSingleton(
        this object? services,
        Type serviceType,
        object implementationInstance)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddSingleton)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 3
            && x.GetParameters()[1].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(serviceType)
            && x.GetParameters()[1].Name == nameof(implementationInstance)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod();
        var result = method?.Invoke(null, [services, serviceType, implementationInstance]);
        return result;
    }

    public static object? AddSingleton<TService>(
        this object? services,
        TService implementationInstance)
        where TService : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddSingleton)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[1].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(implementationInstance)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod([typeof(TService)]);
        var result = method?.Invoke(null, [services, implementationInstance]);
        return result;
    }
}
