using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestLatencyConsoleExtensions
{
    static Object _lock = new Object();
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);
    static List<string> Invoked = LatencyConsoleExtensions.Invoked;

    [TestMethod]
    public void Test_AddConsoleLatencyDataExporter_001() =>
        Test(nameof(
            _Test_AddConsoleLatencyDataExporter_001));
    static void _Test_AddConsoleLatencyDataExporter_001(object? services) =>
        PluginServiceCollection.AddConsoleLatencyDataExporter_(services);

    [TestMethod]
    public void Test_AddConsoleLatencyDataExporter_002() =>
        Test(nameof(
            _Test_AddConsoleLatencyDataExporter_002));
    static void _Test_AddConsoleLatencyDataExporter_002(object? services, Action<object?> configure) =>
        PluginServiceCollection.AddConsoleLatencyDataExporter(services, configure);

    [TestMethod]
    public void Test_AddConsoleLatencyDataExporter_003() =>
        Test(nameof(
            _Test_AddConsoleLatencyDataExporter_003));
    static void _Test_AddConsoleLatencyDataExporter_003(object? services, object? section) =>
        PluginServiceCollection.AddConsoleLatencyDataExporter(services, section);
}
