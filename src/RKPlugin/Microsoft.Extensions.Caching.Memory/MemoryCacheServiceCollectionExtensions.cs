#region アセンブリ Microsoft.Extensions.Caching.Memory, Version=10.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
#endregion

#nullable enable

using Microsoft.Extensions.Caching.Memory;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    //
    // 概要:
    //     Extension methods for setting up memory cache related services in an Microsoft.Extensions.DependencyInjection.IServiceCollection.
    public static class MemoryCacheServiceCollectionExtensions
    {
        //
        // 概要:
        //     Adds a default implementation of Microsoft.Extensions.Caching.Distributed.IDistributedCache
        //     that stores items in memory to the Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //     Frameworks that require a distributed cache to work can safely add this dependency
        //     as part of their dependency list to ensure that there is at least one implementation
        //     available.
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add services
        //     to.
        //
        // 戻り値:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection so that additional
        //     calls can be chained.
        //
        // 注釈:
        //     Microsoft.Extensions.DependencyInjection.MemoryCacheServiceCollectionExtensions.AddDistributedMemoryCache(Microsoft.Extensions.DependencyInjection.IServiceCollection)
        //     should only be used in single server scenarios as this cache stores items in
        //     memory and doesn't expand across multiple machines. For those scenarios it is
        //     recommended to use a proper distributed cache that can expand across multiple
        //     machines.
        public static IServiceCollection AddDistributedMemoryCache(this IServiceCollection services);
        //
        // 概要:
        //     Adds a default implementation of Microsoft.Extensions.Caching.Distributed.IDistributedCache
        //     that stores items in memory to the Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //     Frameworks that require a distributed cache to work can safely add this dependency
        //     as part of their dependency list to ensure that there is at least one implementation
        //     available.
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add services
        //     to.
        //
        //   setupAction:
        //     The System.Action`1 to configure the provided Microsoft.Extensions.Caching.Memory.MemoryDistributedCacheOptions.
        //
        //
        // 戻り値:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection so that additional
        //     calls can be chained.
        //
        // 注釈:
        //     Microsoft.Extensions.DependencyInjection.MemoryCacheServiceCollectionExtensions.AddDistributedMemoryCache(Microsoft.Extensions.DependencyInjection.IServiceCollection)
        //     should only be used in single server scenarios as this cache stores items in
        //     memory and doesn't expand across multiple machines. For those scenarios it is
        //     recommended to use a proper distributed cache that can expand across multiple
        //     machines.
        public static IServiceCollection AddDistributedMemoryCache(this IServiceCollection services, Action<MemoryDistributedCacheOptions> setupAction);
        //
        // 概要:
        //     Adds a non distributed in-memory implementation of Microsoft.Extensions.Caching.Memory.IMemoryCache
        //     to the Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add services
        //     to.
        //
        // 戻り値:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection so that additional
        //     calls can be chained.
        public static IServiceCollection AddMemoryCache(this IServiceCollection services);
        //
        // 概要:
        //     Adds a non distributed in-memory implementation of Microsoft.Extensions.Caching.Memory.IMemoryCache
        //     to the Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add services
        //     to.
        //
        //   setupAction:
        //     The System.Action`1 to configure the provided Microsoft.Extensions.Caching.Memory.MemoryCacheOptions.
        //
        //
        // 戻り値:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection so that additional
        //     calls can be chained.
        public static IServiceCollection AddMemoryCache(this IServiceCollection services, Action<MemoryCacheOptions> setupAction);
    }
}