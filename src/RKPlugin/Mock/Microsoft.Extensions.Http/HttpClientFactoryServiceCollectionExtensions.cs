﻿using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Extensions.DependencyInjection;

public static class HttpClientFactoryServiceCollectionExtensions
{
    public static List<string> Invoked = new List<string>();

    static object? Add(string name)
    {
        Invoked.Add(name);
        return null;
    }

    public static object? AddHttpClient(this object? services)
        => Add("public static object? AddHttpClient(this object? services)");

    public static object? ConfigureHttpClientDefaults(this object? services, Action<object?> configure)
        => Add("public static object? ConfigureHttpClientDefaults(this object? services, Action<object?> configure)");

    public static object? AddHttpClient(this object? services, string name)
        => Add("public static object? AddHttpClient(this object? services, string name)");

    public static object? AddHttpClient(this object? services, string name, Action<HttpClient> configureClient)
        => Add("public static object? AddHttpClient(this object? services, string name, Action<HttpClient> configureClient)");

    public static object? AddHttpClient(this object? services, string name, Action<IServiceProvider, HttpClient> configureClient)
        => Add("public static object? AddHttpClient(this object? services, string name, Action<IServiceProvider, HttpClient> configureClient)");

    public static object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(this object? services) where TClient : class
        => Add("public static object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(this object? services) where TClient : class");
    public static object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services) where TClient : class where TImplementation : class, TClient
        => Add("public static object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services) where TClient : class where TImplementation : class, TClient");

    public static object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(this object? services, string name) where TClient : class
        => Add("public static object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(this object? services, string name) where TClient : class");

    public static object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services, string name) where TClient : class where TImplementation : class, TClient
        => Add("public static object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services, string name) where TClient : class where TImplementation : class, TClient");

    public static object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(this object? services, Action<HttpClient> configureClient) where TClient : class
        => Add("public static object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(this object? services, Action<HttpClient> configureClient) where TClient : class");

    public static object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(this object? services, Action<IServiceProvider, HttpClient> configureClient) where TClient : class
        => Add("public static object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(this object? services, Action<IServiceProvider, HttpClient> configureClient) where TClient : class");

    public static object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services, Action<HttpClient> configureClient) where TClient : class where TImplementation : class, TClient
        => Add("public static object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services, Action<HttpClient> configureClient) where TClient : class where TImplementation : class, TClient");

    public static object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services, Action<IServiceProvider, HttpClient> configureClient) where TClient : class where TImplementation : class, TClient
        => Add("public static object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services, Action<IServiceProvider, HttpClient> configureClient) where TClient : class where TImplementation : class, TClient");

    public static object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(this object? services, string name, Action<HttpClient> configureClient) where TClient : class
        => Add("public static object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(this object? services, string name, Action<HttpClient> configureClient) where TClient : class");

    public static object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(this object? services, string name, Action<IServiceProvider, HttpClient> configureClient) where TClient : class
        => Add("public static object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(this object? services, string name, Action<IServiceProvider, HttpClient> configureClient) where TClient : class");

    public static object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services, string name, Action<HttpClient> configureClient) where TClient : class where TImplementation : class, TClient
        => Add("public static object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services, string name, Action<HttpClient> configureClient) where TClient : class where TImplementation : class, TClient");

    public static object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services, string name, Action<IServiceProvider, HttpClient> configureClient) where TClient : class where TImplementation : class, TClient
        => Add("public static object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services, string name, Action<IServiceProvider, HttpClient> configureClient) where TClient : class where TImplementation : class, TClient");

    public static object? AddHttpClient<TClient, TImplementation>(object? services, Func<HttpClient, TImplementation> factory) where TClient : class where TImplementation : class, TClient
        => Add("public static object? AddHttpClient<TClient, TImplementation>(object? services, Func<HttpClient, TImplementation> factory) where TClient : class where TImplementation : class, TClient");

    public static object? AddHttpClient<TClient, TImplementation>(this object? services, string name, Func<HttpClient, TImplementation> factory) where TClient : class where TImplementation : class, TClient
        => Add("public static object? AddHttpClient<TClient, TImplementation>(this object? services, string name, Func<HttpClient, TImplementation> factory) where TClient : class where TImplementation : class, TClient");

    public static object? AddHttpClient<TClient, TImplementation>(this object? services, Func<HttpClient, IServiceProvider, TImplementation> factory) where TClient : class where TImplementation : class, TClient
        => Add("public static object? AddHttpClient<TClient, TImplementation>(this object? services, Func<HttpClient, IServiceProvider, TImplementation> factory) where TClient : class where TImplementation : class, TClient");

    public static object? AddHttpClient<TClient, TImplementation>(this object? services, string name, Func<HttpClient, IServiceProvider, TImplementation> factory) where TClient : class where TImplementation : class, TClient
        => Add("public static object? AddHttpClient<TClient, TImplementation>(this object? services, string name, Func<HttpClient, IServiceProvider, TImplementation> factory) where TClient : class where TImplementation : class, TClient");
}

