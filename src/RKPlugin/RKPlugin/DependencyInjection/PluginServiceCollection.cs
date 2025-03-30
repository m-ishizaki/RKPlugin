using RkSoftware.RKPlugin.DependencyInjection.Internals;
using System;
using System.Collections.Generic;
using System.Text;

namespace RkSoftware.RKPlugin.DependencyInjection;

public class PluginServiceCollection
{
    object? Services { get; init; }
    static object? GetService(object? obj) => obj?.GetType()?.GetProperty(nameof(Services))?.GetValue(obj);

    internal PluginServiceCollection(object? services)
    {
        this.Services = services;
    }

    object? AddScoped<TService>(Func<IServiceProvider, TService> implementationFactory) where TService : class =>
        PluginServiceCollectionService.AddScoped(Services, implementationFactory);

    public static object? AddScoped<TService>(object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethod("AddScoped", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var method = methodInfo?.MakeGenericMethod(typeof(TService));
        return method?.Invoke(services, [implementationFactory]);
    }

    object? AddHttpClient<TClient, TImplementation>(Func<HttpClient, TImplementation> factory)
        where TClient : class where TImplementation : class, TClient =>
        PluginHttpClientFactoryServiceCollection.AddHttpClient<TClient, TImplementation>(Services, factory);

    public static object? AddHttpClient<TClient, TImplementation>(object? services, Func<HttpClient, TImplementation> factory)
        where TClient : class where TImplementation : class, TClient
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethod("AddHttpClient", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var method = methodInfo?.MakeGenericMethod(typeof(TClient), typeof(TImplementation));
        return method?.Invoke(services, [factory]);
    }
}
