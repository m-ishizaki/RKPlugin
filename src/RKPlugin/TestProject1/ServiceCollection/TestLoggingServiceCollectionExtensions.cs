using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestLoggingServiceCollectionExtensions
{
    static Object _lock = new Object();
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);
    static List<string> Invoked = LoggingServiceCollectionExtensions.Invoked;

    [TestMethod]
    public void Test_AddLogging_001() =>
        Test(nameof(
            _Test_AddLogging_001));
    static void _Test_AddLogging_001(object? services) =>
        PluginServiceCollection.AddLogging(services);

    [TestMethod]
    public void Test_AddLogging_002() =>
        Test(nameof(
            _Test_AddLogging_002));
    static void _Test_AddLogging_002(object? services, Action<object?> configure) =>
        PluginServiceCollection.AddLogging(services, configure);

}