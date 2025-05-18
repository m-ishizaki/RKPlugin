namespace Microsoft.Extensions.DependencyInjection;

public static class FakeLoggerServiceCollectionExtensions
{
    public static List<string> Invoked = new List<string>();

    static object? Add(string name)
    {
        Invoked.Add(name);
        return null;
    }

    public static object? AddFakeLogging(this object? services, object? section)
        => Add("public static object? AddFakeLogging(this object? services, object? section)");

    public static object? AddFakeLogging(this object? services, Action<object?> configure)
        => Add("public static object? AddFakeLogging(this object? services, Action<object?> configure)");

    public static object? AddFakeLogging(this object? services)
        => Add("public static object? AddFakeLogging(this object? services)");
}
