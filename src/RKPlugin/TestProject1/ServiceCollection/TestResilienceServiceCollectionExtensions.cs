using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestResilienceServiceCollectionExtensions
{
    static Object _lock = new Object();
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);
    static List<string> Invoked = ResilienceServiceCollectionExtensions.Invoked;

    [TestMethod]
    public void Test_AddResilienceEnricher_001() => Test(nameof(_Test_AddResilienceEnricher_001));
    static void _Test_AddResilienceEnricher_001(object? services) =>
        PluginServiceCollection.AddResilienceEnricher(services);
}
