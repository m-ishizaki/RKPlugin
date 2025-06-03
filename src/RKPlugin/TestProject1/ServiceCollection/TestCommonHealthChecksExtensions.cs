using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestCommonHealthChecksExtensions
{
    static Object _lock = new Object();
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);
    static List<string> Invoked = CommonHealthChecksExtensions.Invoked;

    [TestMethod]
    public void Test_AddTelemetryHealthCheckPublisher_001() => Test(nameof(_Test_AddTelemetryHealthCheckPublisher_001));
    static void _Test_AddTelemetryHealthCheckPublisher_001(object? services) =>
        PluginServiceCollection.AddTelemetryHealthCheckPublisher_(services);

    [TestMethod]
    public void Test_AddTelemetryHealthCheckPublisher_002() => Test(nameof(_Test_AddTelemetryHealthCheckPublisher_002));
    static void _Test_AddTelemetryHealthCheckPublisher_002(object? services) =>
        PluginServiceCollection.AddTelemetryHealthCheckPublisher(services, section: null);

    [TestMethod]
    public void Test_AddTelemetryHealthCheckPublisher_003() => Test(nameof(_Test_AddTelemetryHealthCheckPublisher_003));
    static void _Test_AddTelemetryHealthCheckPublisher_003(object? services) =>
        PluginServiceCollection.AddTelemetryHealthCheckPublisher(services, configure: Test1.DummyAction);
}
