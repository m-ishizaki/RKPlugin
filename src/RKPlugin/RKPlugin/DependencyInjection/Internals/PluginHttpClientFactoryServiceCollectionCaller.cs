using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginHttpClientFactoryServiceCollectionCaller
{
    public static object? AddHttpClient<TClient, TImplementation>(object? services, Func<HttpClient, TImplementation> factory)
        where TClient : class where TImplementation : class, TClient
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethod("AddHttpClient", BindingFlags.NonPublic | BindingFlags.Instance);
        var method = methodInfo?.MakeGenericMethod(typeof(TClient), typeof(TImplementation));
        return method?.Invoke(services, [factory]);
    }
}

