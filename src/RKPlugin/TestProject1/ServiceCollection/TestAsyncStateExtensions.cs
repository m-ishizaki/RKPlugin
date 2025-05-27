using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestAsyncStateExtensions
{
    static Object _lock = new Object();
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);

    static List<string> Invoked = AsyncStateExtensions.Invoked;

    [TestMethod]
    public void Test_AddAsyncState_001() => Test(nameof(_Test_AddAsyncState_001));
    static void _Test_AddAsyncState_001(object? services) =>
        PluginServiceCollection.AddAsyncState(services);
}
