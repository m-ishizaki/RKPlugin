namespace Microsoft.Extensions.DependencyInjection;

    public static class MemoryCacheServiceCollectionExtensions
{
    public static List<string> Invoked = new List<string>();

    static object? Add(string name)
    {
        Invoked.Add(name);
        return null;
    }

    public static object? AddDistributedMemoryCache(this object? services)
        => Add("public static object? AddDistributedMemoryCache(this object? services)");

    public static object? AddDistributedMemoryCache(this object? services, Action<object?> setupAction)
        => Add("public static object? AddDistributedMemoryCache(this object? services, Action<object?> setupAction)");

    public static object? AddMemoryCache(this object? services)
        => Add("public static object? AddMemoryCache(this object? services)");

    public static object? AddMemoryCache(this object? services, Action<object?> setupAction)
        => Add("public static object? AddMemoryCache(this object? services, Action<object?> setupAction)");
}