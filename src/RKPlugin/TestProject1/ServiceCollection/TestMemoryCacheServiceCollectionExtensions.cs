using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin.DependencyInjection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestMemoryCacheServiceCollectionExtensions
{
    static Object _lock = new Object();
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);
    static List<string> Invoked = MemoryCacheServiceCollectionExtensions.Invoked;

    [TestMethod]
    public void Test_AddDistributedMemoryCache_001() =>
        Test(nameof(
            _Test_AddDistributedMemoryCache_001));
    static void _Test_AddDistributedMemoryCache_001(object? services) =>
        PluginServiceCollection.AddDistributedMemoryCache(services);

    [TestMethod]
    public void Test_AddDistributedMemoryCache_002() =>
        Test(nameof(
            _Test_AddDistributedMemoryCache_002));
    static void _Test_AddDistributedMemoryCache_002(object? services) =>
        PluginServiceCollection.AddDistributedMemoryCache(services, setupAction: Test1.DummyAction);

    [TestMethod]
    public void Test_AddMemoryCache_001() =>
        Test(nameof(
            _Test_AddMemoryCache_001));
    static void _Test_AddMemoryCache_001(object? services) =>
        PluginServiceCollection.AddMemoryCache(services);

    [TestMethod]
    public void Test_AddMemoryCache_002() =>
        Test(nameof(
            _Test_AddMemoryCache_002));
    static void _Test_AddMemoryCache_002(object? services) =>
        PluginServiceCollection.AddMemoryCache(services, setupAction: Test1.DummyAction);
}