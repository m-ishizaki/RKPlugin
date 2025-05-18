namespace Microsoft.Extensions.DependencyInjection;

public static class ResourceMonitoringServiceCollectionExtensions
{
    public static List<string> Invoked = new List<string>();

    static object? Add(string name)
    {
        Invoked.Add(name);
        return null;
    }

    public static object? AddResourceMonitoring(this object? services)
        => Add("public static object? AddResourceMonitoring(this object? services)");

    public static object? AddResourceMonitoring(this object? services, Action<object?> configure)
        => Add("public static object? AddResourceMonitoring(this object? services, Action<object?> configure)");

    private static object? AddResourceMonitoringInternal(this object? services, Action<object?> configure)
        => Add("private static object? AddResourceMonitoringInternal(this object? services, Action<object?> configure)");
}
