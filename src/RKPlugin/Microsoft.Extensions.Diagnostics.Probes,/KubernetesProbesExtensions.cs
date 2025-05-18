#region アセンブリ Microsoft.Extensions.Diagnostics.Probes, Version=9.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Decompiled with ICSharpCode.Decompiler 8.2.0.7535
#endregion

using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Binder.SourceGeneration;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.Probes;
using Microsoft.Shared.Diagnostics;

namespace Microsoft.Extensions.DependencyInjection;

//
// 概要:
//     Extensions for setting up probes for Kubernetes.
public static class KubernetesProbesExtensions
{
    //
    // 概要:
    //     Registers liveness, startup and readiness probes using the default options.
    //
    // パラメーター:
    //   services:
    //     The dependency injection container to add the probe to.
    //
    // 戻り値:
    //     The value of services.
    public static IServiceCollection AddKubernetesProbes(this IServiceCollection services)
    {
        return services.AddKubernetesProbes(delegate
        {
        });
    }

    //
    // 概要:
    //     Registers liveness, startup and readiness probes using the configured options.
    //
    //
    // パラメーター:
    //   services:
    //     The dependency injection container to add the probe to.
    //
    //   section:
    //     Configuration for Microsoft.Extensions.Diagnostics.Probes.KubernetesProbesOptions.
    //
    //
    // 戻り値:
    //     The value of services.
    public static IServiceCollection AddKubernetesProbes(this IServiceCollection services, IConfigurationSection section)
    {
        IConfigurationSection section2 = section;
        Microsoft.Shared.Diagnostics.Throw.IfNull(services, "services");
        Microsoft.Shared.Diagnostics.Throw.IfNull(section2, "section");
        return services.AddKubernetesProbes(delegate (KubernetesProbesOptions o)
        {
            section2.Bind_KubernetesProbesOptions(o);
        });
    }

    //
    // 概要:
    //     Registers liveness, startup and readiness probes using the configured options.
    //
    //
    // パラメーター:
    //   services:
    //     The dependency injection container to add the probe to.
    //
    //   configure:
    //     Configure action for Microsoft.Extensions.Diagnostics.Probes.KubernetesProbesOptions.
    //
    //
    // 戻り値:
    //     The value of services.
    public static IServiceCollection AddKubernetesProbes(this IServiceCollection services, Action<KubernetesProbesOptions> configure)
    {
        Action<KubernetesProbesOptions> configure2 = configure;
        Microsoft.Shared.Diagnostics.Throw.IfNull(services, "services");
        Microsoft.Shared.Diagnostics.Throw.IfNull(configure2, "configure");
        services.AddOptionsWithValidateOnStart<KubernetesProbesOptions, KubernetesProbesOptionsValidator>().Configure(configure2);
        KubernetesProbesOptions wrapperOptions = new KubernetesProbesOptions();
        return services.AddTcpEndpointProbe("_probe_liveness", delegate (TcpEndpointProbesOptions options)
        {
            options.TcpPort = wrapperOptions.LivenessProbe.TcpPort;
            wrapperOptions.LivenessProbe = options;
            configure2(wrapperOptions);
            Func<HealthCheckRegistration, bool> originalPredicate3 = options.FilterChecks;
            if (originalPredicate3 == null)
            {
                options.FilterChecks = (HealthCheckRegistration check) => check.Tags.Contains("_probe_liveness");
            }
            else
            {
                options.FilterChecks = (HealthCheckRegistration check) => check.Tags.Contains("_probe_liveness") && originalPredicate3(check);
            }
        }).AddTcpEndpointProbe("_probe_startup", delegate (TcpEndpointProbesOptions options)
        {
            options.TcpPort = wrapperOptions.StartupProbe.TcpPort;
            wrapperOptions.StartupProbe = options;
            configure2(wrapperOptions);
            Func<HealthCheckRegistration, bool> originalPredicate2 = options.FilterChecks;
            if (originalPredicate2 == null)
            {
                options.FilterChecks = (HealthCheckRegistration check) => check.Tags.Contains("_probe_startup");
            }
            else
            {
                options.FilterChecks = (HealthCheckRegistration check) => check.Tags.Contains("_probe_startup") && originalPredicate2(check);
            }
        }).AddTcpEndpointProbe("_probe_readiness", delegate (TcpEndpointProbesOptions options)
        {
            options.TcpPort = wrapperOptions.ReadinessProbe.TcpPort;
            wrapperOptions.ReadinessProbe = options;
            configure2(wrapperOptions);
            Func<HealthCheckRegistration, bool> originalPredicate = options.FilterChecks;
            if (originalPredicate == null)
            {
                options.FilterChecks = (HealthCheckRegistration check) => check.Tags.Contains("_probe_readiness");
            }
            else
            {
                options.FilterChecks = (HealthCheckRegistration check) => check.Tags.Contains("_probe_readiness") && originalPredicate(check);
            }
        });
    }
}
