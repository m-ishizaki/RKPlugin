using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestApplicationEnricherServiceCollectionExtensions
{
    static Object _lock = new Object();
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);
    static List<string> Invoked = ApplicationEnricherServiceCollectionExtensions.Invoked;

    [TestMethod]
    public void Test_AddServiceLogEnricher_001() => Test(nameof(_Test_AddServiceLogEnricher_001));
    static void _Test_AddServiceLogEnricher_001(object? services) =>
        PluginServiceCollection.AddServiceLogEnricher(services);

    [TestMethod]
    public void Test_AddServiceLogEnricher_002() =>
        Test(nameof(
            _Test_AddServiceLogEnricher_002));
    static void _Test_AddServiceLogEnricher_002(object? services, Action<object?> configure) =>
        PluginServiceCollection.AddServiceLogEnricher(services, configure);

    [TestMethod]
    public void Test_AddServiceLogEnricher_003() =>
        Test(nameof(
            _Test_AddServiceLogEnricher_003));
    static void _Test_AddServiceLogEnricher_003(object? services, object? section) =>
        PluginServiceCollection.AddServiceLogEnricher_(services, section);
}
