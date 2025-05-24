using System;
using System.Linq;
using System.Reflection;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginAsyncStateCaller
{
    public static object? AddAsyncState(this object? services)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(x =>
                x.Name == nameof(AddAsyncState)
                && x.GetGenericArguments().Length == 0
                && x.GetParameters().Length == 0
            );
        return methodInfo?.Invoke(services, Array.Empty<object>());
    }
}
