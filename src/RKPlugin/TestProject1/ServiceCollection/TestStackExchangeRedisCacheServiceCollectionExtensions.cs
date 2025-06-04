using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestStackExchangeRedisCacheServiceCollectionExtensions
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

    static List<string> Invoked = StackExchangeRedisCacheServiceCollectionExtensions.Invoked;

    [TestMethod]
    public void Test_AddStackExchangeRedisCache_001() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddStackExchangeRedisCache_001), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddStackExchangeRedisCache_001(object? services, object? section) =>
        PluginServiceCollection.AddStackExchangeRedisCache(services, section);

    [TestMethod]
    public void Test_AddStackExchangeRedisCache_002() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddStackExchangeRedisCache_002), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddStackExchangeRedisCache_002(object? services, Action<object?> configure) =>
        PluginServiceCollection.AddStackExchangeRedisCache(services, configure);
}