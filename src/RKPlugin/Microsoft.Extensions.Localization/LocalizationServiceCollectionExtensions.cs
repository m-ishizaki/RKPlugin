namespace Microsoft.Extensions.DependencyInjection;

public static class LocalizationServiceCollectionExtensions
{
    public static List<string> Invoked = new List<string>();

    static object? Add(string name)
    {
        Invoked.Add(name);
        return null;
    }

    public static object? AddLocalization(this object? services)
        => Add("public static object? AddLocalization(this object? services)");

    public static object? AddLocalization(this object? services, Action<object?> setupAction)
        => Add("public static object? AddLocalization(this object? services, Action<object?> setupAction)");
}
