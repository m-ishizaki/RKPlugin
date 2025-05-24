using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestObjectPoolServiceCollectionExtensions
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

    static List<string> Invoked = ObjectPoolServiceCollectionExtensions.Invoked;

    [TestMethod]
    public void Test_AddPooled_001() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddPooled_001), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddPooled_001(object? services, Action<object?>? configure = null) =>
        ObjectPoolServiceCollectionExtensions.AddPooled<object>(services, configure);

    [TestMethod]
    public void Test_AddPooled_002() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddPooled_002), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddPooled_002(object? services, Action<object?>? configure = null) =>
        ObjectPoolServiceCollectionExtensions.AddPooled<object, object>(services, configure);

    [TestMethod]
    public void Test_ConfigurePool_001() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_ConfigurePool_001), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_ConfigurePool_001(object? services, Action<object?> configure) =>
        ObjectPoolServiceCollectionExtensions.ConfigurePool<object>(services, configure);

    [TestMethod]
    public void Test_ConfigurePools_001() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_ConfigurePools_001), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_ConfigurePools_001(object? services, object? section) =>
        ObjectPoolServiceCollectionExtensions.ConfigurePools(services, section);

    [TestMethod]
    public void Test_AddPooledInternal_001() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddPooledInternal_001), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddPooledInternal_001(object? services, Action<object?>? configure = null) =>
        AddPooledInternal<object, object>(services, configure);
}
