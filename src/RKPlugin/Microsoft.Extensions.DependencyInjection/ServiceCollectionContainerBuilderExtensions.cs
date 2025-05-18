#region アセンブリ Microsoft.Extensions.DependencyInjection, Version=10.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
#endregion

#nullable enable


using System;

namespace Microsoft.Extensions.DependencyInjection
{
    //
    // 概要:
    //     Extension methods for building a Microsoft.Extensions.DependencyInjection.ServiceProvider
    //     from an Microsoft.Extensions.DependencyInjection.IServiceCollection.
    public static class ServiceCollectionContainerBuilderExtensions
    {
        //
        // 概要:
        //     Creates a Microsoft.Extensions.DependencyInjection.ServiceProvider containing
        //     services from the provided Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection containing service
        //     descriptors.
        //
        // 戻り値:
        //     The Microsoft.Extensions.DependencyInjection.ServiceProvider.
        public static ServiceProvider BuildServiceProvider(this IServiceCollection services);
        //
        // 概要:
        //     Creates a Microsoft.Extensions.DependencyInjection.ServiceProvider containing
        //     services from the provided Microsoft.Extensions.DependencyInjection.IServiceCollection
        //     optionally enabling scope validation.
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection containing service
        //     descriptors.
        //
        //   options:
        //     Configures various service provider behaviors.
        //
        // 戻り値:
        //     The Microsoft.Extensions.DependencyInjection.ServiceProvider.
        public static ServiceProvider BuildServiceProvider(this IServiceCollection services, ServiceProviderOptions options);
        //
        // 概要:
        //     Creates a Microsoft.Extensions.DependencyInjection.ServiceProvider containing
        //     services from the provided Microsoft.Extensions.DependencyInjection.IServiceCollection
        //     optionally enabling scope validation.
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection containing service
        //     descriptors.
        //
        //   validateScopes:
        //     true to perform check verifying that scoped services never gets resolved from
        //     root provider; otherwise false.
        //
        // 戻り値:
        //     The Microsoft.Extensions.DependencyInjection.ServiceProvider.
        public static ServiceProvider BuildServiceProvider(this IServiceCollection services, bool validateScopes);
    }
}