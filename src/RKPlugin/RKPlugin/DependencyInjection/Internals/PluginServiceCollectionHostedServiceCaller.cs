using System;
using System.Linq;
using System.Reflection;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginServiceCollectionHostedServiceCaller
{
    public static object? AddHostedService(this object? services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        var type = services.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(m =>
                m.Name == "AddHostedService"
                && m.IsGenericMethodDefinition
                && m.GetGenericArguments().Length == 1
                && m.GetParameters().Length == 0
            );

        if (methodInfo == null)
            throw new InvalidOperationException("AddHostedService method not found.");

        return methodInfo.Invoke(services, null);
    }

    public static object? AddHostedService(this object? services, Func<IServiceProvider, object> implementationFactory)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));
        if (implementationFactory == null) throw new ArgumentNullException(nameof(implementationFactory));

        var type = services.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(m =>
                m.Name == "AddHostedService"
                && m.IsGenericMethodDefinition
                && m.GetGenericArguments().Length == 1
                && m.GetParameters().Length == 1
                && m.GetParameters()[0].ParameterType.IsGenericType
            );

        if (methodInfo == null)
            throw new InvalidOperationException("AddHostedService method with factory not found.");

        return methodInfo.Invoke(services, new object[] { implementationFactory });
    }
}
