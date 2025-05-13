using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Options.Contextual;
using Microsoft.Extensions.Options.Contextual.Internal;
using Microsoft.Extensions.Options.Contextual.Provider;
using Microsoft.Shared.Diagnostics;

namespace Microsoft.Extensions.DependencyInjection;

//
// 概要:
//     Extension methods for adding contextual options services to the DI container.
public static class ContextualOptionsServiceCollectionExtensions
{
    //
    // 概要:
    //     Adds services required for using contextual options.
    //
    // パラメーター:
    //   services:
    //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the services
    //     to.
    //
    // 戻り値:
    //     The value of services.
    public static IServiceCollection AddContextualOptions(this IServiceCollection services)
    {
        Throw.IfNull(services, "services").AddOptions();
        services.TryAdd(ServiceDescriptor.Singleton(typeof(IContextualOptionsFactory<>), typeof(ContextualOptionsFactory<>)));
        services.TryAdd(ServiceDescriptor.Singleton(typeof(IContextualOptions<,>), typeof(ContextualOptions<,>)));
        services.TryAdd(ServiceDescriptor.Singleton(typeof(INamedContextualOptions<,>), typeof(ContextualOptions<,>)));
        return services;
    }

    //
    // 概要:
    //     Registers an action used to configure a particular type of options.
    //
    // パラメーター:
    //   services:
    //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the services
    //     to.
    //
    //   loadOptions:
    //     The action used to configure the options.
    //
    // 型パラメーター:
    //   TOptions:
    //     The options type to be configured.
    //
    // 戻り値:
    //     The value of services.
    public static IServiceCollection Configure<TOptions>(this IServiceCollection services, Func<IOptionsContext, CancellationToken, ValueTask<IConfigureContextualOptions<TOptions>>> loadOptions) where TOptions : class
    {
        return services.Configure(Microsoft.Extensions.Options.Options.DefaultName, Throw.IfNull(loadOptions, "loadOptions"));
    }

    //
    // 概要:
    //     Registers an action used to configure a particular type of options.
    //
    // パラメーター:
    //   services:
    //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the services
    //     to.
    //
    //   name:
    //     The name of the options to configure.
    //
    //   loadOptions:
    //     The action used to configure the options.
    //
    // 型パラメーター:
    //   TOptions:
    //     The options type to be configured.
    //
    // 戻り値:
    //     The value of services.
    public static IServiceCollection Configure<TOptions>(this IServiceCollection services, string? name, Func<IOptionsContext, CancellationToken, ValueTask<IConfigureContextualOptions<TOptions>>> loadOptions) where TOptions : class
    {
        return services.AddContextualOptions().AddSingleton((ILoadContextualOptions<TOptions>)new LoadContextualOptions<TOptions>(name, Throw.IfNull(loadOptions, "loadOptions")));
    }

    //
    // 概要:
    //     Registers an action used to configure a particular type of options.
    //
    // パラメーター:
    //   services:
    //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the services
    //     to.
    //
    //   configure:
    //     The action used to configure the options.
    //
    // 型パラメーター:
    //   TOptions:
    //     The options type to be configured.
    //
    // 戻り値:
    //     The value of services.
    public static IServiceCollection Configure<TOptions>(this IServiceCollection services, Action<IOptionsContext, TOptions> configure) where TOptions : class
    {
        return services.Configure(Microsoft.Extensions.Options.Options.DefaultName, Throw.IfNull(configure, "configure"));
    }

    //
    // 概要:
    //     Registers an action used to configure a particular type of options.
    //
    // パラメーター:
    //   services:
    //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the services
    //     to.
    //
    //   name:
    //     The name of the options to configure.
    //
    //   configure:
    //     The action used to configure the options.
    //
    // 型パラメーター:
    //   TOptions:
    //     The options type to be configured.
    //
    // 戻り値:
    //     The value of services.
    public static IServiceCollection Configure<TOptions>(this IServiceCollection services, string? name, Action<IOptionsContext, TOptions> configure) where TOptions : class
    {
        Action<IOptionsContext, TOptions> configure2 = configure;
        return services.AddContextualOptions().AddSingleton((ILoadContextualOptions<TOptions>)new LoadContextualOptions<TOptions>(name, (IOptionsContext context, CancellationToken _) => new ValueTask<IConfigureContextualOptions<TOptions>>(new ConfigureContextualOptions<TOptions>(Throw.IfNull(configure2, "configure"), Throw.IfNull(context, "context")))));
    }

    //
    // 概要:
    //     Registers an action used to configure all instances of a particular type of options.
    //
    //
    // パラメーター:
    //   services:
    //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the services
    //     to.
    //
    //   loadOptions:
    //     The action used to configure the options.
    //
    // 型パラメーター:
    //   TOptions:
    //     The options type to be configured.
    //
    // 戻り値:
    //     The value of services.
    public static IServiceCollection ConfigureAll<TOptions>(this IServiceCollection services, Func<IOptionsContext, CancellationToken, ValueTask<IConfigureContextualOptions<TOptions>>> loadOptions) where TOptions : class
    {
        return services.Configure(null, Throw.IfNull(loadOptions, "loadOptions"));
    }

    //
    // 概要:
    //     Registers an action used to configure all instances of a particular type of options.
    //
    //
    // パラメーター:
    //   services:
    //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the services
    //     to.
    //
    //   configure:
    //     The action used to configure the options.
    //
    // 型パラメーター:
    //   TOptions:
    //     The options type to be configured.
    //
    // 戻り値:
    //     The value of services.
    public static IServiceCollection ConfigureAll<TOptions>(this IServiceCollection services, Action<IOptionsContext, TOptions> configure) where TOptions : class
    {
        return services.Configure(null, Throw.IfNull(configure, "configure"));
    }
}
