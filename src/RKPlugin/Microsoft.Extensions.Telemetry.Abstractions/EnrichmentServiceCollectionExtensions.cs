#region アセンブリ Microsoft.Extensions.Telemetry.Abstractions, Version=9.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Decompiled with ICSharpCode.Decompiler 8.2.0.7535
#endregion

using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Diagnostics.Enrichment;
using Microsoft.Shared.Diagnostics;

namespace Microsoft.Extensions.DependencyInjection;

//
// 概要:
//     Lets you register telemetry enrichers in a dependency injection container.
public static class EnrichmentServiceCollectionExtensions
{
    //
    // 概要:
    //     Registers a log enricher type.
    //
    // パラメーター:
    //   services:
    //     The dependency injection container to add the enricher type to.
    //
    // 型パラメーター:
    //   T:
    //     Enricher type.
    //
    // 戻り値:
    //     The value of services.
    //
    // 例外:
    //   T:System.ArgumentNullException:
    //     services is null.
    public static IServiceCollection AddLogEnricher<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] T>(this IServiceCollection services) where T : class, ILogEnricher
    {
        return Microsoft.Shared.Diagnostics.Throw.IfNull(services, "services").AddSingleton<ILogEnricher, T>();
    }

    //
    // 概要:
    //     Registers a log enricher instance.
    //
    // パラメーター:
    //   services:
    //     The dependency injection container to add the enricher instance to.
    //
    //   enricher:
    //     The enricher instance to add.
    //
    // 戻り値:
    //     The value of services.
    //
    // 例外:
    //   T:System.ArgumentNullException:
    //     services or enricher is null.
    public static IServiceCollection AddLogEnricher(this IServiceCollection services, ILogEnricher enricher)
    {
        return Microsoft.Shared.Diagnostics.Throw.IfNull(services, "services").AddSingleton(Microsoft.Shared.Diagnostics.Throw.IfNull(enricher, "enricher"));
    }

    //
    // 概要:
    //     Registers a static log enricher type.
    //
    // パラメーター:
    //   services:
    //     The dependency injection container to add the enricher type to.
    //
    // 型パラメーター:
    //   T:
    //     Enricher type.
    //
    // 戻り値:
    //     The value of services.
    //
    // 例外:
    //   T:System.ArgumentNullException:
    //     services is null.
    public static IServiceCollection AddStaticLogEnricher<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] T>(this IServiceCollection services) where T : class, IStaticLogEnricher
    {
        return Microsoft.Shared.Diagnostics.Throw.IfNull(services, "services").AddSingleton<IStaticLogEnricher, T>();
    }

    //
    // 概要:
    //     Registers a static log enricher instance.
    //
    // パラメーター:
    //   services:
    //     The dependency injection container to add the enricher instance to.
    //
    //   enricher:
    //     The enricher instance to add.
    //
    // 戻り値:
    //     The value of services.
    //
    // 例外:
    //   T:System.ArgumentNullException:
    //     services or enricher is null.
    public static IServiceCollection AddStaticLogEnricher(this IServiceCollection services, IStaticLogEnricher enricher)
    {
        return Microsoft.Shared.Diagnostics.Throw.IfNull(services, "services").AddSingleton(Microsoft.Shared.Diagnostics.Throw.IfNull(enricher, "enricher"));
    }
}
