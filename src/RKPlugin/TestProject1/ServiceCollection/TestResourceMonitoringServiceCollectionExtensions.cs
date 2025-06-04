using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestResourceMonitoringServiceCollectionExtensions
{
    static Object _lock = new Object();
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);
    static List<string> Invoked = ResourceMonitoringServiceCollectionExtensions.Invoked;

    [TestMethod]
    public void Test_AddResourceMonitoring_001() => Test(nameof(_Test_AddResourceMonitoring_001));
    static void _Test_AddResourceMonitoring_001(object? services) =>
        PluginServiceCollection.AddResourceMonitoring(services);

    [TestMethod]
    public void Test_AddResourceMonitoring_002() => Test(nameof(_Test_AddResourceMonitoring_002));
    static void _Test_AddResourceMonitoring_002(object? services) =>
        PluginServiceCollection.AddResourceMonitoring(services, (obj) => { });
}
