namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginTcpEndpointProbes
{
    static readonly string BaseType = "Microsoft.Extensions.DependencyInjection.TcpEndpointProbesExtensions,Microsoft.Extensions.Diagnostics.Probes";

    public static object? AddTcpEndpointProbe(this object? services)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddTcpEndpointProbe)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == "services"
        ).FirstOrDefault();
        var method = methodInfo;
        var result = method?.Invoke(null, [services]);
        return result;
    }

    public static object? AddTcpEndpointProbe(this object? services, string name)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddTcpEndpointProbe)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == "services"
            && x.GetParameters()[1].Name == "name"
            && x.GetParameters()[1].ParameterType == typeof(string)
        ).FirstOrDefault();
        var method = methodInfo;
        var result = method?.Invoke(null, [services, name]);
        return result;
    }

    public static object? AddTcpEndpointProbe(this object? services, Action<object?> configure)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddTcpEndpointProbe)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == "services"
            && x.GetParameters()[1].Name == "configure"
        ).FirstOrDefault();
        var method = methodInfo;
        var result = method?.Invoke(null, [services, configure]);
        return result;
    }

    public static object? AddTcpEndpointProbe(this object? services, string name, Action<object?> configure)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddTcpEndpointProbe)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 3
            && x.GetParameters()[0].Name == "services"
            && x.GetParameters()[1].Name == "name"
            && x.GetParameters()[1].ParameterType == typeof(string)
            && x.GetParameters()[2].Name == "configure"
        ).FirstOrDefault();
        var method = methodInfo;
        var result = method?.Invoke(null, [services, name, configure]);
        return result;
    }

    public static object? AddTcpEndpointProbe(this object? services, object? configurationSection)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddTcpEndpointProbe)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == "services"
            && x.GetParameters()[1].Name == "configurationSection"
        ).FirstOrDefault();
        var method = methodInfo;
        var result = method?.Invoke(null, [services, configurationSection]);
        return result;
    }

    public static object? AddTcpEndpointProbe(this object? services, string name, object? configurationSection)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddTcpEndpointProbe)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 3
            && x.GetParameters()[0].Name == "services"
            && x.GetParameters()[1].Name == "name"
            && x.GetParameters()[1].ParameterType == typeof(string)
            && x.GetParameters()[2].Name == "configurationSection"
        ).FirstOrDefault();
        var method = methodInfo;
        var result = method?.Invoke(null, [services, name, configurationSection]);
        return result;
    }
}
