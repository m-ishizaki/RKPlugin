using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestStackExchangeRedisCacheServiceCollectionExtensions
{
    static Object _lock = new Object();
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);
    static List<string> Invoked = StackExchangeRedisCacheServiceCollectionExtensions.Invoked;

    [TestMethod]
    public void Test_AddStackExchangeRedisCache_001() =>
        Test(nameof(
            _Test_AddStackExchangeRedisCache_001));
    static void _Test_AddStackExchangeRedisCache_001(object? services, object? section) =>
        PluginServiceCollection.AddStackExchangeRedisCache(services, section);

    [TestMethod]
    public void Test_AddStackExchangeRedisCache_002() =>
        Test(nameof(
            _Test_AddStackExchangeRedisCache_002));
    static void _Test_AddStackExchangeRedisCache_002(object? services, Action<object?> configure) =>
        PluginServiceCollection.AddStackExchangeRedisCache(services, configure);
}