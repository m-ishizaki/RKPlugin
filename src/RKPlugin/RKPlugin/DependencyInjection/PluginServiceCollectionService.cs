using RkSoftware.RKPlugin.Reflection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace RkSoftware.RKPlugin.DependencyInjection;

public static class PluginServiceCollectionService
{
    public static readonly string BaseType = "Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions,Microsoft.Extensions.DependencyInjection.Abstractions";

    public static object? AddScoped<TService>(object services, Func<IServiceProvider, TService> implementationFactory)
        where TService : class
    {
        const string MethodName = "AddScoped<T1>(object, Func<IServiceProvider, TService>)";
        var method = TypeInitializer.Method(BaseType, MethodName,
            type =>
            {
                var methodInfo = type?.GetMethods()
                    .Where(x => x.Name == "AddScoped")
                    .Where(x => x.GetGenericArguments().Length == 1)
                    .Where(x => x.GetParameters().Length == 2)
                    .Where(x => x.GetParameters()[1].Name == "implementationFactory").FirstOrDefault();
                var method = methodInfo?.MakeGenericMethod([typeof(TService)]);
                return method;
            });
        return method?.Invoke(null, [services, implementationFactory]);
    }
}
