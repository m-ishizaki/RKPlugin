using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestHybridCacheServiceExtensions
{
    static Object _lock = new Object();
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);
    static List<string> Invoked = HybridCacheServiceExtensions.Invoked;

    [TestMethod]
    public void Test_AddHybridCache_001() =>
        Test(nameof(
            _Test_AddHybridCache_001));
    static void _Test_AddHybridCache_001(object? services) =>
        PluginServiceCollection.AddHybridCache(services);

    [TestMethod]
    public void Test_AddHybridCache_002() =>
        Test(nameof(
            _Test_AddHybridCache_002));
    static void _Test_AddHybridCache_002(object? services, Action<object?> setupAction) =>
        PluginServiceCollection.AddHybridCache(services, setupAction);
}
