namespace Microsoft.Extensions.DependencyInjection;

public static class HttpClientLatencyTelemetryExtensions
{
    public static List<string> Invoked = new List<string>();

    static object? Add(string name)
    {
        Invoked.Add(name);
        return null;
    }

    public static object? AddHttpClientLatencyTelemetry(this object? services)
        => Add("public static object? AddHttpClientLatencyTelemetry(this object? services)");

    public static object? AddHttpClientLatencyTelemetry(this object? services, object? section)
        => Add("public static object? AddHttpClientLatencyTelemetry(this object? services, object? section)");

    public static object? AddHttpClientLatencyTelemetry(this object? services, Action<object?> configure)
        => Add("public static object? AddHttpClientLatencyTelemetry(this object? services, Action<object?> configure)");
}
