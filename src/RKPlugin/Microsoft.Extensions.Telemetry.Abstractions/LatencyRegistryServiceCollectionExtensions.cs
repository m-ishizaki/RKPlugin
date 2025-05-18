#region アセンブリ Microsoft.Extensions.Telemetry.Abstractions, Version=9.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Decompiled with ICSharpCode.Decompiler 8.2.0.7535
#endregion

using System;
using Microsoft.Extensions.Diagnostics.Latency;
using Microsoft.Shared.Diagnostics;

namespace Microsoft.Extensions.DependencyInjection;

//
// 概要:
//     Extensions to configure a latency context.
public static class LatencyRegistryServiceCollectionExtensions
{
    //
    // 概要:
    //     Registers a set of checkpoint names for a latency context.
    //
    // パラメーター:
    //   services:
    //     The dependency injection container to add the names to.
    //
    //   names:
    //     Set of checkpoint names.
    //
    // 戻り値:
    //     The value of services.
    //
    // 例外:
    //   T:System.ArgumentNullException:
    //     services or names is null.
    public static IServiceCollection RegisterCheckpointNames(this IServiceCollection services, params string[] names)
    {
        string[] names2 = names;
        Microsoft.Shared.Diagnostics.Throw.IfNull(services, "services");
        Microsoft.Shared.Diagnostics.Throw.IfNull(names2, "names");
        CheckNames(names2);
        services.ConfigureOption(delegate (LatencyContextRegistrationOptions o)
        {
            o.AddCheckpointNames(names2);
        });
        return services;
    }

    //
    // 概要:
    //     Registers a set of measure names for a latency context.
    //
    // パラメーター:
    //   services:
    //     The dependency injection container to add the names to.
    //
    //   names:
    //     Set of measure names.
    //
    // 戻り値:
    //     The value of services.
    //
    // 例外:
    //   T:System.ArgumentNullException:
    //     services or names is null.
    public static IServiceCollection RegisterMeasureNames(this IServiceCollection services, params string[] names)
    {
        string[] names2 = names;
        Microsoft.Shared.Diagnostics.Throw.IfNull(services, "services");
        Microsoft.Shared.Diagnostics.Throw.IfNull(names2, "names");
        CheckNames(names2);
        services.ConfigureOption(delegate (LatencyContextRegistrationOptions o)
        {
            o.AddMeasureNames(names2);
        });
        return services;
    }

    //
    // 概要:
    //     Registers a set of tag names for a latency context.
    //
    // パラメーター:
    //   services:
    //     The dependency injection container to add the names to.
    //
    //   names:
    //     Set of tag names.
    //
    // 戻り値:
    //     The value of services.
    //
    // 例外:
    //   T:System.ArgumentNullException:
    //     services or names is null.
    public static IServiceCollection RegisterTagNames(this IServiceCollection services, params string[] names)
    {
        string[] names2 = names;
        Microsoft.Shared.Diagnostics.Throw.IfNull(services, "services");
        Microsoft.Shared.Diagnostics.Throw.IfNull(names2, "names");
        CheckNames(names2);
        services.ConfigureOption(delegate (LatencyContextRegistrationOptions o)
        {
            o.AddTagNames(names2);
        });
        return services;
    }

    private static void CheckNames(string[] names)
    {
        foreach (string value in names)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Microsoft.Shared.Diagnostics.Throw.ArgumentException("names", "Name is either null or whitespace");
            }
        }
    }

    private static void ConfigureOption(this IServiceCollection services, Action<LatencyContextRegistrationOptions> action)
    {
        services.AddOptionsWithValidateOnStart<LatencyContextRegistrationOptions, LatencyContextRegistrationOptionsValidator>();
        services.Configure(action);
    }
}
