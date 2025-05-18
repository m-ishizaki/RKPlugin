namespace Microsoft.Extensions.DependencyInjection;

public static class HttpDiagnosticsServiceCollectionExtensions
{
    public static List<string> Invoked = new List<string>();

    static object? Add(string name)
    {
        Invoked.Add(name);
        return null;
    }

    public static object? AddDownstreamDependencyMetadata(this object? services, object? downstreamDependencyMetadata)
        => Add("public static object? AddDownstreamDependencyMetadata(this object? services, object? downstreamDependencyMetadata)");

    public static object? AddDownstreamDependencyMetadata<T>(this object? services) where T : class
        => Add("public static object? AddDownstreamDependencyMetadata<T>(this object? services) where T : class");
}
