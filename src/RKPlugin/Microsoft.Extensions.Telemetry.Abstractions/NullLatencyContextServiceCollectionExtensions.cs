#region アセンブリ Microsoft.Extensions.Telemetry.Abstractions, Version=9.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Decompiled with ICSharpCode.Decompiler 8.2.0.7535
#endregion

using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Diagnostics.Latency;
using Microsoft.Shared.Diagnostics;

namespace Microsoft.Extensions.DependencyInjection;

//
// 概要:
//     Extensions to add a no-op latency context.
public static class NullLatencyContextServiceCollectionExtensions
{
    //
    // 概要:
    //     Adds a no-op latency context to a dependency injection container.
    //
    // パラメーター:
    //   services:
    //     The dependency injection container to add the context to.
    //
    // 戻り値:
    //     The value of services.
    //
    // 例外:
    //   T:System.ArgumentNullException:
    //     services is null.
    public static IServiceCollection AddNullLatencyContext(this IServiceCollection services)
    {
        Microsoft.Shared.Diagnostics.Throw.IfNull(services, "services");
        services.TryAddSingleton<ILatencyContextProvider, NullLatencyContext>();
        services.TryAddSingleton<ILatencyContextTokenIssuer, NullLatencyContext>();
        return services;
    }
}
