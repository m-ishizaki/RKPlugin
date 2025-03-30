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

    object? AddHttpClient<TClient, TImplementation>(Func<HttpClient, TImplementation> factory)
        where TClient : class where TImplementation : class, TClient =>
        PluginHttpClientFactoryServiceCollection.AddHttpClient<TClient, TImplementation>(Services, factory);

    public static object? AddHttpClient<TClient, TImplementation>(object? services, Func<HttpClient, TImplementation> factory)
        where TClient : class where TImplementation : class, TClient =>
        PluginHttpClientFactoryServiceCollectionCaller.AddHttpClient<TClient, TImplementation>(services, factory);

    object? AddScoped<TService>(Func<IServiceProvider, TService> implementationFactory) where TService : class =>
        PluginServiceCollectionService.AddScoped(Services, implementationFactory);

    public static object? AddScoped<TService>(object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class =>
        PluginServiceCollectionServiceCaller.AddScoped(services, implementationFactory);
}
