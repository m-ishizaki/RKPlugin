#region アセンブリ Microsoft.Extensions.Diagnostics, Version=10.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
#endregion

#nullable enable

using Microsoft.Extensions.Diagnostics.Metrics;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    //
    // 概要:
    //     Extension methods for setting up metrics services in an Microsoft.Extensions.DependencyInjection.IServiceCollection.
    public static class MetricsServiceExtensions
    {
        //
        // 概要:
        //     Adds metrics services to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add services
        //     to.
        //
        // 戻り値:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection so that additional
        //     calls can be chained.
        public static IServiceCollection AddMetrics(this IServiceCollection services);
        //
        // 概要:
        //     Adds metrics services to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add services
        //     to.
        //
        //   configure:
        //     A callback to configure the Microsoft.Extensions.Diagnostics.Metrics.IMetricsBuilder.
        //
        //
        // 戻り値:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection so that additional
        //     calls can be chained.
        public static IServiceCollection AddMetrics(this IServiceCollection services, Action<IMetricsBuilder> configure);
    }
}