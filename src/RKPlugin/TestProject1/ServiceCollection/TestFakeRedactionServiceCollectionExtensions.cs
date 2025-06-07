using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin.DependencyInjection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestFakeRedactionServiceCollectionExtensions
{
    static Object _lock = new Object();
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);
    static List<string> Invoked = FakeRedactionServiceCollectionExtensions.Invoked;

    [TestMethod]
    public void Test_AddFakeRedaction_001() => Test(nameof(_Test_AddFakeRedaction_001));
    static void _Test_AddFakeRedaction_001(object? services) =>
        PluginServiceCollection.AddFakeRedaction(services);

    [TestMethod]
    public void Test_AddFakeRedaction_002() => Test(nameof(_Test_AddFakeRedaction_002));
    static void _Test_AddFakeRedaction_002(object? services) =>
        PluginServiceCollection.AddFakeRedaction(services, configure:Test1.DummyAction);
}
