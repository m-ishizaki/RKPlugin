using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Extensions.DependencyInjection;

public static class EnrichmentServiceCollectionExtensions
{
    public static List<string> Invoked = new List<string>();

    static object? Add(string name)
    {
        Invoked.Add(name);
        return null;
    }

    public static object? AddLogEnricher<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] T>(this object? services) where T : class
        => Add("public static object? AddLogEnricher<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] T>(this object? services) where T : class");

    public static object? AddLogEnricher(this object? services, object? enricher)
        => Add("public static object? AddLogEnricher(this object? services, object? enricher)");

    public static object? AddStaticLogEnricher<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] T>(this object? services) where T : class
        => Add("public static object? AddStaticLogEnricher<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] T>(this object? services) where T : class");

    public static object? AddStaticLogEnricher(this object? services, object? enricher)
        => Add("public static object? AddStaticLogEnricher(this object? services, object? enricher)");
}
