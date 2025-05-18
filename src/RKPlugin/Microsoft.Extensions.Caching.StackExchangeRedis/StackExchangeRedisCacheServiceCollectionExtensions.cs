namespace Microsoft.Extensions.DependencyInjection;

public static class StackExchangeRedisCacheServiceCollectionExtensions
{
    public static List<string> Invoked = new List<string>();

    static object? Add(string name)
    {
        Invoked.Add(name);
        return null;
    }

    public static object? AddStackExchangeRedisCache(this object? services, object? section)
        => Add("public static object? AddStackExchangeRedisCache(this object? services, object? section)");

    public static object? AddStackExchangeRedisCache(this object? services, Action<object?> configure)
        => Add("public static object? AddStackExchangeRedisCache(this object? services, Action<object?> configure)");
}