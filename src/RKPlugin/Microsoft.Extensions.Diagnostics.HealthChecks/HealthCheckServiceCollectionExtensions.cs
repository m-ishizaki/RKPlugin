#region アセンブリ Microsoft.Extensions.Diagnostics.HealthChecks, Version=10.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
#endregion

#nullable enable


namespace Microsoft.Extensions.DependencyInjection
{
    //
    // 概要:
    //     Provides extension methods for registering Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckService
    //     in an Microsoft.Extensions.DependencyInjection.IServiceCollection.
    public static class HealthCheckServiceCollectionExtensions
    {
        //
        // 概要:
        //     Adds the Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckService to
        //     the container, using the provided delegate to register health checks.
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckService
        //     to.
        //
        // 戻り値:
        //     An instance of Microsoft.Extensions.DependencyInjection.IHealthChecksBuilder
        //     from which health checks can be registered.
        //
        // 注釈:
        //     This operation is idempotent - multiple invocations will still only result in
        //     a single Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckService instance
        //     in the Microsoft.Extensions.DependencyInjection.IServiceCollection. It can be
        //     invoked multiple times in order to get access to the Microsoft.Extensions.DependencyInjection.IHealthChecksBuilder
        //     in multiple places.
        public static IHealthChecksBuilder AddHealthChecks(this IServiceCollection services);
    }
}