using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestEnrichmentServiceCollectionExtensions
{
    static Object _lock = new Object();
    void Test(List<string> args, Action act)
    {
        lock (_lock)
        {
            int count = args.Count;
            act();
            Assert.AreEqual(count + 1, args.Count);
            Assert.IsTrue(!args.Reverse<string>().Skip(1).Any(x => x == args.LastOrDefault()));
        }
    }

    static List<string> Invoked = EnrichmentServiceCollectionExtensions.Invoked;

    public static object? AddLogEnricher<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] T>(this object? services) where T : class
        => Add("public static object? AddLogEnricher<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] T>(this object? services) where T : class");

    public static object? AddLogEnricher(this object? services, object? enricher)
        => Add("public static object? AddLogEnricher(this object? services, object? enricher)");

    public static object? AddStaticLogEnricher<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] T>(this object? services) where T : class
        => Add("public static object? AddStaticLogEnricher<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] T>(this object? services) where T : class");

    public static object? AddStaticLogEnricher(this object? services, object? enricher)
        => Add("public static object? AddStaticLogEnricher(this object? services, object? enricher)");
}
