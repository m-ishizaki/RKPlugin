using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestCommonHealthChecksExtensions
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

    static List<string> Invoked = CommonHealthChecksExtensions.Invoked;

    [TestMethod]
    public void Test_AddTelemetryHealthCheckPublisher_001() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddTelemetryHealthCheckPublisher_001), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddTelemetryHealthCheckPublisher_001(object? services) =>
        CommonHealthChecksExtensions.AddTelemetryHealthCheckPublisher(services);

    [TestMethod]
    public void Test_AddTelemetryHealthCheckPublisher_002() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddTelemetryHealthCheckPublisher_002), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddTelemetryHealthCheckPublisher_002(object? services, object? section) =>
        CommonHealthChecksExtensions.AddTelemetryHealthCheckPublisher(services, section);

    [TestMethod]
    public void Test_AddTelemetryHealthCheckPublisher_003() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddTelemetryHealthCheckPublisher_003), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddTelemetryHealthCheckPublisher_003(object? services, Action<object?> configure) =>
        CommonHealthChecksExtensions.AddTelemetryHealthCheckPublisher(services, configure);
}
