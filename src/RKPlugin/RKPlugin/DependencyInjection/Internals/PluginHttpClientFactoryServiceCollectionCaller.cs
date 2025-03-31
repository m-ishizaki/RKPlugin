using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginHttpClientFactoryServiceCollectionCaller
{
    public static object? AddHttpClient(this object? services) => throw new NotImplementedException();
    public static object? ConfigureHttpClientDefaults(this object? services, Action<object?> configure) => throw new NotImplementedException();
    public static object? AddHttpClient(this object? services, string name) => throw new NotImplementedException();
    public static object? AddHttpClient(this object? services, string name, Action<HttpClient> configureClient) => throw new NotImplementedException();
    public static object? AddHttpClient(this object? services, string name, Action<IServiceProvider, HttpClient> configureClient) => throw new NotImplementedException();
    public static object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(
        this object? services)
        where TClient : class => throw new NotImplementedException();
    public static object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(
        this object? services)
        where TClient : class
        where TImplementation : class, TClient => throw new NotImplementedException();
    public static object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(
        this object? services, string name)
        where TClient : class => throw new NotImplementedException();
    public static object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(
        this object? services, string name)
        where TClient : class
        where TImplementation : class, TClient => throw new NotImplementedException();
    public static object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(
        this object? services, Action<HttpClient> configureClient)
        where TClient : class => throw new NotImplementedException();
    public static object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(
        this object? services, Action<IServiceProvider, HttpClient> configureClient)
        where TClient : class => throw new NotImplementedException();
    public static object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(
        this object? services, Action<HttpClient> configureClient)
        where TClient : class
        where TImplementation : class, TClient => throw new NotImplementedException();
    public static object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(
        this object? services, Action<IServiceProvider, HttpClient> configureClient)
        where TClient : class
        where TImplementation : class, TClient => throw new NotImplementedException();
    public static object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(
        this object? services, string name, Action<HttpClient> configureClient)
        where TClient : class => throw new NotImplementedException();
    public static object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(
        this object? services, string name, Action<IServiceProvider, HttpClient> configureClient)
        where TClient : class => throw new NotImplementedException();
    public static object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(
        this object? services, string name, Action<HttpClient> configureClient)
        where TClient : class
        where TImplementation : class, TClient => throw new NotImplementedException();
    public static object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(
        this object? services, string name, Action<IServiceProvider, HttpClient> configureClient)
        where TClient : class
        where TImplementation : class, TClient => throw new NotImplementedException();

    public static object? AddHttpClient<TClient, TImplementation>(object? services, Func<HttpClient, TImplementation> factory)
        where TClient : class where TImplementation : class, TClient
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddHttpClient)
            && x.GetGenericArguments().Length == 2
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(factory)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TClient), typeof(TImplementation));
        return method?.Invoke(services, [factory]);
    }

    public static object? AddHttpClient<TClient, TImplementation>(this object? services, string name, Func<HttpClient, TImplementation> factory)
        where TClient : class
        where TImplementation : class, TClient => throw new NotImplementedException();
    public static object? AddHttpClient<TClient, TImplementation>(this object? services, Func<HttpClient, IServiceProvider, TImplementation> factory)
        where TClient : class
        where TImplementation : class, TClient => throw new NotImplementedException();
    public static object? AddHttpClient<TClient, TImplementation>(this object? services, string name, Func<HttpClient, IServiceProvider, TImplementation> factory)
        where TClient : class
        where TImplementation : class, TClient => throw new NotImplementedException();
}

