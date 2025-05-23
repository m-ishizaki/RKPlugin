namespace Microsoft.Extensions.Compliance.Redaction;

public static class RedactionServiceCollectionExtensions
{
    public static List<string> Invoked = new List<string>();

    static object? Add(string name)
    {
        Invoked.Add(name);
        return null;
    }

    public static object? AddRedaction(this object? services, object? section)
        => Add("public static object? AddRedaction(this object? services, object? section)");

    public static object? AddRedaction(this object? services, Action<object?> configure)
        => Add("public static object? AddRedaction(this object? services, Action<object?> configure)");
}
