namespace Microsoft.Extensions.DependencyInjection;

public static class ResilienceServiceCollectionExtensions
{
    public static List<string> Invoked = new List<string>();

    static object? Add(string name)
    {
        Invoked.Add(name);
        return null;
    }

    public static object? AddResilienceEnricher(this object? services)
        => Add("public static object? AddResilienceEnricher(this object? services)");
}
