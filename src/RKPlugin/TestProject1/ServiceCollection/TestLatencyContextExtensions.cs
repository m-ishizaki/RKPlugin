using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin.DependencyInjection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestLatencyContextExtensions
{
    static Object _lock = new Object();
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);
    static List<string> Invoked = LatencyContextExtensions.Invoked;

    [TestMethod]
    public void Test_AddLatencyContext_001() =>
        Test(nameof(
            _Test_AddLatencyContext_001));
    static void _Test_AddLatencyContext_001(object? services) =>
        PluginServiceCollection.AddLatencyContext_(services);

    [TestMethod]
    public void Test_AddLatencyContext_002() =>
        Test(nameof(
            _Test_AddLatencyContext_002));
    static void _Test_AddLatencyContext_002(object? services) =>
        PluginServiceCollection.AddLatencyContext(services, configure: Test1.DummyAction);

    [TestMethod]
    public void Test_AddLatencyContext_003() =>
        Test(nameof(
            _Test_AddLatencyContext_003));
    static void _Test_AddLatencyContext_003(object? services) =>
        PluginServiceCollection.AddLatencyContext(services, section: null);
}
