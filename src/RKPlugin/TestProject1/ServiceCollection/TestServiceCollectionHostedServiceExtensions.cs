using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin.DependencyInjection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestServiceCollectionHostedServiceExtensions
{
    static Object _lock = new Object();
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);
    static List<string> Invoked = ServiceCollectionHostedServiceExtensions.Invoked;

    [TestMethod]
    public void Test_AddHostedService_001() => Test(nameof(_Test_AddHostedService_001));
    static void _Test_AddHostedService_001(object? services) =>
        PluginServiceCollection.AddHostedService<object>(services);

    [TestMethod]
    public void Test_AddHostedService_002() => Test(nameof(_Test_AddHostedService_002));
    static void _Test_AddHostedService_002(object? services) =>
        PluginServiceCollection.AddHostedService<object>(services, implementationFactory: Test1.DummyFunc);
}
