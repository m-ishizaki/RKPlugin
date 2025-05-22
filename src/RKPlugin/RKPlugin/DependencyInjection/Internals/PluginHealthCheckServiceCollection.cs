using System.Linq;

namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginHealthCheckServiceCollection
{
    static readonly string BaseType = "Microsoft.Extensions.DependencyInjection.HealthCheckServiceCollectionExtensions,Microsoft.Extensions.Diagnostics.HealthChecks";

    public static object? AddHealthChecks(this object? services)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddHealthChecks)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 1
            && x.GetParameters()[0].Name == nameof(services)
        ).FirstOrDefault();
        var method = methodInfo;
        var result = method?.Invoke(null, [services]);
        return result;
    }
}