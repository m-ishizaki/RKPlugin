#region アセンブリ Microsoft.Extensions.Hosting.Abstractions, Version=10.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
#endregion

#nullable enable

using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Extensions.DependencyInjection
{
    //
    // 概要:
    //     Extension methods for adding hosted services to an Microsoft.Extensions.DependencyInjection.IServiceCollection.
    public static class ServiceCollectionHostedServiceExtensions
    {
        //
        // 概要:
        //     Add an Microsoft.Extensions.Hosting.IHostedService registration for the given
        //     type.
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to register with.
        //
        //
        // 型パラメーター:
        //   THostedService:
        //     An Microsoft.Extensions.Hosting.IHostedService to register.
        //
        // 戻り値:
        //     The original Microsoft.Extensions.DependencyInjection.IServiceCollection.
        public static IServiceCollection AddHostedService<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] THostedService>(this IServiceCollection services) where THostedService : class, IHostedService;
        //
        // 概要:
        //     Add an Microsoft.Extensions.Hosting.IHostedService registration for the given
        //     type.
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to register with.
        //
        //
        //   implementationFactory:
        //     A factory to create new instances of the service implementation.
        //
        // 型パラメーター:
        //   THostedService:
        //     An Microsoft.Extensions.Hosting.IHostedService to register.
        //
        // 戻り値:
        //     The original Microsoft.Extensions.DependencyInjection.IServiceCollection.
        public static IServiceCollection AddHostedService<THostedService>(this IServiceCollection services, Func<IServiceProvider, THostedService> implementationFactory) where THostedService : class, IHostedService;
    }
}