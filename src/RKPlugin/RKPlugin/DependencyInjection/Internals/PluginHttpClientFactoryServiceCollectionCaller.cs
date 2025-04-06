using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Sockets;
using System.Reflection;
using System.Text;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginHttpClientFactoryServiceCollectionCaller
{
    public static object? AddHttpClient(this object? services)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddHttpClient)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 0
        ).FirstOrDefault();
        var method = methodInfo;
        return method?.Invoke(services, []);
    }

    public static object? ConfigureHttpClientDefaults(this object? services, Action<object?> configure)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(ConfigureHttpClientDefaults)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(configure)
            && x.GetParameters()[0].ParameterType.GenericTypeArguments.Length == 1
        ).FirstOrDefault();
        var method = methodInfo;
        return method?.Invoke(services, [configure]);
    }

    public static object? AddHttpClient(this object? services, string name)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddHttpClient)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(name)
            && x.GetParameters()[0].ParameterType.GenericTypeArguments.Length == 0
        ).FirstOrDefault();
        var method = methodInfo;
        return method?.Invoke(services, [name]);
    }

    public static object? AddHttpClient(this object? services, string name, Action<HttpClient> configureClient)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddHttpClient)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(name)
            && x.GetParameters()[1].Name == nameof(configureClient)
        ).FirstOrDefault();
        var method = methodInfo;
        return method?.Invoke(services, [name, configureClient]);
    }

    public static object? AddHttpClient(this object? services, string name, Action<IServiceProvider, HttpClient> configureClient)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddHttpClient)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(name)
            && x.GetParameters()[1].Name == nameof(configureClient)
            && x.GetParameters()[1].ParameterType.GenericTypeArguments.Length == 2
        ).FirstOrDefault();
        var method = methodInfo;
        return method?.Invoke(services, [name, configureClient]);
    }

    public static object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(
        this object? services)
        where TClient : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddHttpClient)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 0
            && x.GetGenericArguments()[0].Name == nameof(TClient)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TClient));
        return method?.Invoke(services, []);
    }

    public static object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(
        this object? services)
        where TClient : class
        where TImplementation : class, TClient
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddHttpClient)
            && x.GetGenericArguments().Length == 2
            && x.GetParameters().Length == 0
            && x.GetGenericArguments()[0].Name == nameof(TClient)
            && x.GetGenericArguments()[1].Name == nameof(TImplementation)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TClient), typeof(TImplementation));
        return method?.Invoke(services, []);
    }

    public static object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(
        this object? services, string name)
        where TClient : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddHttpClient)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(name)
            && x.GetGenericArguments()[0].Name == nameof(TClient)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TClient));
        return method?.Invoke(services, [name]);
    }

    public static object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(
        this object? services, string name)
        where TClient : class
        where TImplementation : class, TClient
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddHttpClient)
            && x.GetGenericArguments().Length == 2
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(name)
            && x.GetGenericArguments()[0].Name == nameof(TClient)
            && x.GetGenericArguments()[1].Name == nameof(TImplementation)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TClient), typeof(TImplementation));
        return method?.Invoke(services, [name]);
    }

    public static object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(
        this object? services, Action<HttpClient> configureClient)
        where TClient : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddHttpClient)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(configureClient)
            && x.GetGenericArguments()[0].Name == nameof(TClient)
            && x.GetParameters()[0].ParameterType.GenericTypeArguments.Length == 1
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TClient));
        return method?.Invoke(services, [configureClient]);
    }

    public static object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(
        this object? services, Action<IServiceProvider, HttpClient> configureClient)
        where TClient : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddHttpClient)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(configureClient)
            && x.GetGenericArguments()[0].Name == nameof(TClient)
            && x.GetParameters()[0].ParameterType.GenericTypeArguments.Length == 2
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TClient));
        return method?.Invoke(services, [configureClient]);
    }

    public static object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(
        this object? services, Action<HttpClient> configureClient)
        where TClient : class
        where TImplementation : class, TClient
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddHttpClient)
            && x.GetGenericArguments().Length == 2
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(configureClient)
            && x.GetGenericArguments()[0].Name == nameof(TClient)
            && x.GetGenericArguments()[1].Name == nameof(TImplementation)
            && x.GetParameters()[0].ParameterType.GenericTypeArguments.Length == 1
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TClient), typeof(TImplementation));
        return method?.Invoke(services, [configureClient]);
    }

    public static object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(
        this object? services, Action<IServiceProvider, HttpClient> configureClient)
        where TClient : class
        where TImplementation : class, TClient
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddHttpClient)
            && x.GetGenericArguments().Length == 2
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(configureClient)
            && x.GetGenericArguments()[0].Name == nameof(TClient)
            && x.GetGenericArguments()[1].Name == nameof(TImplementation)
            && x.GetParameters()[0].ParameterType.GenericTypeArguments.Length == 2
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TClient), typeof(TImplementation));
        return method?.Invoke(services, [configureClient]);
    }

    public static object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(
        this object? services, string name, Action<HttpClient> configureClient)
        where TClient : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddHttpClient)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(name)
            && x.GetParameters()[1].Name == nameof(configureClient)
            && x.GetGenericArguments()[0].Name == nameof(TClient)
            && x.GetParameters()[1].ParameterType.GenericTypeArguments.Length == 1
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TClient));
        return method?.Invoke(services, [name, configureClient]);
    }

    public static object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(
        this object? services, string name, Action<IServiceProvider, HttpClient> configureClient)
        where TClient : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddHttpClient)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(name)
            && x.GetParameters()[1].Name == nameof(configureClient)
            && x.GetGenericArguments()[0].Name == nameof(TClient)
            && x.GetParameters()[1].ParameterType.GenericTypeArguments.Length == 2
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TClient));
        return method?.Invoke(services, [name, configureClient]);
    }

    public static object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(
        this object? services, string name, Action<HttpClient> configureClient)
        where TClient : class
        where TImplementation : class, TClient
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddHttpClient)
            && x.GetGenericArguments().Length == 2
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(name)
            && x.GetParameters()[1].Name == nameof(configureClient)
            && x.GetGenericArguments()[0].Name == nameof(TClient)
            && x.GetGenericArguments()[1].Name == nameof(TImplementation)
            && x.GetParameters()[1].ParameterType.GenericTypeArguments.Length == 1
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TClient), typeof(TImplementation));
        return method?.Invoke(services, [name, configureClient]);
    }

    public static object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(
        this object? services, string name, Action<IServiceProvider, HttpClient> configureClient)
        where TClient : class
        where TImplementation : class, TClient
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddHttpClient)
            && x.GetGenericArguments().Length == 2
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(name)
            && x.GetParameters()[1].Name == nameof(configureClient)
            && x.GetGenericArguments()[0].Name == nameof(TClient)
            && x.GetGenericArguments()[1].Name == nameof(TImplementation)
            && x.GetParameters()[1].ParameterType.GenericTypeArguments.Length == 2
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TClient), typeof(TImplementation));
        return method?.Invoke(services, [name, configureClient]);
    }


    public static object? AddHttpClient<TClient, TImplementation>(object? services, Func<HttpClient, TImplementation> factory)
        where TClient : class where TImplementation : class, TClient
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddHttpClient)
            && x.GetGenericArguments().Length == 2
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(factory)
            && x.GetGenericArguments()[0].Name == nameof(TClient)
            && x.GetGenericArguments()[1].Name == nameof(TImplementation)
            && x.GetParameters()[0].ParameterType.GenericTypeArguments.Length == 2
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TClient), typeof(TImplementation));
        return method?.Invoke(services, [factory]);
    }

    public static object? AddHttpClient<TClient, TImplementation>(this object? services, string name, Func<HttpClient, TImplementation> factory)
        where TClient : class
        where TImplementation : class, TClient
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddHttpClient)
            && x.GetGenericArguments().Length == 2
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(name)
            && x.GetParameters()[1].Name == nameof(factory)
            && x.GetParameters()[1].ParameterType.GenericTypeArguments.Length == 2
            && x.GetParameters()[1].ParameterType.GenericTypeArguments[1].Name == nameof(TImplementation)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TClient), typeof(TImplementation));
        return method?.Invoke(services, [name, factory]);
    }

    public static object? AddHttpClient<TClient, TImplementation>(this object? services, Func<HttpClient, IServiceProvider, TImplementation> factory)
        where TClient : class
        where TImplementation : class, TClient
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddHttpClient)
            && x.GetGenericArguments().Length == 2
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(factory)
            && x.GetParameters()[0].ParameterType.GenericTypeArguments.Length == 3
            && x.GetParameters()[0].ParameterType.GenericTypeArguments[2].Name == nameof(TImplementation)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TClient), typeof(TImplementation));
        return method?.Invoke(services, [factory]);
    }

    public static object? AddHttpClient<TClient, TImplementation>(this object? services, string name, Func<HttpClient, IServiceProvider, TImplementation> factory)
        where TClient : class
        where TImplementation : class, TClient
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddHttpClient)
            && x.GetGenericArguments().Length == 2
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(name)
            && x.GetParameters()[1].Name == nameof(factory)
            && x.GetParameters()[1].ParameterType.GenericTypeArguments.Length == 3
            && x.GetParameters()[1].ParameterType.GenericTypeArguments[2].Name == nameof(TImplementation)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TClient), typeof(TImplementation));
        return method?.Invoke(services, [name, factory]);
    }

}

