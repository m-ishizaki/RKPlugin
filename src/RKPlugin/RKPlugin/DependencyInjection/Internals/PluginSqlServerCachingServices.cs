namespace RkSoftware.RKPlugin.DependencyInjection.Internals;

internal static class PluginSqlServerCachingServices
{
    static readonly string BaseType = "Microsoft.Extensions.DependencyInjection.SqlServerCachingServicesExtensions,Microsoft.Extensions.Caching.SqlServer";

    public static object? AddDistributedSqlServerCache(this object? services, Action<object?> setupAction)
    {
        var type = Type.GetType(BaseType);
        var methodInfo = type?.GetMethods().Where(x =>
            x.Name == nameof(AddDistributedSqlServerCache)
            && x.GetGenericArguments().Length == 0
            && x.GetParameters().Length == 2
            && x.GetParameters()[0].Name == "services"
            && x.GetParameters()[1].Name == "setupAction"
        ).FirstOrDefault();
        var method = methodInfo;
        var result = method?.Invoke(null, [services, setupAction]);
        return result;
    }
}