using System;
using System.Linq;
using System.Reflection;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginServiceCollectionHostedServiceCaller
{
    public static object? AddHostedService(this object? services, Type hostedServiceType)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));
        if (hostedServiceType == null) throw new ArgumentNullException(nameof(hostedServiceType));

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

        var genericMethod = methodInfo.MakeGenericMethod(hostedServiceType);
        return genericMethod.Invoke(services, null);
    }

    public static object? AddHostedService(this object? services, Type hostedServiceType, Func<IServiceProvider, object> implementationFactory)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));
        if (hostedServiceType == null) throw new ArgumentNullException(nameof(hostedServiceType));
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

        var genericMethod = methodInfo.MakeGenericMethod(hostedServiceType);
        return genericMethod.Invoke(services, new object[] { implementationFactory