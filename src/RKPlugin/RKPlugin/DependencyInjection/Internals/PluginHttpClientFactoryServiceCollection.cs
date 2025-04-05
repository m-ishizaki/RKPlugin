using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginHttpClientFactoryServiceCollection
{
    static readonly string BaseType = "Microsoft.Extensions.DependencyInjection.HttpClientFactoryServiceCollectionExtensions,Microsoft.Extensions.Http";

    public static object? AddHttpClient(this object? services)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddHttpClient)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(services)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod();
        var result = method?.Invoke(null, [services]);
        return result;
    }

    public static object? ConfigureHttpClientDefaults(this object? services, Action<object?> configure)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddHttpClient)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[1].Name == nameof(configure)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod();
        var result = method?.Invoke(null, [services, configure]);
        return result;
    }

    public static object? AddHttpClient(this object? services, string name)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddHttpClient)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[1].Name == nameof(name)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod();
        var result = method?.Invoke(null, [services, name]);
        return result;
    }

    public static object? AddHttpClient(this object? services, string name, Action<HttpClient> configureClient)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddHttpClient)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 3
            && x.GetParameters()[2].Name == nameof(configureClient)
            && x.GetParameters()[2].ParameterType.GenericTypeArguments.Length == 1
            && x.GetParameters()[2].ParameterType.GenericTypeArguments[0].Name == nameof(HttpClient)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod();
        var result = method?.Invoke(null, [services, name, configureClient]);
        return result;
    }

    public static object? AddHttpClient(this object? services, string name, Action<IServiceProvider, HttpClient> configureClient)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddHttpClient)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 3
            && x.GetParameters()[2].Name == nameof(configureClient)
            && x.GetParameters()[2].ParameterType.GenericTypeArguments.Length == 2
            && x.GetParameters()[2].ParameterType.GenericTypeArguments[1].Name == nameof(HttpClient)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod();
        var result = method?.Invoke(null, [services, name, configureClient]);
        return result;
    }

    public static object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(
        this object? services)
        where TClient : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddHttpClient)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(services)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TClient));
        var result = method?.Invoke(null, [services]);
        return result;
    }

    public static object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(
        this object? services)
        where TClient : class
        where TImplementation : class, TClient
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddHttpClient)
            && x.GetGenericArguments().Length == 2
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(services)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TClient));
        var result = method?.Invoke(null, [services]);
        return result;
    }

    public static object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(
        this object? services, string name)
        where TClient : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddHttpClient)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 2
            && x.GetParameters()[1].Name == nameof(name)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TClient));
        var result = method?.Invoke(null, [services, name]);
        return result;
    }

    public static object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(
        this object? services, string name)
        where TClient : class
        where TImplementation : class, TClient
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddHttpClient)
            && x.GetGenericArguments().Length == 2
            && x.GetParameters().Length == 2
            && x.GetParameters()[1].Name == nameof(name)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TClient), typeof(TImplementation));
        var result = method?.Invoke(null, [services, name]);
        return result;
    }

    public static object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(
        this object? services, Action<HttpClient> configureClient)
        where TClient : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddHttpClient)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 2
            && x.GetParameters()[1].Name == nameof(configureClient)
            && x.GetParameters()[1].ParameterType.GenericTypeArguments.Count() == 1
            && x.GetParameters()[1].ParameterType.GenericTypeArguments[0].Name == nameof(HttpClient)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TClient));
        var result = method?.Invoke(null, [services, configureClient]);
        return result;
    }

    public static object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(
        this object? services, Action<IServiceProvider, HttpClient> configureClient)
        where TClient : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddHttpClient)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 2
            && x.GetParameters()[1].Name == nameof(configureClient)
            && x.GetParameters()[1].ParameterType.GenericTypeArguments.Count() == 2
            && x.GetParameters()[1].ParameterType.GenericTypeArguments[1].Name == nameof(HttpClient)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TClient));
        var result = method?.Invoke(null, [services, configureClient]);
        return result;
    }

    public static object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(
        this object? services, Action<HttpClient> configureClient)
        where TClient : class
        where TImplementation : class, TClient
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddHttpClient)
            && x.GetGenericArguments().Length == 2
            && x.GetParameters().Length == 2
            && x.GetParameters()[1].Name == nameof(configureClient)
            && x.GetParameters()[1].ParameterType.GenericTypeArguments.Count() == 1
            && x.GetParameters()[1].ParameterType.GenericTypeArguments[0].Name == nameof(HttpClient)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TClient));
        var result = method?.Invoke(null, [services, configureClient]);
        return result;
    }

    public static object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(
        this object? services, Action<IServiceProvider, HttpClient> configureClient)
        where TClient : class
        where TImplementation : class, TClient
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddHttpClient)
            && x.GetGenericArguments().Length == 2
            && x.GetParameters().Length == 2
            && x.GetParameters()[1].Name == nameof(configureClient)
            && x.GetParameters()[1].ParameterType.GenericTypeArguments.Count() == 2
            && x.GetParameters()[1].ParameterType.GenericTypeArguments[1].Name == nameof(HttpClient)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TClient));
        var result = method?.Invoke(null, [services, configureClient]);
        return result;
    }

    public static object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(
        this object? services, string name, Action<HttpClient> configureClient)
        where TClient : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddHttpClient)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 3
            && x.GetParameters()[1].Name == nameof(name)
            && x.GetParameters()[2].Name == nameof(configureClient)
            && x.GetParameters()[2].ParameterType.GenericTypeArguments.Count() == 1
            && x.GetParameters()[2].ParameterType.GenericTypeArguments[0].Name == nameof(HttpClient)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TClient));
        var result = method?.Invoke(null, [services, name, configureClient]);
        return result;
    }

    public static object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(
        this object? services, string name, Action<IServiceProvider, HttpClient> configureClient)
        where TClient : class
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddHttpClient)
            && x.GetGenericArguments().Length == 1
            && x.GetParameters().Length == 3
            && x.GetParameters()[1].Name == nameof(name)
            && x.GetParameters()[2].Name == nameof(configureClient)
            && x.GetParameters()[2].ParameterType.GenericTypeArguments.Count() == 2
            && x.GetParameters()[2].ParameterType.GenericTypeArguments[1].Name == nameof(HttpClient)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TClient));
        var result = method?.Invoke(null, [services, name, configureClient]);
        return result;
    }

    public static object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(
        this object? services, string name, Action<HttpClient> configureClient)
        where TClient : class
        where TImplementation : class, TClient
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddHttpClient)
            && x.GetGenericArguments().Length == 2
            && x.GetParameters().Length == 3
            && x.GetParameters()[1].Name == nameof(name)
            && x.GetParameters()[2].Name == nameof(configureClient)
            && x.GetParameters()[2].ParameterType.GenericTypeArguments.Count() == 1
            && x.GetParameters()[2].ParameterType.GenericTypeArguments[0].Name == nameof(HttpClient)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TClient), typeof(TImplementation));
        var result = method?.Invoke(null, [services, name, configureClient]);
        return result;
    }

    public static object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(
        this object? services, string name, Action<IServiceProvider, HttpClient> configureClient)
        where TClient : class
        where TImplementation : class, TClient
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddHttpClient)
            && x.GetGenericArguments().Length == 2
            && x.GetParameters().Length == 3
            && x.GetParameters()[1].Name == nameof(name)
            && x.GetParameters()[2].Name == nameof(configureClient)
            && x.GetParameters()[2].ParameterType.GenericTypeArguments.Count() == 2
            && x.GetParameters()[2].ParameterType.GenericTypeArguments[1].Name == nameof(HttpClient)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TClient), typeof(TImplementation));
        var result = method?.Invoke(null, [services, name, configureClient]);
        return result;
    }

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
            && x.GetParameters()[1].ParameterType.GenericTypeArguments.Count() == 2
            && x.GetParameters()[1].ParameterType.GenericTypeArguments[1].Name == nameof(TImplementation)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TClient), typeof(TImplementation));
        var result = method?.Invoke(null, [services, factory]);
        return result;
    }

    public static object? AddHttpClient<TClient, TImplementation>(this object? services, string name, Func<HttpClient, TImplementation> factory)
        where TClient : class
        where TImplementation : class, TClient
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddHttpClient)
            && x.GetGenericArguments().Length == 2
            && x.GetParameters().Length == 3
            && x.GetParameters()[1].Name == nameof(name)
            && x.GetParameters()[2].Name == nameof(factory)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TClient), typeof(TImplementation));
        var result = method?.Invoke(null, [services, name, factory]);
        return result;
    }

    public static object? AddHttpClient<TClient, TImplementation>(this object? services, Func<HttpClient, IServiceProvider, TImplementation> factory)
        where TClient : class
        where TImplementation : class, TClient
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddHttpClient)
            && x.GetGenericArguments().Length == 2
            && x.GetParameters().Length == 2
            && x.GetParameters()[1].Name == nameof(factory)
            && x.GetParameters()[1].ParameterType.GenericTypeArguments.Count() == 3
            && x.GetParameters()[1].ParameterType.GenericTypeArguments[2].Name == nameof(TImplementation)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TClient), typeof(TImplementation));
        var result = method?.Invoke(null, [services, factory]);
        return result;
    }

    public static object? AddHttpClient<TClient, TImplementation>(this object? services, string name, Func<HttpClient, IServiceProvider, TImplementation> factory)
        where TClient : class
        where TImplementation : class, TClient
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddHttpClient)
            && x.GetGenericArguments().Length == 2
            && x.GetParameters().Length == 3
            && x.GetParameters()[1].Name == nameof(name)
            && x.GetParameters()[2].Name == nameof(factory)
            && x.GetParameters()[2].ParameterType.GenericTypeArguments.Count() == 3
            && x.GetParameters()[2].ParameterType.GenericTypeArguments[2].Name == nameof(TImplementation)
        ).FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod(typeof(TClient), typeof(TImplementation));
        var result = method?.Invoke(null, [services, name, factory]);
        return result;
    }
}
