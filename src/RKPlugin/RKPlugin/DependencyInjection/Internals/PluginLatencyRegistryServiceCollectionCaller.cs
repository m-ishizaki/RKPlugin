using System;
using System.Linq;
using System.Reflection;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginLatencyRegistryServiceCollectionCaller
{
    public static object? RegisterCheckpointNames(this object? services, params string[] names)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x =>
                x.Name == nameof(RegisterCheckpointNames)
                && x.GetGenericArguments().Length == 0
                && x.GetParameters().Length == 1
                && x.GetParameters()[0].ParameterType == typeof(string[])
            ).FirstOrDefault();
        return methodInfo?.Invoke(services, new object[] { names });
    }

    public static object? RegisterMeasureNames(this object? services, params string[] names)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x =>
                x.Name == nameof(RegisterMeasureNames)
                && x.GetGenericArguments().Length == 0
                && x.GetParameters().Length == 1
                && x.GetParameters()[0].ParameterType == typeof(string[])
            ).FirstOrDefault();
        return methodInfo?.Invoke(services, new object[] { names });
    }

    public static object? RegisterTagNames(this object? services, params string[] names)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x =>
                x.Name == nameof(RegisterTagNames)
                && x.GetGenericArguments().Length == 0
                && x.GetParameters().Length == 1
                && x.GetParameters()[0].ParameterType == typeof(string[])
            ).FirstOrDefault();
        return methodInfo?.Invoke(services, new object[] { names });
    }

    private static void ConfigureOption(this object? services, Action<object?> action)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x =>
                x.Name == nameof(ConfigureOption)
                && x.GetGenericArguments().Length == 0
                && x.GetParameters().Length == 1
                && x.GetParameters()[0].ParameterType == typeof(Action<object?>)
            ).FirstOrDefault();
        methodInfo?.Invoke(services, new object[] { action });
    }
}
