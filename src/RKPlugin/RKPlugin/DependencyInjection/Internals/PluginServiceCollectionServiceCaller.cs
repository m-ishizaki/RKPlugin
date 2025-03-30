using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginServiceCollectionServiceCaller
{
    public static object? AddScoped<TService>(object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethod("AddScoped", BindingFlags.NonPublic | BindingFlags.Instance);
        var method = methodInfo?.MakeGenericMethod(typeof(TService));
        return method?.Invoke(services, [implementationFactory]);
    }

}
