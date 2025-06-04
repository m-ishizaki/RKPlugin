using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestMetricsServiceExtensions
{
    static Object _lock = new Object();
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);
    static List<string> Invoked = MetricsServiceExtensions.Invoked;

    [TestMethod]
    public void Test_AddMetrics_001() =>
        Test(nameof(
            _Test_AddMetrics_001));
    static void _Test_AddMetrics_001(object? services) =>
        PluginServiceCollection.AddMetrics(services);

    [TestMethod]
    public void Test_AddMetrics_002() =>
        Test(nameof(
            _Test_AddMetrics_002));
    static void _Test_AddMetrics_002(object? services, Action<object?> configure) =>
        PluginServiceCollection.AddMetrics(services, configure);

}
