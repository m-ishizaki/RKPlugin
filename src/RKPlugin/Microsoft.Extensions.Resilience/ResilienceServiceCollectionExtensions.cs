#region アセンブリ Microsoft.Extensions.Resilience, Version=9.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Decompiled with ICSharpCode.Decompiler 8.2.0.7535
#endregion

using System.Linq;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Resilience.Internal;
using Microsoft.Shared.Diagnostics;
using Polly.Telemetry;

namespace Microsoft.Extensions.DependencyInjection;

//
// 概要:
//     Extension class for the Service Collection DI container.
public static class ResilienceServiceCollectionExtensions
{
    //
    // 概要:
    //     Adds resilience enrichers.
    //
    // パラメーター:
    //   services:
    //     The services.
    //
    // 戻り値:
    //     The input services.
    //
    // 例外:
    //   T:System.ArgumentNullException:
    //     services is null.
    //
    // 注釈:
    //     This method adds additional dimensions on top of the default ones that are built-in
    //     to the Polly library. These include:
    //
    //     • Exception enrichment based on Microsoft.Extensions.Diagnostics.ExceptionSummarization.IExceptionSummarizer.
    //
    //     • Request metadata enrichment based on Microsoft.Extensions.Http.Diagnostics.RequestMetadata.
    public static IServiceCollection AddResilienceEnricher(this IServiceCollection services)
    {
        Microsoft.Shared.Diagnostics.Throw.IfNull(services, "services");
        if (services.Any((ServiceDescriptor s) => s.ServiceType == typeof(ResilienceMetricsEnricher)))
        {
            return services;
        }

        services.TryAddSingleton<ResilienceMetricsEnricher>();
        services.AddOptionsWithValidateOnStart<TelemetryOptions>().Configure(delegate (TelemetryOptions options, ResilienceMetricsEnricher enricher)
        {
            options.MeteringEnrichers.Add(enricher);
        });
        return services;
    }
}
