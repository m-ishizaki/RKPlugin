namespace Microsoft.Extensions.DependencyInjection;

public static class LatencyRegistryServiceCollectionExtensions
{
    public static List<string> Invoked = new List<string>();

    static object? Add(string name)
    {
        Invoked.Add(name);
        return null;
    }

    public static object? RegisterCheckpointNames(this object? services, params string[] names)
        => Add("public static object? RegisterCheckpointNames(this object? services, params string[] names)");

    public static object? RegisterMeasureNames(this object? services, params string[] names)
        => Add("public static object? RegisterMeasureNames(this object? services, params string[] names)");

    public static object? RegisterTagNames(this object? services, params string[] names)
        => Add("public static object? RegisterTagNames(this object? services, params string[] names)");

    private static void ConfigureOption(this object? services, Action<object?> action)
        => Add("private static void ConfigureOption(this object? services, Action<object?> action)");
}
