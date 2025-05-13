
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Binder.SourceGeneration;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Shared.Diagnostics;

namespace Microsoft.Extensions.DependencyInjection;

//
// 概要:
//     Controls various health check features.
public static class CommonHealthChecksExtensions
{
    //
    // 概要:
    //     Registers a health check provider that's tied to the application's lifecycle.
    //
    //
    // パラメーター:
    //   builder:
    //     The builder to add the provider to.
    //
    //   tags:
    //     A list of tags that can be used to filter health checks.
    //
    // 戻り値:
    //     The value of builder.
    public static IHealthChecksBuilder AddApplicationLifecycleHealthCheck(this IHealthChecksBuilder builder, params string[] tags)
    {
        IHealthChecksBuilder builder2 = Microsoft.Shared.Diagnostics.Throw.IfNull(builder, "builder");
        IEnumerable<string> tags2 = Microsoft.Shared.Diagnostics.Throw.IfNull(tags, "tags");
        return builder2.AddCheck<ApplicationLifecycleHealthCheck>("ApplicationLifecycle", null, tags2, null);
    }

    //
    // 概要:
    //     Registers a health check provider that's tied to the application's lifecycle.
    //
    //
    // パラメーター:
    //   builder:
    //     The builder to add the provider to.
    //
    //   tags:
    //     A list of tags that can be used to filter health checks.
    //
    // 戻り値:
    //     The value of builder.
    //
    // 例外:
    //   T:System.ArgumentNullException:
    //     builder or tags is null.
    public static IHealthChecksBuilder AddApplicationLifecycleHealthCheck(this IHealthChecksBuilder builder, IEnumerable<string> tags)
    {
        IHealthChecksBuilder builder2 = Microsoft.Shared.Diagnostics.Throw.IfNull(builder, "builder");
        IEnumerable<string> tags2 = Microsoft.Shared.Diagnostics.Throw.IfNull(tags, "tags");
        return builder2.AddCheck<ApplicationLifecycleHealthCheck>("ApplicationLifecycle", null, tags2, null);
    }

    //
    // 概要:
    //     Registers a health check provider that enables manual control of the application's
    //     health.
    //
    // パラメーター:
    //   builder:
    //     The builder to add the provider to.
    //
    //   tags:
    //     A list of tags that can be used to filter health checks.
    //
    // 戻り値:
    //     The value of builder.
    //
    // 例外:
    //   T:System.ArgumentNullException:
    //     builder or tags is null.
    public static IHealthChecksBuilder AddManualHealthCheck(this IHealthChecksBuilder builder, params string[] tags)
    {
        IHealthChecksBuilder builder2 = Microsoft.Shared.Diagnostics.Throw.IfNull(builder, "builder").AddManualHealthCheckDependencies();
        IEnumerable<string> tags2 = Microsoft.Shared.Diagnostics.Throw.IfNull(tags, "tags");
        return builder2.AddCheck<ManualHealthCheckService>("Manual", null, tags2, null);
    }

    //
    // 概要:
    //     Registers a health check provider that enables manual control of the application's
    //     health.
    //
    // パラメーター:
    //   builder:
    //     The builder to add the provider to.
    //
    //   tags:
    //     A list of tags that can be used to filter health checks.
    //
    // 戻り値:
    //     The value of builder.
    //
    // 例外:
    //   T:System.ArgumentNullException:
    //     builder or tags is null.
    public static IHealthChecksBuilder AddManualHealthCheck(this IHealthChecksBuilder builder, IEnumerable<string> tags)
    {
        IHealthChecksBuilder builder2 = Microsoft.Shared.Diagnostics.Throw.IfNull(builder, "builder").AddManualHealthCheckDependencies();
        IEnumerable<string> tags2 = Microsoft.Shared.Diagnostics.Throw.IfNull(tags, "tags");
        return builder2.AddCheck<ManualHealthCheckService>("Manual", null, tags2, null);
    }

    //
    // 概要:
    //     Sets the manual health check to the healthy state.
    //
    // パラメーター:
    //   manualHealthCheck:
    //     The Microsoft.Extensions.Diagnostics.HealthChecks.IManualHealthCheck.
    //
    // 例外:
    //   T:System.ArgumentNullException:
    //     manualHealthCheck is null.
    public static void ReportHealthy(this IManualHealthCheck manualHealthCheck)
    {
        Microsoft.Shared.Diagnostics.Throw.IfNull(manualHealthCheck, "manualHealthCheck").Result = HealthCheckResult.Healthy();
    }

    //
    // 概要:
    //     Sets the manual health check to return an unhealthy states and an associated
    //     reason.
    //
    // パラメーター:
    //   manualHealthCheck:
    //     The Microsoft.Extensions.Diagnostics.HealthChecks.IManualHealthCheck.
    //
    //   reason:
    //     The reason why the health check is unhealthy.
    //
    // 例外:
    //   T:System.ArgumentNullException:
    //     manualHealthCheck is null.
    public static void ReportUnhealthy(this IManualHealthCheck manualHealthCheck, string reason)
    {
        Microsoft.Shared.Diagnostics.Throw.IfNull(manualHealthCheck, "manualHealthCheck").Result = HealthCheckResult.Unhealthy(Microsoft.Shared.Diagnostics.Throw.IfNullOrWhitespace(reason, "reason"));
    }

    private static IHealthChecksBuilder AddManualHealthCheckDependencies(this IHealthChecksBuilder builder)
    {
        return builder.Services.AddSingleton<ManualHealthCheckTracker>().AddTransient(typeof(IManualHealthCheck<>), typeof(ManualHealthCheck<>)).AddHealthChecks();
    }

    //
    // 概要:
    //     Registers a health check publisher which emits telemetry representing the application's
    //     health.
    //
    // パラメーター:
    //   services:
    //     The dependency injection container to add the publisher to.
    //
    // 戻り値:
    //     The value of services.
    //
    // 例外:
    //   T:System.ArgumentNullException:
    //     services is null.
    public static IServiceCollection AddTelemetryHealthCheckPublisher(this IServiceCollection services)
    {
        return Microsoft.Shared.Diagnostics.Throw.IfNull(services, "services").AddMetrics().AddSingleton<HealthCheckMetrics>()
            .AddSingleton<IHealthCheckPublisher, TelemetryHealthCheckPublisher>();
    }

    //
    // 概要:
    //     Registers a health check publisher which emits telemetry representing the application's
    //     health.
    //
    // パラメーター:
    //   services:
    //     The dependency injection container to add the publisher to.
    //
    //   section:
    //     Configuration for Microsoft.Extensions.Diagnostics.HealthChecks.TelemetryHealthCheckPublisherOptions.
    //
    //
    // 戻り値:
    //     The value of services.
    //
    // 例外:
    //   T:System.ArgumentNullException:
    //     services or section is null.
    public static IServiceCollection AddTelemetryHealthCheckPublisher(this IServiceCollection services, IConfigurationSection section)
    {
        return _003CBindingExtensions_g_003EFDB9C93A769923A781DA8D9288327B6E7CFB2E2C74E63C159E7C244A1A13AD82D__BindingExtensions.Configure<TelemetryHealthCheckPublisherOptions>(Microsoft.Shared.Diagnostics.Throw.IfNull(services, "services"), Microsoft.Shared.Diagnostics.Throw.IfNull(section, "section")).AddMetrics().AddSingleton<HealthCheckMetrics>()
            .AddSingleton<IHealthCheckPublisher, TelemetryHealthCheckPublisher>();
    }

    //
    // 概要:
    //     Registers a health check publisher which emits telemetry representing the application's
    //     health.
    //
    // パラメーター:
    //   services:
    //     The dependency injection container to add the publisher to.
    //
    //   configure:
    //     Configuration for Microsoft.Extensions.Diagnostics.HealthChecks.TelemetryHealthCheckPublisherOptions.
    //
    //
    // 戻り値:
    //     The value of services.
    //
    // 例外:
    //   T:System.ArgumentNullException:
    //     services or configure is null.
    public static IServiceCollection AddTelemetryHealthCheckPublisher(this IServiceCollection services, Action<TelemetryHealthCheckPublisherOptions> configure)
    {
        return Microsoft.Shared.Diagnostics.Throw.IfNull(services, "services").Configure(Microsoft.Shared.Diagnostics.Throw.IfNull(configure, "configure")).AddMetrics()
            .AddSingleton<HealthCheckMetrics>()
            .AddSingleton<IHealthCheckPublisher, TelemetryHealthCheckPublisher>();
    }
}
