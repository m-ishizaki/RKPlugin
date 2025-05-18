using System;
using System.Linq;
using System.Reflection;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginEnrichmentServiceCollectionCaller
{
    public static object? AddLogEnricher<T>(this object? services) where T : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(x =>
                x.Name == nameof(AddLogEnricher)
                && x.GetGenericArguments().Length == 1
                && x.GetParameters().Length == 0
            );
        var genericMethod = methodInfo?.MakeGenericMethod(typeof(T));
        return genericMethod?.Invoke(services, Array.Empty<object>());
    }

    public static object? AddLogEnricher(this object? services, object? enricher)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(x =>
                x.Name == nameof(AddLogEnricher)
                && x.GetGenericArguments().Length == 0
                && x.GetParameters().Length == 1
                && x.GetParameters()[0].ParameterType == enricher?.GetType()
            );
        return methodInfo?.Invoke(services, new object[] { enricher! });
    }

    public static object? AddStaticLogEnricher<T>(this object? services) where T : class
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(x =>
                x.Name == nameof(AddStaticLogEnricher)
                && x.GetGenericArguments().Length == 1
                && x.GetParameters().Length == 0
            );
        var genericMethod = methodInfo?.MakeGenericMethod(typeof(T));
        return genericMethod?.Invoke(services, Array.Empty<object>());
    }

    public static object? AddStaticLogEnricher(this object? services, object? enricher)
    {
        var type = services!.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(x =>
                x.Name == nameof(AddStaticLogEnricher)
                && x.GetGenericArguments().Length == 0
                && x.GetParameters().Length == 1
                && x.GetParameters()[0].ParameterType == enricher?.GetType()
            );
        return methodInfo?.Invoke(services, new object[] { enricher! });