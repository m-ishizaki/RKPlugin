#region アセンブリ Microsoft.Extensions.Caching.SqlServer, Version=10.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
#endregion

#nullable enable

using Microsoft.Extensions.Caching.SqlServer;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    //
    // 概要:
    //     Extension methods for setting up Microsoft SQL Server distributed cache services
    //     in an Microsoft.Extensions.DependencyInjection.IServiceCollection.
    public static class SqlServerCachingServicesExtensions
    {
        //
        // 概要:
        //     Adds Microsoft SQL Server distributed caching services to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add services
        //     to.
        //
        //   setupAction:
        //     An System.Action`1 to configure the provided Microsoft.Extensions.Caching.SqlServer.SqlServerCacheOptions.
        //
        //
        // 戻り値:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection so that additional
        //     calls can be chained.
        public static IServiceCollection AddDistributedSqlServerCache(this IServiceCollection services, Action<SqlServerCacheOptions> setupAction);
    }
}