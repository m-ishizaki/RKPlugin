using System;
using System.Linq;
using System.Reflection;

namespace Microsoft.Extensions.Hosting;

public static class WindowsServiceLifetimeHostBuilderExtensions
{
    public static object? AddWindowsService(this object? services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        var type = services.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(m =>
                m.Name == nameof(AddWindowsService)
                && m.GetParameters().Length == 0
            );

        if (methodInfo == null)
            throw new InvalidOperationException("AddWindowsService method not found.");

        return methodInfo.Invoke(services, null);
    }

    public static object? AddWindowsService(this object? services, Action<object?> configure)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));
        if (configure == null) throw new ArgumentNullException(nameof(configure));

        var type = services.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(m =>
                m.Name == nameof(AddWindowsService)
                && m.GetParameters().Length == 1
                && m.GetParameters()[0].ParameterType == typeof(Action<object?>)
            );

        if (methodInfo == null)
            throw new InvalidOperationException("AddWindowsService method with configure not found.");

        return methodInfo.Invoke(services, new object[] { configure });
    }
}
