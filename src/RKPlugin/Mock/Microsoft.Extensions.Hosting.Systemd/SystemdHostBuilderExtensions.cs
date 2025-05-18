namespace Microsoft.Extensions.Hosting;

public static class SystemdHostBuilderExtensions
{
    public static List<string> Invoked = new List<string>();

    static object? Add(string name)
    {
        Invoked.Add(name);
        return null;
    }

    public static object? AddSystemd(this object? services)
        => Add("public static object? AddSystemd(this object? services)");
}