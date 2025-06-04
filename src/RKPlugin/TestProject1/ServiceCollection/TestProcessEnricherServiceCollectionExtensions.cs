using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestProcessEnricherServiceCollectionExtensions
{
    static Object _lock = new Object();
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);
    static List<string> Invoked = ProcessEnricherServiceCollectionExtensions.Invoked;

    [TestMethod]
    public void Test_AddProcessLogEnricher_001() => Test(nameof(_Test_AddProcessLogEnricher_001));
    static void _Test_AddProcessLogEnricher_001(object? services) =>
        PluginServiceCollection.AddProcessLogEnricher_(services);

    [TestMethod]
    public void Test_AddProcessLogEnricher_002() => Test(nameof(_Test_AddProcessLogEnricher_002));
    static void _Test_AddProcessLogEnricher_002(object? services) =>
        PluginServiceCollection.AddProcessLogEnricher(services, (obj) => { });

    [TestMethod]
    public void Test_AddProcessLogEnricher_003() => Test(nameof(_Test_AddProcessLogEnricher_003));
    static void _Test_AddProcessLogEnricher_003(object? services) =>
        PluginServiceCollection.AddProcessLogEnricher(services, null);
}
