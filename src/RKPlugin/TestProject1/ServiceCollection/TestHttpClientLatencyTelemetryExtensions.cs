using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestHttpClientLatencyTelemetryExtensions
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

    static List<string> Invoked = HttpClientLatencyTelemetryExtensions.Invoked;

    [TestMethod]
    public void Test_AddHttpClientLatencyTelemetry_001() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddHttpClientLatencyTelemetry_001), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddHttpClientLatencyTelemetry_001(object? services) =>
        PluginServiceCollection.AddHttpClientLatencyTelemetry_(services);

    [TestMethod]
    public void Test_AddHttpClientLatencyTelemetry_002() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddHttpClientLatencyTelemetry_002), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddHttpClientLatencyTelemetry_002(object? services, object? section) =>
        PluginServiceCollection.AddHttpClientLatencyTelemetry(services, section);

    [TestMethod]
    public void Test_AddHttpClientLatencyTelemetry_003() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddHttpClientLatencyTelemetry_003), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddHttpClientLatencyTelemetry_003(object? services, Action<object?> configure) =>
        PluginServiceCollection.AddHttpClientLatencyTelemetry(services, configure);
}
