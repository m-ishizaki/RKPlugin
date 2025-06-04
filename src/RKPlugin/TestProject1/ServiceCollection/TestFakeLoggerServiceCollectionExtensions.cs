using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestFakeLoggerServiceCollectionExtensions
{
    static Object _lock = new Object();
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);
    static List<string> Invoked = FakeLoggerServiceCollectionExtensions.Invoked;

    [TestMethod]
    public void Test_AddFakeLogging_001() => Test(nameof(_Test_AddFakeLogging_001));
    static void _Test_AddFakeLogging_001(object? services, object? section) =>
        PluginServiceCollection.AddFakeLogging(services, section);

    [TestMethod]
    public void Test_AddFakeLogging_002() => Test(nameof(_Test_AddFakeLogging_002));
    static void _Test_AddFakeLogging_002(object? services, Action<object?> configure) =>
        PluginServiceCollection.AddFakeLogging(services, configure);

    [TestMethod]
    public void Test_AddFakeLogging_003() => Test(nameof(_Test_AddFakeLogging_003));
    static void _Test_AddFakeLogging_003(object? services) =>
        PluginServiceCollection.AddFakeLogging_(services);
}
