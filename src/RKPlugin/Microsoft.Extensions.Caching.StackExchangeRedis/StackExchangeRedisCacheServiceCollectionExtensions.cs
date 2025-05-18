#region アセンブリ Microsoft.Extensions.Caching.StackExchangeRedis, Version=10.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
#endregion

#nullable enable

using Microsoft.Extensions.Caching.StackExchangeRedis;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    //
    // 概要:
    //     Extension methods for setting up Redis distributed cache related services in
    //     an Microsoft.Extensions.DependencyInjection.IServiceCollection.
    public static class StackExchangeRedisCacheServiceCollectionExtensions
    {
        //
        // 概要:
        //     Adds Redis distributed caching services to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add services
        //     to.
        //
        //   setupAction:
        //     An System.Action`1 to configure the provided Microsoft.Extensions.Caching.StackExchangeRedis.RedisCacheOptions.
        //
        //
        // 戻り値:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection so that additional
        //     calls can be chained.
        public static IServiceCollection AddStackExchangeRedisCache(this IServiceCollection services, Action<RedisCacheOptions> setupAction);
    }
}