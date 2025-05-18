#region アセンブリ Microsoft.Extensions.Hosting.WindowsServices, Version=10.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
#endregion

#nullable enable

using Microsoft.Extensions.DependencyInjection;
using System;

namespace Microsoft.Extensions.Hosting
{
    //
    // 概要:
    //     Extension methods for setting up WindowsServiceLifetime.
    public static class WindowsServiceLifetimeHostBuilderExtensions
    {
        //
        // 概要:
        //     Configures the lifetime of the Microsoft.Extensions.Hosting.IHost built from
        //     services to Microsoft.Extensions.Hosting.WindowsServices.WindowsServiceLifetime
        //     and enables logging to the event log with the application name as the default
        //     source name.
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection used to build
        //     the Microsoft.Extensions.Hosting.IHost. For example, Microsoft.Extensions.Hosting.HostApplicationBuilder.Services
        //     or the Microsoft.Extensions.DependencyInjection.IServiceCollection passed to
        //     the Microsoft.Extensions.Hosting.IHostBuilder.ConfigureServices(System.Action{Microsoft.Extensions.Hosting.HostBuilderContext,Microsoft.Extensions.DependencyInjection.IServiceCollection})
        //     callback.
        //
        // 戻り値:
        //     The services instance for chaining.
        //
        // 注釈:
        //     This is context aware and will only activate if it detects the process is running
        //     as a Windows Service.
        public static IServiceCollection AddWindowsService(this IServiceCollection services);
        //
        // 概要:
        //     Configures the lifetime of the Microsoft.Extensions.Hosting.IHost built from
        //     services to Microsoft.Extensions.Hosting.WindowsServices.WindowsServiceLifetime
        //     and enables logging to the event log with the application name as the default
        //     source name.
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection used to build
        //     the Microsoft.Extensions.Hosting.IHost. For example, Microsoft.Extensions.Hosting.HostApplicationBuilder.Services
        //     or the Microsoft.Extensions.DependencyInjection.IServiceCollection passed to
        //     the Microsoft.Extensions.Hosting.IHostBuilder.ConfigureServices(System.Action{Microsoft.Extensions.Hosting.HostBuilderContext,Microsoft.Extensions.DependencyInjection.IServiceCollection})
        //     callback.
        //
        //   configure:
        //     An System.Action`1 to configure the provided Microsoft.Extensions.Hosting.WindowsServiceLifetimeOptions.
        //
        //
        // 戻り値:
        //     The services instance for chaining.
        //
        // 注釈:
        //     This is context aware and will only activate if it detects the process is running
        //     as a Windows Service.
        public static IServiceCollection AddWindowsService(this IServiceCollection services, Action<WindowsServiceLifetimeOptions> configure);
        //
        // 概要:
        //     Sets the host lifetime to Microsoft.Extensions.Hosting.WindowsServices.WindowsServiceLifetime
        //     and enables logging to the event log with the application name as the default
        //     source name.
        //
        // パラメーター:
        //   hostBuilder:
        //     The Microsoft.Extensions.Hosting.IHostBuilder to operate on.
        //
        // 戻り値:
        //     The hostBuilder instance for chaining.
        //
        // 注釈:
        //     This is context aware and will only activate if it detects the process is running
        //     as a Windows Service.
        public static IHostBuilder UseWindowsService(this IHostBuilder hostBuilder);
        //
        // 概要:
        //     Sets the host lifetime to Microsoft.Extensions.Hosting.WindowsServices.WindowsServiceLifetime
        //     and enables logging to the event log with the application name as the default
        //     source name.
        //
        // パラメーター:
        //   hostBuilder:
        //     The Microsoft.Extensions.Hosting.IHostBuilder to operate on.
        //
        //   configure:
        //     An System.Action`1 to configure the provided Microsoft.Extensions.Hosting.WindowsServiceLifetimeOptions.
        //
        //
        // 戻り値:
        //     The hostBuilder instance for chaining.
        //
        // 注釈:
        //     This is context aware and will only activate if it detects the process is running
        //     as a Windows Service.
        public static IHostBuilder UseWindowsService(this IHostBuilder hostBuilder, Action<WindowsServiceLifetimeOptions> configure);
    }
}