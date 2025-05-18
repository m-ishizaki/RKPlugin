using System;
using System.Linq;
using System.Reflection;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginApplicationMetadataServiceCollectionCaller
{
    public static object? AddApplicationMetadata(this object? services, object? section)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddApplicationMetadata)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(section)
            && x.GetParameters()[0].ParameterType.GenericTypeArguments.Length == 0
        ).FirstOrDefault();
        var method = methodInfo;
        return method?.Invoke(services, new[] { section });
    }

    public static object? AddApplicationMetadata(this object? services, Action<object?> configure)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddApplicationMetadata)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(configure)
            && x.GetParameters()[0].ParameterType.GenericTypeArguments.Length == 1
        ).FirstOrDefault();
        var method = methodInfo;
        return method?.Invoke(services, new object[] { configure });
    }
}