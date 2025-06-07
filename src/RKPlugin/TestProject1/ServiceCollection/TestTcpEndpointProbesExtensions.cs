using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin.DependencyInjection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestTcpEndpointProbesExtensions
{
    static Object _lock = new Object();
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);
    static List<string> Invoked = TcpEndpointProbesExtensions.Invoked;

    [TestMethod]
    public void Test_AddTcpEndpointProbe_001() => Test(nameof(_Test_AddTcpEndpointProbe_001));
    static void _Test_AddTcpEndpointProbe_001(object? services) =>
        PluginServiceCollection.AddTcpEndpointProbe(services);

    [TestMethod]
    public void Test_AddTcpEndpointProbe_002() => Test(nameof(_Test_AddTcpEndpointProbe_002));
    static void _Test_AddTcpEndpointProbe_002(object? services) =>
        PluginServiceCollection.AddTcpEndpointProbe(services, name: null);

    [TestMethod]
    public void Test_AddTcpEndpointProbe_003() => Test(nameof(_Test_AddTcpEndpointProbe_003));
    static void _Test_AddTcpEndpointProbe_003(object? services) =>
        PluginServiceCollection.AddTcpEndpointProbe(services, configure: Test1.DummyAction);

    [TestMethod]
    public void Test_AddTcpEndpointProbe_004() => Test(nameof(_Test_AddTcpEndpointProbe_004));
    static void _Test_AddTcpEndpointProbe_004(object? services) =>
        PluginServiceCollection.AddTcpEndpointProbe(services, name: "", configure: Test1.DummyAction);

    [TestMethod]
    public void Test_AddTcpEndpointProbe_005() => Test(nameof(_Test_AddTcpEndpointProbe_005));
    static void _Test_AddTcpEndpointProbe_005(object? services) =>
        PluginServiceCollection.AddTcpEndpointProbe(services, configurationSection: null);

    [TestMethod]
    public void Test_AddTcpEndpointProbe_006() => Test(nameof(_Test_AddTcpEndpointProbe_006));
    static void _Test_AddTcpEndpointProbe_006(object? services) =>
        PluginServiceCollection.AddTcpEndpointProbe(services, name: "", configurationSection: null);
}
