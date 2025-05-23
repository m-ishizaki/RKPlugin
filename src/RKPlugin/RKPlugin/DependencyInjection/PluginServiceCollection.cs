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

    // ApplicationEnricherServiceCollectionExtensions
    object? AddServiceLogEnricher() => PluginApplicationEnricherServiceCollection.AddServiceLogEnricher(Services);
    public static object? AddServiceLogEnricher(object? services) => PluginApplicationEnricherServiceCollectionCaller.AddServiceLogEnricher(services);

    object? AddServiceLogEnricher(Action<object?> configure) => PluginApplicationEnricherServiceCollection.AddServiceLogEnricher(Services, configure);
    public static object? AddServiceLogEnricher(object? services, Action<object?> configure) => PluginApplicationEnricherServiceCollectionCaller.AddServiceLogEnricher(services, configure);

    object? AddServiceLogEnricher_(object? section) => PluginApplicationEnricherServiceCollection.AddServiceLogEnricher_(Services, section);
    public static object? AddServiceLogEnricher_(object? services, object? section) => PluginApplicationEnricherServiceCollectionCaller.AddServiceLogEnricher_(services, section);

    //
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
    public static object? AddTransient(object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) => PluginServiceCollectionServiceCaller.AddTransient(services, serviceType, implementationType);
    object? AddTransient(Type serviceType, Func<IServiceProvider, object> implementationFactory) => PluginServiceCollectionService.AddTransient(Services, serviceType, implementationFactory);
    public static object? AddTransient(object? services, Type serviceType, Func<IServiceProvider, object> implementationFactory) => PluginServiceCollectionServiceCaller.AddTransient(services, serviceType, implementationFactory);
    object? AddTransient<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>() where TService : class where TImplementation : class, TService => PluginServiceCollectionService.AddTransient<TService, TImplementation>(Services);
    public static object? AddTransient<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services) where TService : class where TImplementation : class, TService => PluginServiceCollectionServiceCaller.AddTransient<TService, TImplementation>(services);
    object? AddTransient([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType) => PluginServiceCollectionService.AddTransient(Services, serviceType);
    public static object? AddTransient(object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType) => PluginServiceCollectionServiceCaller.AddTransient(services, serviceType);
    object? AddTransient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>() where TService : class => PluginServiceCollectionService.AddTransient<TService>(Services);
    public static object? AddTransient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(object? services) where TService : class => PluginServiceCollectionServiceCaller.AddTransient<TService>(services);
    object? AddTransient<TService>(Func<IServiceProvider, TService> implementationFactory) where TService : class => PluginServiceCollectionService.AddTransient<TService>(Services, implementationFactory);
    public static object? AddTransient<TService>(object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class => PluginServiceCollectionServiceCaller.AddTransient<TService>(services, implementationFactory);
    object? AddTransient<TService, TImplementation>(Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService => PluginServiceCollectionService.AddTransient<TService, TImplementation>(Services, implementationFactory);
    public static object? AddTransient<TService, TImplementation>(object? services, Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService => PluginServiceCollectionServiceCaller.AddTransient<TService, TImplementation>(services, implementationFactory);
    object? AddScoped(Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) => PluginServiceCollectionService.AddScoped(Services, serviceType, implementationType);
    public static object? AddScoped(object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) => PluginServiceCollectionServiceCaller.AddScoped(services, serviceType, implementationType);
    object? AddScoped(Type serviceType, Func<IServiceProvider, object> implementationFactory) => PluginServiceCollectionService.AddScoped(Services, serviceType, implementationFactory);
    public static object? AddScoped(object? services, Type serviceType, Func<IServiceProvider, object> implementationFactory) => PluginServiceCollectionServiceCaller.AddScoped(services, serviceType, implementationFactory);
    object? AddScoped<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>() where TService : class where TImplementation : class, TService => PluginServiceCollectionService.AddScoped<TService, TImplementation>(Services);
    public static object? AddScoped<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services) where TService : class where TImplementation : class, TService => PluginServiceCollectionServiceCaller.AddScoped<TService, TImplementation>(services);
    object? AddScoped([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType) => PluginServiceCollectionService.AddScoped(Services, serviceType);
    public static object? AddScoped(object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType) => PluginServiceCollectionServiceCaller.AddScoped(services, serviceType);
    object? AddScoped<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>() where TService : class => PluginServiceCollectionService.AddScoped<TService>(Services);
    public static object? AddScoped<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(object? services) where TService : class => PluginServiceCollectionServiceCaller.AddScoped<TService>(services);
    object? AddScoped<TService>(Func<IServiceProvider, TService> implementationFactory) where TService : class => PluginServiceCollectionService.AddScoped(Services, implementationFactory);
    public static object? AddScoped<TService>(object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class => PluginServiceCollectionServiceCaller.AddScoped(services, implementationFactory);
    object? AddScoped<TService, TImplementation>(Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService => PluginServiceCollectionService.AddScoped<TService, TImplementation>(Services, implementationFactory);
    public static object? AddScoped<TService, TImplementation>(object? services, Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService => PluginServiceCollectionServiceCaller.AddScoped<TService, TImplementation>(services, implementationFactory);
    object? AddSingleton(Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) => PluginServiceCollectionService.AddSingleton(Services, serviceType, implementationType);
    public static object? AddSingleton(object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) => PluginServiceCollectionServiceCaller.AddSingleton(services, serviceType, implementationType);
    object? AddSingleton(Type serviceType, Func<IServiceProvider, object> implementationFactory) => PluginServiceCollectionService.AddSingleton(Services, serviceType, implementationFactory);
    public static object? AddSingleton(object? services, Type serviceType, Func<IServiceProvider, object> implementationFactory) => PluginServiceCollectionServiceCaller.AddSingleton(services, serviceType, implementationFactory);
    object? AddSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>() where TService : class where TImplementation : class, TService => PluginServiceCollectionService.AddSingleton<TService, TImplementation>(Services);
    public static object? AddSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services) where TService : class where TImplementation : class, TService => PluginServiceCollectionServiceCaller.AddSingleton<TService, TImplementation>(services);
    object? AddSingleton([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType) => PluginServiceCollectionService.AddSingleton(Services, serviceType);
    public static object? AddSingleton(object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType) => PluginServiceCollectionServiceCaller.AddSingleton(services, serviceType);
    object? AddSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>() where TService : class => PluginServiceCollectionService.AddSingleton<TService>(Services);
    public static object? AddSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(object? services) where TService : class => PluginServiceCollectionServiceCaller.AddSingleton<TService>(services);
    object? AddSingleton<TService>(Func<IServiceProvider, TService> implementationFactory) where TService : class => PluginServiceCollectionService.AddSingleton<TService>(Services, implementationFactory);
    public static object? AddSingleton<TService>(object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class => PluginServiceCollectionServiceCaller.AddSingleton<TService>(services, implementationFactory);
    object? AddSingleton<TService, TImplementation>(Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService => PluginServiceCollectionService.AddSingleton<TService, TImplementation>(Services, implementationFactory);
    public static object? AddSingleton<TService, TImplementation>(object? services, Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService => PluginServiceCollectionServiceCaller.AddSingleton<TService, TImplementation>(services, implementationFactory);
    object? AddSingleton(Type serviceType, object implementationInstance) => PluginServiceCollectionService.AddSingleton(Services, serviceType, implementationInstance);
    public static object? AddSingleton(object? services, Type serviceType, object implementationInstance) => PluginServiceCollectionServiceCaller.AddSingleton(services, serviceType, implementationInstance);
    object? AddSingleton<TService>(TService implementationInstance) where TService : class => PluginServiceCollectionService.AddSingleton<TService>(Services, implementationInstance);
    public static object? AddSingleton<TService>(object? services, TService implementationInstance) where TService : class => PluginServiceCollectionServiceCaller.AddSingleton<TService>(services, implementationInstance);

    #region ApplicationMetadataServiceCollectionExtensions
    #endregion ApplicationMetadataServiceCollectionExtensions

    #region AsyncStateExtensions
    #endregion AsyncStateExtensions

    #region AutoActivationExtensions
    #endregion AutoActivationExtensions

    #region CommonHealthChecksExtensions
    #endregion CommonHealthChecksExtensions

    #region ContextualOptionsServiceCollectionExtensions

    object? AddContextualOptions() =>
        PluginContextualOptionsServiceCollection.AddContextualOptions(Services);
    public static object? AddContextualOptions(object? services) =>
        PluginContextualOptionsServiceCollectionCaller.AddContextualOptions(services);

    object? Configure<TOptions>(Func<object?, object?, object?> loadOptions) where TOptions : class =>
        PluginContextualOptionsServiceCollection.Configure<TOptions>(Services, loadOptions);
    public static object? Configure<TOptions>(object? services, Func<object?, object?, object?> loadOptions) where TOptions : class =>
        PluginContextualOptionsServiceCollectionCaller.Configure<TOptions>(services, loadOptions);

    object? Configure<TOptions>(string? name, Func<object?, object?, object?> loadOptions) where TOptions : class =>
        PluginContextualOptionsServiceCollection.Configure<TOptions>(Services, name, loadOptions);
    public static object? Configure<TOptions>(object? services, string? name, Func<object?, object?, object?> loadOptions) where TOptions : class =>
        PluginContextualOptionsServiceCollectionCaller.Configure<TOptions>(services, name, loadOptions);

    object? Configure<TOptions>(Action<object?, TOptions> configure) where TOptions : class =>
        PluginContextualOptionsServiceCollection.Configure<TOptions>(Services, configure);
    public static object? Configure<TOptions>(object? services, Action<object?, TOptions> configure) where TOptions : class =>
        PluginContextualOptionsServiceCollectionCaller.Configure<TOptions>(services, configure);

    object? Configure<TOptions>(string? name, Action<object?, TOptions> configure) where TOptions : class =>
        PluginContextualOptionsServiceCollection.Configure<TOptions>(Services, name, configure);
    public static object? Configure<TOptions>(object? services, string? name, Action<object?, TOptions> configure) where TOptions : class =>
        PluginContextualOptionsServiceCollectionCaller.Configure<TOptions>(services, name, configure);

    object? ConfigureAll<TOptions>(Func<object?, object?, object?> loadOptions) where TOptions : class =>
        PluginContextualOptionsServiceCollection.ConfigureAll<TOptions>(Services, loadOptions);
    public static object? ConfigureAll<TOptions>(object? services, Func<object?, object?, object?> loadOptions) where TOptions : class =>
        PluginContextualOptionsServiceCollectionCaller.ConfigureAll<TOptions>(services, loadOptions);

    object? ConfigureAll<TOptions>(Action<object?, TOptions> configure) where TOptions : class =>
        PluginContextualOptionsServiceCollection.ConfigureAll<TOptions>(Services, configure);
    public static object? ConfigureAll<TOptions>(object? services, Action<object?, TOptions> configure) where TOptions : class =>
        PluginContextualOptionsServiceCollectionCaller.ConfigureAll<TOptions>(services, configure);

    #endregion ContextualOptionsServiceCollectionExtensions

    #region EncoderServiceCollectionExtensions
    #endregion EncoderServiceCollectionExtensions

    #region EncoderServiceCollectionExtensions
    #endregion EncoderServiceCollectionExtensions

    #region EnrichmentServiceCollectionExtensions
    
    object? AddLogEnricher<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] T>() where T : class =>
        PluginEnrichmentServiceCollection.AddLogEnricher<T>(Services);
    public static object? AddLogEnricher<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] T>(object? services) where T : class =>
        PluginEnrichmentServiceCollectionCaller.AddLogEnricher<T>(services);
        
    object? AddLogEnricher(object? enricher) =>
        PluginEnrichmentServiceCollection.AddLogEnricher(Services, enricher);
    public static object? AddLogEnricher(object? services, object? enricher) =>
        PluginEnrichmentServiceCollectionCaller.AddLogEnricher(services, enricher);
        
    object? AddStaticLogEnricher<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] T>() where T : class =>
        PluginEnrichmentServiceCollection.AddStaticLogEnricher<T>(Services);
    public static object? AddStaticLogEnricher<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] T>(object? services) where T : class =>
        PluginEnrichmentServiceCollectionCaller.AddStaticLogEnricher<T>(services);
        
    object? AddStaticLogEnricher(object? enricher) =>
        PluginEnrichmentServiceCollection.AddStaticLogEnricher(Services, enricher);
    public static object? AddStaticLogEnricher(object? services, object? enricher) =>
        PluginEnrichmentServiceCollectionCaller.AddStaticLogEnricher(services, enricher);
        
    #endregion EnrichmentServiceCollectionExtensions

    #region ExceptionSummarizationServiceCollectionExtensions
    
    object? AddExceptionSummarizer() =>
        PluginExceptionSummarizationServiceCollection.AddExceptionSummarizer(Services);
    public static object? AddExceptionSummarizer(object? services) =>
        PluginExceptionSummarizationServiceCollectionCaller.AddExceptionSummarizer(services);
        
    object? AddExceptionSummarizer(Action<object?> configure) =>
        PluginExceptionSummarizationServiceCollection.AddExceptionSummarizer(Services, configure);
    public static object? AddExceptionSummarizer(object? services, Action<object?> configure) =>
        PluginExceptionSummarizationServiceCollectionCaller.AddExceptionSummarizer(services, configure);
        
    #endregion ExceptionSummarizationServiceCollectionExtensions

    #region ServiceCollectionDescriptorExtensions
    
    object? Add(object? descriptor) =>
        PluginServiceCollectionDescriptor.Add(Services, descriptor);
    public static object? Add(object? collection, object? descriptor) =>
        PluginServiceCollectionDescriptorCaller.Add(collection, descriptor);
        
    object? Add(IEnumerable<object?> descriptors) =>
        PluginServiceCollectionDescriptor.Add(Services, descriptors);
    public static object? Add(object? collection, IEnumerable<object?> descriptors) =>
        PluginServiceCollectionDescriptorCaller.Add(collection, descriptors);
        
    object? RemoveAll(Type serviceType) =>
        PluginServiceCollectionDescriptor.RemoveAll(Services, serviceType);
    public static object? RemoveAll(object? collection, Type serviceType) =>
        PluginServiceCollectionDescriptorCaller.RemoveAll(collection, serviceType);
        
    object? RemoveAll<T>() =>
        PluginServiceCollectionDescriptor.RemoveAll<T>(Services);
    public static object? RemoveAll<T>(object? collection) =>
        PluginServiceCollectionDescriptorCaller.RemoveAll<T>(collection);
        
    object? RemoveAllKeyed<T>(object? serviceKey) =>
        PluginServiceCollectionDescriptor.RemoveAllKeyed<T>(Services, serviceKey);
    public static object? RemoveAllKeyed<T>(object? collection, object? serviceKey) =>
        PluginServiceCollectionDescriptorCaller.RemoveAllKeyed<T>(collection, serviceKey);
    
    #endregion ServiceCollectionDescriptorExtensions

    #region FakeLoggerServiceCollectionExtensions
    
    object? AddFakeLogging(object? section) =>
        PluginFakeLoggerServiceCollection.AddFakeLogging(Services, section);
    public static object? AddFakeLogging(object? services, object? section) =>
        PluginFakeLoggerServiceCollectionCaller.AddFakeLogging(services, section);
        
    object? AddFakeLogging(Action<object?> configure) =>
        PluginFakeLoggerServiceCollection.AddFakeLogging(Services, configure);
    public static object? AddFakeLogging(object? services, Action<object?> configure) =>
        PluginFakeLoggerServiceCollectionCaller.AddFakeLogging(services, configure);
        
    object? AddFakeLogging() =>
        PluginFakeLoggerServiceCollection.AddFakeLogging(Services);
    public static object? AddFakeLogging(object? services) =>
        PluginFakeLoggerServiceCollectionCaller.AddFakeLogging(services);
        
    #endregion FakeLoggerServiceCollectionExtensions

    #region FakeRedactionServiceCollectionExtensions
    
    object? AddFakeRedaction() =>
        PluginFakeRedactionServiceCollection.AddFakeRedaction(Services);
    public static object? AddFakeRedaction(object? services) =>
        PluginFakeRedactionServiceCollectionCaller.AddFakeRedaction(services);
        
    object? AddFakeRedaction(Action<object?> configure) =>
        PluginFakeRedactionServiceCollection.AddFakeRedaction(Services, configure);
    public static object? AddFakeRedaction(object? services, Action<object?> configure) =>
        PluginFakeRedactionServiceCollectionCaller.AddFakeRedaction(services, configure);
        
    #endregion FakeRedactionServiceCollectionExtensions

    #region HealthCheckServiceCollectionExtensions
    
    object? AddHealthChecks() =>
        PluginHealthCheckServiceCollection.AddHealthChecks(Services);
    public static object? AddHealthChecks(object? services) =>
        PluginHealthCheckServiceCollectionCaller.AddHealthChecks(services);
        
    #endregion HealthCheckServiceCollectionExtensions

    #region HttpClientFactoryServiceCollectionExtensions
    // Methods already implemented at the top of the file (lines 30-71)
    #endregion HttpClientFactoryServiceCollectionExtensions

    #region HttpClientLatencyTelemetryExtensions
    
    object? AddHttpClientLatencyTelemetry() =>
        PluginHttpClientLatencyTelemetry.AddHttpClientLatencyTelemetry(Services);
    public static object? AddHttpClientLatencyTelemetry(object? services) =>
        PluginHttpClientLatencyTelemetryCaller.AddHttpClientLatencyTelemetry(services);
        
    object? AddHttpClientLatencyTelemetry(object? section) =>
        PluginHttpClientLatencyTelemetry.AddHttpClientLatencyTelemetry(Services, section);
    public static object? AddHttpClientLatencyTelemetry(object? services, object? section) =>
        PluginHttpClientLatencyTelemetryCaller.AddHttpClientLatencyTelemetry(services, section);
        
    object? AddHttpClientLatencyTelemetry(Action<object?> configure) =>
        PluginHttpClientLatencyTelemetry.AddHttpClientLatencyTelemetry(Services, configure);
    public static object? AddHttpClientLatencyTelemetry(object? services, Action<object?> configure) =>
        PluginHttpClientLatencyTelemetryCaller.AddHttpClientLatencyTelemetry(services, configure);
        
    #endregion HttpClientLatencyTelemetryExtensions

    #region HttpClientLoggingServiceCollectionExtensions
    
    object? AddExtendedHttpClientLogging() =>
        PluginHttpClientLoggingServiceCollection.AddExtendedHttpClientLogging(Services);
    public static object? AddExtendedHttpClientLogging(object? services) =>
        PluginHttpClientLoggingServiceCollectionCaller.AddExtendedHttpClientLogging(services);
        
    object? AddExtendedHttpClientLogging(object? section) =>
        PluginHttpClientLoggingServiceCollection.AddExtendedHttpClientLogging(Services, section);
    public static object? AddExtendedHttpClientLogging(object? services, object? section) =>
        PluginHttpClientLoggingServiceCollectionCaller.AddExtendedHttpClientLogging(services, section);
        
    object? AddExtendedHttpClientLogging(Action<object?> configure) =>
        PluginHttpClientLoggingServiceCollection.AddExtendedHttpClientLogging(Services, configure);
    public static object? AddExtendedHttpClientLogging(object? services, Action<object?> configure) =>
        PluginHttpClientLoggingServiceCollectionCaller.AddExtendedHttpClientLogging(services, configure);
        
    object? AddHttpClientLogEnricher<T>() where T : class =>
        PluginHttpClientLoggingServiceCollection.AddHttpClientLogEnricher<T>(Services);
    public static object? AddHttpClientLogEnricher<T>(object? services) where T : class =>
        PluginHttpClientLoggingServiceCollectionCaller.AddHttpClientLogEnricher<T>(services);
        
    #endregion HttpClientLoggingServiceCollectionExtensions

    #region HttpDiagnosticsServiceCollectionExtensions
    
    object? AddDownstreamDependencyMetadata(object? downstreamDependencyMetadata) =>
        PluginHttpDiagnosticsServiceCollection.AddDownstreamDependencyMetadata(Services, downstreamDependencyMetadata);
    public static object? AddDownstreamDependencyMetadata(object? services, object? downstreamDependencyMetadata) =>
        PluginHttpDiagnosticsServiceCollectionCaller.AddDownstreamDependencyMetadata(services, downstreamDependencyMetadata);
        
    object? AddDownstreamDependencyMetadata<T>() where T : class =>
        PluginHttpDiagnosticsServiceCollection.AddDownstreamDependencyMetadata<T>(Services);
    public static object? AddDownstreamDependencyMetadata<T>(object? services) where T : class =>
        PluginHttpDiagnosticsServiceCollectionCaller.AddDownstreamDependencyMetadata<T>(services);
        
    #endregion HttpDiagnosticsServiceCollectionExtensions

    #region HybridCacheServiceExtensions
    
    object? AddHybridCache() =>
        PluginHybridCacheService.AddHybridCache(Services);
    public static object? AddHybridCache(object? services) =>
        PluginHybridCacheServiceCaller.AddHybridCache(services);
        
    object? AddHybridCache(Action<object?> setupAction) =>
        PluginHybridCacheService.AddHybridCache(Services, setupAction);
    public static object? AddHybridCache(object? services, Action<object?> setupAction) =>
        PluginHybridCacheServiceCaller.AddHybridCache(services, setupAction);
        
    #endregion HybridCacheServiceExtensions

    #region KubernetesProbesExtensions
    
    object? AddKubernetesProbes() =>
        PluginKubernetesProbes.AddKubernetesProbes(Services);
    public static object? AddKubernetesProbes(object? services) =>
        PluginKubernetesProbesCaller.AddKubernetesProbes(services);
        
    object? AddKubernetesProbes(object? section) =>
        PluginKubernetesProbes.AddKubernetesProbes(Services, section);
    public static object? AddKubernetesProbes(object? services, object? section) =>
        PluginKubernetesProbesCaller.AddKubernetesProbes(services, section);
        
    object? AddKubernetesProbes(Action<object?> configure) =>
        PluginKubernetesProbes.AddKubernetesProbes(Services, configure);
    public static object? AddKubernetesProbes(object? services, Action<object?> configure) =>
        PluginKubernetesProbesCaller.AddKubernetesProbes(services, configure);
        
    #endregion KubernetesProbesExtensions

    #region LatencyConsoleExtensions
    
    object? AddConsoleLatencyDataExporter() =>
        PluginLatencyConsole.AddConsoleLatencyDataExporter(Services);
    public static object? AddConsoleLatencyDataExporter(object? services) =>
        PluginLatencyConsoleCaller.AddConsoleLatencyDataExporter(services);
        
    object? AddConsoleLatencyDataExporter(Action<object?> configure) =>
        PluginLatencyConsole.AddConsoleLatencyDataExporter(Services, configure);
    public static object? AddConsoleLatencyDataExporter(object? services, Action<object?> configure) =>
        PluginLatencyConsoleCaller.AddConsoleLatencyDataExporter(services, configure);
        
    object? AddConsoleLatencyDataExporter(object? section) =>
        PluginLatencyConsole.AddConsoleLatencyDataExporter(Services, section);
    public static object? AddConsoleLatencyDataExporter(object? services, object? section) =>
        PluginLatencyConsoleCaller.AddConsoleLatencyDataExporter(services, section);
        
    #endregion LatencyConsoleExtensions

    #region LatencyContextExtensions
    
    object? AddLatencyContext() =>
        PluginLatencyContext.AddLatencyContext(Services);
    public static object? AddLatencyContext(object? services) =>
        PluginLatencyContextCaller.AddLatencyContext(services);
        
    object? AddLatencyContext(Action<object?> configure) =>
        PluginLatencyContext.AddLatencyContext(Services, configure);
    public static object? AddLatencyContext(object? services, Action<object?> configure) =>
        PluginLatencyContextCaller.AddLatencyContext(services, configure);
        
    object? AddLatencyContext(object? section) =>
        PluginLatencyContext.AddLatencyContext(Services, section);
    public static object? AddLatencyContext(object? services, object? section) =>
        PluginLatencyContextCaller.AddLatencyContext(services, section);
        
    #endregion LatencyContextExtensions

    #region LatencyRegistryServiceCollectionExtensions
    
    object? RegisterCheckpointNames(params string[] names) =>
        PluginLatencyRegistryServiceCollection.RegisterCheckpointNames(Services, names);
    public static object? RegisterCheckpointNames(object? services, params string[] names) =>
        PluginLatencyRegistryServiceCollectionCaller.RegisterCheckpointNames(services, names);
        
    object? RegisterMeasureNames(params string[] names) =>
        PluginLatencyRegistryServiceCollection.RegisterMeasureNames(Services, names);
    public static object? RegisterMeasureNames(object? services, params string[] names) =>
        PluginLatencyRegistryServiceCollectionCaller.RegisterMeasureNames(services, names);
        
    object? RegisterTagNames(params string[] names) =>
        PluginLatencyRegistryServiceCollection.RegisterTagNames(Services, names);
    public static object? RegisterTagNames(object? services, params string[] names) =>
        PluginLatencyRegistryServiceCollectionCaller.RegisterTagNames(services, names);
        
    // Note: private method ConfigureOption is not exposed in the public API
        
    #endregion LatencyRegistryServiceCollectionExtensions

    #region LocalizationServiceCollectionExtensions
    
    object? AddLocalization() =>
        PluginLocalizationServiceCollection.AddLocalization(Services);
    public static object? AddLocalization(object? services) =>
        PluginLocalizationServiceCollectionCaller.AddLocalization(services);
        
    object? AddLocalization(Action<object?> setupAction) =>
        PluginLocalizationServiceCollection.AddLocalization(Services, setupAction);
    public static object? AddLocalization(object? services, Action<object?> setupAction) =>
        PluginLocalizationServiceCollectionCaller.AddLocalization(services, setupAction);
        
    #endregion LocalizationServiceCollectionExtensions

    #region LoggingServiceCollectionExtensions
    
    object? AddLogging() =>
        PluginLoggingServiceCollection.AddLogging(Services);
    public static object? AddLogging(object? services) =>
        PluginLoggingServiceCollectionCaller.AddLogging(services);
        
    object? AddLogging(Action<object?> configure) =>
        PluginLoggingServiceCollection.AddLogging(Services, configure);
    public static object? AddLogging(object? services, Action<object?> configure) =>
        PluginLoggingServiceCollectionCaller.AddLogging(services, configure);
        
    #endregion LoggingServiceCollectionExtensions

    #region MemoryCacheServiceCollectionExtensions
    
    object? AddDistributedMemoryCache() =>
        PluginMemoryCacheServiceCollection.AddDistributedMemoryCache(Services);
    public static object? AddDistributedMemoryCache(object? services) =>
        PluginMemoryCacheServiceCollectionCaller.AddDistributedMemoryCache(services);
        
    object? AddDistributedMemoryCache(Action<object?> setupAction) =>
        PluginMemoryCacheServiceCollection.AddDistributedMemoryCache(Services, setupAction);
    public static object? AddDistributedMemoryCache(object? services, Action<object?> setupAction) =>
        PluginMemoryCacheServiceCollectionCaller.AddDistributedMemoryCache(services, setupAction);
        
    object? AddMemoryCache() =>
        PluginMemoryCacheServiceCollection.AddMemoryCache(Services);
    public static object? AddMemoryCache(object? services) =>
        PluginMemoryCacheServiceCollectionCaller.AddMemoryCache(services);
        
    object? AddMemoryCache(Action<object?> setupAction) =>
        PluginMemoryCacheServiceCollection.AddMemoryCache(Services, setupAction);
    public static object? AddMemoryCache(object? services, Action<object?> setupAction) =>
        PluginMemoryCacheServiceCollectionCaller.AddMemoryCache(services, setupAction);
        
    #endregion MemoryCacheServiceCollectionExtensions

    #region MetricsServiceExtensions
    
    object? AddMetrics() =>
        PluginMetricsService.AddMetrics(Services);
    public static object? AddMetrics(object? services) =>
        PluginMetricsServiceCaller.AddMetrics(services);
        
    object? AddMetrics(Action<object?> configure) =>
        PluginMetricsService.AddMetrics(Services, configure);
    public static object? AddMetrics(object? services, Action<object?> configure) =>
        PluginMetricsServiceCaller.AddMetrics(services, configure);
        
    #endregion MetricsServiceExtensions

    #region NullLatencyContextServiceCollectionExtensions
    
    object? AddNullLatencyContext() =>
        PluginNullLatencyContextServiceCollection.AddNullLatencyContext(Services);
    public static object? AddNullLatencyContext(object? services) =>
        PluginNullLatencyContextServiceCollectionCaller.AddNullLatencyContext(services);
        
    #endregion NullLatencyContextServiceCollectionExtensions

    #region ObjectPoolServiceCollectionExtensions
    
    object? AddPooled<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(Action<object?>? configure = null) where TService : class =>
        PluginObjectPoolServiceCollection.AddPooled<TService>(Services, configure);
    public static object? AddPooled<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(object? services, Action<object?>? configure = null) where TService : class =>
        PluginObjectPoolServiceCollectionCaller.AddPooled<TService>(services, configure);
        
    object? AddPooled<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(Action<object?>? configure = null) where TService : class where TImplementation : class, TService =>
        PluginObjectPoolServiceCollection.AddPooled<TService, TImplementation>(Services, configure);
    public static object? AddPooled<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services, Action<object?>? configure = null) where TService : class where TImplementation : class, TService =>
        PluginObjectPoolServiceCollectionCaller.AddPooled<TService, TImplementation>(services, configure);
        
    object? ConfigurePool<TService>(Action<object?> configure) where TService : class =>
        PluginObjectPoolServiceCollection.ConfigurePool<TService>(Services, configure);
    public static object? ConfigurePool<TService>(object? services, Action<object?> configure) where TService : class =>
        PluginObjectPoolServiceCollectionCaller.ConfigurePool<TService>(services, configure);
        
    object? ConfigurePools(object? section) =>
        PluginObjectPoolServiceCollection.ConfigurePools(Services, section);
    public static object? ConfigurePools(object? services, object? section) =>
        PluginObjectPoolServiceCollectionCaller.ConfigurePools(services, section);
        
    // Note: private method AddPooledInternal is not exposed in the public API
        
    #endregion ObjectPoolServiceCollectionExtensions

    #region OptionsConfigurationServiceCollectionExtensions
    #endregion OptionsConfigurationServiceCollectionExtensions

    #region OptionsServiceCollectionExtensions
    #endregion OptionsServiceCollectionExtensions

    #region ProcessEnricherServiceCollectionExtensions
    #endregion ProcessEnricherServiceCollectionExtensions

    #region RedactionServiceCollectionExtensions
    #endregion RedactionServiceCollectionExtensions

    #region ResilienceServiceCollectionExtensions
    #endregion ResilienceServiceCollectionExtensions

    #region ResourceMonitoringServiceCollectionExtensions
    #endregion ResourceMonitoringServiceCollectionExtensions

    #region ServiceCollectionContainerBuilderExtensions
    #endregion ServiceCollectionContainerBuilderExtensions

    #region ServiceCollectionHostedServiceExtensions
    #endregion ServiceCollectionHostedServiceExtensions

    #region ServiceCollectionServiceExtensions
    #endregion ServiceCollectionServiceExtensions

    #region SqlServerCachingServicesExtensions
    #endregion SqlServerCachingServicesExtensions

    #region StackExchangeRedisCacheServiceCollectionExtensions
    #endregion StackExchangeRedisCacheServiceCollectionExtensions

    #region TcpEndpointProbesExtensions
    #endregion TcpEndpointProbesExtensions

    #region SystemdHostBuilderExtensions
    #endregion SystemdHostBuilderExtensions

    #region WindowsServiceLifetimeHostBuilderExtensions
    #endregion WindowsServiceLifetimeHostBuilderExtensions
}
