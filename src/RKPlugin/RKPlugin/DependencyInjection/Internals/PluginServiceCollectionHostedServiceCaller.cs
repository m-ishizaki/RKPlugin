using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginServiceCollectionHostedServiceCaller
{
    public static object? AddHostedService<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] THostedService>(this object? services)
        where THostedService : class
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
        var method = methodInfo?.MakeGenericMethod([typeof(THostedService)]);
        return method.Invoke(services, null);
    }

    public static object? AddHostedService<THostedService>(this object? services, Func<IServiceProvider, THostedService> implementationFactory)
        where THostedService : class
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
        var method = methodInfo?.MakeGenericMethod([typeof(THostedService)]);
        return method.Invoke(services, new object[] { implementationFactory });
    }
}
