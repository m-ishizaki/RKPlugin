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
