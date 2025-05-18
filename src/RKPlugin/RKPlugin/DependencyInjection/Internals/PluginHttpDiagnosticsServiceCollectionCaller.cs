using System;
using System.Linq;
using System.Reflection;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginHttpDiagnosticsServiceCollectionCaller
{
    public static object? AddDownstreamDependencyMetadata(this object? services, object? downstreamDependencyMetadata)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x =>
                x.Name == nameof(AddDownstreamDependencyMetadata)
                && x.GetGenericArguments().Length == 0
                && x.GetParameters().Length == 1
                && x.GetParameters()[0].Name == nameof(downstreamDependencyMetadata)
            ).FirstOrDefault();
        return methodInfo?.Invoke(services, new object[] { downstreamDependencyMetadata });
    }

    public static object? AddDownstreamDependencyMetadata<T>(this object? services) where T : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x =>
                x.Name == nameof(AddDownstreamDependencyMetadata)
                && x.GetGenericArguments().Length == 1
                && x.GetParameters().Length == 0
            ).FirstOrDefault();
        if (methodInfo == null)
            return null;
        var genericMethod = methodInfo.MakeGenericMethod(typeof(T));
        return genericMethod.Invoke(services, null);