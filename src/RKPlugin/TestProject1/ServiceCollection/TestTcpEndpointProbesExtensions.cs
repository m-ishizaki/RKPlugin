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
    static List<string> Invoked = TcpEndpointProbesExtensions.Invoked;

    [TestMethod]
    public void Test_AddTcpEndpointProbe_001() =>
        Test(nameof(
            _Test_AddTcpEndpointProbe_001));
    static void _Test_AddTcpEndpointProbe_001(object? services) =>
        PluginServiceCollection.AddTcpEndpointProbe(services);

    [TestMethod]
    public void Test_AddTcpEndpointProbe_002() =>
        Test(nameof(
            _Test_AddTcpEndpointProbe_002));
    static void _Test_AddTcpEndpointProbe_002(object? services, string name) =>
        PluginServiceCollection.AddTcpEndpointProbe(services, name);

    [TestMethod]
    public void Test_AddTcpEndpointProbe_003() =>
        Test(nameof(
            _Test_AddTcpEndpointProbe_003));
    static void _Test_AddTcpEndpointProbe_003(object? services, Action<object?> configure) =>
        PluginServiceCollection.AddTcpEndpointProbe(services, configure);

    [TestMethod]
    public void Test_AddTcpEndpointProbe_004() =>
        Test(nameof(
            _Test_AddTcpEndpointProbe_004));
    static void _Test_AddTcpEndpointProbe_004(object? services, string name, Action<object?> configure) =>
        PluginServiceCollection.AddTcpEndpointProbe(services, name, configure);

    [TestMethod]
    public void Test_AddTcpEndpointProbe_005() =>
        Test(nameof(
            _Test_AddTcpEndpointProbe_005));
    static void _Test_AddTcpEndpointProbe_005(object? services, object? configurationSection) =>
        PluginServiceCollection.AddTcpEndpointProbe(services, configurationSection);

    [TestMethod]
    public void Test_AddTcpEndpointProbe_006() =>
        Test(nameof(
            _Test_AddTcpEndpointProbe_006));
    static void _Test_AddTcpEndpointProbe_006(object? services, string name, object? configurationSection) =>
        PluginServiceCollection.AddTcpEndpointProbe(services, name, configurationSection);
}
