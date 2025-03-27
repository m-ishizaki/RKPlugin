using System;
using System.Collections.Generic;
using System.Text;

namespace RkSoftware.RKPlugin.DependencyInjection;

public static class PluginServiceCollectionService
{
    static Type Init() => typeof(Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions);

    public static object? AddScoped<TService>(object services, Func<IServiceProvider, TService> implementationFactory)
        where TService : class
    {
        var type = Type.GetType("Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions,Microsoft.Extensions.DependencyInjection.Abstractions");
        var methodInfo = type?.GetMethods()
            .Where(x => x.Name == "AddScoped")
            .Where(x => x.GetGenericArguments().Length == 1)
            .Where(x => x.GetParameters().Length == 2)
            .Where(x => x.GetParameters()[1].Name == "implementationFactory").FirstOrDefault();
        var method = methodInfo?.MakeGenericMethod([typeof(TService)]);
        return method?.Invoke(null, [services, implementationFactory]);
    }

}
