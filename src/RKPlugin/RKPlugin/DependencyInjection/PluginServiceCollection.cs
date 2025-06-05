using RkSoftware.RKPlugin.DependencyInjection.Internals;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;
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

    #region ApplicationEnricherServiceCollectionExtensions

    object? AddServiceLogEnricher() =>
        PluginApplicationEnricherServiceCollection.AddServiceLogEnricher(Services);
    public static object? AddServiceLogEnricher(object? services) =>
        PluginApplicationEnricherServiceCollectionCaller.AddServiceLogEnricher(services);

    object? AddServiceLogEnricher(Action<object?> configure) =>
        PluginApplicationEnricherServiceCollection.AddServiceLogEnricher(Services, configure);
    public static object? AddServiceLogEnricher(object? services, Action<object?> configure) =>
        PluginApplicationEnricherServiceCollectionCaller.AddServiceLogEnricher(services, configure);

    object? AddServiceLogEnricher_(object? section) =>
        PluginApplicationEnricherServiceCollection.AddServiceLogEnricher_(Services, section);
    public static object? AddServiceLogEnricher_(object? services, object? section) =>
        PluginApplicationEnricherServiceCollectionCaller.AddServiceLogEnricher_(services, section);

    #endregion ApplicationEnricherServiceCollectionExtensions

    #region ApplicationMetadataServiceCollectionExtensions

    object? AddApplicationMetadata(object? section) =>
        PluginApplicationMetadataServiceCollection.AddApplicationMetadata(Services, section);
    public static object? AddApplicationMetadata(object? services, object? section) =>
        PluginApplicationMetadataServiceCollectionCaller.AddApplicationMetadata(services, section);

    object? AddApplicationMetadata(Action<object?> configure) =>
        PluginApplicationMetadataServiceCollection.AddApplicationMetadata(Services, configure);
    public static object? AddApplicationMetadata(object? services, Action<object?> configure) =>
        PluginApplicationMetadataServiceCollectionCaller.AddApplicationMetadata(services, configure);

    #endregion ApplicationMetadataServiceCollectionExtensions

    #region AsyncStateExtensions

    object? AddAsyncState() =>
        PluginAsyncState.AddAsyncState(Services);
    public static object? AddAsyncState(object? services) =>
        PluginAsyncStateCaller.AddAsyncState(services);

    #endregion AsyncStateExtensions

    #region AutoActivationExtensions

    object? ActivateSingleton<TService>() where TService : class =>
        PluginAutoActivation.ActivateSingleton<TService>(Services);
    public static object? ActivateSingleton<TService>(object? services) where TService : class =>
        PluginAutoActivationCaller.ActivateSingleton<TService>(services);

    object? ActivateSingleton(Type serviceType) =>
        PluginAutoActivation.ActivateSingleton(Services, serviceType);
    public static object? ActivateSingleton(object? services, Type serviceType) =>
        PluginAutoActivationCaller.ActivateSingleton(services, serviceType);

    object? AddActivatedSingleton<TService, TImplementation>(Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService =>
        PluginAutoActivation.AddActivatedSingleton<TService, TImplementation>(Services, implementationFactory);
    public static object? AddActivatedSingleton<TService, TImplementation>(object? services, Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService =>
            PluginAutoActivationCaller.AddActivatedSingleton<TService, TImplementation>(services, implementationFactory);

    object? AddActivatedSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>() where TService : class where TImplementation : class, TService =>
        PluginAutoActivation.AddActivatedSingleton<TService, TImplementation>(Services);
    public static object? AddActivatedSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services) where TService : class where TImplementation : class, TService =>
        PluginAutoActivationCaller.AddActivatedSingleton<TService, TImplementation>(services);

    object? AddActivatedSingleton<TService>(Func<IServiceProvider, TService> implementationFactory) where TService : class =>
            PluginAutoActivation.AddActivatedSingleton<TService>(Services, implementationFactory);
    public static object? AddActivatedSingleton<TService>(object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class =>
        PluginAutoActivationCaller.AddActivatedSingleton<TService>(services, implementationFactory);

    object? AddActivatedSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(object? services) where TService : class =>
        PluginAutoActivation.AddActivatedSingleton<TService>(Services);
    public static object? AddActivatedSingleton_<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(object? services) where TService : class =>
        PluginAutoActivationCaller.AddActivatedSingleton<TService>(services);

    object? AddActivatedSingleton([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType) =>
        PluginAutoActivation.AddActivatedSingleton(Services, serviceType);
    public static object? AddActivatedSingleton(object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType) =>
        PluginAutoActivationCaller.AddActivatedSingleton(services, serviceType);

    object? AddActivatedSingleton([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType, Func<IServiceProvider, object> implementationFactory) =>
        PluginAutoActivation.AddActivatedSingleton(Services, serviceType, implementationFactory);
    public static object? AddActivatedSingleton(object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType, Func<IServiceProvider, object> implementationFactory) =>
        PluginAutoActivationCaller.AddActivatedSingleton(services, serviceType, implementationFactory);

    object? AddActivatedSingleton(Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) =>
        PluginAutoActivation.AddActivatedSingleton(Services, serviceType, implementationType);
    public static object? AddActivatedSingleton(object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) =>
        PluginAutoActivationCaller.AddActivatedSingleton(services, serviceType, implementationType);

    void TryAddActivatedSingleton([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType) =>
        PluginAutoActivation.TryAddActivatedSingleton(Services, serviceType);
    public static void TryAddActivatedSingleton(object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType) =>
        PluginAutoActivationCaller.TryAddActivatedSingleton(services, serviceType);

    void TryAddActivatedSingleton(Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) =>
        PluginAutoActivation.TryAddActivatedSingleton(Services, serviceType, implementationType);
    public static void TryAddActivatedSingleton(object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) =>
        PluginAutoActivationCaller.TryAddActivatedSingleton(services, serviceType, implementationType);

    void TryAddActivatedSingleton(Type serviceType, Func<IServiceProvider, object> implementationFactory) =>
        PluginAutoActivation.TryAddActivatedSingleton(Services, serviceType, implementationFactory);
    public static void TryAddActivatedSingleton(object? services, Type serviceType, Func<IServiceProvider, object> implementationFactory) =>
        PluginAutoActivationCaller.TryAddActivatedSingleton(services, serviceType, implementationFactory);

    void TryAddActivatedSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(object? services) where TService : class =>
            PluginAutoActivation.TryAddActivatedSingleton<TService>(Services);
    public static void TryAddActivatedSingleton_<TService>(object? services) where TService : class =>
        PluginAutoActivationCaller.TryAddActivatedSingleton<TService>(services);

    void TryAddActivatedSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services) where TService : class where TImplementation : class, TService =>
        PluginAutoActivation.TryAddActivatedSingleton<TService, TImplementation>(Services);
    public static void TryAddActivatedSingleton_<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services) where TService : class where TImplementation : class, TService =>
        PluginAutoActivationCaller.TryAddActivatedSingleton<TService, TImplementation>(services);

    void TryAddActivatedSingleton<TService>(Func<IServiceProvider, TService> implementationFactory) where TService : class =>
        PluginAutoActivation.TryAddActivatedSingleton<TService>(Services, implementationFactory);
    public static void TryAddActivatedSingleton<TService>(object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class =>
        PluginAutoActivationCaller.TryAddActivatedSingleton<TService>(services, implementationFactory);

    object? ActivateKeyedSingleton<TService>(object? serviceKey) where TService : class =>
        PluginAutoActivation.ActivateKeyedSingleton<TService>(Services, serviceKey);
    public static object? ActivateKeyedSingleton<TService>(object? services, object? serviceKey) where TService : class =>
        PluginAutoActivationCaller.ActivateKeyedSingleton<TService>(services, serviceKey);

    object? ActivateKeyedSingleton(Type serviceType, object? serviceKey) =>
        PluginAutoActivation.ActivateKeyedSingleton(Services, serviceType, serviceKey);
    public static object? ActivateKeyedSingleton(object? services, Type serviceType, object? serviceKey) =>
        PluginAutoActivationCaller.ActivateKeyedSingleton(services, serviceType, serviceKey);

    object? AddActivatedKeyedSingleton<TService, TImplementation>(object? serviceKey, Func<IServiceProvider, object?, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService =>
        PluginAutoActivation.AddActivatedKeyedSingleton<TService, TImplementation>(Services, serviceKey, implementationFactory);
    public static object? AddActivatedKeyedSingleton<TService, TImplementation>(object? services, object? serviceKey, Func<IServiceProvider, object?, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService =>
        PluginAutoActivationCaller.AddActivatedKeyedSingleton<TService, TImplementation>(services, serviceKey, implementationFactory);

    object? AddActivatedKeyedSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? serviceKey) where TService : class where TImplementation : class, TService =>
        PluginAutoActivation.AddActivatedKeyedSingleton<TService, TImplementation>(Services, serviceKey);
    public static object? AddActivatedKeyedSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services, object? serviceKey) where TService : class where TImplementation : class, TService =>
        PluginAutoActivationCaller.AddActivatedKeyedSingleton<TService, TImplementation>(services, serviceKey);

    object? AddActivatedKeyedSingleton<TService>(object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class =>
        PluginAutoActivation.AddActivatedKeyedSingleton<TService>(Services, serviceKey, implementationFactory);
    public static object? AddActivatedKeyedSingleton<TService>(object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class =>
        PluginAutoActivationCaller.AddActivatedKeyedSingleton<TService>(services, serviceKey, implementationFactory);

    object? AddActivatedKeyedSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(object? serviceKey) where TService : class =>
        PluginAutoActivation.AddActivatedKeyedSingleton<TService>(Services, serviceKey);
    public static object? AddActivatedKeyedSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(object? services, object? serviceKey) where TService : class =>
        PluginAutoActivationCaller.AddActivatedKeyedSingleton<TService>(services, serviceKey);

    object? AddActivatedKeyedSingleton([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType, object? serviceKey) =>
        PluginAutoActivation.AddActivatedKeyedSingleton(Services, serviceType, serviceKey);
    public static object? AddActivatedKeyedSingleton(object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType, object? serviceKey) =>
        PluginAutoActivationCaller.AddActivatedKeyedSingleton(services, serviceType, serviceKey);

    object? AddActivatedKeyedSingleton(Type serviceType, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory) =>
        PluginAutoActivation.AddActivatedKeyedSingleton(Services, serviceType, serviceKey, implementationFactory);
    public static object? AddActivatedKeyedSingleton(object? services, Type serviceType, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory) =>
        PluginAutoActivationCaller.AddActivatedKeyedSingleton(services, serviceType, serviceKey, implementationFactory);

    object? AddActivatedKeyedSingleton(Type serviceType, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) =>
        PluginAutoActivation.AddActivatedKeyedSingleton(Services, serviceType, serviceKey, implementationType);
    public static object? AddActivatedKeyedSingleton(object? services, Type serviceType, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) =>
        PluginAutoActivationCaller.AddActivatedKeyedSingleton(services, serviceType, serviceKey, implementationType);

    void TryAddActivatedKeyedSingleton([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType, object? serviceKey) =>
        PluginAutoActivation.TryAddActivatedKeyedSingleton(Services, serviceType, serviceKey);
    public static void TryAddActivatedKeyedSingleton(object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType, object? serviceKey) =>
        PluginAutoActivationCaller.TryAddActivatedKeyedSingleton(services, serviceType, serviceKey);

    void TryAddActivatedKeyedSingleton(Type serviceType, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) =>
        PluginAutoActivation.TryAddActivatedKeyedSingleton(Services, serviceType, serviceKey, implementationType);
    public static void TryAddActivatedKeyedSingleton(object? services, Type serviceType, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) =>
        PluginAutoActivationCaller.TryAddActivatedKeyedSingleton(services, serviceType, serviceKey, implementationType);

    void TryAddActivatedKeyedSingleton(Type serviceType, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory) =>
        PluginAutoActivation.TryAddActivatedKeyedSingleton(Services, serviceType, serviceKey, implementationFactory);
    public static void TryAddActivatedKeyedSingleton(object? services, Type serviceType, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory) =>
        PluginAutoActivationCaller.TryAddActivatedKeyedSingleton(services, serviceType, serviceKey, implementationFactory);

    void TryAddActivatedKeyedSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(object? serviceKey) where TService : class =>
        PluginAutoActivation.TryAddActivatedKeyedSingleton<TService>(Services, serviceKey);
    public static void TryAddActivatedKeyedSingleton<TService>(object? services, object? serviceKey) where TService : class =>
        PluginAutoActivationCaller.TryAddActivatedKeyedSingleton<TService>(services, serviceKey);

    void TryAddActivatedKeyedSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? serviceKey) where TService : class where TImplementation : class, TService =>
        PluginAutoActivation.TryAddActivatedKeyedSingleton<TService, TImplementation>(Services, serviceKey);
    public static void TryAddActivatedKeyedSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services, object? serviceKey) where TService : class where TImplementation : class, TService =>
        PluginAutoActivationCaller.TryAddActivatedKeyedSingleton<TService, TImplementation>(services, serviceKey);

    void TryAddActivatedKeyedSingleton<TService>(object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class =>
        PluginAutoActivation.TryAddActivatedKeyedSingleton<TService>(Services, serviceKey, implementationFactory);
    public static void TryAddActivatedKeyedSingleton<TService>(object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class =>
        PluginAutoActivationCaller.TryAddActivatedKeyedSingleton<TService>(services, serviceKey, implementationFactory);

    #endregion AutoActivationExtensions

    #region CommonHealthChecksExtensions

    object? AddTelemetryHealthCheckPublisher() =>
        PluginCommonHealthChecks.AddTelemetryHealthCheckPublisher(Services);
    public static object? AddTelemetryHealthCheckPublisher_(object? services) =>
        PluginCommonHealthChecksCaller.AddTelemetryHealthCheckPublisher(services);

    object? AddTelemetryHealthCheckPublisher(object? section) =>
                PluginCommonHealthChecks.AddTelemetryHealthCheckPublisher(Services, section);
    public static object? AddTelemetryHealthCheckPublisher(object? services, object? section) =>
        PluginCommonHealthChecksCaller.AddTelemetryHealthCheckPublisher(services, section);

    object? AddTelemetryHealthCheckPublisher(Action<object?> configure) =>
        PluginCommonHealthChecks.AddTelemetryHealthCheckPublisher(Services, configure);
    public static object? AddTelemetryHealthCheckPublisher(object? services, Action<object?> configure) =>
        PluginCommonHealthChecksCaller.AddTelemetryHealthCheckPublisher(services, configure);

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

    object? AddWebEncoders() =>
        PluginEncoderServiceCollection.AddWebEncoders(Services);
    public static object? AddWebEncoders(object? services) =>
        PluginEncoderServiceCollectionCaller.AddWebEncoders(services);

    object? AddWebEncoders(Action<object?> setupAction) =>
        PluginEncoderServiceCollection.AddWebEncoders(Services, setupAction);
    public static object? AddWebEncoders(object? services, Action<object?> setupAction) =>
        PluginEncoderServiceCollectionCaller.AddWebEncoders(services, setupAction);

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

    object? RemoveAll<T>(object? collection) =>
            PluginServiceCollectionDescriptor.RemoveAll<T>(Services);
    public static object? RemoveAll_<T>(object? collection) =>
            PluginServiceCollectionDescriptorCaller.RemoveAll<T>(collection);

    object? RemoveAllKeyed<T>(object? serviceKey) =>
            PluginServiceCollectionDescriptor.RemoveAllKeyed<T>(Services, serviceKey);
    public static object? RemoveAllKeyed<T>(object? collection, object? serviceKey) =>
            PluginServiceCollectionDescriptorCaller.RemoveAllKeyed<T>(collection, serviceKey);

    object? RemoveAllKeyed(Type serviceType, object? serviceKey) =>
            PluginServiceCollectionDescriptor.RemoveAllKeyed(Services, serviceType, serviceKey);
    public static object? RemoveAllKeyed(object? collection, Type serviceType, object? serviceKey) =>
            PluginServiceCollectionDescriptorCaller.RemoveAllKeyed(collection, serviceType, serviceKey);

    object? Replace(object? descriptor) =>
            PluginServiceCollectionDescriptor.Replace(Services, descriptor);
    public static object? Replace(object? collection, object? descriptor) =>
            PluginServiceCollectionDescriptorCaller.Replace(collection, descriptor);

    void TryAdd(object? descriptor) =>
        PluginServiceCollectionDescriptor.TryAdd(Services, descriptor);
    public static void TryAdd(object? collection, object? descriptor) =>
        PluginServiceCollectionDescriptorCaller.TryAdd(collection, descriptor);

    void TryAdd(IEnumerable<object?> descriptors) =>
        PluginServiceCollectionDescriptor.TryAdd(Services, descriptors);
    public static void TryAdd(object? collection, IEnumerable<object?> descriptors) =>
        PluginServiceCollectionDescriptorCaller.TryAdd(collection, descriptors);

    void TryAddEnumerable(object? services, object? descriptor) =>
        PluginServiceCollectionDescriptor.TryAddEnumerable(Services, descriptor);
    public static void TryAddEnumerable_(object? services, object? descriptor) =>
            PluginServiceCollectionDescriptorCaller.TryAddEnumerable(services, descriptor);

    void TryAddEnumerable(object? services, IEnumerable<object?> descriptors) =>
        PluginServiceCollectionDescriptor.TryAddEnumerable(Services, descriptors);
    public static void TryAddEnumerable_(object? services, IEnumerable<object?> descriptors) =>
PluginServiceCollectionDescriptorCaller.TryAddEnumerable(services, descriptors);

    void TryAddKeyedScoped<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? serviceKey) where TService : class where TImplementation : class, TService =>
        PluginServiceCollectionDescriptor.TryAddKeyedScoped<TService, TImplementation>(Services, serviceKey);
    public static void TryAddKeyedScoped<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services, object? serviceKey) where TService : class where TImplementation : class, TService =>
            PluginServiceCollectionDescriptorCaller.TryAddKeyedScoped<TService, TImplementation>(services, serviceKey);

    void TryAddKeyedScoped<TService>(object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class =>
        PluginServiceCollectionDescriptor.TryAddKeyedScoped<TService>(Services, serviceKey, implementationFactory);
    public static void TryAddKeyedScoped_<TService>(object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class =>
        PluginServiceCollectionDescriptorCaller.TryAddKeyedScoped<TService>(services, serviceKey, implementationFactory);

    void TryAddKeyedScoped<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(object? serviceKey) where TService : class =>
        PluginServiceCollectionDescriptor.TryAddKeyedScoped<TService>(Services, serviceKey);
    public static void TryAddKeyedScoped<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(object? services, object? serviceKey) where TService : class =>
        PluginServiceCollectionDescriptorCaller.TryAddKeyedScoped<TService>(services, serviceKey);

    void TryAddKeyedScoped(Type service, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory) =>
        PluginServiceCollectionDescriptor.TryAddKeyedScoped(Services, service, serviceKey, implementationFactory);
    public static void TryAddKeyedScoped(object? services, Type service, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory) =>
        PluginServiceCollectionDescriptorCaller.TryAddKeyedScoped(services, service, serviceKey, implementationFactory);

    void TryAddKeyedScoped(Type service, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) =>
        PluginServiceCollectionDescriptor.TryAddKeyedScoped(Services, service, serviceKey, implementationType);
    public static void TryAddKeyedScoped(object? services, Type service, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) =>
        PluginServiceCollectionDescriptorCaller.TryAddKeyedScoped(services, service, serviceKey, implementationType);

    void TryAddKeyedScoped([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service, object? serviceKey) =>
        PluginServiceCollectionDescriptor.TryAddKeyedScoped(Services, service, serviceKey);
    public static void TryAddKeyedScoped(object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service, object? serviceKey) =>
        PluginServiceCollectionDescriptorCaller.TryAddKeyedScoped(services, service, serviceKey);

    void TryAddKeyedSingleton<TService>(object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class =>
        PluginServiceCollectionDescriptor.TryAddKeyedSingleton<TService>(Services, serviceKey, implementationFactory);
    public static void TryAddKeyedSingleton_<TService>(object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class =>
        PluginServiceCollectionDescriptorCaller.TryAddKeyedSingleton<TService>(services, serviceKey, implementationFactory);

    void TryAddKeyedSingleton<TService>(object? serviceKey, TService instance) where TService : class =>
        PluginServiceCollectionDescriptor.TryAddKeyedSingleton<TService>(Services, serviceKey, instance);
    public static void TryAddKeyedSingleton<TService>(object? services, object? serviceKey, TService instance) where TService : class =>
        PluginServiceCollectionDescriptorCaller.TryAddKeyedSingleton<TService>(services, serviceKey, instance);

    void TryAddKeyedSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? serviceKey) where TService : class where TImplementation : class, TService =>
        PluginServiceCollectionDescriptor.TryAddKeyedSingleton<TService, TImplementation>(Services, serviceKey);
    public static void TryAddKeyedSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services, object? serviceKey) where TService : class where TImplementation : class, TService =>
        PluginServiceCollectionDescriptorCaller.TryAddKeyedSingleton<TService, TImplementation>(services, serviceKey);

    void TryAddKeyedSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(object? serviceKey) where TService : class =>
        PluginServiceCollectionDescriptor.TryAddKeyedSingleton<TService>(Services, serviceKey);
    public static void TryAddKeyedSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(object? services, object? serviceKey) where TService : class =>
        PluginServiceCollectionDescriptorCaller.TryAddKeyedSingleton<TService>(services, serviceKey);

    void TryAddKeyedSingleton(Type service, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory) =>
        PluginServiceCollectionDescriptor.TryAddKeyedSingleton(Services, service, serviceKey, implementationFactory);
    public static void TryAddKeyedSingleton(object? services, Type service, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory) =>
        PluginServiceCollectionDescriptorCaller.TryAddKeyedSingleton(services, service, serviceKey, implementationFactory);

    void TryAddKeyedSingleton(Type service, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) =>
        PluginServiceCollectionDescriptor.TryAddKeyedSingleton(Services, service, serviceKey, implementationType);
    public static void TryAddKeyedSingleton(object? services, Type service, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) =>
        PluginServiceCollectionDescriptorCaller.TryAddKeyedSingleton(services, service, serviceKey, implementationType);

    void TryAddKeyedSingleton([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service, object? serviceKey) =>
        PluginServiceCollectionDescriptor.TryAddKeyedSingleton(Services, service, serviceKey);
    public static void TryAddKeyedSingleton(object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service, object? serviceKey) =>
        PluginServiceCollectionDescriptorCaller.TryAddKeyedSingleton(services, service, serviceKey);

    void TryAddKeyedTransient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(object? serviceKey) where TService : class =>
        PluginServiceCollectionDescriptor.TryAddKeyedTransient<TService>(Services, serviceKey);
    public static void TryAddKeyedTransient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(object? services, object? serviceKey) where TService : class =>
        PluginServiceCollectionDescriptorCaller.TryAddKeyedTransient<TService>(services, serviceKey);

    void TryAddKeyedTransient<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? serviceKey) where TService : class where TImplementation : class, TService =>
        PluginServiceCollectionDescriptor.TryAddKeyedTransient<TService, TImplementation>(Services, serviceKey);
    public static void TryAddKeyedTransient<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services, object? serviceKey) where TService : class where TImplementation : class, TService =>
        PluginServiceCollectionDescriptorCaller.TryAddKeyedTransient<TService, TImplementation>(services, serviceKey);

    void TryAddKeyedTransient(Type service, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) =>
        PluginServiceCollectionDescriptor.TryAddKeyedTransient(Services, service, serviceKey, implementationType);
    public static void TryAddKeyedTransient(object? services, Type service, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) =>
        PluginServiceCollectionDescriptorCaller.TryAddKeyedTransient(services, service, serviceKey, implementationType);

    void TryAddKeyedTransient([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service, object? serviceKey) =>
        PluginServiceCollectionDescriptor.TryAddKeyedTransient(Services, service, serviceKey);
    public static void TryAddKeyedTransient(object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service, object? serviceKey) =>
        PluginServiceCollectionDescriptorCaller.TryAddKeyedTransient(services, service, serviceKey);

    void TryAddKeyedTransient<TService>(object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class =>
        PluginServiceCollectionDescriptor.TryAddKeyedTransient<TService>(Services, serviceKey, implementationFactory);
    public static void TryAddKeyedTransient_<TService>(object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class =>
        PluginServiceCollectionDescriptorCaller.TryAddKeyedTransient<TService>(services, serviceKey, implementationFactory);

    void TryAddKeyedTransient(Type service, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory) =>
        PluginServiceCollectionDescriptor.TryAddKeyedTransient(Services, service, serviceKey, implementationFactory);
    public static void TryAddKeyedTransient(object? services, Type service, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory) =>
        PluginServiceCollectionDescriptorCaller.TryAddKeyedTransient(services, service, serviceKey, implementationFactory);

    void TryAddScoped(Type service, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) =>
            PluginServiceCollectionDescriptor.TryAddScoped(Services, service, implementationType);
    public static void TryAddScoped(object? services, Type service, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) =>
        PluginServiceCollectionDescriptorCaller.TryAddScoped(services, service, implementationType);

    void TryAddScoped(Type service, Func<IServiceProvider, object> implementationFactory) =>
        PluginServiceCollectionDescriptor.TryAddScoped(Services, service, implementationFactory);
    public static void TryAddScoped(object? services, Type service, Func<IServiceProvider, object> implementationFactory) =>
        PluginServiceCollectionDescriptorCaller.TryAddScoped(services, service, implementationFactory);

    void TryAddScoped<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(object? collection) where TService : class =>
        PluginServiceCollectionDescriptor.TryAddScoped<TService>(Services);
    public static void TryAddScoped_<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(object? collection) where TService : class =>
        PluginServiceCollectionDescriptorCaller.TryAddScoped<TService>(collection);

    void TryAddScoped<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? collection) where TService : class where TImplementation : class, TService =>
        PluginServiceCollectionDescriptor.TryAddScoped<TService, TImplementation>(Services);
    public static void TryAddScoped_<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? collection) where TService : class where TImplementation : class, TService =>
        PluginServiceCollectionDescriptorCaller.TryAddScoped<TService, TImplementation>(collection);

    void TryAddScoped<TService>(object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class =>
        PluginServiceCollectionDescriptor.TryAddScoped<TService>(Services, implementationFactory);
    public static void TryAddScoped_<TService>(object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class =>
        PluginServiceCollectionDescriptorCaller.TryAddScoped<TService>(services, implementationFactory);

    void TryAddScoped([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service) =>
        PluginServiceCollectionDescriptor.TryAddScoped(Services, service);
    public static void TryAddScoped(object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service) =>
        PluginServiceCollectionDescriptorCaller.TryAddScoped(services, service);

    void TryAddSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(object? collection) where TService : class =>
        PluginServiceCollectionDescriptor.TryAddSingleton<TService>(Services);
    public static void TryAddSingleton_<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(object? collection) where TService : class =>
        PluginServiceCollectionDescriptorCaller.TryAddSingleton<TService>(collection);

    void TryAddSingleton<TService>(object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class =>
        PluginServiceCollectionDescriptor.TryAddSingleton<TService>(Services, implementationFactory);
    public static void TryAddSingleton_<TService>(object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class =>
        PluginServiceCollectionDescriptorCaller.TryAddSingleton<TService>(services, implementationFactory);

    void TryAddSingleton<TService>(TService instance) where TService : class =>
        PluginServiceCollectionDescriptor.TryAddSingleton<TService>(Services, instance);
    public static void TryAddSingleton<TService>(object? services, TService instance) where TService : class =>
        PluginServiceCollectionDescriptorCaller.TryAddSingleton<TService>(services, instance);

    void TryAddSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? collection) where TService : class where TImplementation : class, TService =>
        PluginServiceCollectionDescriptor.TryAddSingleton<TService, TImplementation>(Services);
    public static void TryAddSingleton_<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? collection) where TService : class where TImplementation : class, TService =>
        PluginServiceCollectionDescriptorCaller.TryAddSingleton<TService, TImplementation>(collection);

    void TryAddSingleton(Type service, Func<IServiceProvider, object> implementationFactory) =>
        PluginServiceCollectionDescriptor.TryAddSingleton(Services, service, implementationFactory);
    public static void TryAddSingleton(object? services, Type service, Func<IServiceProvider, object> implementationFactory) =>
        PluginServiceCollectionDescriptorCaller.TryAddSingleton(services, service, implementationFactory);

    void TryAddSingleton(Type service, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) =>
        PluginServiceCollectionDescriptor.TryAddSingleton(Services, service, implementationType);
    public static void TryAddSingleton(object? services, Type service, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) =>
        PluginServiceCollectionDescriptorCaller.TryAddSingleton(services, service, implementationType);

    void TryAddSingleton([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service) =>
        PluginServiceCollectionDescriptor.TryAddSingleton(Services, service);
    public static void TryAddSingleton(object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service) =>
    PluginServiceCollectionDescriptorCaller.TryAddSingleton(services, service);

    void TryAddTransient(Type service, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) =>
        PluginServiceCollectionDescriptor.TryAddTransient(Services, service, implementationType);
    public static void TryAddTransient(object? services, Type service, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) =>
        PluginServiceCollectionDescriptorCaller.TryAddTransient(services, service, implementationType);

    void TryAddTransient([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service) =>
        PluginServiceCollectionDescriptor.TryAddTransient(Services, service);
    public static void TryAddTransient(object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service) =>
        PluginServiceCollectionDescriptorCaller.TryAddTransient(services, service);

    void TryAddTransient<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? collection) where TService : class where TImplementation : class, TService =>
        PluginServiceCollectionDescriptor.TryAddTransient<TService, TImplementation>(Services);
    public static void TryAddTransient_<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? collection) where TService : class where TImplementation : class, TService =>
        PluginServiceCollectionDescriptorCaller.TryAddTransient<TService, TImplementation>(collection);

    void TryAddTransient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(object? collection) where TService : class =>
        PluginServiceCollectionDescriptor.TryAddTransient<TService>(Services);
    public static void TryAddTransient_<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(object? collection) where TService : class =>
        PluginServiceCollectionDescriptorCaller.TryAddTransient<TService>(collection);

    void TryAddTransient<TService>(object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class =>
        PluginServiceCollectionDescriptor.TryAddTransient<TService>(Services, implementationFactory);
    public static void TryAddTransient_<TService>(object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class =>
        PluginServiceCollectionDescriptorCaller.TryAddTransient<TService>(services, implementationFactory);

    void TryAddTransient(Type service, Func<IServiceProvider, object> implementationFactory) =>
        PluginServiceCollectionDescriptor.TryAddTransient(Services, service, implementationFactory);
    public static void TryAddTransient(object? services, Type service, Func<IServiceProvider, object> implementationFactory) =>
        PluginServiceCollectionDescriptorCaller.TryAddTransient(services, service, implementationFactory);

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
    public static object? AddFakeLogging_(object? services) =>
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

    #endregion HttpClientFactoryServiceCollectionExtensions

    #region HttpClientLatencyTelemetryExtensions

    object? AddHttpClientLatencyTelemetry() =>
        PluginHttpClientLatencyTelemetry.AddHttpClientLatencyTelemetry(Services);
    public static object? AddHttpClientLatencyTelemetry_(object? services) =>
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
    public static object? AddExtendedHttpClientLogging_(object? services) =>
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
    public static object? AddKubernetesProbes_(object? services) =>
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
    public static object? AddConsoleLatencyDataExporter_(object? services) =>
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
    public static object? AddLatencyContext_(object? services) =>
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

    #endregion ObjectPoolServiceCollectionExtensions

    #region OptionsConfigurationServiceCollectionExtensions

    object? Configure<[DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] TOptions>(object? config) where TOptions : class =>
        PluginOptionsConfigurationServiceCollection.Configure<TOptions>(Services, config);
    public static object? Configure<[DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] TOptions>(object? services, object? config) where TOptions : class =>
        PluginOptionsConfigurationServiceCollectionCaller.Configure<TOptions>(services, config);

    object? Configure<[DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] TOptions>(string? name, object? config) where TOptions : class =>
        PluginOptionsConfigurationServiceCollection.Configure<TOptions>(Services, name, config);
    public static object? Configure<[DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] TOptions>(object? services, string? name, object? config) where TOptions : class =>
        PluginOptionsConfigurationServiceCollectionCaller.Configure<TOptions>(services, name, config);

    object? Configure<[DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] TOptions>(object? config, Action<object?>? configureBinder) where TOptions : class =>
        PluginOptionsConfigurationServiceCollection.Configure<TOptions>(Services, config, configureBinder);
    public static object? Configure<[DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] TOptions>(object? services, object? config, Action<object?>? configureBinder) where TOptions : class =>
        PluginOptionsConfigurationServiceCollectionCaller.Configure<TOptions>(services, config, configureBinder);

    object? Configure<[DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] TOptions>(string? name, object? config, Action<object?>? configureBinder) where TOptions : class =>
        PluginOptionsConfigurationServiceCollection.Configure<TOptions>(Services, name, config, configureBinder);
    public static object? Configure<[DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] TOptions>(object? services, string? name, object? config, Action<object?>? configureBinder) where TOptions : class =>
        PluginOptionsConfigurationServiceCollectionCaller.Configure<TOptions>(services, name, config, configureBinder);

    #endregion OptionsConfigurationServiceCollectionExtensions

    #region OptionsServiceCollectionExtensions

    object? AddOptions() =>
        PluginOptionsServiceCollection.AddOptions(Services);
    public static object? AddOptions(object? services) =>
        PluginOptionsServiceCollectionCaller.AddOptions(services);

    object? AddOptions<TOptions>() where TOptions : class =>
        PluginOptionsServiceCollection.AddOptions<TOptions>(Services);
    public static object? AddOptions<TOptions>(object? services) where TOptions : class =>
        PluginOptionsServiceCollectionCaller.AddOptions<TOptions>(services);

    object? AddOptions<TOptions>(string? name) where TOptions : class =>
        PluginOptionsServiceCollection.AddOptions<TOptions>(Services, name);
    public static object? AddOptions<TOptions>(object? services, string? name) where TOptions : class =>
        PluginOptionsServiceCollectionCaller.AddOptions<TOptions>(services, name);

    object? AddOptionsWithValidateOnStart<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)] TOptions>(string? name = null) where TOptions : class =>
        PluginOptionsServiceCollection.AddOptionsWithValidateOnStart<TOptions>(Services, name);
    public static object? AddOptionsWithValidateOnStart<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)] TOptions>(object? services, string? name = null) where TOptions : class =>
        PluginOptionsServiceCollectionCaller.AddOptionsWithValidateOnStart<TOptions>(services, name);

    object? AddOptionsWithValidateOnStart<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)] TOptions, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TValidateOptions>(string? name = null) where TOptions : class where TValidateOptions : class =>
        PluginOptionsServiceCollection.AddOptionsWithValidateOnStart<TOptions, TValidateOptions>(Services, name);
    public static object? AddOptionsWithValidateOnStart<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)] TOptions, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TValidateOptions>(object? services, string? name = null) where TOptions : class where TValidateOptions : class =>
        PluginOptionsServiceCollectionCaller.AddOptionsWithValidateOnStart<TOptions, TValidateOptions>(services, name);

    object? Configure<TOptions>(Action<TOptions> configureOptions) where TOptions : class =>
        PluginOptionsServiceCollection.Configure<TOptions>(Services, configureOptions);
    public static object? Configure<TOptions>(object? services, Action<TOptions> configureOptions) where TOptions : class =>
        PluginOptionsServiceCollectionCaller.Configure<TOptions>(services, configureOptions);

    object? Configure<TOptions>(string? name, Action<TOptions> configureOptions) where TOptions : class =>
        PluginOptionsServiceCollection.Configure<TOptions>(Services, name, configureOptions);
    public static object? Configure<TOptions>(object? services, string? name, Action<TOptions> configureOptions) where TOptions : class =>
        PluginOptionsServiceCollectionCaller.Configure<TOptions>(services, name, configureOptions);

    object? ConfigureAll<TOptions>(Action<TOptions> configureOptions) where TOptions : class =>
        PluginOptionsServiceCollection.ConfigureAll<TOptions>(Services, configureOptions);
    public static object? ConfigureAll<TOptions>(object? services, Action<TOptions> configureOptions) where TOptions : class =>
        PluginOptionsServiceCollectionCaller.ConfigureAll<TOptions>(services, configureOptions);

    object? ConfigureOptions<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TConfigureOptions>() where TConfigureOptions : class =>
        PluginOptionsServiceCollection.ConfigureOptions<TConfigureOptions>(Services);
    public static object? ConfigureOptions<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TConfigureOptions>(object? services) where TConfigureOptions : class =>
        PluginOptionsServiceCollectionCaller.ConfigureOptions<TConfigureOptions>(services);

    object? ConfigureOptions([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type configureType) =>
        PluginOptionsServiceCollection.ConfigureOptions(Services, configureType);
    public static object? ConfigureOptions(object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type configureType) =>
        PluginOptionsServiceCollectionCaller.ConfigureOptions(services, configureType);

    object? ConfigureOptions(object configureInstance) =>
        PluginOptionsServiceCollection.ConfigureOptions(Services, configureInstance);
    public static object? ConfigureOptions(object? services, object configureInstance) =>
        PluginOptionsServiceCollectionCaller.ConfigureOptions(services, configureInstance);

    object? PostConfigure<TOptions>(Action<TOptions> configureOptions) where TOptions : class =>
        PluginOptionsServiceCollection.PostConfigure<TOptions>(Services, configureOptions);
    public static object? PostConfigure<TOptions>(object? services, Action<TOptions> configureOptions) where TOptions : class =>
        PluginOptionsServiceCollectionCaller.PostConfigure<TOptions>(services, configureOptions);

    object? PostConfigure<TOptions>(string? name, Action<TOptions> configureOptions) where TOptions : class =>
        PluginOptionsServiceCollection.PostConfigure<TOptions>(Services, name, configureOptions);
    public static object? PostConfigure<TOptions>(object? services, string? name, Action<TOptions> configureOptions) where TOptions : class =>
        PluginOptionsServiceCollectionCaller.PostConfigure<TOptions>(services, name, configureOptions);

    object? PostConfigureAll<TOptions>(Action<TOptions> configureOptions) where TOptions : class =>
        PluginOptionsServiceCollection.PostConfigureAll<TOptions>(Services, configureOptions);
    public static object? PostConfigureAll<TOptions>(object? services, Action<TOptions> configureOptions) where TOptions : class =>
        PluginOptionsServiceCollectionCaller.PostConfigureAll<TOptions>(services, configureOptions);

    #endregion OptionsServiceCollectionExtensions

    #region ProcessEnricherServiceCollectionExtensions

    object? AddProcessLogEnricher() =>
        PluginProcessEnricherServiceCollection.AddProcessLogEnricher(Services);
    public static object? AddProcessLogEnricher_(object? services) =>
        PluginProcessEnricherServiceCollectionCaller.AddProcessLogEnricher(services);

    object? AddProcessLogEnricher(Action<object?> configure) =>
        PluginProcessEnricherServiceCollection.AddProcessLogEnricher(Services, configure);
    public static object? AddProcessLogEnricher(object? services, Action<object?> configure) =>
        PluginProcessEnricherServiceCollectionCaller.AddProcessLogEnricher(services, configure);

    object? AddProcessLogEnricher(object? section) =>
        PluginProcessEnricherServiceCollection.AddProcessLogEnricher(Services, section);
    public static object? AddProcessLogEnricher(object? services, object? section) =>
        PluginProcessEnricherServiceCollectionCaller.AddProcessLogEnricher(services, section);

    #endregion ProcessEnricherServiceCollectionExtensions

    #region RedactionServiceCollectionExtensions

    object? AddRedaction(object? section) =>
        PluginRedactionServiceCollection.AddRedaction(Services, section);
    public static object? AddRedaction(object? services, object? section) =>
        PluginRedactionServiceCollectionCaller.AddRedaction(services, section);

    object? AddRedaction(Action<object?> configure) =>
        PluginRedactionServiceCollection.AddRedaction(Services, configure);
    public static object? AddRedaction(object? services, Action<object?> configure) =>
        PluginRedactionServiceCollectionCaller.AddRedaction(services, configure);

    #endregion RedactionServiceCollectionExtensions

    #region ResilienceServiceCollectionExtensions

    object? AddResilienceEnricher() =>
        PluginResilienceServiceCollection.AddResilienceEnricher(Services);
    public static object? AddResilienceEnricher(object? services) =>
        PluginResilienceServiceCollectionCaller.AddResilienceEnricher(services);

    #endregion ResilienceServiceCollectionExtensions

    #region ResourceMonitoringServiceCollectionExtensions

    object? AddResourceMonitoring() =>
        PluginResourceMonitoringServiceCollection.AddResourceMonitoring(Services);
    public static object? AddResourceMonitoring(object? services) =>
        PluginResourceMonitoringServiceCollectionCaller.AddResourceMonitoring(services);

    object? AddResourceMonitoring(Action<object?> configure) =>
        PluginResourceMonitoringServiceCollection.AddResourceMonitoring(Services, configure);
    public static object? AddResourceMonitoring(object? services, Action<object?> configure) =>
        PluginResourceMonitoringServiceCollectionCaller.AddResourceMonitoring(services, configure);

    #endregion ResourceMonitoringServiceCollectionExtensions

    #region ServiceCollectionContainerBuilderExtensions

    object? BuildServiceProvider() =>
        PluginServiceCollectionContainerBuilder.BuildServiceProvider(Services);
    public static object? BuildServiceProvider_(object? services) =>
        PluginServiceCollectionContainerBuilderCaller.BuildServiceProvider(services);

    object? BuildServiceProvider(object? options) =>
        PluginServiceCollectionContainerBuilder.BuildServiceProvider(Services, options);
    public static object? BuildServiceProvider(object? services, object? options) =>
        PluginServiceCollectionContainerBuilderCaller.BuildServiceProvider(services, options);

    object? BuildServiceProvider(bool validateScopes) =>
        PluginServiceCollectionContainerBuilder.BuildServiceProvider(Services, validateScopes);
    public static object? BuildServiceProvider(object? services, bool validateScopes) =>
        PluginServiceCollectionContainerBuilderCaller.BuildServiceProvider(services, validateScopes);

    #endregion ServiceCollectionContainerBuilderExtensions

    #region ServiceCollectionHostedServiceExtensions

    object? AddHostedService<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] THostedService>() where THostedService : class =>
        PluginServiceCollectionHostedService.AddHostedService<THostedService>(Services);
    public static object? AddHostedService<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] THostedService>(object? services) where THostedService : class =>
        PluginServiceCollectionHostedServiceCaller.AddHostedService(services);

    object? AddHostedService<THostedService>(Func<IServiceProvider, THostedService> implementationFactory) where THostedService : class =>
        PluginServiceCollectionHostedService.AddHostedService<THostedService>(Services, implementationFactory);
    public static object? AddHostedService<THostedService>(object? services, Func<IServiceProvider, THostedService> implementationFactory) where THostedService : class =>
        PluginServiceCollectionHostedServiceCaller.AddHostedService(services, implementationFactory);

    #endregion ServiceCollectionHostedServiceExtensions

    #region ServiceCollectionServiceExtensions

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

    #endregion ServiceCollectionServiceExtensions

    #region SqlServerCachingServicesExtensions

    object? AddDistributedSqlServerCache(Action<object?> setupAction) =>
        PluginSqlServerCachingServices.AddDistributedSqlServerCache(Services, setupAction);
    public static object? AddDistributedSqlServerCache(object? services, Action<object?> setupAction) =>
        PluginSqlServerCachingServicesCaller.AddDistributedSqlServerCache(services, setupAction);

    #endregion SqlServerCachingServicesExtensions

    #region StackExchangeRedisCacheServiceCollectionExtensions

    object? AddStackExchangeRedisCache(object? section) =>
        PluginStackExchangeRedisCacheServiceCollection.AddStackExchangeRedisCache(Services, section);
    public static object? AddStackExchangeRedisCache(object? services, object? section) =>
        PluginStackExchangeRedisCacheServiceCollectionCaller.AddStackExchangeRedisCache(services, section);

    object? AddStackExchangeRedisCache(Action<object?> configure) =>
        PluginStackExchangeRedisCacheServiceCollection.AddStackExchangeRedisCache(Services, configure);
    public static object? AddStackExchangeRedisCache(object? services, Action<object?> configure) =>
        PluginStackExchangeRedisCacheServiceCollectionCaller.AddStackExchangeRedisCache(services, configure);

    #endregion StackExchangeRedisCacheServiceCollectionExtensions

    #region TcpEndpointProbesExtensions

    object? AddTcpEndpointProbe() =>
        PluginTcpEndpointProbes.AddTcpEndpointProbe(Services);
    public static object? AddTcpEndpointProbe(object? services) =>
        PluginTcpEndpointProbesCaller.AddTcpEndpointProbe(services);

    object? AddTcpEndpointProbe(string name) =>
        PluginTcpEndpointProbes.AddTcpEndpointProbe(Services, name);
    public static object? AddTcpEndpointProbe(object? services, string name) =>
        PluginTcpEndpointProbesCaller.AddTcpEndpointProbe(services, name);

    object? AddTcpEndpointProbe(Action<object?> configure) =>
        PluginTcpEndpointProbes.AddTcpEndpointProbe(Services, configure);
    public static object? AddTcpEndpointProbe(object? services, Action<object?> configure) =>
        PluginTcpEndpointProbesCaller.AddTcpEndpointProbe(services, configure);

    object? AddTcpEndpointProbe(string name, Action<object?> configure) =>
        PluginTcpEndpointProbes.AddTcpEndpointProbe(Services, name, configure);
    public static object? AddTcpEndpointProbe(object? services, string name, Action<object?> configure) =>
        PluginTcpEndpointProbesCaller.AddTcpEndpointProbe(services, name, configure);

    object? AddTcpEndpointProbe_(object? configurationSection) =>
        PluginTcpEndpointProbes.AddTcpEndpointProbe(Services, configurationSection);
    public static object? AddTcpEndpointProbe(object? services, object? configurationSection) =>
        PluginTcpEndpointProbesCaller.AddTcpEndpointProbe_(services, configurationSection);

    object? AddTcpEndpointProbe(string name, object? configurationSection) =>
        PluginTcpEndpointProbes.AddTcpEndpointProbe(Services, name, configurationSection);
    public static object? AddTcpEndpointProbe(object? services, string name, object? configurationSection) =>
        PluginTcpEndpointProbesCaller.AddTcpEndpointProbe(services, name, configurationSection);

    #endregion TcpEndpointProbesExtensions

    #region SystemdHostBuilderExtensions

    object? AddSystemd() =>
        PluginSystemdHostBuilder.AddSystemd(Services);
    public static object? AddSystemd(object? services) =>
        PluginSystemdHostBuilderCaller.AddSystemd(services);

    #endregion SystemdHostBuilderExtensions

    #region WindowsServiceLifetimeHostBuilderExtensions

    object? AddWindowsService() =>
        PluginWindowsServiceLifetimeHostBuilder.AddWindowsService(Services);
    public static object? AddWindowsService(object? services) =>
        PluginWindowsServiceLifetimeHostBuilderCaller.AddWindowsService(services);

    object? AddWindowsService(Action<object?> configure) =>
        PluginWindowsServiceLifetimeHostBuilder.AddWindowsService(Services, configure);
    public static object? AddWindowsService(object? services, Action<object?> configure) =>
        PluginWindowsServiceLifetimeHostBuilderCaller.AddWindowsService(services, configure);

    #endregion WindowsServiceLifetimeHostBuilderExtensions
}
