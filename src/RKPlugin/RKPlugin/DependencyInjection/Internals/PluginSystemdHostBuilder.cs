using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Extensions.Hosting;

public static class SystemdHostBuilderExtensions
{
    public static List<string> Invoked = new List<string>();

    static object? Add(string name)
    {
        Invoked.Add(name);
        return null;
    }

    public static object? AddSystemd(this object? services)
        => Add("public static object? AddSystemd(this object? services)");
}

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginSystemdHostBuilder
{
    static readonly string BaseType = "Microsoft.Extensions.Hosting.SystemdHostBuilderExtensions,Microsoft.Extensions.Hosting.Systemd";

    public static object? AddSystemd(this object? services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddSystemd)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == "services"
        ).FirstOrDefault();
        var method = methodInfo;
        var result = method?.Invoke(null, [services]);
        return result;
    }
}