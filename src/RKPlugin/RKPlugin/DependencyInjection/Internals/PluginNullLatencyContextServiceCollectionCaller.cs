using System;
using System.Linq;
using System.Reflection;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginNullLatencyContextServiceCollectionCaller
{
    public static object? AddNullLatencyContext(this object? services)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x =>
                x.Name == nameof(AddNullLatencyContext)
                && x.GetGenericArguments().Length == 0
                && x.GetParameters().Length == 0
            ).FirstOrDefault();
        return methodInfo?.Invoke(services, Array.Empty<object>());
    }
}