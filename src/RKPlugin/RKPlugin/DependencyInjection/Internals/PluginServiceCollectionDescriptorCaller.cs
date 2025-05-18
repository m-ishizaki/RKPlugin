using System;
using System.Linq;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection.Extensions;

public static class PluginServiceCollectionDescriptorCaller
{
    public static object? AddDescriptor(this object? services, object? descriptor)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));
        if (descriptor == null) throw new ArgumentNullException(nameof(descriptor));

        var type = services.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(m =>
                m.Name == "AddDescriptor"
                && m.GetParameters().Length == 1
            );

        if (methodInfo == null)
            throw new InvalidOperationException("AddDescriptor method not found.");

        return methodInfo.Invoke(services, new object[] { descriptor });
    }

    public static object? RemoveAllDescriptors(this object? services, Type serviceType)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));
        if (serviceType == null) throw new ArgumentNullException(nameof(serviceType));

        var type = services.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(m =>
                m.Name == "RemoveAllDescriptors"
                && m.GetParameters().Length == 1
                && m.GetParameters()[0].ParameterType == typeof(Type)
            );

        if (methodInfo == null)
            throw new InvalidOperationException("RemoveAllDescriptors method not found.");

        return methodInfo.Invoke(services, new object[] { serviceType });
    }
}
