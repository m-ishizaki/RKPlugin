using System;
using System.Collections.Generic;
using System.Reflection;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginServiceCollectionContainerBuilderCaller
{
    public static List<string> Invoked = new List<string>();

    static object? Add(string name)
    {
        Invoked.Add(name);
        return null;
    }

    public static object? BuildServiceProvider(this object? services)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethod(
            "BuildServiceProvider",
            BindingFlags.Public | BindingFlags.Instance,
            binder: null,
            types: Type.EmptyTypes,
            modifiers: null
        );
        return methodInfo?.Invoke(services, null);
    }

    public static object? BuildServiceProvider(this object? services, object? options)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethod(
            "BuildServiceProvider",
            BindingFlags.Public | BindingFlags.Instance,
            binder: null,
            types: new[] { options?.GetType() ?? typeof(object) },
            modifiers: null
        );
        return methodInfo?.Invoke(services, new[] { options });
    }

    public static object? BuildServiceProvider(this object? services, bool validateScopes)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethod(
            "BuildServiceProvider",
            BindingFlags.Public | BindingFlags.Instance,
            binder: null,
            types: new[] { typeof(bool) },
            modifiers: null
        );
        return methodInfo?.Invoke(services, new object[] { validateScopes });
    }
}
