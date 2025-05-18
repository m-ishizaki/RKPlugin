using System;
using System.Linq;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection;

public static class PluginSqlServerCachingServicesCaller
{
    public static object? AddDistributedSqlServerCache(this object? services, Action<object?> setupAction)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));
        if (setupAction == null) throw new ArgumentNullException(nameof(setupAction));

        var type = services.GetType();
        var methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(m =>
                m.Name == nameof(AddDistributedSqlServerCache)
                && m.GetParameters().Length == 1
                && m.GetParameters()[0].ParameterType == typeof(Action<object?>)
            );

        if (methodInfo == null)
            throw new InvalidOperationException("AddDistributedSqlServerCache method not found.");

        return methodInfo.Invoke(services, new object[] { setupAction