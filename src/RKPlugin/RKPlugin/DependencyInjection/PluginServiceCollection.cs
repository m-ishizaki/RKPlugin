using RkSoftware.RKPlugin.DependencyInjection.Internals;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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

    object? AddHttpClient() => PluginHttpClientFactoryServiceCollection.AddHttpClient(Services);
    public static object? AddHttpClient(object? services) => PluginHttpClientFactoryServiceCollectionCaller.AddHttpClient(services);
    object? ConfigureHttpClientDefaults(Action<object?> configure) => PluginHttpClientFactoryServiceCollection.ConfigureHttpClientDefaults(Services, configure);
    public static object? ConfigureHttpClientDefaults(object? services, Action<object?> configure) => PluginHttpClientFactoryServiceCollectionCaller.ConfigureHttpClientDefaults(services, configure);
    object? AddHttpClient(string name) => PluginHttpClientFactoryServiceCollection.AddHttpClient(Services, name);
    public static object? AddHttpClient(object? services, string name) => PluginHttpClientFactoryServiceCollectionCaller.AddHttpClient(services, name);
    object? AddHttpClient(string name, Action<HttpClient> configureClient) => PluginHttpClientFactoryServiceCollection.AddHttpClient(Services, name, configureClient);
    public static object? AddHttpClient(object? services, string name, Action<HttpClient> configureClient) => PluginHttpClientFactoryServiceCollectionCaller.AddHttpClient(services, name, configureClient);
    object? AddHttpClient(string name, Action<IServiceProvider, HttpClient> configureClient) => PluginHttpClientFactoryServiceCollection.AddHttpClient(Services, name, configureClient);
    public static object? AddHttpClient(object? services, string name, Action<IServiceProvider, HttpClient> configureClient) => PluginHttpClientFactoryServiceCollectionCaller.AddHttpClient(services, name, configureClient);
    object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>() where TClient : class => PluginHttpClientFactoryServiceCollection.AddHttpClient<TClient>(Services);
    public static object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(object? services) where TClient : class => PluginHttpClientFactoryServiceCollectionCaller.AddHttpClient<TClient>(services);
    object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>() where TClient : class where TImplementation : class, TClient => PluginHttpClientFactoryServiceCollection.AddHttpClient<TClient, TImplementation>(Services);
    public static object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services) where TClient : class where TImplementation : class, TClient => PluginHttpClientFactoryServiceCollectionCaller.AddHttpClient<TClient, TImplementation>(services);
    object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(string name) where TClient : class => PluginHttpClientFactoryServiceCollection.AddHttpClient<TClient>(Services, name);
    public static object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(object? services, string name) where TClient : class => PluginHttpClientFactoryServiceCollectionCaller.AddHttpClient<TClient>(services, name);
    object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(string name) where TClient : class where TImplementation : class, TClient => PluginHttpClientFactoryServiceCollection.AddHttpClient<TClient, TImplementation>(Services, name);
    public static object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services, string name) where TClient : class where TImplementation : class, TClient => PluginHttpClientFactoryServiceCollectionCaller.AddHttpClient<TClient, TImplementation>(services, name);
    object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(Action<HttpClient> configureClient) where TClient : class => PluginHttpClientFactoryServiceCollection.AddHttpClient<TClient>(Services, configureClient);
    public static object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(object? services, Action<HttpClient> configureClient) where TClient : class => PluginHttpClientFactoryServiceCollectionCaller.AddHttpClient<TClient>(services, configureClient);
    object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(Action<IServiceProvider, HttpClient> configureClient) where TClient : class => PluginHttpClientFactoryServiceCollection.AddHttpClient<TClient>(Services, configureClient);
    public static object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(object? services, Action<IServiceProvider, HttpClient> configureClient) where TClient : class => PluginHttpClientFactoryServiceCollectionCaller.AddHttpClient<TClient>(services, configureClient);
    object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(Action<HttpClient> configureClient) where TClient : class where TImplementation : class, TClient => PluginHttpClientFactoryServiceCollection.AddHttpClient<TClient, TImplementation>(Services, configureClient);
    public static object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services, Action<HttpClient> configureClient) where TClient : class where TImplementation : class, TClient => PluginHttpClientFactoryServiceCollectionCaller.AddHttpClient<TClient, TImplementation>(services, configureClient);
    object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(Action<IServiceProvider, HttpClient> configureClient) where TClient : class where TImplementation : class, TClient => PluginHttpClientFactoryServiceCollection.AddHttpClient<TClient, TImplementation>(Services, configureClient);
    public static object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services, Action<IServiceProvider, HttpClient> configureClient) where TClient : class where TImplementation : class, TClient => PluginHttpClientFactoryServiceCollectionCaller.AddHttpClient<TClient, TImplementation>(services, configureClient);
    object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(string name, Action<HttpClient> configureClient) where TClient : class => PluginHttpClientFactoryServiceCollection.AddHttpClient<TClient>(Services, name, configureClient);
    public static object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(object? services, string name, Action<HttpClient> configureClient) where TClient : class => PluginHttpClientFactoryServiceCollectionCaller.AddHttpClient<TClient>(services, name, configureClient);
    object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(string name, Action<IServiceProvider, HttpClient> configureClient) where TClient : class => PluginHttpClientFactoryServiceCollection.AddHttpClient<TClient>(Services, name, configureClient);
    public static object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(object? services, string name, Action<IServiceProvider, HttpClient> configureClient) where TClient : class => PluginHttpClientFactoryServiceCollectionCaller.AddHttpClient<TClient>(services, name, configureClient);
    object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(string name, Action<HttpClient> configureClient) where TClient : class where TImplementation : class, TClient => PluginHttpClientFactoryServiceCollection.AddHttpClient<TClient, TImplementation>(Services, name, configureClient);
    public static object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services, string name, Action<HttpClient> configureClient) where TClient : class where TImplementation : class, TClient => PluginHttpClientFactoryServiceCollectionCaller.AddHttpClient<TClient, TImplementation>(services, name, configureClient);
    object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(string name, Action<IServiceProvider, HttpClient> configureClient) where TClient : class where TImplementation : class, TClient => PluginHttpClientFactoryServiceCollection.AddHttpClient<TClient, TImplementation>(Services, name, configureClient);
    public static object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services, string name, Action<IServiceProvider, HttpClient> configureClient) where TClient : class where TImplementation : class, TClient => PluginHttpClientFactoryServiceCollectionCaller.AddHttpClient<TClient, TImplementation>(services, name, configureClient);
    object? AddHttpClient<TClient, TImplementation>(Func<HttpClient, TImplementation> factory) where TClient : class where TImplementation : class, TClient => PluginHttpClientFactoryServiceCollection.AddHttpClient<TClient, TImplementation>(Services, factory);
    public static object? AddHttpClient<TClient, TImplementation>(object? services, Func<HttpClient, TImplementation> factory) where TClient : class where TImplementation : class, TClient => PluginHttpClientFactoryServiceCollectionCaller.AddHttpClient<TClient, TImplementation>(services, factory);
    object? AddHttpClient<TClient, TImplementation>(string name, Func<HttpClient, TImplementation> factory) where TClient : class where TImplementation : class, TClient => PluginHttpClientFactoryServiceCollection.AddHttpClient<TClient, TImplementation>(Services, name, factory);
    public static object? AddHttpClient<TClient, TImplementation>(object? services, string name, Func<HttpClient, TImplementation> factory) where TClient : class where TImplementation : class, TClient => PluginHttpClientFactoryServiceCollectionCaller.AddHttpClient<TClient, TImplementation>(services, name, factory);
    object? AddHttpClient<TClient, TImplementation>(Func<HttpClient, IServiceProvider, TImplementation> factory) where TClient : class where TImplementation : class, TClient => PluginHttpClientFactoryServiceCollection.AddHttpClient<TClient, TImplementation>(Services, factory);
    public static object? AddHttpClient<TClient, TImplementation>(object? services, Func<HttpClient, IServiceProvider, TImplementation> factory) where TClient : class where TImplementation : class, TClient => PluginHttpClientFactoryServiceCollectionCaller.AddHttpClient<TClient, TImplementation>(services, factory);
    object? AddHttpClient<TClient, TImplementation>(string name, Func<HttpClient, IServiceProvider, TImplementation> factory) where TClient : class where TImplementation : class, TClient => PluginHttpClientFactoryServiceCollection.AddHttpClient<TClient, TImplementation>(Services, name, factory);
    public static object? AddHttpClient<TClient, TImplementation>(object? services, string name, Func<HttpClient, IServiceProvider, TImplementation> factory) where TClient : class where TImplementation : class, TClient => PluginHttpClientFactoryServiceCollectionCaller.AddHttpClient<TClient, TImplementation>(services, name, factory);

    object? AddTransient(Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) => PluginServiceCollectionService.AddTransient(Services, serviceType, implementationType);
    public static object? AddTransient(object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) => throw new NotImplementedException();
    object? AddTransient(Type serviceType, Func<IServiceProvider, object> implementationFactory) => PluginServiceCollectionService.AddTransient(Services, serviceType, implementationFactory);
    public static object? AddTransient(object? services, Type serviceType, Func<IServiceProvider, object> implementationFactory) => throw new NotImplementedException();
    object? AddTransient<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>() where TService : class where TImplementation : class, TService => PluginServiceCollectionService.AddTransient<TService, TImplementation>(Services);
    public static object? AddTransient<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services) where TService : class where TImplementation : class, TService => throw new NotImplementedException();
    object? AddTransient([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType) => PluginServiceCollectionService.AddTransient(Services, serviceType);
    public static object? AddTransient(object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType) => throw new NotImplementedException();
    object? AddTransient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>() where TService : class => PluginServiceCollectionService.AddTransient<TService>(Services);
    public static object? AddTransient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(object? services) where TService : class => throw new NotImplementedException();
    object? AddTransient<TService>(Func<IServiceProvider, TService> implementationFactory) where TService : class => throw new NotImplementedException();
    public static object? AddTransient<TService>(object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class => throw new NotImplementedException();
    object? AddTransient<TService, TImplementation>(Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService => throw new NotImplementedException();
    public static object? AddTransient<TService, TImplementation>(object? services, Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService => throw new NotImplementedException();
    object? AddScoped(Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) => throw new NotImplementedException();
    public static object? AddScoped(object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) => throw new NotImplementedException();
    object? AddScoped(Type serviceType, Func<IServiceProvider, object> implementationFactory) => throw new NotImplementedException();
    public static object? AddScoped(object? services, Type serviceType, Func<IServiceProvider, object> implementationFactory) => throw new NotImplementedException();
    object? AddScoped<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>() where TService : class where TImplementation : class, TService => throw new NotImplementedException();
    public static object? AddScoped<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services) where TService : class where TImplementation : class, TService => throw new NotImplementedException();
    object? AddScoped([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType) => throw new NotImplementedException();
    public static object? AddScoped(object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType) => throw new NotImplementedException();
    object? AddScoped<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>() where TService : class => throw new NotImplementedException();
    public static object? AddScoped<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(object? services) where TService : class => throw new NotImplementedException();

    object? AddScoped<TService>(Func<IServiceProvider, TService> implementationFactory) where TService : class => PluginServiceCollectionService.AddScoped(Services, implementationFactory);
    public static object? AddScoped<TService>(object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class => PluginServiceCollectionServiceCaller.AddScoped(services, implementationFactory);

    object? AddScoped<TService, TImplementation>(Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService => throw new NotImplementedException();
    public static object? AddScoped<TService, TImplementation>(object? services, Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService => throw new NotImplementedException();
    object? AddSingleton(Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) => throw new NotImplementedException();
    public static object? AddSingleton(object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) => throw new NotImplementedException();
    object? AddSingleton(Type serviceType, Func<IServiceProvider, object> implementationFactory) => throw new NotImplementedException();
    public static object? AddSingleton(object? services, Type serviceType, Func<IServiceProvider, object> implementationFactory) => throw new NotImplementedException();
    object? AddSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>() where TService : class where TImplementation : class, TService => throw new NotImplementedException();
    public static object? AddSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services) where TService : class where TImplementation : class, TService => throw new NotImplementedException();
    object? AddSingleton([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType) => throw new NotImplementedException();
    public static object? AddSingleton(object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType) => throw new NotImplementedException();
    object? AddSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>() where TService : class => throw new NotImplementedException();
    public static object? AddSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(object? services) where TService : class => throw new NotImplementedException();
    object? AddSingleton<TService>(Func<IServiceProvider, TService> implementationFactory) where TService : class => throw new NotImplementedException();
    public static object? AddSingleton<TService>(object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class => throw new NotImplementedException();
    object? AddSingleton<TService, TImplementation>(Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService => throw new NotImplementedException();
    public static object? AddSingleton<TService, TImplementation>(object? services, Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService => throw new NotImplementedException();
    object? AddSingleton(Type serviceType, object implementationInstance) => throw new NotImplementedException();
    public static object? AddSingleton(object? services, Type serviceType, object implementationInstance) => throw new NotImplementedException();
    object? AddSingleton<TService>(TService implementationInstance) where TService : class => throw new NotImplementedException();
    public static object? AddSingleton<TService>(object? services, TService implementationInstance) where TService : class => throw new NotImplementedException();
}
