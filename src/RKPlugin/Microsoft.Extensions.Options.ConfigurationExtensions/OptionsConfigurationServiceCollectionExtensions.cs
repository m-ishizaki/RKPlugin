#region アセンブリ Microsoft.Extensions.Options.ConfigurationExtensions, Version=10.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
#endregion

#nullable enable

using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Extensions.DependencyInjection
{
    //
    // 概要:
    //     Extension methods for adding configuration-related options services to the DI
    //     container.
    public static class OptionsConfigurationServiceCollectionExtensions
    {
        //
        // 概要:
        //     Registers a configuration instance that TOptions will bind against.
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the services
        //     to.
        //
        //   config:
        //     The configuration being bound.
        //
        // 型パラメーター:
        //   TOptions:
        //     The type of options being configured.
        //
        // 戻り値:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection so that additional
        //     calls can be chained.
        [RequiresDynamicCode("Binding strongly typed objects to configuration values may require generating dynamic code at runtime.")]
        [RequiresUnreferencedCode("TOptions's dependent types may have their members trimmed. Ensure all required members are preserved.")]
        public static IServiceCollection Configure<[DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] TOptions>(this IServiceCollection services, IConfiguration config) where TOptions : class;
        //
        // 概要:
        //     Registers a configuration instance that TOptions will bind against.
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the services
        //     to.
        //
        //   name:
        //     The name of the options instance.
        //
        //   config:
        //     The configuration being bound.
        //
        // 型パラメーター:
        //   TOptions:
        //     The type of options being configured.
        //
        // 戻り値:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection so that additional
        //     calls can be chained.
        [RequiresDynamicCode("Binding strongly typed objects to configuration values may require generating dynamic code at runtime.")]
        [RequiresUnreferencedCode("TOptions's dependent types may have their members trimmed. Ensure all required members are preserved.")]
        public static IServiceCollection Configure<[DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] TOptions>(this IServiceCollection services, string? name, IConfiguration config) where TOptions : class;
        //
        // 概要:
        //     Registers a configuration instance that TOptions will bind against.
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the services
        //     to.
        //
        //   config:
        //     The configuration being bound.
        //
        //   configureBinder:
        //     Used to configure the Microsoft.Extensions.Configuration.BinderOptions.
        //
        // 型パラメーター:
        //   TOptions:
        //     The type of options being configured.
        //
        // 戻り値:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection so that additional
        //     calls can be chained.
        [RequiresDynamicCode("Binding strongly typed objects to configuration values may require generating dynamic code at runtime.")]
        [RequiresUnreferencedCode("TOptions's dependent types may have their members trimmed. Ensure all required members are preserved.")]
        public static IServiceCollection Configure<[DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] TOptions>(this IServiceCollection services, IConfiguration config, Action<BinderOptions>? configureBinder) where TOptions : class;
        //
        // 概要:
        //     Registers a configuration instance that TOptions will bind against.
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the services
        //     to.
        //
        //   name:
        //     The name of the options instance.
        //
        //   config:
        //     The configuration being bound.
        //
        //   configureBinder:
        //     Used to configure the Microsoft.Extensions.Configuration.BinderOptions.
        //
        // 型パラメーター:
        //   TOptions:
        //     The type of options being configured.
        //
        // 戻り値:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection so that additional
        //     calls can be chained.
        [RequiresDynamicCode("Binding strongly typed objects to configuration values may require generating dynamic code at runtime.")]
        [RequiresUnreferencedCode("TOptions's dependent types may have their members trimmed. Ensure all required members are preserved.")]
        public static IServiceCollection Configure<[DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] TOptions>(this IServiceCollection services, string? name, IConfiguration config, Action<BinderOptions>? configureBinder) where TOptions : class;
    }
}