using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginOptionsConfigurationServiceCollectionCaller
{
    public static object? Configure<[DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] TOptions>(this object? services, object? config) where TOptions : class => null;

    public static object? Configure<[DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] TOptions>(this object? services, string? name, object? config) where TOptions : class => null;

    public static object? Configure<[DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] TOptions>(this object? services, object? config, Action<object?>? configureBinder) where TOptions : class => null;

    public static object? Configure<[DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] TOptions>(this object? services, string? name, object? config, Action<object?>? configureBinder) where TOptions : class => null;

}
