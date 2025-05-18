#region アセンブリ Microsoft.Extensions.Diagnostics.Probes, Version=9.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Decompiled with ICSharpCode.Decompiler 8.2.0.7535
#endregion

using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Binder.SourceGeneration;
using Microsoft.Extensions.Diagnostics.Probes;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.Shared.Diagnostics;

namespace Microsoft.Extensions.DependencyInjection;

//
// 概要:
//     Extension methods for setting up TCP-based health check probes.
public static class TcpEndpointProbesExtensions
{
    //
    // 概要:
    //     Registers health status reporting using a TCP port if service is considered as
    //     healthy Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheck.
    //
    // パラメーター:
    //   services:
    //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the services
    //     to.
    //
    // 戻り値:
    //     The value of services.
    public static IServiceCollection AddTcpEndpointProbe(this IServiceCollection services)
    {
        Microsoft.Shared.Diagnostics.Throw.IfNull(services, "services");
        return services.AddTcpEndpointProbe(Microsoft.Extensions.Options.Options.DefaultName);
    }

    //
    // 概要:
    //     Registers health status reporting using a TCP port if service is considered as
    //     healthy Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheck.
    //
    // パラメーター:
    //   services:
    //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the services
    //     to.
    //
    //   name:
    //     Name used to retrieve the options.
    //
    // 戻り値:
    //     The value of services.
    public static IServiceCollection AddTcpEndpointProbe(this IServiceCollection services, string name)
    {
        string name2 = name;
        Microsoft.Shared.Diagnostics.Throw.IfNull(services, "services");
        services.AddHealthChecks();
        services.AddOptionsWithValidateOnStart<TcpEndpointProbesOptions, TcpEndpointProbesOptionsValidator>(name2);
        services.AddSingleton((Func<IServiceProvider, IHostedService>)delegate (IServiceProvider provider)
        {
            TcpEndpointProbesOptions tcpEndpointProbesOptions = provider.GetRequiredService<IOptionsMonitor<TcpEndpointProbesOptions>>().Get(name2);
            return ActivatorUtilities.CreateInstance<TcpEndpointProbesService>(provider, new object[1] { tcpEndpointProbesOptions });
        });
        return services;
    }

    //
    // 概要:
    //     Registers health status reporting using a TCP port if service is considered as
    //     healthy Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheck.
    //
    // パラメーター:
    //   services:
    //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the services
    //     to.
    //
    //   configure:
    //     Configuration for Microsoft.Extensions.Diagnostics.Probes.TcpEndpointProbesOptions.
    //
    //
    // 戻り値:
    //     The value of services.
    public static IServiceCollection AddTcpEndpointProbe(this IServiceCollection services, Action<TcpEndpointProbesOptions> configure)
    {
        Microsoft.Shared.Diagnostics.Throw.IfNull(services, "services");
        Microsoft.Shared.Diagnostics.Throw.IfNull(configure, "configure");
        services.Configure(configure);
        return services.AddTcpEndpointProbe();
    }

    //
    // 概要:
    //     Registers health status reporting using a TCP port if service is considered as
    //     healthy Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheck.
    //
    // パラメーター:
    //   services:
    //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the services
    //     to.
    //
    //   name:
    //     Name for the options.
    //
    //   configure:
    //     Configuration for Microsoft.Extensions.Diagnostics.Probes.TcpEndpointProbesOptions.
    //
    //
    // 戻り値:
    //     The value of services.
    public static IServiceCollection AddTcpEndpointProbe(this IServiceCollection services, string name, Action<TcpEndpointProbesOptions> configure)
    {
        Microsoft.Shared.Diagnostics.Throw.IfNull(services, "services");
        Microsoft.Shared.Diagnostics.Throw.IfNull(configure, "configure");
        services.Configure(name, configure);
        return services.AddTcpEndpointProbe(name);
    }

    //
    // 概要:
    //     Registers health status reporting using a TCP port if service is considered as
    //     healthy Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheck.
    //
    // パラメーター:
    //   services:
    //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the services
    //     to.
    //
    //   configurationSection:
    //     Configuration for Microsoft.Extensions.Diagnostics.Probes.TcpEndpointProbesOptions.
    //
    //
    // 戻り値:
    //     The value of services.
    public static IServiceCollection AddTcpEndpointProbe(this IServiceCollection services, IConfigurationSection configurationSection)
    {
        Microsoft.Shared.Diagnostics.Throw.IfNull(services, "services");
        Microsoft.Shared.Diagnostics.Throw.IfNull(configurationSection, "configurationSection");
        _003CBindingExtensions_g_003EF2839C051B02FCCDEB7AFFC44488201FA646A45270E7DEFFEEF2D2A2DC748F606__BindingExtensions.Configure<TcpEndpointProbesOptions>(services, configurationSection);
        return services.AddTcpEndpointProbe();
    }

    //
    // 概要:
    //     Registers health status reporting using a TCP port if service is considered as
    //     healthy Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheck.
    //
    // パラメーター:
    //   services:
    //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the services
    //     to.
    //
    //   name:
    //     Name for the options.
    //
    //   configurationSection:
    //     Configuration for Microsoft.Extensions.Diagnostics.Probes.TcpEndpointProbesOptions.
    //
    //
    // 戻り値:
    //     The value of services.
    public static IServiceCollection AddTcpEndpointProbe(this IServiceCollection services, string name, IConfigurationSection configurationSection)
    {
        Microsoft.Shared.Diagnostics.Throw.IfNull(services, "services");
        Microsoft.Shared.Diagnostics.Throw.IfNull(configurationSection, "configurationSection");
        _003CBindingExtensions_g_003EF2839C051B02FCCDEB7AFFC44488201FA646A45270E7DEFFEEF2D2A2DC748F606__BindingExtensions.Configure<TcpEndpointProbesOptions>(services, name, configurationSection);
        return services.AddTcpEndpointProbe(name);
    }
}
