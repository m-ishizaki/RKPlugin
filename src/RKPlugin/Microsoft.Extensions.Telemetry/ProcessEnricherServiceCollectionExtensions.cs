#region アセンブリ Microsoft.Extensions.Telemetry, Version=9.4.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Decompiled with ICSharpCode.Decompiler 8.2.0.7535
#endregion

using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Binder.SourceGeneration;
using Microsoft.Extensions.Diagnostics.Enrichment;
using Microsoft.Shared.Diagnostics;

namespace Microsoft.Extensions.DependencyInjection;

//
// 概要:
//     Provides extension methods for setting up Process enrichers in an Microsoft.Extensions.DependencyInjection.IServiceCollection.
public static class ProcessEnricherServiceCollectionExtensions
{
    //
    // 概要:
    //     Adds an instance of the process enricher to the Microsoft.Extensions.DependencyInjection.IServiceCollection.
    //
    //
    // パラメーター:
    //   services:
    //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the process
    //     enricher to.
    //
    // 戻り値:
    //     The value of services.
    //
    // 例外:
    //   T:System.ArgumentNullException:
    //     services is null.
    public static IServiceCollection AddProcessLogEnricher(this IServiceCollection services)
    {
        Microsoft.Shared.Diagnostics.Throw.IfNull(services, "services");
        return services.AddProcessLogEnricher(delegate
        {
        });
    }

    //
    // 概要:
    //     Adds an instance of the process enricher to the Microsoft.Extensions.DependencyInjection.IServiceCollection.
    //
    //
    // パラメーター:
    //   services:
    //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the process
    //     enricher to.
    //
    //   configure:
    //     The Microsoft.Extensions.Diagnostics.Enrichment.ProcessLogEnricherOptions configuration
    //     delegate.
    //
    // 戻り値:
    //     The value of services.
    //
    // 例外:
    //   T:System.ArgumentNullException:
    //     Any of the arguments is null.
    public static IServiceCollection AddProcessLogEnricher(this IServiceCollection services, Action<ProcessLogEnricherOptions> configure)
    {
        Microsoft.Shared.Diagnostics.Throw.IfNull(services, "services");
        Microsoft.Shared.Diagnostics.Throw.IfNull(configure, "configure");
        return services.AddLogEnricher<ProcessLogEnricher>().AddStaticLogEnricher<StaticProcessLogEnricher>().Configure(configure);
    }

    //
    // 概要:
    //     Adds an instance of the host enricher to the Microsoft.Extensions.DependencyInjection.IServiceCollection.
    //
    //
    // パラメーター:
    //   services:
    //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the process
    //     enricher to.
    //
    //   section:
    //     The Microsoft.Extensions.Configuration.IConfigurationSection to use for configuring
    //     Microsoft.Extensions.Diagnostics.Enrichment.ProcessLogEnricherOptions in the
    //     process enricher.
    //
    // 戻り値:
    //     The value of services.
    //
    // 例外:
    //   T:System.ArgumentNullException:
    //     Any of the arguments is null.
    public static IServiceCollection AddProcessLogEnricher(this IServiceCollection services, IConfigurationSection section)
    {
        Microsoft.Shared.Diagnostics.Throw.IfNull(services, "services");
        Microsoft.Shared.Diagnostics.Throw.IfNull(section, "section");
        return _003CBindingExtensions_g_003EFD8ACD7B628BEE36AC5ED19878E34354CAB78D16CDBDF235E14209C725A978270__BindingExtensions.Configure<ProcessLogEnricherOptions>(services.AddLogEnricher<ProcessLogEnricher>().AddStaticLogEnricher<StaticProcessLogEnricher>(), section);
    }
}
