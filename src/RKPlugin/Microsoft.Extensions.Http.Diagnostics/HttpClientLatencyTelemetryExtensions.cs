#region アセンブリ Microsoft.Extensions.Http.Diagnostics, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Decompiled with ICSharpCode.Decompiler 8.2.0.7535
#endregion

using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.Http.Latency;
using Microsoft.Extensions.Http.Latency.Internal;
using Microsoft.Extensions.Http.Logging;
using Microsoft.Shared.Diagnostics;

namespace Microsoft.Extensions.DependencyInjection;

//
// 概要:
//     Extensions to add http client latency telemetry.
public static class HttpClientLatencyTelemetryExtensions
{
    //
    // 概要:
    //     Adds a System.Net.Http.DelegatingHandler to collect latency information and enrich
    //     outgoing request log for all http clients.
    //
    // パラメーター:
    //   services:
    //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
    //
    // 戻り値:
    //     The value of services.
    //
    // 注釈:
    //     This extension configures latency information collection globally for all http
    //     clients.
    public static IServiceCollection AddHttpClientLatencyTelemetry(this IServiceCollection services)
    {
        Microsoft.Shared.Diagnostics.Throw.IfNull(services, "services");
        services.RegisterCheckpointNames(HttpCheckpoints.Checkpoints);
        services.AddOptions<HttpClientLatencyTelemetryOptions>();
        services.AddActivatedSingleton<HttpRequestLatencyListener>();
        services.AddActivatedSingleton<HttpClientLatencyContext>();
        services.AddTransient<HttpLatencyTelemetryHandler>();
        services.AddHttpClientLogEnricher<HttpClientLatencyLogEnricher>();
        return services.ConfigureAll(delegate (HttpClientFactoryOptions httpClientOptions)
        {
            httpClientOptions.HttpMessageHandlerBuilderActions.Add(delegate (HttpMessageHandlerBuilder httpMessageHandlerBuilder)
            {
                HttpLatencyTelemetryHandler requiredService = httpMessageHandlerBuilder.Services.GetRequiredService<HttpLatencyTelemetryHandler>();
                httpMessageHandlerBuilder.AdditionalHandlers.Add(requiredService);
            });
        });
    }

    //
    // 概要:
    //     Adds a System.Net.Http.DelegatingHandler to collect latency information and enrich
    //     outgoing request log for all http clients.
    //
    // パラメーター:
    //   services:
    //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
    //
    //   section:
    //     The Microsoft.Extensions.Configuration.IConfigurationSection to use for configuring
    //     Microsoft.Extensions.Http.Latency.HttpClientLatencyTelemetryOptions.
    //
    // 戻り値:
    //     The value of services.
    //
    // 注釈:
    //     This extension configures outgoing request logs auto collection globally for
    //     all http clients.
    [DynamicDependency(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicProperties, typeof(LoggingOptions))]
    [UnconditionalSuppressMessage("Trimming", "IL2026:Members annotated with 'RequiresUnreferencedCodeAttribute' require dynamic access otherwise can break functionality when trimming application code", Justification = "Addressed with [DynamicDependency]")]
    public static IServiceCollection AddHttpClientLatencyTelemetry(this IServiceCollection services, IConfigurationSection section)
    {
        Microsoft.Shared.Diagnostics.Throw.IfNull(section, "section");
        services.Configure<HttpClientLatencyTelemetryOptions>(section);
        return services.AddHttpClientLatencyTelemetry();
    }

    //
    // 概要:
    //     Adds a System.Net.Http.DelegatingHandler to collect latency information and enrich
    //     outgoing request log for all http clients.
    //
    // パラメーター:
    //   services:
    //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
    //
    //   configure:
    //     The delegate to configure Microsoft.Extensions.Http.Latency.HttpClientLatencyTelemetryOptions
    //     with.
    //
    // 戻り値:
    //     The value of services.
    //
    // 注釈:
    //     This extension configures outgoing request logs auto collection globally for
    //     all http clients.
    public static IServiceCollection AddHttpClientLatencyTelemetry(this IServiceCollection services, Action<HttpClientLatencyTelemetryOptions> configure)
    {
        Microsoft.Shared.Diagnostics.Throw.IfNull(configure, "configure");
        services.Configure(configure);
        return services.AddHttpClientLatencyTelemetry();
    }
}
