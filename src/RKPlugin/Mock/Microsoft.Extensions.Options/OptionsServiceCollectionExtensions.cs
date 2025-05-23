﻿using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Extensions.DependencyInjection;

public static class OptionsServiceCollectionExtensions
{
    public static List<string> Invoked = new List<string>();

    static object? Add(string name)
    {
        Invoked.Add(name);
        return null;
    }

    public static object? AddOptions(this object? services)
        => Add("public static object? AddOptions(this object? services)");

    public static object? AddOptions<TOptions>(this object? services) where TOptions : class
        => Add("public static object? AddOptions<TOptions>(this object? services) where TOptions : class");

    public static object? AddOptions<TOptions>(this object? services, string? name) where TOptions : class
        => Add("public static object? AddOptions<TOptions>(this object? services, string? name) where TOptions : class");

    public static object? AddOptionsWithValidateOnStart<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)] TOptions>(this object? services, string? name = null) where TOptions : class
        => Add("public static object? AddOptionsWithValidateOnStart<TOptions>(this IServiceCollection services, string? name = null) where TOptions : class");

    public static object? AddOptionsWithValidateOnStart<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)] TOptions, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TValidateOptions>(this object? services, string? name = null) where TOptions : class where TValidateOptions : class
        => Add("public static object? AddOptionsWithValidateOnStart<TOptions, TValidateOptions>(this IServiceCollection services, string? name = null) where TOptions : class where TValidateOptions : class, IValidateOptions<TOptions>");

    public static object? Configure<TOptions>(this object? services, Action<TOptions> configureOptions) where TOptions : class
        => Add("public static object? Configure<TOptions>(this object? services, Action<TOptions> configureOptions) where TOptions : class");

    public static object? Configure<TOptions>(this object? services, string? name, Action<TOptions> configureOptions) where TOptions : class
        => Add("public static object? Configure<TOptions>(this object? services, string? name, Action<TOptions> configureOptions) where TOptions : class");

    public static object? ConfigureAll<TOptions>(this object? services, Action<TOptions> configureOptions) where TOptions : class
        => Add("public static object? ConfigureAll<TOptions>(this object? services, Action<TOptions> configureOptions) where TOptions : class");

    public static object? ConfigureOptions<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TConfigureOptions>(this object? services) where TConfigureOptions : class
        => Add("public static object? ConfigureOptions<TConfigureOptions>(this object? services) where TConfigureOptions : class");

    public static object? ConfigureOptions(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type configureType)
        => Add("public static object? ConfigureOptions(this object? services, Type configureType)");

    public static object? ConfigureOptions(this object? services, object configureInstance)
        => Add("public static object? ConfigureOptions(this object? services, object configureInstance)");

    public static object? PostConfigure<TOptions>(this object? services, Action<TOptions> configureOptions) where TOptions : class
        => Add("public static object? PostConfigure<TOptions>(this object? services, Action<TOptions> configureOptions) where TOptions : class");

    public static object? PostConfigure<TOptions>(this object? services, string? name, Action<TOptions> configureOptions) where TOptions : class
        => Add("public static object? PostConfigure<TOptions>(this object? services, string? name, Action<TOptions> configureOptions) where TOptions : class");

    public static object? PostConfigureAll<TOptions>(this object? services, Action<TOptions> configureOptions) where TOptions : class
        => Add("public static object? PostConfigureAll<TOptions>(this object? services, Action<TOptions> configureOptions) where TOptions : class");
}