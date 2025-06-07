using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestWindowsServiceLifetimeHostBuilderExtensions
{
    static Object _lock = new Object();
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);
    static List<string> Invoked = WindowsServiceLifetimeHostBuilderExtensions.Invoked;

    [TestMethod]
    public void Test_AddWindowsService_001() => Test(nameof(_Test_AddWindowsService_001));
    static void _Test_AddWindowsService_001(object? services) =>
        PluginServiceCollection.AddWindowsService(services);

    [TestMethod]
    public void Test_AddWindowsService_002() => Test(nameof(_Test_AddWindowsService_002));
    static void _Test_AddWindowsService_002(object? services) =>
        PluginServiceCollection.AddWindowsService(services, configure: Test1.DummyAction);
}