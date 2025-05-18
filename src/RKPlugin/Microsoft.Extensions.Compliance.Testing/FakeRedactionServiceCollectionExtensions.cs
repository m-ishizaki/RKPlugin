#region アセンブリ Microsoft.Extensions.Compliance.Testing, Version=9.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Decompiled with ICSharpCode.Decompiler 8.2.0.7535
#endregion

using System;
using Microsoft.Extensions.Compliance.Redaction;
using Microsoft.Extensions.Compliance.Testing;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Microsoft.Shared.Diagnostics;

namespace Microsoft.Extensions.DependencyInjection;

//
// 概要:
//     Extensions that allow registering a fake redactor in the application.
public static class FakeRedactionServiceCollectionExtensions
{
    //
    // 概要:
    //     Registers the fake redactor provider that always returns fake redactor instances.
    //
    //
    // パラメーター:
    //   services:
    //     Container used to register fake redaction classes.
    //
    // 戻り値:
    //     The value of services.
    //
    // 例外:
    //   T:System.ArgumentNullException:
    //     services is null.
    public static IServiceCollection AddFakeRedaction(this IServiceCollection services)
    {
        Microsoft.Shared.Diagnostics.Throw.IfNull(services, "services");
        services.TryAddSingleton<FakeRedactionCollector>();
        services.TryAddSingleton((Func<IServiceProvider, IRedactorProvider>)delegate (IServiceProvider serviceProvider)
        {
            FakeRedactionCollector requiredService = serviceProvider.GetRequiredService<FakeRedactionCollector>();
            FakeRedactorOptions value = serviceProvider.GetRequiredService<IOptions<FakeRedactorOptions>>().Value;
            return new FakeRedactorProvider(value, requiredService);
        });
        return services.AddOptionsWithValidateOnStart<FakeRedactorOptions, FakeRedactorOptionsAutoValidator>().Services.AddOptionsWithValidateOnStart<FakeRedactorOptions, FakeRedactorOptionsCustomValidator>().Services;
    }

    //
    // 概要:
    //     Registers the fake redactor provider that always returns fake redactor instances.
    //
    //
    // パラメーター:
    //   services:
    //     Container used to register fake redaction classes.
    //
    //   configure:
    //     Configures fake redactor.
    //
    // 戻り値:
    //     The value of services.
    //
    // 例外:
    //   T:System.ArgumentNullException:
    //     services or configure> are null.
    public static IServiceCollection AddFakeRedaction(this IServiceCollection services, Action<FakeRedactorOptions> configure)
    {
        Microsoft.Shared.Diagnostics.Throw.IfNull(services, "services");
        Microsoft.Shared.Diagnostics.Throw.IfNull(configure, "configure");
        services.TryAddSingleton<FakeRedactionCollector>();
        services.TryAddSingleton((Func<IServiceProvider, IRedactorProvider>)delegate (IServiceProvider serviceProvider)
        {
            FakeRedactionCollector requiredService = serviceProvider.GetRequiredService<FakeRedactionCollector>();
            FakeRedactorOptions value = serviceProvider.GetRequiredService<IOptions<FakeRedactorOptions>>().Value;
            return new FakeRedactorProvider(value, requiredService);
        });
        return services.AddOptionsWithValidateOnStart<FakeRedactorOptions, FakeRedactorOptionsAutoValidator>().Services.AddOptionsWithValidateOnStart<FakeRedactorOptions, FakeRedactorOptionsCustomValidator>().Configure(configure).Services;
    }
}
