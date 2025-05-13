
using Microsoft.Extensions.AsyncState;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Shared.Diagnostics;

namespace Microsoft.Extensions.DependencyInjection;

//
// 概要:
//     Extensions to manipulate async state.
public static class AsyncStateExtensions
{
    //
    // 概要:
    //     Adds default implementations for Microsoft.Extensions.AsyncState.IAsyncState,
    //     Microsoft.Extensions.AsyncState.IAsyncContext`1, and Microsoft.Extensions.AsyncState.IAsyncLocalContext`1
    //     services. Please note that implementations of these interfaces are not thread
    //     safe.
    //
    // パラメーター:
    //   services:
    //     The dependency injection container to add the implementations to.
    //
    // 戻り値:
    //     The value of services.
    //
    // 例外:
    //   T:System.ArgumentNullException:
    //     services is null.
    public static IServiceCollection AddAsyncState(this IServiceCollection services)
    {
        Microsoft.Shared.Diagnostics.Throw.IfNull(services, "services");
        services.TryAddSingleton(typeof(IAsyncContext<>), typeof(AsyncContext<>));
        services.TryAddActivatedSingleton<IAsyncState, Microsoft.Extensions.AsyncState.AsyncState>();
        services.TryAddSingleton(typeof(IAsyncLocalContext<>), typeof(AsyncContext<>));
        return services;
    }
}
