#region アセンブリ Microsoft.Extensions.Hosting.Systemd, Version=10.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
#endregion

#nullable enable

using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.Hosting
{
    //
    // 概要:
    //     Extension methods for setting up Microsoft.Extensions.Hosting.Systemd.SystemdLifetime.
    public static class SystemdHostBuilderExtensions
    {
        //
        // 概要:
        //     Configures the lifetime of the Microsoft.Extensions.Hosting.IHost built from
        //     services to Microsoft.Extensions.Hosting.Systemd.SystemdLifetime, provides notification
        //     messages for application started and stopping, and configures console logging
        //     to the systemd format.
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
        //     as a systemd Service.
        //
        //     The systemd service file must be configured with Type=notify to enable notifications.
        //     See https://www.freedesktop.org/software/systemd/man/systemd.service.html.
        public static IServiceCollection AddSystemd(this IServiceCollection services);
        //
        // 概要:
        //     Configures the Microsoft.Extensions.Hosting.IHost lifetime to Microsoft.Extensions.Hosting.Systemd.SystemdLifetime,
        //     provides notification messages for application started and stopping, and configures
        //     console logging to the systemd format.
        //
        // パラメーター:
        //   hostBuilder:
        //     The Microsoft.Extensions.Hosting.IHostBuilder to configure.
        //
        // 戻り値:
        //     The hostBuilder instance for chaining.
        //
        // 注釈:
        //     This is context aware and will only activate if it detects the process is running
        //     as a systemd Service.
        //
        //     The systemd service file must be configured with Type=notify to enable notifications.
        //     See https://www.freedesktop.org/software/systemd/man/systemd.service.html.
        public static IHostBuilder UseSystemd(this IHostBuilder hostBuilder);
    }
}