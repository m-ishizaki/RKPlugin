using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.AccessControl;
using System.Text;
using System.Xml.Linq;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginApplicationEnricherServiceCollectionCaller
{
    public static object? AddServiceLogEnricher(this object? services)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddServiceLogEnricher)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 0
        ).FirstOrDefault();
        var method = methodInfo;
        return method?.Invoke(services, []);
    }

    public static object? AddServiceLogEnricher(this object? services, Action<object?> configure)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddServiceLogEnricher)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(configure)
            && x.GetParameters()[0].ParameterType.GenericTypeArguments.Length == 1
        ).FirstOrDefault();
        var method = methodInfo;
        return method?.Invoke(services, [configure]);
    }

    public static object? AddServiceLogEnricher_(this object? services, object? section)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x =>
            x.Name == nameof(AddServiceLogEnricher_)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(section)
            && x.GetParameters()[0].ParameterType.GenericTypeArguments.Length == 0
        ).FirstOrDefault();
        var method = methodInfo;
        return method?.Invoke(services, [section]);
    }

}
