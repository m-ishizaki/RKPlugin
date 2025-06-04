using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestHealthCheckServiceCollectionExtensions
{
    static Object _lock = new Object();
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);
    static List<string> Invoked = HealthCheckServiceCollectionExtensions.Invoked;

    [TestMethod]
    public void Test_AddHealthChecks_001() =>
        Test(nameof(
            _Test_AddHealthChecks_001));
    static void _Test_AddHealthChecks_001(object? services) =>
        PluginServiceCollection.AddHealthChecks(services);
}