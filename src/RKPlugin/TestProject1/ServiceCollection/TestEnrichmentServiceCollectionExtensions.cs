using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestEnrichmentServiceCollectionExtensions
{
    static Object _lock = new Object();
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);

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
    public void Test_AddLogEnricher_001() => Test(nameof(_Test_AddLogEnricher_001));
    static void _Test_AddLogEnricher_001(object? services) =>
        EnrichmentServiceCollectionExtensions.AddLogEnricher<object>(services);

    [TestMethod]
    public void Test_AddLogEnricher_002() => Test(nameof(_Test_AddLogEnricher_002));
    static void _Test_AddLogEnricher_002(object? services, object? enricher) =>
        EnrichmentServiceCollectionExtensions.AddLogEnricher(services, enricher);

    [TestMethod]
    public void Test_AddStaticLogEnricher_001() => Test(nameof(_Test_AddStaticLogEnricher_001));
    static void _Test_AddStaticLogEnricher_001(object? services) =>
        EnrichmentServiceCollectionExtensions.AddStaticLogEnricher<object>(services);

    [TestMethod]
    public void Test_AddStaticLogEnricher_002() => Test(nameof(_Test_AddStaticLogEnricher_002));
    static void _Test_AddStaticLogEnricher_002(object? services, object? enricher) =>
        EnrichmentServiceCollectionExtensions.AddStaticLogEnricher(services, enricher);
}
