using System;
using System.Linq;
using System.Reflection;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginObjectPoolServiceCollectionCaller
{
    public static object? AddPooled(this object? services, Type serviceType, Action<object?>? configure = null)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x =>
                x.Name == nameof(AddPooled)
                && x.GetGenericArguments().Length == 1
                && (configure == null
                    ? x.GetParameters().Length == 0
                    : x.GetParameters().Length == 1 && x.GetParameters()[0].ParameterType == typeof(Action<object?>))
            ).FirstOrDefault();

        if (methodInfo == null)
            return null;

        var genericMethod = methodInfo.MakeGenericMethod(serviceType);
        return configure == null
            ? genericMethod.Invoke(services, null)
            : genericMethod.Invoke(services, new object[] { configure });
    }

    public static object? ConfigurePool(this object? services, Type serviceType, Action<object?> configure)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x =>
                x.Name == nameof(ConfigurePool)
                && x.GetGenericArguments().Length == 1
                && x.GetParameters().Length == 1
                && x.GetParameters()[0].ParameterType == typeof(Action<object?>)
            ).FirstOrDefault();

        if (methodInfo == null)
            return null;

        var genericMethod = methodInfo.MakeGenericMethod(serviceType);
        return genericMethod.Invoke(services, new object[] { configure });
    }

    public static object? ConfigurePools(this object? services, object? section)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x =>
                x.Name == nameof(ConfigurePools)
                && x.GetGenericArguments().Length == 0
                && x.GetParameters().Length == 1
                && x.GetParameters()[0].ParameterType == section?.GetType()
            ).FirstOrDefault();

        return methodInfo?.Invoke(services, new object[] { section! });
    }
}
