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

    object? AddHttpClient() => throw new NotImplementedException();
    public static object? AddHttpClient(object? services) => throw new NotImplementedException();
    object? ConfigureHttpClientDefaults(Action<object?> configure) => throw new NotImplementedException();
    public static object? ConfigureHttpClientDefaults(object? services, Action<object?> configure) => throw new NotImplementedException();
    object? AddHttpClient(string name) => throw new NotImplementedException();
    public static object? AddHttpClient(object? services, string name) => throw new NotImplementedException();
    object? AddHttpClient(string name, Action<HttpClient> configureClient) => throw new NotImplementedException();
    public static object? AddHttpClient(object? services, string name, Action<HttpClient> configureClient) => throw new NotImplementedException();
    object? AddHttpClient(string name, Action<IServiceProvider, HttpClient> configureClient) => throw new NotImplementedException();
    public static object? AddHttpClient(object? services, string name, Action<IServiceProvider, HttpClient> configureClient) => throw new NotImplementedException();
    object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>() where TClient : class => throw new NotImplementedException();
    public static object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(object? services) where TClient : class => throw new NotImplementedException();
    object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>() where TClient : class where TImplementation : class, TClient => throw new NotImplementedException();
    public static object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services) where TClient : class where TImplementation : class, TClient => throw new NotImplementedException();
    object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(string name) where TClient : class => throw new NotImplementedException();
    public static object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(object? services, string name) where TClient : class => throw new NotImplementedException();
    object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(string name) where TClient : class where TImplementation : class, TClient => throw new NotImplementedException();
    public static object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services, string name) where TClient : class where TImplementation : class, TClient => throw new NotImplementedException();
    object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(Action<HttpClient> configureClient) where TClient : class => throw new NotImplementedException();
    public static object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(object? services, Action<HttpClient> configureClient) where TClient : class => throw new NotImplementedException();
    object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(Action<IServiceProvider, HttpClient> configureClient) where TClient : class => throw new NotImplementedException();
    public static object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(object? services, Action<IServiceProvider, HttpClient> configureClient) where TClient : class => throw new NotImplementedException();
    object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(Action<HttpClient> configureClient) where TClient : class where TImplementation : class, TClient => throw new NotImplementedException();
    public static object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services, Action<HttpClient> configureClient) where TClient : class where TImplementation : class, TClient => throw new NotImplementedException();
    object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(Action<IServiceProvider, HttpClient> configureClient) where TClient : class where TImplementation : class, TClient => throw new NotImplementedException();
    public static object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services, Action<IServiceProvider, HttpClient> configureClient) where TClient : class where TImplementation : class, TClient => throw new NotImplementedException();
    object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(string name, Action<HttpClient> configureClient) where TClient : class => throw new NotImplementedException();
    public static object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(object? services, string name, Action<HttpClient> configureClient) where TClient : class => throw new NotImplementedException();
    object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(string name, Action<IServiceProvider, HttpClient> configureClient) where TClient : class => throw new NotImplementedException();
    public static object? AddHttpClient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient>(object? services, string name, Action<IServiceProvider, HttpClient> configureClient) where TClient : class => throw new NotImplementedException();
    object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(string name, Action<HttpClient> configureClient) where TClient : class where TImplementation : class, TClient => throw new NotImplementedException();
    public static object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services, string name, Action<HttpClient> configureClient) where TClient : class where TImplementation : class, TClient => throw new NotImplementedException();
    object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(string name, Action<IServiceProvider, HttpClient> configureClient) where TClient : class where TImplementation : class, TClient => throw new NotImplementedException();
    public static object? AddHttpClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services, string name, Action<IServiceProvider, HttpClient> configureClient) where TClient : class where TImplementation : class, TClient => throw new NotImplementedException();

    object? AddHttpClient<TClient, TImplementation>(Func<HttpClient, TImplementation> factory) where TClient : class where TImplementation : class, TClient => PluginHttpClientFactoryServiceCollection.AddHttpClient<TClient, TImplementation>(Services, factory);
    public static object? AddHttpClient<TClient, TImplementation>(object? services, Func<HttpClient, TImplementation> factory) where TClient : class where TImplementation : class, TClient => PluginHttpClientFactoryServiceCollectionCaller.AddHttpClient<TClient, TImplementation>(services, factory);

    object? AddHttpClient<TClient, TImplementation>(string name, Func<HttpClient, TImplementation> factory) where TClient : class where TImplementation : class, TClient => throw new NotImplementedException();
    public static object? AddHttpClient<TClient, TImplementation>(object? services, string name, Func<HttpClient, TImplementation> factory) where TClient : class where TImplementation : class, TClient => throw new NotImplementedException();
    object? AddHttpClient<TClient, TImplementation>(Func<HttpClient, IServiceProvider, TImplementation> factory) where TClient : class where TImplementation : class, TClient => throw new NotImplementedException();
    public static object? AddHttpClient<TClient, TImplementation>(object? services, Func<HttpClient, IServiceProvider, TImplementation> factory) where TClient : class where TImplementation : class, TClient => throw new NotImplementedException();
    object? AddHttpClient<TClient, TImplementation>(string name, Func<HttpClient, IServiceProvider, TImplementation> factory) where TClient : class where TImplementation : class, TClient => throw new NotImplementedException();
    public static object? AddHttpClient<TClient, TImplementation>(object? services, string name, Func<HttpClient, IServiceProvider, TImplementation> factory) where TClient : class where TImplementation : class, TClient => throw new NotImplementedException();

    object? AddTransient(Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) => throw new NotImplementedException();
    public static object? AddTransient(object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) => throw new NotImplementedException();
    object? AddTransient(Type serviceType, Func<IServiceProvider, object> implementationFactory) => throw new NotImplementedException();
    public static object? AddTransient(object? services, Type serviceType, Func<IServiceProvider, object> implementationFactory) => throw new NotImplementedException();
    object? AddTransient<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>() where TService : class where TImplementation : class, TService => throw new NotImplementedException();
    public static object? AddTransient<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services) where TService : class where TImplementation : class, TService => throw new NotImplementedException();
    object? AddTransient([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType) => throw new NotImplementedException();
    public static object? AddTransient(object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType) => throw new NotImplementedException();
    object? AddTransient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>() where TService : class => throw new NotImplementedException();
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
