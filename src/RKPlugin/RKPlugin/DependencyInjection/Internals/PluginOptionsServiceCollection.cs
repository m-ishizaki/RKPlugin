using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginOptionsServiceCollection
{
    static readonly string BaseType = "Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions,Microsoft.Extensions.Options";

    public static object? AddOptions(this object? services) => null;

    public static object? AddOptions<TOptions>(this object? services) where TOptions : class => null;

    public static object? AddOptions<TOptions>(this object? services, string? name) where TOptions : class => null;

    public static object? AddOptionsWithValidateOnStart<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)] TOptions>(this object? services, string? name = null) where TOptions : class => null;

    public static object? AddOptionsWithValidateOnStart<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)] TOptions, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TValidateOptions>(this object? services, string? name = null) where TOptions : class where TValidateOptions : class => null;

    public static object? Configure<TOptions>(this object? services, Action<TOptions> configureOptions) where TOptions : class => null;

    public static object? Configure<TOptions>(this object? services, string? name, Action<TOptions> configureOptions) where TOptions : class => null;

    public static object? ConfigureAll<TOptions>(this object? services, Action<TOptions> configureOptions) where TOptions : class => null;

    public static object? ConfigureOptions<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TConfigureOptions>(this object? services) where TConfigureOptions : class => null;

    public static object? ConfigureOptions(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type configureType) => null;

    public static object? ConfigureOptions(this object? services, object configureInstance) => null;

    public static object? PostConfigure<TOptions>(this object? services, Action<TOptions> configureOptions) where TOptions : class => null;

    public static object? PostConfigure<TOptions>(this object? services, string? name, Action<TOptions> configureOptions) where TOptions : class => null;

    public static object? PostConfigureAll<TOptions>(this object? services, Action<TOptions> configureOptions) where TOptions : class => null;
}