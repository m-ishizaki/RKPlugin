using System;
using System.Linq;
using System.Reflection;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginOptionsConfigurationServiceCollectionCaller
{
    public static object? Configure(this object? services, Type optionsType, object? config)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x =>
                x.Name == nameof(Configure)
                && x.GetGenericArguments().Length == 1
                && x.GetParameters().Length == 1
                && x.GetParameters()[0].ParameterType == config?.GetType()
            ).FirstOrDefault();

        if (methodInfo == null)
            return null;

        var genericMethod = methodInfo.MakeGenericMethod(optionsType);
        return genericMethod.Invoke(services, new object[] { config! });
    }

    public static object? Configure(this object? services, Type optionsType, string? name, object? config)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x =>
                x.Name == nameof(Configure)
                && x.GetGenericArguments().Length == 1
                && x.GetParameters().Length == 2
                && x.GetParameters()[0].ParameterType == typeof(string)
                && x.GetParameters()[1].ParameterType == config?.GetType()
            ).FirstOrDefault();

        if (methodInfo == null)
            return null;

        var genericMethod = methodInfo.MakeGenericMethod(optionsType);
        return genericMethod.Invoke(services, new object[] { name!, config! });
    }
}
