using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestHttpClientLatencyTelemetryExtensions
{
    static Object _lock = new Object();
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);
    static List<string> Invoked = HttpClientLatencyTelemetryExtensions.Invoked;

    [TestMethod]
    public void Test_AddHttpClientLatencyTelemetry_001() =>
        Test(nameof(
            _Test_AddHttpClientLatencyTelemetry_001));
    static void _Test_AddHttpClientLatencyTelemetry_001(object? services) =>
        PluginServiceCollection.AddHttpClientLatencyTelemetry_(services);

    [TestMethod]
    public void Test_AddHttpClientLatencyTelemetry_002() =>
        Test(nameof(
            _Test_AddHttpClientLatencyTelemetry_002));
    static void _Test_AddHttpClientLatencyTelemetry_002(object? services, object? section) =>
        PluginServiceCollection.AddHttpClientLatencyTelemetry(services, section);

    [TestMethod]
    public void Test_AddHttpClientLatencyTelemetry_003() =>
        Test(nameof(
            _Test_AddHttpClientLatencyTelemetry_003));
    static void _Test_AddHttpClientLatencyTelemetry_003(object? services, Action<object?> configure) =>
        PluginServiceCollection.AddHttpClientLatencyTelemetry(services, configure);
}
