#region アセンブリ Microsoft.Extensions.ObjectPool.DependencyInjection, Version=9.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Decompiled with ICSharpCode.Decompiler 8.2.0.7535
#endregion

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.ObjectPool;
using Microsoft.Extensions.Options;
using Microsoft.Shared.Diagnostics;

namespace Microsoft.Extensions.DependencyInjection;

//
// 概要:
//     Extension methods for adding Microsoft.Extensions.ObjectPool.ObjectPool`1 to
//     DI container.
public static class ObjectPoolServiceCollectionExtensions
{
    //
    // 概要:
    //     Adds an Microsoft.Extensions.ObjectPool.ObjectPool`1 and lets DI return scoped
    //     instances of TService.
    //
    // パラメーター:
    //   services:
    //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add to.
    //
    //   configure:
    //     The action used to configure the options of the pool.
    //
    // 型パラメーター:
    //   TService:
    //     The type of objects to pool.
    //
    // 戻り値:
    //     Provided service collection.
    //
    // 例外:
    //   T:System.ArgumentNullException:
    //     services is null.
    //
    // 注釈:
    //     The default capacity is 1024. The pooled type instances are obtainable by resolving
    //     Microsoft.Extensions.ObjectPool.ObjectPool`1 from the DI container.
    public static IServiceCollection AddPooled<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this IServiceCollection services, Action<DependencyInjectionPoolOptions>? configure = null) where TService : class
    {
        return services.AddPooledInternal<TService, TService>(configure);
    }

    //
    // 概要:
    //     Adds an Microsoft.Extensions.ObjectPool.ObjectPool`1 and lets DI return scoped
    //     instances of TService.
    //
    // パラメーター:
    //   services:
    //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add to.
    //
    //   configure:
    //     Configuration of the pool.
    //
    // 型パラメーター:
    //   TService:
    //     The type of objects to pool.
    //
    //   TImplementation:
    //     The type of the implementation to use.
    //
    // 戻り値:
    //     Provided service collection.
    //
    // 例外:
    //   T:System.ArgumentNullException:
    //     services is null.
    //
    // 注釈:
    //     The default capacity is 1024. The pooled type instances are obtainable by resolving
    //     Microsoft.Extensions.ObjectPool.ObjectPool`1 from the DI container.
    public static IServiceCollection AddPooled<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this IServiceCollection services, Action<DependencyInjectionPoolOptions>? configure = null) where TService : class where TImplementation : class, TService
    {
        return services.AddPooledInternal<TService, TImplementation>(configure);
    }

    //
    // 概要:
    //     Registers an action used to configure the Microsoft.Extensions.ObjectPool.DependencyInjectionPoolOptions
    //     of a typed pool.
    //
    // パラメーター:
    //   services:
    //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the services
    //     to.
    //
    //   configure:
    //     The action used to configure the options.
    //
    // 型パラメーター:
    //   TService:
    //     The type of objects to pool.
    //
    // 戻り値:
    //     The value of services.
    public static IServiceCollection ConfigurePool<TService>(this IServiceCollection services, Action<DependencyInjectionPoolOptions> configure) where TService : class
    {
        return services.Configure(typeof(TService).FullName, configure);
    }

    //
    // 概要:
    //     Configures DI pools.
    //
    // パラメーター:
    //   services:
    //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add to.
    //
    //   section:
    //     The configuration section to bind.
    //
    // 戻り値:
    //     The value of services.
    public static IServiceCollection ConfigurePools(this IServiceCollection services, IConfigurationSection section)
    {
        foreach (IConfigurationSection child in Throw.IfNull(section, "section").GetChildren())
        {
            if (!int.TryParse(child.Value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var capacity))
            {
                Throw.ArgumentException("section", $"Can't parse '{child.Key}' value '{child.Value}' to integer.");
            }

            services.Configure(child.Key, delegate (DependencyInjectionPoolOptions options)
            {
                options.Capacity = capacity;
            });
        }

        return services;
    }

    private static IServiceCollection AddPooledInternal<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this IServiceCollection services, Action<DependencyInjectionPoolOptions>? configure) where TService : class where TImplementation : class, TService
    {
        Throw.IfNull(services, "services");
        if (configure != null)
        {
            services.ConfigurePool<TService>(configure);
        }

        return services.AddSingleton((Func<IServiceProvider, ObjectPool<TService>>)delegate (IServiceProvider provider)
        {
            DependencyInjectionPoolOptions dependencyInjectionPoolOptions = provider.GetService<IOptionsFactory<DependencyInjectionPoolOptions>>()?.Create(typeof(TService).FullName) ?? new DependencyInjectionPoolOptions();
            return new DefaultObjectPool<TService>(new DependencyInjectionPooledObjectPolicy<TService, TImplementation>(provider), dependencyInjectionPoolOptions.Capacity);
        });
    }
}
