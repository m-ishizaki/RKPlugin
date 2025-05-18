#region アセンブリ Microsoft.Extensions.Caching.Hybrid, Version=9.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Decompiled with ICSharpCode.Decompiler 8.2.0.7535
#endregion

using System;
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.Caching.Hybrid.Internal;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Shared.Diagnostics;

namespace Microsoft.Extensions.DependencyInjection;

//
// 概要:
//     Configuration extension methods for Microsoft.Extensions.Caching.Hybrid.HybridCache.
public static class HybridCacheServiceExtensions
{
    //
    // 概要:
    //     Adds support for multi-tier caching services.
    //
    // 戻り値:
    //     A builder instance that allows further configuration of the Microsoft.Extensions.Caching.Hybrid.HybridCache
    //     system.
    public static IHybridCacheBuilder AddHybridCache(this IServiceCollection services, Action<HybridCacheOptions> setupAction)
    {
        Throw.IfNull(setupAction, "setupAction");
        services.AddHybridCache();
        services.Configure(setupAction);
        return new HybridCacheBuilder(services);
    }

    //
    // 概要:
    //     Adds support for multi-tier caching services.
    //
    // 戻り値:
    //     A builder instance that allows further configuration of the Microsoft.Extensions.Caching.Hybrid.HybridCache
    //     system.
    public static IHybridCacheBuilder AddHybridCache(this IServiceCollection services)
    {
        Throw.IfNull(services, "services");
        services.TryAddSingleton(TimeProvider.System);
        services.AddOptions().AddMemoryCache();
        services.TryAddSingleton<IHybridCacheSerializerFactory, DefaultJsonSerializerFactory>();
        services.TryAddSingleton((IHybridCacheSerializer<string>)InbuiltTypeSerializer.Instance);
        services.TryAddSingleton((IHybridCacheSerializer<byte[]>)InbuiltTypeSerializer.Instance);
        services.TryAddSingleton<HybridCache, DefaultHybridCache>();
        return new HybridCacheBuilder(services);
    }
}
