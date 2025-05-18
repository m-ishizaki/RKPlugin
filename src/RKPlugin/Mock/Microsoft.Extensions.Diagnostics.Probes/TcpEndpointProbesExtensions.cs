namespace Microsoft.Extensions.DependencyInjection;

public static class TcpEndpointProbesExtensions
{
    public static List<string> Invoked = new List<string>();

    static object? Add(string name)
    {
        Invoked.Add(name);
        return null;
    }

    public static object? AddTcpEndpointProbe(this object? services)
        => Add("public static object? AddTcpEndpointProbe(this object? services)");

    public static object? AddTcpEndpointProbe(this object? services, string name)
        => Add("public static object? AddTcpEndpointProbe(this object? services, string name)");

    public static object? AddTcpEndpointProbe(this object? services, Action<object?> configure)
        => Add("public static object? AddTcpEndpointProbe(this object? services, Action<object?> configure)");

    public static object? AddTcpEndpointProbe(this object? services, string name, Action<object?> configure)
        => Add("public static object? AddTcpEndpointProbe(this object? services, string name, Action<object?> configure)");

    public static object? AddTcpEndpointProbe(this object? services, object? configurationSection)
        => Add("public static object? AddTcpEndpointProbe(this object? services, object? configurationSection)");

    public static object? AddTcpEndpointProbe(this object? services, string name, object? configurationSection)
        => Add("public static object? AddTcpEndpointProbe(this object? services, string name, object? configurationSection)");
}
