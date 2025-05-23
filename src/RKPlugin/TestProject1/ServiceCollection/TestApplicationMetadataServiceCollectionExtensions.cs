namespace Microsoft.Extensions.AmbientMetadata.Application;

public static class ApplicationMetadataServiceCollectionExtensions
{
    public static List<string> Invoked = new List<string>();

    static object? Add(string name)
    {
        Invoked.Add(name);
        return null;
    }

    public static object? AddApplicationMetadata(this object? services, object? section)
        => Add("public static object? AddApplicationMetadata(this object? services, object? section)");

    public static object? AddApplicationMetadata(this object? services, Action<object?> configure)
        => Add("public static object? AddApplicationMetadata(this object? services, Action<object?> configure)");
}
