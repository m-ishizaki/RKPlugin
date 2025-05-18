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
//     Extensions to add console latency data exporter.
public static class LatencyConsoleExtensions
{
    //
    // 概要:
    //     Add latency data exporter for the console.
    //
    // パラメーター:
    //   services:
    //     Dependency injection container.
    //
    // 戻り値:
    //     The value of services.
    //
    // 例外:
    //   T:System.ArgumentNullException:
    //     services is null.
    public static IServiceCollection AddConsoleLatencyDataExporter(this IServiceCollection services)
    {
        Microsoft.Shared.Diagnostics.Throw.IfNull(services, "services");
        services.AddOptions<LatencyConsoleOptions>();
        services.TryAddSingleton<ILatencyDataExporter, LatencyConsoleExporter>();
        return services;
    }

    //
    // 概要:
    //     Add latency data exporter for the console.
    //
    // パラメーター:
    //   services:
    //     Dependency injection container.
    //
    //   configure:
    //     Microsoft.Extensions.Diagnostics.Latency.LatencyConsoleOptions configuration
    //     delegate.
    //
    // 戻り値:
    //     The value of services.
    //
    // 例外:
    //   T:System.ArgumentNullException:
    //     Either services or configure is null.
    public static IServiceCollection AddConsoleLatencyDataExporter(this IServiceCollection services, Action<LatencyConsoleOptions> configure)
    {
        Microsoft.Shared.Diagnostics.Throw.IfNull(services, "services");
        Microsoft.Shared.Diagnostics.Throw.IfNull(configure, "configure");
        services.Configure(configure);
        return services.AddConsoleLatencyDataExporter();
    }

    //
    // 概要:
    //     Add latency data exporter for the console.
    //
    // パラメーター:
    //   services:
    //     Dependency injection container.
    //
    //   section:
    //     Configuration of Microsoft.Extensions.Diagnostics.Latency.LatencyConsoleOptions.
    //
    //
    // 戻り値:
    //     The value of services.
    //
    // 例外:
    //   T:System.ArgumentNullException:
    //     Either services or section is null.
    public static IServiceCollection AddConsoleLatencyDataExporter(this IServiceCollection services, IConfigurationSection section)
    {
        Microsoft.Shared.Diagnostics.Throw.IfNull(services, "services");
        Microsoft.Shared.Diagnostics.Throw.IfNull(section, "section");
        _003CBindingExtensions_g_003EFD8ACD7B628BEE36AC5ED19878E34354CAB78D16CDBDF235E14209C725A978270__BindingExtensions.Configure<LatencyConsoleOptions>(services, section);
        return services.AddConsoleLatencyDataExporter();
    }
}
