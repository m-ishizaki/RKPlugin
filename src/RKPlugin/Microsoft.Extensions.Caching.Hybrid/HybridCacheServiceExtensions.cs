namespace Microsoft.Extensions.DependencyInjection;

public static class HybridCacheServiceExtensions
{
    public static List<string> Invoked = new List<string>();

    static object? Add(string name)
    {
        Invoked.Add(name);
        return null;
    }

    public static object? AddHybridCache(this object? services)
        => Add("public static object? AddHybridCache(this object? services)");

    public static object? AddHybridCache(this object? services, Action<object?> setupAction)
        => Add("public static object? AddHybridCache(this object? services, Action<object?> setupAction)");
}
