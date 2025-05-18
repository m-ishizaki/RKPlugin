#region アセンブリ Microsoft.Extensions.Compliance.Redaction, Version=9.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Decompiled with ICSharpCode.Decompiler 8.2.0.7535
#endregion

using System;
using Microsoft.Extensions.Compliance.Redaction;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Shared.Diagnostics;

namespace Microsoft.Extensions.DependencyInjection;

//
// 概要:
//     Extensions to register redaction functionality.
public static class RedactionServiceCollectionExtensions
{
    //
    // 概要:
    //     Registers an implementation of Microsoft.Extensions.Compliance.Redaction.IRedactorProvider
    //     in the Microsoft.Extensions.DependencyInjection.IServiceCollection.
    //
    // パラメーター:
    //   services:
    //     Instance of Microsoft.Extensions.DependencyInjection.IServiceCollection used
    //     to configure redaction.
    //
    // 戻り値:
    //     The value of services.
    //
    // 例外:
    //   T:System.ArgumentNullException:
    //     services is null.
    public static IServiceCollection AddRedaction(this IServiceCollection services)
    {
        return Microsoft.Shared.Diagnostics.Throw.IfNull(services, "services").AddRedaction(delegate
        {
        });
    }

    //
    // 概要:
    //     Registers an implementation of Microsoft.Extensions.Compliance.Redaction.IRedactorProvider
    //     in the Microsoft.Extensions.DependencyInjection.IServiceCollection and configures
    //     available redactors.
    //
    // パラメーター:
    //   services:
    //     Instance of Microsoft.Extensions.DependencyInjection.IServiceCollection used
    //     to configure redaction.
    //
    //   configure:
    //     Configuration function for Microsoft.Extensions.Compliance.Redaction.IRedactionBuilder.
    //
    //
    // 戻り値:
    //     The value of services.
    //
    // 例外:
    //   T:System.ArgumentNullException:
    //     services is null.
    //
    //   T:System.ArgumentNullException:
    //     configure is null.
    public static IServiceCollection AddRedaction(this IServiceCollection services, Action<IRedactionBuilder> configure)
    {
        Microsoft.Shared.Diagnostics.Throw.IfNull(services, "services");
        Microsoft.Shared.Diagnostics.Throw.IfNull(configure, "configure");
        services.AddOptions<RedactorProviderOptions>().Services.TryAddSingleton<IRedactorProvider, RedactorProvider>();
        configure(new RedactionBuilder(services));
        return services;
    }
}
