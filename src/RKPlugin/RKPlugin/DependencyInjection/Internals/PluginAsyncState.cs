namespace Microsoft.Extensions.DependencyInjection;

public static class AsyncStateExtensions
{
    public static List<string> Invoked = new List<string>();

    static object? Add(string name)
    {
        Invoked.Add(name);
        return null;
    }

    public static object? AddAsyncState(this object? services)
        => Add("public static object? AddAsyncState(this object? services)");
}
