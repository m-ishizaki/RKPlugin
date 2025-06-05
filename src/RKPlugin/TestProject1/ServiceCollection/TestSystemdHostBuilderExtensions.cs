using Microsoft.Extensions.Hosting;
using RkSoftware.RKPlugin.DependencyInjection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestSystemdHostBuilderExtensions
{
    static Object _lock = new Object();
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);
    static List<string> Invoked = SystemdHostBuilderExtensions.Invoked;

    [TestMethod]
    public void Test_AddSystemd_001() => Test(nameof(_Test_AddSystemd_001));
    static void _Test_AddSystemd_001(object? services) =>
        PluginServiceCollection.AddSystemd(services);
}