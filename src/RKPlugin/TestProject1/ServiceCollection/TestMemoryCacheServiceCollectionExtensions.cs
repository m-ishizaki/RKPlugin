using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestMemoryCacheServiceCollectionExtensions
{
    static Object _lock = new Object();
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);
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

    static List<string> Invoked = MemoryCacheServiceCollectionExtensions.Invoked;

    [TestMethod]
    public void Test_AddDistributedMemoryCache_001() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddDistributedMemoryCache_001), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddDistributedMemoryCache_001(object? services) =>
        PluginServiceCollection.AddDistributedMemoryCache(services);

    [TestMethod]
    public void Test_AddDistributedMemoryCache_002() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddDistributedMemoryCache_002), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddDistributedMemoryCache_002(object? services, Action<object?> setupAction) =>
        PluginServiceCollection.AddDistributedMemoryCache(services, setupAction);

    [TestMethod]
    public void Test_AddMemoryCache_001() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddMemoryCache_001), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddMemoryCache_001(object? services) =>
        PluginServiceCollection.AddMemoryCache(services);

    [TestMethod]
    public void Test_AddMemoryCache_002() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddMemoryCache_002), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddMemoryCache_002(object? services, Action<object?> setupAction) =>
        PluginServiceCollection.AddMemoryCache(services, setupAction);
}