using System;
using System.Collections.Generic;
using System.Text;

namespace RkSoftware.RKPlugin.DependencyInjection;

public static class PluginHttpClientFactoryServiceCollection
{
    static Type Init() => typeof(Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionDescriptorExtensions);

    public static object? AddHttpClient<TClient, TImplementation>(object services, Func<HttpClient, TImplementation> factory)
        where TClient : class where TImplementation : class, TClient
    {
        var type = Type.GetType("Microsoft.Extensions.DependencyInjection.HttpClientFactoryServiceCollectionExtensions,Microsoft.Extensions.Http");
        var methodInfo = type?.GetMethods()
            .Where(x => x.Name == "AddHttpClient")
            .Where(x => x.GetGenericArguments().Length == 2)
            .Where(x => x.GetParameters().Length == 2)
            .Where(x => x.GetParameters()[1].Name == "factory").FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod([typeof(TClient), typeof(TImplementation)]);
        return method?.Invoke(null, [services, factory]);
    }
}

