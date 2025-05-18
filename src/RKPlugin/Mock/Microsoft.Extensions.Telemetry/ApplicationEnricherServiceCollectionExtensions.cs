namespace Microsoft.Extensions.DependencyInjection;

public static class ApplicationEnricherServiceCollectionExtensions
{
    public static List<string> Invoked = new List<string>();

    static object? Add(string name)
    {
        Invoked.Add(name);
        return null;
    }

    public static object? AddServiceLogEnricher(this object? services)
        => Add("public static object? AddServiceLogEnricher(this object? services)");

    public static object? AddServiceLogEnricher(this object? services, Action<object?> configure)
        => Add("public static object? AddServiceLogEnricher(this object? services, Action<ApplicationLogEnricherOptions> configure)");

    public static object? AddServiceLogEnricher(this object? services, object? section)
        => Add("public static object? AddServiceLogEnricher(this object? services, IConfigurationSection section)");
}
