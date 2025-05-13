
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.Shared.Diagnostics;

namespace Microsoft.Extensions.DependencyInjection;

//
// 概要:
//     Extension methods for automatically activating singletons after application starts.
public static class AutoActivationExtensions
{
    //
    // 概要:
    //     Enforces singleton activation at startup time rather than at runtime.
    //
    // パラメーター:
    //   services:
    //     The service collection containing the service.
    //
    // 型パラメーター:
    //   TService:
    //     The type of the service to activate.
    //
    // 戻り値:
    //     The value of services.
    public static IServiceCollection ActivateSingleton<TService>(this IServiceCollection services) where TService : class
    {
        Throw.IfNull(services, "services");
        services.AddHostedService<AutoActivationHostedService>().AddOptions<AutoActivatorOptions>().Configure(delegate (AutoActivatorOptions ao)
        {
            Type typeFromHandle = typeof(IEnumerable<TService>);
            if (!ao.AutoActivators.Contains(typeFromHandle))
            {
                if (ao.AutoActivators.Remove(typeof(TService)))
                {
                    ao.AutoActivators.Add(typeFromHandle);
                }
                else
                {
                    ao.AutoActivators.Add(typeof(TService));
                }
            }
        });
        return services;
    }

    //
    // 概要:
    //     Enforces singleton activation at startup time rather than at runtime.
    //
    // パラメーター:
    //   services:
    //     The service collection containing the service.
    //
    //   serviceType:
    //     The type of the service to activate.
    //
    // 戻り値:
    //     The value of services.
    public static IServiceCollection ActivateSingleton(this IServiceCollection services, Type serviceType)
    {
        Type serviceType2 = serviceType;
        Throw.IfNull(services, "services");
        Throw.IfNull(serviceType2, "serviceType");
        services.AddHostedService<AutoActivationHostedService>().AddOptions<AutoActivatorOptions>().Configure(delegate (AutoActivatorOptions ao)
        {
            Type enumerableServiceType = GetEnumerableServiceType(serviceType2);
            if (!ao.AutoActivators.Contains(enumerableServiceType))
            {
                if (ao.AutoActivators.Remove(serviceType2))
                {
                    ao.AutoActivators.Add(enumerableServiceType);
                }
                else
                {
                    ao.AutoActivators.Add(serviceType2);
                }
            }
        });
        return services;
        [UnconditionalSuppressMessage("AotAnalysis", "IL3050:RequiresDynamicCode", Justification = "When IsDynamicCodeSupported is not supported, DependencyInjection ensures IEnumerable service types are not a ValueType.")]
        static Type GetEnumerableServiceType(Type serviceType)
        {
            return typeof(IEnumerable<>).MakeGenericType(serviceType);
        }
    }

    //
    // 概要:
    //     Adds an auto-activated singleton service.
    //
    // パラメーター:
    //   services:
    //     The service collection to add the service to.
    //
    //   implementationFactory:
    //     The factory that creates the service.
    //
    // 型パラメーター:
    //   TService:
    //     The type of the service to add.
    //
    //   TImplementation:
    //     The type of the implementation to use.
    //
    // 戻り値:
    //     The value of services.
    public static IServiceCollection AddActivatedSingleton<TService, TImplementation>(this IServiceCollection services, Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService
    {
        Throw.IfNull(services, "services");
        Throw.IfNull(implementationFactory, "implementationFactory");
        return services.AddSingleton<TService, TImplementation>(implementationFactory).ActivateSingleton<TService>();
    }

    //
    // 概要:
    //     Adds an auto-activated singleton service.
    //
    // パラメーター:
    //   services:
    //     The service collection to add the service to.
    //
    // 型パラメーター:
    //   TService:
    //     The type of the service to add.
    //
    //   TImplementation:
    //     The type of the implementation to use.
    //
    // 戻り値:
    //     The value of services.
    public static IServiceCollection AddActivatedSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this IServiceCollection services) where TService : class where TImplementation : class, TService
    {
        Throw.IfNull(services, "services");
        return services.AddSingleton<TService, TImplementation>().ActivateSingleton<TService>();
    }

    //
    // 概要:
    //     Adds an auto-activated singleton service.
    //
    // パラメーター:
    //   services:
    //     The service collection to add the service to.
    //
    //   implementationFactory:
    //     The factory that creates the service.
    //
    // 型パラメーター:
    //   TService:
    //     The type of the service to add.
    //
    // 戻り値:
    //     The value of services.
    public static IServiceCollection AddActivatedSingleton<TService>(this IServiceCollection services, Func<IServiceProvider, TService> implementationFactory) where TService : class
    {
        Throw.IfNull(services, "services");
        Throw.IfNull(implementationFactory, "implementationFactory");
        return services.AddSingleton(implementationFactory).ActivateSingleton<TService>();
    }

    //
    // 概要:
    //     Adds an auto-activated singleton service.
    //
    // パラメーター:
    //   services:
    //     The service collection to add the service to.
    //
    // 型パラメーター:
    //   TService:
    //     The type of the service to add.
    //
    // 戻り値:
    //     The value of services.
    public static IServiceCollection AddActivatedSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this IServiceCollection services) where TService : class
    {
        Throw.IfNull(services, "services");
        return services.AddSingleton<TService>().ActivateSingleton<TService>();
    }

    //
    // 概要:
    //     Adds an auto-activated singleton service of the type specified in serviceType
    //     to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
    //
    //
    // パラメーター:
    //   services:
    //     The service collection to add the service to.
    //
    //   serviceType:
    //     The type of the service to register and the implementation to use.
    //
    // 戻り値:
    //     The value of services.
    public static IServiceCollection AddActivatedSingleton(this IServiceCollection services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType)
    {
        Throw.IfNull(services, "services");
        Throw.IfNull(serviceType, "serviceType");
        return services.AddSingleton(serviceType).ActivateSingleton(serviceType);
    }

    //
    // 概要:
    //     Adds an auto-activated singleton service.
    //
    // パラメーター:
    //   services:
    //     The service collection to add the service to.
    //
    //   serviceType:
    //     The type of the service to register.
    //
    //   implementationFactory:
    //     The factory that creates the service.
    //
    // 戻り値:
    //     The value of services.
    public static IServiceCollection AddActivatedSingleton(this IServiceCollection services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType, Func<IServiceProvider, object> implementationFactory)
    {
        Throw.IfNull(services, "services");
        Throw.IfNull(serviceType, "serviceType");
        Throw.IfNull(implementationFactory, "implementationFactory");
        return services.AddSingleton(serviceType, implementationFactory).ActivateSingleton(serviceType);
    }

    //
    // 概要:
    //     Adds an auto-activated singleton service.
    //
    // パラメーター:
    //   services:
    //     The service collection to add the service to.
    //
    //   serviceType:
    //     The type of the service to register.
    //
    //   implementationType:
    //     The implementation type of the service.
    //
    // 戻り値:
    //     The value of services.
    public static IServiceCollection AddActivatedSingleton(this IServiceCollection services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
    {
        Throw.IfNull(services, "services");
        Throw.IfNull(serviceType, "serviceType");
        Throw.IfNull(implementationType, "implementationType");
        return services.AddSingleton(serviceType, implementationType).ActivateSingleton(serviceType);
    }

    //
    // 概要:
    //     Tries to add an auto-activated singleton service.
    //
    // パラメーター:
    //   services:
    //     The service collection to add the service to.
    //
    //   serviceType:
    //     The type of the service to register.
    public static void TryAddActivatedSingleton(this IServiceCollection services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType)
    {
        Throw.IfNull(services, "services");
        Throw.IfNull(serviceType, "serviceType");
        services.TryAddAndActivate(ServiceDescriptor.Singleton(serviceType, serviceType));
    }

    //
    // 概要:
    //     Tries to add an auto-activated singleton service.
    //
    // パラメーター:
    //   services:
    //     The service collection to add the service to.
    //
    //   serviceType:
    //     The type of the service to register.
    //
    //   implementationType:
    //     The implementation type of the service.
    public static void TryAddActivatedSingleton(this IServiceCollection services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
    {
        Throw.IfNull(services, "services");
        Throw.IfNull(serviceType, "serviceType");
        Throw.IfNull(implementationType, "implementationType");
        services.TryAddAndActivate(ServiceDescriptor.Singleton(serviceType, implementationType));
    }

    //
    // 概要:
    //     Tries to add an auto-activated singleton service.
    //
    // パラメーター:
    //   services:
    //     The service collection to add the service to.
    //
    //   serviceType:
    //     The type of the service to register.
    //
    //   implementationFactory:
    //     The factory that creates the service.
    public static void TryAddActivatedSingleton(this IServiceCollection services, Type serviceType, Func<IServiceProvider, object> implementationFactory)
    {
        Throw.IfNull(services, "services");
        Throw.IfNull(serviceType, "serviceType");
        Throw.IfNull(implementationFactory, "implementationFactory");
        services.TryAddAndActivate(ServiceDescriptor.Singleton(serviceType, implementationFactory));
    }

    //
    // 概要:
    //     Tries to add an auto-activated singleton service.
    //
    // パラメーター:
    //   services:
    //     The service collection to add the service to.
    //
    // 型パラメーター:
    //   TService:
    //     The type of the service to add.
    public static void TryAddActivatedSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this IServiceCollection services) where TService : class
    {
        Throw.IfNull(services, "services");
        services.TryAddAndActivate<TService>(ServiceDescriptor.Singleton<TService, TService>());
    }

    //
    // 概要:
    //     Tries to add an auto-activated singleton service.
    //
    // パラメーター:
    //   services:
    //     The service collection to add the service to.
    //
    // 型パラメーター:
    //   TService:
    //     The type of the service to add.
    //
    //   TImplementation:
    //     The type of the implementation to use.
    public static void TryAddActivatedSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this IServiceCollection services) where TService : class where TImplementation : class, TService
    {
        Throw.IfNull(services, "services");
        services.TryAddAndActivate<TService>(ServiceDescriptor.Singleton<TService, TImplementation>());
    }

    //
    // 概要:
    //     Tries to add an auto-activated singleton service.
    //
    // パラメーター:
    //   services:
    //     The service collection to add the service to.
    //
    //   implementationFactory:
    //     The factory that creates the service.
    //
    // 型パラメーター:
    //   TService:
    //     The type of the service to add.
    public static void TryAddActivatedSingleton<TService>(this IServiceCollection services, Func<IServiceProvider, TService> implementationFactory) where TService : class
    {
        Throw.IfNull(services, "services");
        Throw.IfNull(implementationFactory, "implementationFactory");
        services.TryAddAndActivate<TService>(ServiceDescriptor.Singleton(implementationFactory));
    }

    private static void TryAddAndActivate<TService>(this IServiceCollection services, ServiceDescriptor descriptor) where TService : class
    {
        ServiceDescriptor descriptor2 = descriptor;
        if (!services.Any((ServiceDescriptor d) => d.ServiceType == descriptor2.ServiceType && d.ServiceKey == descriptor2.ServiceKey))
        {
            services.Add(descriptor2);
            services.ActivateSingleton<TService>();
        }
    }

    private static void TryAddAndActivate(this IServiceCollection services, ServiceDescriptor descriptor)
    {
        ServiceDescriptor descriptor2 = descriptor;
        if (!services.Any((ServiceDescriptor d) => d.ServiceType == descriptor2.ServiceType && d.ServiceKey == descriptor2.ServiceKey))
        {
            services.Add(descriptor2);
            services.ActivateSingleton(descriptor2.ServiceType);
        }
    }

    //
    // 概要:
    //     Enforces keyed singleton activation at startup time rather than at runtime.
    //
    // パラメーター:
    //   services:
    //     The service collection containing the service.
    //
    //   serviceKey:
    //     An object used to uniquely identify the specific service.
    //
    // 型パラメーター:
    //   TService:
    //     The type of the service to activate.
    //
    // 戻り値:
    //     The value of services.
    public static IServiceCollection ActivateKeyedSingleton<TService>(this IServiceCollection services, object? serviceKey) where TService : class
    {
        object serviceKey2 = serviceKey;
        Throw.IfNull(services, "services");
        services.AddHostedService<AutoActivationHostedService>().AddOptions<AutoActivatorOptions>().Configure(delegate (AutoActivatorOptions ao)
        {
            Type typeFromHandle = typeof(IEnumerable<TService>);
            if (!ao.KeyedAutoActivators.Contains((typeFromHandle, serviceKey2)))
            {
                if (ao.KeyedAutoActivators.Remove((typeof(TService), serviceKey2)))
                {
                    ao.KeyedAutoActivators.Add((typeFromHandle, serviceKey2));
                }
                else
                {
                    ao.KeyedAutoActivators.Add((typeof(TService), serviceKey2));
                }
            }
        });
        return services;
    }

    //
    // 概要:
    //     Enforces keyed singleton activation at startup time rather than at runtime.
    //
    // パラメーター:
    //   services:
    //     The service collection to add the service to.
    //
    //   serviceType:
    //     The type of the service to activate.
    //
    //   serviceKey:
    //     An object used to uniquely identify the specific service.
    //
    // 戻り値:
    //     The value of services.
    public static IServiceCollection ActivateKeyedSingleton(this IServiceCollection services, Type serviceType, object? serviceKey)
    {
        Type serviceType2 = serviceType;
        object serviceKey2 = serviceKey;
        Throw.IfNull(services, "services");
        Throw.IfNull(serviceType2, "serviceType");
        services.AddHostedService<AutoActivationHostedService>().AddOptions<AutoActivatorOptions>().Configure(delegate (AutoActivatorOptions ao)
        {
            Type enumerableServiceType = GetEnumerableServiceType(serviceType2);
            if (!ao.KeyedAutoActivators.Contains((enumerableServiceType, serviceKey2)))
            {
                if (ao.KeyedAutoActivators.Remove((serviceType2, serviceKey2)))
                {
                    ao.KeyedAutoActivators.Add((enumerableServiceType, serviceKey2));
                }
                else
                {
                    ao.KeyedAutoActivators.Add((serviceType2, serviceKey2));
                }
            }
        });
        return services;
        [UnconditionalSuppressMessage("AotAnalysis", "IL3050:RequiresDynamicCode", Justification = "When IsDynamicCodeSupported is not supported, DependencyInjection ensures IEnumerable service types are not a ValueType.")]
        static Type GetEnumerableServiceType(Type serviceType)
        {
            return typeof(IEnumerable<>).MakeGenericType(serviceType);
        }
    }

    //
    // 概要:
    //     Adds an auto-activated keyed singleton service.
    //
    // パラメーター:
    //   services:
    //     The service collection to add the service to.
    //
    //   serviceKey:
    //     An object used to uniquely identify the specific service.
    //
    //   implementationFactory:
    //     The factory that creates the service.
    //
    // 型パラメーター:
    //   TService:
    //     The type of the service to add.
    //
    //   TImplementation:
    //     The type of the implementation to use.
    //
    // 戻り値:
    //     The value of services.
    public static IServiceCollection AddActivatedKeyedSingleton<TService, TImplementation>(this IServiceCollection services, object? serviceKey, Func<IServiceProvider, object?, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService
    {
        Throw.IfNull(services, "services");
        Throw.IfNull(implementationFactory, "implementationFactory");
        return services.AddKeyedSingleton<TService, TImplementation>(serviceKey, implementationFactory).ActivateKeyedSingleton<TService>(serviceKey);
    }

    //
    // 概要:
    //     Adds an auto-activated keyed singleton service.
    //
    // パラメーター:
    //   services:
    //     The service collection to add the service to.
    //
    //   serviceKey:
    //     An object used to uniquely identify the specific service.
    //
    // 型パラメーター:
    //   TService:
    //     The type of the service to add.
    //
    //   TImplementation:
    //     The type of the implementation to use.
    //
    // 戻り値:
    //     The value of services.
    public static IServiceCollection AddActivatedKeyedSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this IServiceCollection services, object? serviceKey) where TService : class where TImplementation : class, TService
    {
        return services.AddKeyedSingleton<TService, TImplementation>(serviceKey).ActivateKeyedSingleton<TService>(serviceKey);
    }

    //
    // 概要:
    //     Adds an auto-activated keyed singleton service.
    //
    // パラメーター:
    //   services:
    //     The service collection to add the service to.
    //
    //   serviceKey:
    //     An object used to uniquely identify the specific service.
    //
    //   implementationFactory:
    //     The factory that creates the service.
    //
    // 型パラメーター:
    //   TService:
    //     The type of the service to add.
    //
    // 戻り値:
    //     The value of services.
    public static IServiceCollection AddActivatedKeyedSingleton<TService>(this IServiceCollection services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class
    {
        return services.AddKeyedSingleton(serviceKey, implementationFactory).ActivateKeyedSingleton<TService>(serviceKey);
    }

    //
    // 概要:
    //     Adds an auto-activated keyed singleton service.
    //
    // パラメーター:
    //   services:
    //     The service collection to add the service to.
    //
    //   serviceKey:
    //     An object used to uniquely identify the specific service.
    //
    // 型パラメーター:
    //   TService:
    //     The type of the service to add.
    //
    // 戻り値:
    //     The value of services.
    public static IServiceCollection AddActivatedKeyedSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this IServiceCollection services, object? serviceKey) where TService : class
    {
        return services.AddKeyedSingleton<TService>(serviceKey).ActivateKeyedSingleton<TService>(serviceKey);
    }

    //
    // 概要:
    //     Adds an auto-activated keyed singleton service.
    //
    // パラメーター:
    //   services:
    //     The service collection to add the service to.
    //
    //   serviceType:
    //     The type of the service to register and the implementation to use.
    //
    //   serviceKey:
    //     An object used to uniquely identify the specific service.
    //
    // 戻り値:
    //     The value of services.
    public static IServiceCollection AddActivatedKeyedSingleton(this IServiceCollection services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType, object? serviceKey)
    {
        Throw.IfNull(services, "services");
        Throw.IfNull(serviceType, "serviceType");
        return services.AddKeyedSingleton(serviceType, serviceKey).ActivateKeyedSingleton(serviceType, serviceKey);
    }

    //
    // 概要:
    //     Adds an auto-activated keyed singleton service.
    //
    // パラメーター:
    //   services:
    //     The service collection to add the service to.
    //
    //   serviceType:
    //     The type of the service to register.
    //
    //   serviceKey:
    //     An object used to uniquely identify the specific service.
    //
    //   implementationFactory:
    //     The factory that creates the service.
    //
    // 戻り値:
    //     The value of services.
    public static IServiceCollection AddActivatedKeyedSingleton(this IServiceCollection services, Type serviceType, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory)
    {
        Throw.IfNull(services, "services");
        Throw.IfNull(serviceType, "serviceType");
        Throw.IfNull(implementationFactory, "implementationFactory");
        return services.AddKeyedSingleton(serviceType, serviceKey, implementationFactory).ActivateKeyedSingleton(serviceType, serviceKey);
    }

    //
    // 概要:
    //     Adds an auto-activated keyed singleton service.
    //
    // パラメーター:
    //   services:
    //     The service collection to add the service to.
    //
    //   serviceType:
    //     The type of the service to register.
    //
    //   serviceKey:
    //     An object used to uniquely identify the specific service.
    //
    //   implementationType:
    //     The implementation type of the service.
    //
    // 戻り値:
    //     The value of services.
    public static IServiceCollection AddActivatedKeyedSingleton(this IServiceCollection services, Type serviceType, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
    {
        Throw.IfNull(services, "services");
        Throw.IfNull(serviceType, "serviceType");
        Throw.IfNull(implementationType, "implementationType");
        return services.AddKeyedSingleton(serviceType, serviceKey, implementationType).ActivateKeyedSingleton(serviceType, serviceKey);
    }

    //
    // 概要:
    //     Tries to add an auto-activated keyed singleton service.
    //
    // パラメーター:
    //   services:
    //     The service collection to add the service to.
    //
    //   serviceType:
    //     The type of the service to register.
    //
    //   serviceKey:
    //     An object used to uniquely identify the specific service.
    public static void TryAddActivatedKeyedSingleton(this IServiceCollection services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType, object? serviceKey)
    {
        Throw.IfNull(services, "services");
        Throw.IfNull(serviceType, "serviceType");
        services.TryAddAndActivateKeyed(ServiceDescriptor.KeyedSingleton(serviceType, serviceKey, serviceType));
    }

    //
    // 概要:
    //     Tries to add an auto-activated keyed singleton service.
    //
    // パラメーター:
    //   services:
    //     The service collection to add the service to.
    //
    //   serviceType:
    //     The type of the service to register.
    //
    //   serviceKey:
    //     An object used to uniquely identify the specific service.
    //
    //   implementationType:
    //     The implementation type of the service.
    public static void TryAddActivatedKeyedSingleton(this IServiceCollection services, Type serviceType, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
    {
        Throw.IfNull(services, "services");
        Throw.IfNull(serviceType, "serviceType");
        Throw.IfNull(implementationType, "implementationType");
        services.TryAddAndActivateKeyed(ServiceDescriptor.KeyedSingleton(serviceType, serviceKey, implementationType));
    }

    //
    // 概要:
    //     Tries to add an auto-activated keyed singleton service.
    //
    // パラメーター:
    //   services:
    //     The service collection to add the service to.
    //
    //   serviceType:
    //     The type of the service to register.
    //
    //   serviceKey:
    //     An object used to uniquely identify the specific service.
    //
    //   implementationFactory:
    //     The factory that creates the service.
    public static void TryAddActivatedKeyedSingleton(this IServiceCollection services, Type serviceType, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory)
    {
        Throw.IfNull(services, "services");
        Throw.IfNull(serviceType, "serviceType");
        Throw.IfNull(implementationFactory, "implementationFactory");
        services.TryAddAndActivateKeyed(ServiceDescriptor.KeyedSingleton(serviceType, serviceKey, implementationFactory));
    }

    //
    // 概要:
    //     Tries to add an auto-activated keyed singleton service.
    //
    // パラメーター:
    //   services:
    //     The service collection to add the service to.
    //
    //   serviceKey:
    //     An object used to uniquely identify the specific service.
    //
    // 型パラメーター:
    //   TService:
    //     The type of the service to add.
    public static void TryAddActivatedKeyedSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this IServiceCollection services, object? serviceKey) where TService : class
    {
        Throw.IfNull(services, "services");
        services.TryAddAndActivateKeyed<TService>(ServiceDescriptor.KeyedSingleton<TService, TService>(serviceKey));
    }

    //
    // 概要:
    //     Tries to add an auto-activated keyed singleton service.
    //
    // パラメーター:
    //   services:
    //     The service collection to add the service to.
    //
    //   serviceKey:
    //     An object used to uniquely identify the specific service.
    //
    // 型パラメーター:
    //   TService:
    //     The type of the service to add.
    //
    //   TImplementation:
    //     The type of the implementation to use.
    public static void TryAddActivatedKeyedSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this IServiceCollection services, object? serviceKey) where TService : class where TImplementation : class, TService
    {
        Throw.IfNull(services, "services");
        services.TryAddAndActivateKeyed<TService>(ServiceDescriptor.KeyedSingleton<TService, TImplementation>(serviceKey));
    }

    //
    // 概要:
    //     Tries to add an auto-activated keyed singleton service.
    //
    // パラメーター:
    //   services:
    //     The service collection to add the service to.
    //
    //   serviceKey:
    //     An object used to uniquely identify the specific service.
    //
    //   implementationFactory:
    //     The factory that creates the service.
    //
    // 型パラメーター:
    //   TService:
    //     The type of the service to add.
    public static void TryAddActivatedKeyedSingleton<TService>(this IServiceCollection services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class
    {
        Throw.IfNull(services, "services");
        Throw.IfNull(implementationFactory, "implementationFactory");
        services.TryAddAndActivateKeyed<TService>(ServiceDescriptor.KeyedSingleton(serviceKey, implementationFactory));
    }

    private static void TryAddAndActivateKeyed<TService>(this IServiceCollection services, ServiceDescriptor descriptor) where TService : class
    {
        ServiceDescriptor descriptor2 = descriptor;
        if (!services.Any((ServiceDescriptor d) => d.ServiceType == descriptor2.ServiceType && d.ServiceKey == descriptor2.ServiceKey))
        {
            services.Add(descriptor2);
            services.ActivateKeyedSingleton<TService>(descriptor2.ServiceKey);
        }
    }

    private static void TryAddAndActivateKeyed(this IServiceCollection services, ServiceDescriptor descriptor)
    {
        ServiceDescriptor descriptor2 = descriptor;
        if (!services.Any((ServiceDescriptor d) => d.ServiceType == descriptor2.ServiceType && d.ServiceKey == descriptor2.ServiceKey))
        {
            services.Add(descriptor2);
            services.ActivateKeyedSingleton(descriptor2.ServiceType, descriptor2.ServiceKey);
        }
    }
}
