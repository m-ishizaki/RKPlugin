#region アセンブリ Microsoft.Extensions.Diagnostics.ResourceMonitoring, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Decompiled with ICSharpCode.Decompiler 8.2.0.7535
#endregion

using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Diagnostics.ResourceMonitoring;
using Microsoft.Extensions.Diagnostics.ResourceMonitoring.Linux;
using Microsoft.Extensions.Diagnostics.ResourceMonitoring.Windows;
using Microsoft.Extensions.Diagnostics.ResourceMonitoring.Windows.Interop;
using Microsoft.Extensions.Diagnostics.ResourceMonitoring.Windows.Network;
using Microsoft.Shared.Diagnostics;

namespace Microsoft.Extensions.DependencyInjection;

//
// 概要:
//     Lets you configure and register resource monitoring components.
public static class ResourceMonitoringServiceCollectionExtensions
{
    //
    // 概要:
    //     Configures and adds an Microsoft.Extensions.Diagnostics.ResourceMonitoring.IResourceMonitor
    //     implementation to a service collection.
    //
    // パラメーター:
    //   services:
    //     The dependency injection container to add the monitor to.
    //
    // 戻り値:
    //     The value of services.
    //
    // 例外:
    //   T:System.ArgumentNullException:
    //     services is null.
    public static IServiceCollection AddResourceMonitoring(this IServiceCollection services)
    {
        Microsoft.Shared.Diagnostics.Throw.IfNull(services, "services");
        return services.AddResourceMonitoringInternal(delegate
        {
        });
    }

    //
    // 概要:
    //     Configures and adds an Microsoft.Extensions.Diagnostics.ResourceMonitoring.IResourceMonitor
    //     implementation to a service collection.
    //
    // パラメーター:
    //   services:
    //     The dependency injection container to add the monitor to.
    //
    //   configure:
    //     Delegate to configure Microsoft.Extensions.Diagnostics.ResourceMonitoring.IResourceMonitorBuilder.
    //
    //
    // 戻り値:
    //     The value of services.
    //
    // 例外:
    //   T:System.ArgumentNullException:
    //     Either services or configure is null.
    public static IServiceCollection AddResourceMonitoring(this IServiceCollection services, Action<IResourceMonitorBuilder> configure)
    {
        Microsoft.Shared.Diagnostics.Throw.IfNull(services, "services");
        Microsoft.Shared.Diagnostics.Throw.IfNull(configure, "configure");
        return services.AddResourceMonitoringInternal(configure);
    }

    private static IServiceCollection AddResourceMonitoringInternal(this IServiceCollection services, Action<IResourceMonitorBuilder> configure)
    {
        ResourceMonitorBuilder resourceMonitorBuilder = new ResourceMonitorBuilder(services);
        services.AddMetrics();
        if (GetPlatform() == PlatformID.Win32NT)
        {
            resourceMonitorBuilder.AddWindowsProvider();
        }
        else
        {
            resourceMonitorBuilder.AddLinuxProvider();
        }

        configure(resourceMonitorBuilder);
        return services;
    }

    [ExcludeFromCodeCoverage]
    private static PlatformID GetPlatform()
    {
        OperatingSystem oSVersion = Environment.OSVersion;
        if (oSVersion.Platform != PlatformID.Win32NT && oSVersion.Platform != PlatformID.Unix)
        {
            throw new NotSupportedException("Resource monitoring is not supported on this operating system.");
        }

        return oSVersion.Platform;
    }

    private static ResourceMonitorBuilder AddWindowsProvider(this ResourceMonitorBuilder builder)
    {
        builder.PickWindowsSnapshotProvider();
        builder.Services.AddActivatedSingleton<WindowsCounters>();
        builder.Services.AddActivatedSingleton<TcpTableInfo>();
        return builder;
    }

    [ExcludeFromCodeCoverage]
    private static void PickWindowsSnapshotProvider(this ResourceMonitorBuilder builder)
    {
        if (JobObjectInfo.SafeJobHandle.IsProcessInJob())
        {
            builder.Services.TryAddSingleton<ISnapshotProvider, WindowsContainerSnapshotProvider>();
        }
        else
        {
            builder.Services.TryAddSingleton<ISnapshotProvider, WindowsSnapshotProvider>();
        }
    }

    private static IResourceMonitorBuilder AddLinuxProvider(this IResourceMonitorBuilder builder)
    {
        Microsoft.Shared.Diagnostics.Throw.IfNull(builder, "builder");
        builder.Services.TryAddActivatedSingleton<ISnapshotProvider, LinuxUtilizationProvider>();
        builder.Services.TryAddSingleton<IFileSystem, OSFileSystem>();
        builder.Services.TryAddSingleton<IUserHz, UserHz>();
        builder.Services.TryAddSingleton<LinuxUtilizationParser>();
        return builder;
    }
}
