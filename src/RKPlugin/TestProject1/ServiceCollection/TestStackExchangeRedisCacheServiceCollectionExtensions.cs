using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin.DependencyInjection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestStackExchangeRedisCacheServiceCollectionExtensions
{
    static Object _lock = new Object();
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);
    static List<string> Invoked = StackExchangeRedisCacheServiceCollectionExtensions.Invoked;

    [TestMethod]
    public void Test_AddStackExchangeRedisCache_001() => Test(nameof(_Test_AddStackExchangeRedisCache_001));
    static void _Test_AddStackExchangeRedisCache_001(object? services) =>
        PluginServiceCollection.AddStackExchangeRedisCache(services, section: null);

    [TestMethod]
    public void Test_AddStackExchangeRedisCache_002() => Test(nameof(_Test_AddStackExchangeRedisCache_002));
    static void _Test_AddStackExchangeRedisCache_002(object? services) =>
        PluginServiceCollection.AddStackExchangeRedisCache(services, configure: Test1.DummyAction);
}