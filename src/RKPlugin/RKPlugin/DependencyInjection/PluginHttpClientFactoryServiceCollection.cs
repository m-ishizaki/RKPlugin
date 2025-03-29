using RkSoftware.RKPlugin.Reflection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace RkSoftware.RKPlugin.DependencyInjection;

public static class PluginHttpClientFactoryServiceCollection
{
    public static readonly string BaseType = "Microsoft.Extensions.DependencyInjection.HttpClientFactoryServiceCollectionExtensions,Microsoft.Extensions.Http";

    public static object? AddHttpClient<TClient, TImplementation>(object services, Func<HttpClient, TImplementation> factory)
        where TClient : class where TImplementation : class, TClient
    {
        const string MethodName = "AddHttpClient<T1, T2>(object, Func<HttpClient, TImplementation>)";
        var method = TypeInitializer.Method(BaseType, MethodName,
            type =>
            {
                var methodInfo = type?.GetMethods().Where(x =>
                    x.Name == "AddHttpClient"
                    && x.GetGenericArguments().Length == 2
                    && x.GetParameters().Length == 2
                    && x.GetParameters()[1].Name == "factory"
                ).FirstOrDefault();
                var method = methodInfo?.MakeGenericMethod([typeof(TClient), typeof(TImplementation)]);
                return method;
            });
        return method?.Invoke(null, [services, factory]);
    }
}

