namespace Microsoft.Extensions.DependencyInjection;

    public static class SqlServerCachingServicesExtensions
{
    public static List<string> Invoked = new List<string>();

    static object? Add(string name)
    {
        Invoked.Add(name);
        return null;
    }

    public static object? AddDistributedSqlServerCache(this object? services, Action<object?> setupAction)
        => Add("public static object? AddDistributedSqlServerCache(this object? services, Action<object?> setupAction)");
}