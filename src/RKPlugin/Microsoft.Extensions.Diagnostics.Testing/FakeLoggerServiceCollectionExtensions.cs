#region アセンブリ Microsoft.Extensions.Diagnostics.Testing, Version=9.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Decompiled with ICSharpCode.Decompiler 8.2.0.7535
#endregion

using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Testing;

namespace Microsoft.Extensions.DependencyInjection;

//
// 概要:
//     Extensions for configuring fake logging, used in unit tests.
public static class FakeLoggerServiceCollectionExtensions
{
    //
    // 概要:
    //     Configures fake logging.
    //
    // パラメーター:
    //   services:
    //     Service collection.
    //
    //   section:
    //     Configuration section that contains Microsoft.Extensions.Logging.Testing.FakeLogCollectorOptions.
    //
    //
    // 戻り値:
    //     The value of services.
    public static IServiceCollection AddFakeLogging(this IServiceCollection services, IConfigurationSection section)
    {
        IConfigurationSection section2 = section;
        return services.AddLogging(delegate (ILoggingBuilder x)
        {
            x.AddFakeLogging(section2);
        });
    }

    //
    // 概要:
    //     Configures fake logging.
    //
    // パラメーター:
    //   services:
    //     Service collection.
    //
    //   configure:
    //     Logging configuration options.
    //
    // 戻り値:
    //     The value of services.
    public static IServiceCollection AddFakeLogging(this IServiceCollection services, Action<FakeLogCollectorOptions> configure)
    {
        Action<FakeLogCollectorOptions> configure2 = configure;
        return services.AddLogging(delegate (ILoggingBuilder x)
        {
            x.AddFakeLogging(configure2);
        });
    }

    //
    // 概要:
    //     Configures fake logging with default options.
    //
    // パラメーター:
    //   services:
    //     Service collection.
    //
    // 戻り値:
    //     The value of services.
    public static IServiceCollection AddFakeLogging(this IServiceCollection services)
    {
        return services.AddLogging(delegate (ILoggingBuilder builder)
        {
            builder.AddFakeLogging();
        });
    }
}
