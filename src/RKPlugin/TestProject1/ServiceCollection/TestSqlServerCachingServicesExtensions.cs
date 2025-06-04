using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestSqlServerCachingServicesExtensions
{
    static Object _lock = new Object();
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);
    static List<string> Invoked = SqlServerCachingServicesExtensions.Invoked;

    [TestMethod]
    public void Test_AddDistributedSqlServerCache_001() => Test(nameof(_Test_AddDistributedSqlServerCache_001));
    static void _Test_AddDistributedSqlServerCache_001(object? services) =>
        PluginServiceCollection.AddDistributedSqlServerCache(services, setupAction: Test1.DummyAction);
}