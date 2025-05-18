using System;
using System.Linq;
using System.Reflection;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginTcpEndpointProbesCaller
{
    public static object? AddTcpEndpointProbe(this object? services)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddTcpEndpointProbe)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 0
        ).FirstOrDefault();
        var method = methodInfo;
        return method?.Invoke(services, []);
    }

    public static object? AddTcpEndpointProbe(this object? services, string name)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddTcpEndpointProbe)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].ParameterType == typeof(string)
        ).FirstOrDefault();
        var method = methodInfo;
        return method?.Invoke(services, [name]);
    }

    public static object? AddTcpEndpointProbe(this object? services, Action<object?> configure)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddTcpEndpointProbe)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].ParameterType.IsGenericType
            && x.GetParameters()[0].ParameterType.GetGenericTypeDefinition() == typeof(Action<>)
        ).FirstOrDefault();
        var method = methodInfo;
        return method?.Invoke(services, [configure]);
    }

    public static object? AddTcpEndpointProbe(this object? services, string name, Action<object?> configure)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddTcpEndpointProbe)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].ParameterType == typeof(string)
            && x.GetParameters()[1].ParameterType.IsGenericType
            && x.GetParameters()[1].ParameterType.GetGenericTypeDefinition() == typeof(Action<>)
        ).FirstOrDefault();
        var method = methodInfo;
        return method?.Invoke(services, [name, configure]);
    }

    public static object? AddTcpEndpointProbe(this object? services, object? configurationSection)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddTcpEndpointProbe)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].ParameterType != typeof(string)
            && !x.GetParameters()[0].ParameterType.IsGenericType
        ).FirstOrDefault();
        var method = methodInfo;
        return method?.Invoke(services, [configurationSection]);
    }

    public static object? AddTcpEndpointProbe(this object? services, string name, object? configurationSection)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddTcpEndpointProbe)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].ParameterType == typeof(string)
            && x.GetParameters()[1].ParameterType != typeof(string)
            && !x.GetParameters()[1].ParameterType.IsGenericType
        ).FirstOrDefault();
        var method = methodInfo;
        return method?.Invoke(services, [name, configurationSection]);
    }
}
