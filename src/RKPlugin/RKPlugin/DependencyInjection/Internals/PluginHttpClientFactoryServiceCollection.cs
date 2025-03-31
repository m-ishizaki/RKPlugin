using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginHttpClientFactoryServiceCollection
{
    static readonly string BaseType = "Microsoft.Extensions.DependencyInjection.HttpClientFactoryServiceCollectionExtensions,Microsoft.Extensions.Http";

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

    // キャッシュしたいが、キーの名前をきちんとつけるより実装を増やすことを優先する
    /*
    public static object? AddHttpClient<TClient, TImplementation>(object? services, Func<HttpClient, TImplementation> factory)
        where TClient : class where TImplementation : class, TClient
    {
        const string MethodName = "AddHttpClient<T1, T2>(object, Func<HttpClient, TImplementation>)";
        var method = TypeInitializer.Method(BaseType, MethodName,
            type =>
            {
                var methodInfo = type?.GetMethods().Where(x =>
                    x.Name == nameof(AddHttpClient)
                    && x.GetGenericArguments().Length == 2
                    && x.GetParameters().Length == 2
                    && x.GetParameters()[1].Name == nameof(factory)
                ).FirstOrDefault();
                var method = methodInfo?.MakeGenericMethod([typeof(TClient), typeof(TImplementation)]);
                return method;
            });
        return method?.Invoke(null, [services, factory]);
    }
    */
    public static object? AddHttpClient<TClient, TImplementation>(object? services, Func<HttpClient, TImplementation> factory)
        where TClient : class where TImplementation : class, TClient
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddHttpClient)
            && x.GetGenericArguments().Length == 2
            && x.GetParameters().Length == 2
            && x.GetParameters()[1].Name == nameof(factory)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TClient), typeof(TImplementation));
        var result = method?.Invoke(null, [services, factory]);
        return result;
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

