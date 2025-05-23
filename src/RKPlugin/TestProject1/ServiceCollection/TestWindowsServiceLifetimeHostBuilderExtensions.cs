namespace Microsoft.Extensions.Hosting;

public static class WindowsServiceLifetimeHostBuilderExtensions
{
    public static List<string> Invoked = new List<string>();

    static object? Add(string name)
    {
        Invoked.Add(name);
        return null;
    }

    public static object? AddWindowsService(this object? services)
        => Add("public static object? AddWindowsService(this object? services)");

    public static object? AddWindowsService(this object? services, Action<object?> configure)
        => Add("public static object? AddWindowsService(this object? services, Action<object?> configure)");
}