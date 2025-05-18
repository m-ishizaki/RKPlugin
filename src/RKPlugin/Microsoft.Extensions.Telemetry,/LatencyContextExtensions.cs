#region アセンブリ Microsoft.Extensions.Telemetry, Version=9.4.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Decompiled with ICSharpCode.Decompiler 8.2.0.7535
#endregion

using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Binder.SourceGeneration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Diagnostics.Latency;
using Microsoft.Extensions.Diagnostics.Latency.Internal;
using Microsoft.Shared.Diagnostics;

namespace Microsoft.Extensions.DependencyInjection;

//
// 概要:
//     Extensions to add latency context.
public static class LatencyContextExtensions
{
    //
    // 概要:
    //     Adds latency context.
    //
    // パラメーター:
    //   services:
    //     The dependency injection container.
    //
    // 戻り値:
    //     The value of services.
    public static IServiceCollection AddLatencyContext(this IServiceCollection services)
    {
        Microsoft.Shared.Diagnostics.Throw.IfNull(services, "services");
        services.AddOptions<LatencyContextOptions>();
        services.TryAddSingleton<LatencyContextRegistrySet>();
        services.TryAddSingleton<LatencyInstrumentProvider>();
        services.TryAddSingleton<ILatencyContextProvider, LatencyContextProvider>();
        services.TryAddSingleton<ILatencyContextTokenIssuer, LatencyContextTokenIssuer>();
        return services;
    }

    //
    // 概要:
    //     Adds latency context.
    //
    // パラメーター:
    //   services:
    //     The dependency injection container.
    //
    //   configure:
    //     The Microsoft.Extensions.Diagnostics.Latency.LatencyContextOptions configuration
    //     delegate.
    //
    // 戻り値:
    //     The value of services.
    public static IServiceCollection AddLatencyContext(this IServiceCollection services, Action<LatencyContextOptions> configure)
    {
        Microsoft.Shared.Diagnostics.Throw.IfNull(services, "services");
        Microsoft.Shared.Diagnostics.Throw.IfNull(configure, "configure");
        services.Configure(configure);
        return services.AddLatencyContext();
    }

    //
    // 概要:
    //     Adds latency context.
    //
    // パラメーター:
    //   services:
    //     The dependency injection container.
    //
    //   section:
    //     The configuration of Microsoft.Extensions.Diagnostics.Latency.LatencyContextOptions.
    //
    //
    // 戻り値:
    //     The value of services.
    public static IServiceCollection AddLatencyContext(this IServiceCollection services, IConfigurationSection section)
    {
        Microsoft.Shared.Diagnostics.Throw.IfNull(services, "services");
        Microsoft.Shared.Diagnostics.Throw.IfNull(section, "section");
        _003CBindingExtensions_g_003EFD8ACD7B628BEE36AC5ED19878E34354CAB78D16CDBDF235E14209C725A978270__BindingExtensions.Configure<LatencyContextOptions>(services, section);
        return services.AddLatencyContext();
    }
}
