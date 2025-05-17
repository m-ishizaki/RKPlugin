#region アセンブリ Microsoft.Extensions.Diagnostics.ExceptionSummarization, Version=9.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Decompiled with ICSharpCode.Decompiler 8.2.0.7535
#endregion

using System;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Diagnostics.ExceptionSummarization;
using Microsoft.Shared.Diagnostics;

namespace Microsoft.Extensions.DependencyInjection;

//
// 概要:
//     Extensions to register exception summarization.
public static class ExceptionSummarizationServiceCollectionExtensions
{
    //
    // 概要:
    //     Registers an exception summarizer into a dependency injection container.
    //
    // パラメーター:
    //   services:
    //     The dependency injection container to add the summarizer to.
    //
    // 戻り値:
    //     The value of services.
    //
    // 例外:
    //   T:System.ArgumentNullException:
    //     services is null.
    public static IServiceCollection AddExceptionSummarizer(this IServiceCollection services)
    {
        Throw.IfNull(services, "services");
        services.TryAddSingleton<IExceptionSummarizer, ExceptionSummarizer>();
        return services;
    }

    //
    // 概要:
    //     Registers an exception summarizer into a dependency injection container.
    //
    // パラメーター:
    //   services:
    //     The dependency injection container to add the summarizer to.
    //
    //   configure:
    //     Delegates that configures the set of registered summary providers.
    //
    // 戻り値:
    //     The value of services.
    //
    // 例外:
    //   T:System.ArgumentNullException:
    //     services or configure is null.
    public static IServiceCollection AddExceptionSummarizer(this IServiceCollection services, Action<IExceptionSummarizationBuilder> configure)
    {
        Throw.IfNull(services, "services");
        Throw.IfNull(configure, "configure");
        services.TryAddSingleton<IExceptionSummarizer, ExceptionSummarizer>();
        configure(new ExceptionSummarizationBuilder(services));
        return services;
    }
}
