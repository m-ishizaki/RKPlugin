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

    [TestMethod]
    public void Test_AddLogEnricher_001() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddLogEnricher_001), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddLogEnricher_001(object? services) =>
        EnrichmentServiceCollectionExtensions.AddLogEnricher<object>(services);

    [TestMethod]
    public void Test_AddLogEnricher_002() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddLogEnricher_002), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddLogEnricher_002(object? services, object? enricher) =>
        EnrichmentServiceCollectionExtensions.AddLogEnricher(services, enricher);

    [TestMethod]
    public void Test_AddStaticLogEnricher_001() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddStaticLogEnricher_001), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddStaticLogEnricher_001(object? services) =>
        EnrichmentServiceCollectionExtensions.AddStaticLogEnricher<object>(services);

    [TestMethod]
    public void Test_AddStaticLogEnricher_002() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddStaticLogEnricher_002), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddStaticLogEnricher_002(object? services, object? enricher) =>
        EnrichmentServiceCollectionExtensions.AddStaticLogEnricher(services, enricher);
}
