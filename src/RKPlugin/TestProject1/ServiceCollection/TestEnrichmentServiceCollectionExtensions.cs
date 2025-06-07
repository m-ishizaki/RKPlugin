using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin.DependencyInjection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestEnrichmentServiceCollectionExtensions
{
    static Object _lock = new Object();
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);
    static List<string> Invoked = EnrichmentServiceCollectionExtensions.Invoked;

    [TestMethod]
    public void Test_AddLogEnricher_001() => Test(nameof(_Test_AddLogEnricher_001));
    static void _Test_AddLogEnricher_001(object? services) =>
        PluginServiceCollection.AddLogEnricher<object>(services);

    [TestMethod]
    public void Test_AddLogEnricher_002() => Test(nameof(_Test_AddLogEnricher_002));
    static void _Test_AddLogEnricher_002(object? services) =>
        PluginServiceCollection.AddLogEnricher(services, enricher: null);

    [TestMethod]
    public void Test_AddStaticLogEnricher_001() => Test(nameof(_Test_AddStaticLogEnricher_001));
    static void _Test_AddStaticLogEnricher_001(object? services) =>
        PluginServiceCollection.AddStaticLogEnricher<object>(services);

    [TestMethod]
    public void Test_AddStaticLogEnricher_002() => Test(nameof(_Test_AddStaticLogEnricher_002));
    static void _Test_AddStaticLogEnricher_002(object? services) =>
        PluginServiceCollection.AddStaticLogEnricher(services, enricher: null);
}
