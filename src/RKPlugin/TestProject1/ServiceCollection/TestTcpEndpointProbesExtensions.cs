using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestTcpEndpointProbesExtensions
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

    static List<string> Invoked = TcpEndpointProbesExtensions.Invoked;

    [TestMethod]
    public void Test_AddTcpEndpointProbe_001() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddTcpEndpointProbe_001), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddTcpEndpointProbe_001(object? services) =>
        PluginServiceCollection.AddTcpEndpointProbe(services);

    [TestMethod]
    public void Test_AddTcpEndpointProbe_002() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddTcpEndpointProbe_002), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddTcpEndpointProbe_002(object? services, string name) =>
        PluginServiceCollection.AddTcpEndpointProbe(services, name);

    [TestMethod]
    public void Test_AddTcpEndpointProbe_003() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddTcpEndpointProbe_003), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddTcpEndpointProbe_003(object? services, Action<object?> configure) =>
        PluginServiceCollection.AddTcpEndpointProbe(services, configure);

    [TestMethod]
    public void Test_AddTcpEndpointProbe_004() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddTcpEndpointProbe_004), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null, null]));
    static void _Test_AddTcpEndpointProbe_004(object? services, string name, Action<object?> configure) =>
        PluginServiceCollection.AddTcpEndpointProbe(services, name, configure);

    [TestMethod]
    public void Test_AddTcpEndpointProbe_005() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddTcpEndpointProbe_005), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddTcpEndpointProbe_005(object? services, object? configurationSection) =>
        PluginServiceCollection.AddTcpEndpointProbe(services, configurationSection);

    [TestMethod]
    public void Test_AddTcpEndpointProbe_006() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddTcpEndpointProbe_006), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null, null]));
    static void _Test_AddTcpEndpointProbe_006(object? services, string name, object? configurationSection) =>
        PluginServiceCollection.AddTcpEndpointProbe(services, name, configurationSection);
}
