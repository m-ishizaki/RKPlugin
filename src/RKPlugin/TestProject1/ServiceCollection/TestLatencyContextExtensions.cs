using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestLatencyContextExtensions
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

    static List<string> Invoked = LatencyContextExtensions.Invoked;

    [TestMethod]
    public void Test_AddLatencyContext_001() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddLatencyContext_001), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddLatencyContext_001(object? services) =>
        PluginServiceCollection.AddLatencyContext_(services);

    [TestMethod]
    public void Test_AddLatencyContext_002() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddLatencyContext_002), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddLatencyContext_002(object? services, Action<object?> configure) =>
        PluginServiceCollection.AddLatencyContext(services, configure);

    [TestMethod]
    public void Test_AddLatencyContext_003() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddLatencyContext_003), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddLatencyContext_003(object? services, object? section) =>
        PluginServiceCollection.AddLatencyContext(services, section);
}
