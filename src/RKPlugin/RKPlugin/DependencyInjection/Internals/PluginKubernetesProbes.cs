﻿using System;
using System.Linq;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginKubernetesProbes
{
    static readonly string BaseType = "Microsoft.Extensions.DependencyInjection.KubernetesProbesExtensions,Microsoft.Extensions.Diagnostics.Probes";

    public static object? AddKubernetesProbes(this object? services)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddKubernetesProbes)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(services)
        ).FirstOrDefault();
        var method = methodInfo;
        var result = method?.Invoke(null, [services]);
        return result;
    }

    public static object? AddKubernetesProbes(this object? services, object? section)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddKubernetesProbes)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(section)
        ).FirstOrDefault();
        var method = methodInfo;
        var result = method?.Invoke(null, [services, section]);
        return result;
    }

    public static object? AddKubernetesProbes(this object? services, Action<object?> configure)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddKubernetesProbes)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == nameof(services)
            && x.GetParameters()[1].Name == nameof(configure)
        ).FirstOrDefault();
        var method = methodInfo;
        var result = method?.Invoke(null, [services, configure]);
        return result;
    }
}
