#region アセンブリ Microsoft.Extensions.DependencyInjection.Abstractions, Version=10.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
#endregion

#nullable enable

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Extensions.DependencyInjection.Extensions
{
    //
    // 概要:
    //     Extension methods for adding and removing services to an Microsoft.Extensions.DependencyInjection.IServiceCollection.
    public static class ServiceCollectionDescriptorExtensions
    {
        //
        // 概要:
        //     Adds the specified descriptor to the collection.
        //
        // パラメーター:
        //   collection:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //   descriptor:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor to add.
        //
        // 戻り値:
        //     A reference to the current instance of Microsoft.Extensions.DependencyInjection.IServiceCollection.
        public static IServiceCollection Add(this IServiceCollection collection, ServiceDescriptor descriptor);
        //
        // 概要:
        //     Adds a sequence of Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     to the collection.
        //
        // パラメーター:
        //   collection:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //   descriptors:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptors to add.
        //
        // 戻り値:
        //     A reference to the current instance of Microsoft.Extensions.DependencyInjection.IServiceCollection.
        public static IServiceCollection Add(this IServiceCollection collection, IEnumerable<ServiceDescriptor> descriptors);
        //
        // 概要:
        //     Removes all services of type serviceType in Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // パラメーター:
        //   collection:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //   serviceType:
        //     The service type to remove.
        //
        // 戻り値:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection for chaining.
        public static IServiceCollection RemoveAll(this IServiceCollection collection, Type serviceType);
        //
        // 概要:
        //     Removes all services of type T in Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // パラメーター:
        //   collection:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        // 戻り値:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection for chaining.
        public static IServiceCollection RemoveAll<T>(this IServiceCollection collection);
        //
        // 概要:
        //     Removes all services of type T in Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // パラメーター:
        //   collection:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //   serviceKey:
        //     The service key.
        //
        // 戻り値:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection for chaining.
        public static IServiceCollection RemoveAllKeyed<T>(this IServiceCollection collection, object? serviceKey);
        //
        // 概要:
        //     Removes all services of type serviceType in Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // パラメーター:
        //   collection:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //   serviceType:
        //     The service type to remove.
        //
        //   serviceKey:
        //     The service key.
        //
        // 戻り値:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection for chaining.
        public static IServiceCollection RemoveAllKeyed(this IServiceCollection collection, Type serviceType, object? serviceKey);
        //
        // 概要:
        //     Removes the first service in Microsoft.Extensions.DependencyInjection.IServiceCollection
        //     with the same service type as descriptor and adds descriptor to the collection.
        //
        //
        // パラメーター:
        //   collection:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //   descriptor:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor to replace with.
        //
        //
        // 戻り値:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection for chaining.
        public static IServiceCollection Replace(this IServiceCollection collection, ServiceDescriptor descriptor);
        //
        // 概要:
        //     Adds the specified descriptor to the collection if the service type hasn't already
        //     been registered.
        //
        // パラメーター:
        //   collection:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //   descriptor:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor to add.
        public static void TryAdd(this IServiceCollection collection, ServiceDescriptor descriptor);
        //
        // 概要:
        //     Adds the specified descriptors to the collection if the service type hasn't already
        //     been registered.
        //
        // パラメーター:
        //   collection:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //   descriptors:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptors to add.
        public static void TryAdd(this IServiceCollection collection, IEnumerable<ServiceDescriptor> descriptors);
        //
        // 概要:
        //     Adds a Microsoft.Extensions.DependencyInjection.ServiceDescriptor if an existing
        //     descriptor with the same Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceType
        //     and an implementation that does not already exist in services.
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //   descriptor:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptor.
        //
        // 注釈:
        //     Use Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionDescriptorExtensions.TryAddEnumerable(Microsoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.DependencyInjection.ServiceDescriptor)
        //     when registering a service implementation of a service type that supports multiple
        //     registrations of the same service type. Using Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionDescriptorExtensions.Add(Microsoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.DependencyInjection.ServiceDescriptor)
        //     is not idempotent and can add duplicate Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     instances if called twice. Using Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionDescriptorExtensions.TryAddEnumerable(Microsoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.DependencyInjection.ServiceDescriptor)
        //     will prevent registration of multiple implementation types.
        public static void TryAddEnumerable(this IServiceCollection services, ServiceDescriptor descriptor);
        //
        // 概要:
        //     Adds the specified Microsoft.Extensions.DependencyInjection.ServiceDescriptors
        //     if an existing descriptor with the same Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceType
        //     and an implementation that does not already exist in services.
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //   descriptors:
        //     The Microsoft.Extensions.DependencyInjection.ServiceDescriptors.
        //
        // 注釈:
        //     Use Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionDescriptorExtensions.TryAddEnumerable(Microsoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.DependencyInjection.ServiceDescriptor)
        //     when registering a service implementation of a service type that supports multiple
        //     registrations of the same service type. Using Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionDescriptorExtensions.Add(Microsoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.DependencyInjection.ServiceDescriptor)
        //     is not idempotent and can add duplicate Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        //     instances if called twice. Using Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionDescriptorExtensions.TryAddEnumerable(Microsoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.DependencyInjection.ServiceDescriptor)
        //     will prevent registration of multiple implementation types.
        public static void TryAddEnumerable(this IServiceCollection services, IEnumerable<ServiceDescriptor> descriptors);
        //
        // 概要:
        //     Adds the specified TService as a Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped
        //     service implementation type specified in TImplementation to the collection if
        //     the service type hasn't already been registered.
        //
        // パラメーター:
        //   collection:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //   serviceKey:
        //     The service key.
        //
        // 型パラメーター:
        //   TService:
        //     The type of the service to add.
        //
        //   TImplementation:
        //     The type of the implementation to use.
        public static void TryAddKeyedScoped<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this IServiceCollection collection, object? serviceKey)
            where TService : class
            where TImplementation : class, TService;
        //
        // 概要:
        //     Adds the specified TService as a Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped
        //     service using the factory specified in implementationFactory to the services
        //     if the service type hasn't already been registered.
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //   implementationFactory:
        //     The factory that creates the service.
        //
        //   serviceKey:
        //     The service key.
        //
        // 型パラメーター:
        //   TService:
        //     The type of the service to add.
        public static void TryAddKeyedScoped<TService>(this IServiceCollection services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class;
        //
        // 概要:
        //     Adds the specified TService as a Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped
        //     service to the collection if the service type hasn't already been registered.
        //
        //
        // パラメーター:
        //   collection:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //   serviceKey:
        //     The service key.
        //
        // 型パラメーター:
        //   TService:
        //     The type of the service to add.
        public static void TryAddKeyedScoped<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this IServiceCollection collection, object? serviceKey) where TService : class;
        //
        // 概要:
        //     Adds the specified service as a Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped
        //     service using the factory specified in implementationFactory to the collection
        //     if the service type hasn't already been registered.
        //
        // パラメーター:
        //   collection:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //   service:
        //     The type of the service to register.
        //
        //   serviceKey:
        //     The service key.
        //
        //   implementationFactory:
        //     The factory that creates the service.
        public static void TryAddKeyedScoped(this IServiceCollection collection, Type service, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory);
        //
        // 概要:
        //     Adds the specified service as a Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped
        //     service with the implementationType implementation to the collection if the service
        //     type hasn't already been registered.
        //
        // パラメーター:
        //   collection:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //   service:
        //     The type of the service to register.
        //
        //   serviceKey:
        //     The service key.
        //
        //   implementationType:
        //     The implementation type of the service.
        public static void TryAddKeyedScoped(this IServiceCollection collection, Type service, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType);
        //
        // 概要:
        //     Adds the specified service as a Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped
        //     service to the collection if the service type hasn't already been registered.
        //
        //
        // パラメーター:
        //   collection:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //   service:
        //     The type of the service to register.
        //
        //   serviceKey:
        //     The service key.
        public static void TryAddKeyedScoped(this IServiceCollection collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service, object? serviceKey);
        //
        // 概要:
        //     Adds the specified TService as a Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton
        //     service using the factory specified in implementationFactory to the services
        //     if the service type hasn't already been registered.
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //   serviceKey:
        //     The service key.
        //
        //   implementationFactory:
        //     The factory that creates the service.
        //
        // 型パラメーター:
        //   TService:
        //     The type of the service to add.
        public static void TryAddKeyedSingleton<TService>(this IServiceCollection services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class;
        //
        // 概要:
        //     Adds the specified TService as a Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton
        //     service with an instance specified in instance to the collection if the service
        //     type hasn't already been registered.
        //
        // パラメーター:
        //   collection:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //   serviceKey:
        //     The service key.
        //
        //   instance:
        //     The instance of the service to add.
        //
        // 型パラメーター:
        //   TService:
        //     The type of the service to add.
        public static void TryAddKeyedSingleton<TService>(this IServiceCollection collection, object? serviceKey, TService instance) where TService : class;
        //
        // 概要:
        //     Adds the specified TService as a Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton
        //     service implementation type specified in TImplementation to the collection if
        //     the service type hasn't already been registered.
        //
        // パラメーター:
        //   collection:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //   serviceKey:
        //     The service key.
        //
        // 型パラメーター:
        //   TService:
        //     The type of the service to add.
        //
        //   TImplementation:
        //     The type of the implementation to use.
        public static void TryAddKeyedSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this IServiceCollection collection, object? serviceKey)
            where TService : class
            where TImplementation : class, TService;
        //
        // 概要:
        //     Adds the specified TService as a Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton
        //     service to the collection if the service type hasn't already been registered.
        //
        //
        // パラメーター:
        //   collection:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //   serviceKey:
        //     The service key.
        //
        // 型パラメーター:
        //   TService:
        //     The type of the service to add.
        public static void TryAddKeyedSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this IServiceCollection collection, object? serviceKey) where TService : class;
        //
        // 概要:
        //     Adds the specified service as a Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton
        //     service using the factory specified in implementationFactory to the collection
        //     if the service type hasn't already been registered.
        //
        // パラメーター:
        //   collection:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //   service:
        //     The type of the service to register.
        //
        //   serviceKey:
        //     The service key.
        //
        //   implementationFactory:
        //     The factory that creates the service.
        public static void TryAddKeyedSingleton(this IServiceCollection collection, Type service, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory);
        //
        // 概要:
        //     Adds the specified service as a Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton
        //     service with the implementationType implementation to the collection if the service
        //     type hasn't already been registered.
        //
        // パラメーター:
        //   collection:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //   service:
        //     The type of the service to register.
        //
        //   serviceKey:
        //     The service key.
        //
        //   implementationType:
        //     The implementation type of the service.
        public static void TryAddKeyedSingleton(this IServiceCollection collection, Type service, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType);
        //
        // 概要:
        //     Adds the specified service as a Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton
        //     service to the collection if the service type hasn't already been registered.
        //
        //
        // パラメーター:
        //   collection:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //   service:
        //     The type of the service to register.
        //
        //   serviceKey:
        //     The service key.
        public static void TryAddKeyedSingleton(this IServiceCollection collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service, object? serviceKey);
        //
        // 概要:
        //     Adds the specified TService as a Microsoft.Extensions.DependencyInjection.ServiceLifetime.Transient
        //     service to the collection if the service type hasn't already been registered.
        //
        //
        // パラメーター:
        //   collection:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //   serviceKey:
        //     The service key.
        //
        // 型パラメーター:
        //   TService:
        //     The type of the service to add.
        public static void TryAddKeyedTransient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this IServiceCollection collection, object? serviceKey) where TService : class;
        //
        // 概要:
        //     Adds the specified TService as a Microsoft.Extensions.DependencyInjection.ServiceLifetime.Transient
        //     service implementation type specified in TImplementation to the collection if
        //     the service type hasn't already been registered.
        //
        // パラメーター:
        //   collection:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //   serviceKey:
        //     The service key.
        //
        // 型パラメーター:
        //   TService:
        //     The type of the service to add.
        //
        //   TImplementation:
        //     The type of the implementation to use.
        public static void TryAddKeyedTransient<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this IServiceCollection collection, object? serviceKey)
            where TService : class
            where TImplementation : class, TService;
        //
        // 概要:
        //     Adds the specified service as a Microsoft.Extensions.DependencyInjection.ServiceLifetime.Transient
        //     service with the implementationType implementation to the collection if the service
        //     type hasn't already been registered.
        //
        // パラメーター:
        //   collection:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //   service:
        //     The type of the service to register.
        //
        //   serviceKey:
        //     The service key.
        //
        //   implementationType:
        //     The implementation type of the service.
        public static void TryAddKeyedTransient(this IServiceCollection collection, Type service, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType);
        //
        // 概要:
        //     Adds the specified service as a Microsoft.Extensions.DependencyInjection.ServiceLifetime.Transient
        //     service to the collection if the service type hasn't already been registered.
        //
        //
        // パラメーター:
        //   collection:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //   service:
        //     The type of the service to register.
        //
        //   serviceKey:
        //     The service key.
        public static void TryAddKeyedTransient(this IServiceCollection collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service, object? serviceKey);
        //
        // 概要:
        //     Adds the specified TService as a Microsoft.Extensions.DependencyInjection.ServiceLifetime.Transient
        //     service using the factory specified in implementationFactory to the services
        //     if the service type hasn't already been registered.
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //   serviceKey:
        //     The service key.
        //
        //   implementationFactory:
        //     The factory that creates the service.
        //
        // 型パラメーター:
        //   TService:
        //     The type of the service to add.
        public static void TryAddKeyedTransient<TService>(this IServiceCollection services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class;
        //
        // 概要:
        //     Adds the specified service as a Microsoft.Extensions.DependencyInjection.ServiceLifetime.Transient
        //     service using the factory specified in implementationFactory to the collection
        //     if the service type hasn't already been registered.
        //
        // パラメーター:
        //   collection:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //   service:
        //     The type of the service to register.
        //
        //   serviceKey:
        //     The service key.
        //
        //   implementationFactory:
        //     The factory that creates the service.
        public static void TryAddKeyedTransient(this IServiceCollection collection, Type service, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory);
        //
        // 概要:
        //     Adds the specified service as a Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped
        //     service with the implementationType implementation to the collection if the service
        //     type hasn't already been registered.
        //
        // パラメーター:
        //   collection:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //   service:
        //     The type of the service to register.
        //
        //   implementationType:
        //     The implementation type of the service.
        public static void TryAddScoped(this IServiceCollection collection, Type service, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType);
        //
        // 概要:
        //     Adds the specified service as a Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped
        //     service using the factory specified in implementationFactory to the collection
        //     if the service type hasn't already been registered.
        //
        // パラメーター:
        //   collection:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //   service:
        //     The type of the service to register.
        //
        //   implementationFactory:
        //     The factory that creates the service.
        public static void TryAddScoped(this IServiceCollection collection, Type service, Func<IServiceProvider, object> implementationFactory);
        //
        // 概要:
        //     Adds the specified TService as a Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped
        //     service to the collection if the service type hasn't already been registered.
        //
        //
        // パラメーター:
        //   collection:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        // 型パラメーター:
        //   TService:
        //     The type of the service to add.
        public static void TryAddScoped<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this IServiceCollection collection) where TService : class;
        //
        // 概要:
        //     Adds the specified TService as a Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped
        //     service implementation type specified in TImplementation to the collection if
        //     the service type hasn't already been registered.
        //
        // パラメーター:
        //   collection:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        // 型パラメーター:
        //   TService:
        //     The type of the service to add.
        //
        //   TImplementation:
        //     The type of the implementation to use.
        public static void TryAddScoped<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this IServiceCollection collection)
            where TService : class
            where TImplementation : class, TService;
        //
        // 概要:
        //     Adds the specified TService as a Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped
        //     service using the factory specified in implementationFactory to the services
        //     if the service type hasn't already been registered.
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //   implementationFactory:
        //     The factory that creates the service.
        //
        // 型パラメーター:
        //   TService:
        //     The type of the service to add.
        public static void TryAddScoped<TService>(this IServiceCollection services, Func<IServiceProvider, TService> implementationFactory) where TService : class;
        //
        // 概要:
        //     Adds the specified service as a Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped
        //     service to the collection if the service type hasn't already been registered.
        //
        //
        // パラメーター:
        //   collection:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //   service:
        //     The type of the service to register.
        public static void TryAddScoped(this IServiceCollection collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service);
        //
        // 概要:
        //     Adds the specified TService as a Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton
        //     service to the collection if the service type hasn't already been registered.
        //
        //
        // パラメーター:
        //   collection:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        // 型パラメーター:
        //   TService:
        //     The type of the service to add.
        public static void TryAddSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this IServiceCollection collection) where TService : class;
        //
        // 概要:
        //     Adds the specified TService as a Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton
        //     service using the factory specified in implementationFactory to the services
        //     if the service type hasn't already been registered.
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //   implementationFactory:
        //     The factory that creates the service.
        //
        // 型パラメーター:
        //   TService:
        //     The type of the service to add.
        public static void TryAddSingleton<TService>(this IServiceCollection services, Func<IServiceProvider, TService> implementationFactory) where TService : class;
        //
        // 概要:
        //     Adds the specified TService as a Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton
        //     service with an instance specified in instance to the collection if the service
        //     type hasn't already been registered.
        //
        // パラメーター:
        //   collection:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //   instance:
        //     The instance of the service to add.
        //
        // 型パラメーター:
        //   TService:
        //     The type of the service to add.
        public static void TryAddSingleton<TService>(this IServiceCollection collection, TService instance) where TService : class;
        //
        // 概要:
        //     Adds the specified TService as a Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton
        //     service implementation type specified in TImplementation to the collection if
        //     the service type hasn't already been registered.
        //
        // パラメーター:
        //   collection:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        // 型パラメーター:
        //   TService:
        //     The type of the service to add.
        //
        //   TImplementation:
        //     The type of the implementation to use.
        public static void TryAddSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this IServiceCollection collection)
            where TService : class
            where TImplementation : class, TService;
        //
        // 概要:
        //     Adds the specified service as a Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton
        //     service using the factory specified in implementationFactory to the collection
        //     if the service type hasn't already been registered.
        //
        // パラメーター:
        //   collection:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //   service:
        //     The type of the service to register.
        //
        //   implementationFactory:
        //     The factory that creates the service.
        public static void TryAddSingleton(this IServiceCollection collection, Type service, Func<IServiceProvider, object> implementationFactory);
        //
        // 概要:
        //     Adds the specified service as a Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton
        //     service with the implementationType implementation to the collection if the service
        //     type hasn't already been registered.
        //
        // パラメーター:
        //   collection:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //   service:
        //     The type of the service to register.
        //
        //   implementationType:
        //     The implementation type of the service.
        public static void TryAddSingleton(this IServiceCollection collection, Type service, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType);
        //
        // 概要:
        //     Adds the specified service as a Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton
        //     service to the collection if the service type hasn't already been registered.
        //
        //
        // パラメーター:
        //   collection:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //   service:
        //     The type of the service to register.
        public static void TryAddSingleton(this IServiceCollection collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service);
        //
        // 概要:
        //     Adds the specified service as a Microsoft.Extensions.DependencyInjection.ServiceLifetime.Transient
        //     service with the implementationType implementation to the collection if the service
        //     type hasn't already been registered.
        //
        // パラメーター:
        //   collection:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //   service:
        //     The type of the service to register.
        //
        //   implementationType:
        //     The implementation type of the service.
        public static void TryAddTransient(this IServiceCollection collection, Type service, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType);
        //
        // 概要:
        //     Adds the specified service as a Microsoft.Extensions.DependencyInjection.ServiceLifetime.Transient
        //     service to the collection if the service type hasn't already been registered.
        //
        //
        // パラメーター:
        //   collection:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //   service:
        //     The type of the service to register.
        public static void TryAddTransient(this IServiceCollection collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service);
        //
        // 概要:
        //     Adds the specified TService as a Microsoft.Extensions.DependencyInjection.ServiceLifetime.Transient
        //     service implementation type specified in TImplementation to the collection if
        //     the service type hasn't already been registered.
        //
        // パラメーター:
        //   collection:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        // 型パラメーター:
        //   TService:
        //     The type of the service to add.
        //
        //   TImplementation:
        //     The type of the implementation to use.
        public static void TryAddTransient<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this IServiceCollection collection)
            where TService : class
            where TImplementation : class, TService;
        //
        // 概要:
        //     Adds the specified TService as a Microsoft.Extensions.DependencyInjection.ServiceLifetime.Transient
        //     service to the collection if the service type hasn't already been registered.
        //
        //
        // パラメーター:
        //   collection:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        // 型パラメーター:
        //   TService:
        //     The type of the service to add.
        public static void TryAddTransient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this IServiceCollection collection) where TService : class;
        //
        // 概要:
        //     Adds the specified TService as a Microsoft.Extensions.DependencyInjection.ServiceLifetime.Transient
        //     service using the factory specified in implementationFactory to the services
        //     if the service type hasn't already been registered.
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //   implementationFactory:
        //     The factory that creates the service.
        //
        // 型パラメーター:
        //   TService:
        //     The type of the service to add.
        public static void TryAddTransient<TService>(this IServiceCollection services, Func<IServiceProvider, TService> implementationFactory) where TService : class;
        //
        // 概要:
        //     Adds the specified service as a Microsoft.Extensions.DependencyInjection.ServiceLifetime.Transient
        //     service using the factory specified in implementationFactory to the collection
        //     if the service type hasn't already been registered.
        //
        // パラメーター:
        //   collection:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //   service:
        //     The type of the service to register.
        //
        //   implementationFactory:
        //     The factory that creates the service.
        public static void TryAddTransient(this IServiceCollection collection, Type service, Func<IServiceProvider, object> implementationFactory);
    }
}