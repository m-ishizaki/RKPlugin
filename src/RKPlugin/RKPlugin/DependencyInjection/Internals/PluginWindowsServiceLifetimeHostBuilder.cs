using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Microsoft.Extensions.Hosting;

public static class WindowsServiceLifetimeHostBuilderExtensions
{
    public static List<string> Invoked = new List<string>();

    static object? Add(string name)
    {
        Invoked.Add(name);
        return null;
    }

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

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginWindowsServiceLifetimeHostBuilder
{
    static readonly string BaseType = "Microsoft.Extensions.Hosting.WindowsServiceLifetimeHostBuilderExtensions,Microsoft.Extensions.Hosting.WindowsServices";

    public static object? AddWindowsService(this object? services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddWindowsService)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == "services"
        ).FirstOrDefault();
        var method = methodInfo;
        var result = method?.Invoke(null, [services]);
        return result;
    }

    public static object? AddWindowsService(this object? services, Action<object?> configure)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));
        if (configure == null) throw new ArgumentNullException(nameof(configure));

        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddWindowsService)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == "services"
            && x.GetParameters()[1].Name == "configure"
        ).FirstOrDefault();
        var method = methodInfo;
        var result = method?.Invoke(null, [services, configure]);
        return result;
    }
}
