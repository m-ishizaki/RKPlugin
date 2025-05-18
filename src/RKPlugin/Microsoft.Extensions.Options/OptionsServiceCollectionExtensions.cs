#region アセンブリ Microsoft.Extensions.Options, Version=10.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
#endregion

#nullable enable

using Microsoft.Extensions.Options;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Extensions.DependencyInjection
{
    //
    // 概要:
    //     Extension methods for adding options services to the DI container.
    public static class OptionsServiceCollectionExtensions
    {
        //
        // 概要:
        //     Adds services required for using options.
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the services
        //     to.
        //
        // 戻り値:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection so that additional
        //     calls can be chained.
        public static IServiceCollection AddOptions(this IServiceCollection services);
        //
        // 概要:
        //     Gets an options builder that forwards Configure calls for the same TOptions to
        //     the underlying service collection.
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the services
        //     to.
        //
        // 型パラメーター:
        //   TOptions:
        //     The options type to be configured.
        //
        // 戻り値:
        //     The Microsoft.Extensions.Options.OptionsBuilder`1 so that configure calls can
        //     be chained in it.
        public static OptionsBuilder<TOptions> AddOptions<TOptions>(this IServiceCollection services) where TOptions : class;
        //
        // 概要:
        //     Gets an options builder that forwards Configure calls for the same named TOptions
        //     to the underlying service collection.
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the services
        //     to.
        //
        //   name:
        //     The name of the options instance.
        //
        // 型パラメーター:
        //   TOptions:
        //     The options type to be configured.
        //
        // 戻り値:
        //     The Microsoft.Extensions.Options.OptionsBuilder`1 so that configure calls can
        //     be chained in it.
        public static OptionsBuilder<TOptions> AddOptions<TOptions>(this IServiceCollection services, string? name) where TOptions : class;
        //
        // 概要:
        //     Adds services required for using options and enforces options validation check
        //     on start rather than at run time.
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the services
        //     to.
        //
        //   name:
        //     The name of the options instance.
        //
        // 型パラメーター:
        //   TOptions:
        //     The options type to be configured.
        //
        // 戻り値:
        //     The Microsoft.Extensions.Options.OptionsBuilder`1 so that configure calls can
        //     be chained in it.
        //
        // 注釈:
        //     The Microsoft.Extensions.DependencyInjection.OptionsBuilderExtensions.ValidateOnStart``1(Microsoft.Extensions.Options.OptionsBuilder{``0})
        //     extension is called by this method.
        public static OptionsBuilder<TOptions> AddOptionsWithValidateOnStart<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)] TOptions>(this IServiceCollection services, string? name = null) where TOptions : class;
        //
        // 概要:
        //     Adds services required for using options and enforces options validation check
        //     on start rather than at run time.
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the services
        //     to.
        //
        //   name:
        //     The name of the options instance.
        //
        // 型パラメーター:
        //   TOptions:
        //     The options type to be configured.
        //
        //   TValidateOptions:
        //     The Microsoft.Extensions.Options.IValidateOptions`1 validator type.
        //
        // 戻り値:
        //     The Microsoft.Extensions.Options.OptionsBuilder`1 so that configure calls can
        //     be chained in it.
        //
        // 注釈:
        //     The Microsoft.Extensions.DependencyInjection.OptionsBuilderExtensions.ValidateOnStart``1(Microsoft.Extensions.Options.OptionsBuilder{``0})
        //     extension is called by this method.
        public static OptionsBuilder<TOptions> AddOptionsWithValidateOnStart<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)] TOptions, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TValidateOptions>(this IServiceCollection services, string? name = null)
            where TOptions : class
            where TValidateOptions : class, IValidateOptions<TOptions>;
        //
        // 概要:
        //     Registers an action used to configure a particular type of options. Note: These
        //     are run before all Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions.PostConfigure``1(Microsoft.Extensions.DependencyInjection.IServiceCollection,System.Action{``0}).
        //
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the services
        //     to.
        //
        //   configureOptions:
        //     The action used to configure the options.
        //
        // 型パラメーター:
        //   TOptions:
        //     The options type to be configured.
        //
        // 戻り値:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection so that additional
        //     calls can be chained.
        public static IServiceCollection Configure<TOptions>(this IServiceCollection services, Action<TOptions> configureOptions) where TOptions : class;
        //
        // 概要:
        //     Registers an action used to configure a particular type of options. Note: These
        //     are run before all Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions.PostConfigure``1(Microsoft.Extensions.DependencyInjection.IServiceCollection,System.Action{``0}).
        //
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the services
        //     to.
        //
        //   name:
        //     The name of the options instance.
        //
        //   configureOptions:
        //     The action used to configure the options.
        //
        // 型パラメーター:
        //   TOptions:
        //     The options type to be configured.
        //
        // 戻り値:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection so that additional
        //     calls can be chained.
        public static IServiceCollection Configure<TOptions>(this IServiceCollection services, string? name, Action<TOptions> configureOptions) where TOptions : class;
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
        //   configureOptions:
        //     The action used to configure the options.
        //
        // 型パラメーター:
        //   TOptions:
        //     The options type to be configured.
        //
        // 戻り値:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection so that additional
        //     calls can be chained.
        public static IServiceCollection ConfigureAll<TOptions>(this IServiceCollection services, Action<TOptions> configureOptions) where TOptions : class;
        //
        // 概要:
        //     Registers a type that will have all of its Microsoft.Extensions.Options.IConfigureOptions`1,
        //     Microsoft.Extensions.Options.IPostConfigureOptions`1, and Microsoft.Extensions.Options.IValidateOptions`1
        //     registered.
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the services
        //     to.
        //
        // 型パラメーター:
        //   TConfigureOptions:
        //     The type that will configure options.
        //
        // 戻り値:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection so that additional
        //     calls can be chained.
        public static IServiceCollection ConfigureOptions<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TConfigureOptions>(this IServiceCollection services) where TConfigureOptions : class;
        //
        // 概要:
        //     Registers a type that will have all of its Microsoft.Extensions.Options.IConfigureOptions`1,
        //     Microsoft.Extensions.Options.IPostConfigureOptions`1, and Microsoft.Extensions.Options.IValidateOptions`1
        //     registered.
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the services
        //     to.
        //
        //   configureType:
        //     The type that will configure options.
        //
        // 戻り値:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection so that additional
        //     calls can be chained.
        public static IServiceCollection ConfigureOptions(this IServiceCollection services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type configureType);
        //
        // 概要:
        //     Registers an object that will have all of its Microsoft.Extensions.Options.IConfigureOptions`1,
        //     Microsoft.Extensions.Options.IPostConfigureOptions`1, and Microsoft.Extensions.Options.IValidateOptions`1
        //     registered.
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the services
        //     to.
        //
        //   configureInstance:
        //     The instance that will configure options.
        //
        // 戻り値:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection so that additional
        //     calls can be chained.
        public static IServiceCollection ConfigureOptions(this IServiceCollection services, object configureInstance);
        //
        // 概要:
        //     Registers an action used to initialize a particular type of options. Note: These
        //     are run after all Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions.Configure``1(Microsoft.Extensions.DependencyInjection.IServiceCollection,System.Action{``0}).
        //
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the services
        //     to.
        //
        //   configureOptions:
        //     The action used to configure the options.
        //
        // 型パラメーター:
        //   TOptions:
        //     The options type to be configured.
        //
        // 戻り値:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection so that additional
        //     calls can be chained.
        public static IServiceCollection PostConfigure<TOptions>(this IServiceCollection services, Action<TOptions> configureOptions) where TOptions : class;
        //
        // 概要:
        //     Registers an action used to configure a particular type of options. Note: These
        //     are run after all Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions.Configure``1(Microsoft.Extensions.DependencyInjection.IServiceCollection,System.Action{``0}).
        //
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the services
        //     to.
        //
        //   name:
        //     The name of the options instance.
        //
        //   configureOptions:
        //     The action used to configure the options.
        //
        // 型パラメーター:
        //   TOptions:
        //     The options type to be configure.
        //
        // 戻り値:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection so that additional
        //     calls can be chained.
        public static IServiceCollection PostConfigure<TOptions>(this IServiceCollection services, string? name, Action<TOptions> configureOptions) where TOptions : class;
        //
        // 概要:
        //     Registers an action used to post configure all instances of a particular type
        //     of options. Note: These are run after all Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions.Configure``1(Microsoft.Extensions.DependencyInjection.IServiceCollection,System.Action{``0}).
        //
        //
        // パラメーター:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the services
        //     to.
        //
        //   configureOptions:
        //     The action used to configure the options.
        //
        // 型パラメーター:
        //   TOptions:
        //     The options type to be configured.
        //
        // 戻り値:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection so that additional
        //     calls can be chained.
        public static IServiceCollection PostConfigureAll<TOptions>(this IServiceCollection services, Action<TOptions> configureOptions) where TOptions : class;
    }
}