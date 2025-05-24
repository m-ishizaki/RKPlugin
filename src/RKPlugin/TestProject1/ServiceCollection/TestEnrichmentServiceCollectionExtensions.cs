using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestEnrichmentServiceCollectionExtensions
{
    static Object _lock = new Lock();
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

    [TestMethod]
    public static object? AddLogEnricher<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] T>(this object? services) where T : class
        => Add("public static object? AddLogEnricher<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] T>(this object? services) where T : class");

    [TestMethod]
    public static object? AddLogEnricher(this object? services, object? enricher)
        => Add("public static object? AddLogEnricher(this object? services, object? enricher)");

    [TestMethod]
    public static object? AddStaticLogEnricher<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] T>(this object? services) where T : class
        => Add("public static object? AddStaticLogEnricher<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] T>(this object? services) where T : class");

    [TestMethod]
    public static object? AddStaticLogEnricher(this object? services, object? enricher)
        => Add("public static object? AddStaticLogEnricher(this object? services, object? enricher)");

    [TestMethod]
    public void Test_AddServiceLogEnricher_002() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddServiceLogEnricher_002), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddServiceLogEnricher_002(object? services, Action<object?> configure) =>
        PluginServiceCollection.AddServiceLogEnricher(services, configure);
}
