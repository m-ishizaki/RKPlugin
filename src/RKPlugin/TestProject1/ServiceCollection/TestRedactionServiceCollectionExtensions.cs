using Microsoft.Extensions.Compliance.Redaction;
using RkSoftware.RKPlugin.DependencyInjection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestRedactionServiceCollectionExtensions
{
    static Object _lock = new Object();
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);
    static List<string> Invoked = RedactionServiceCollectionExtensions.Invoked;

    [TestMethod]
    public void Test_AddRedaction_001() => Test(nameof(_Test_AddRedaction_001));
    static void _Test_AddRedaction_001(object? services) =>
        PluginServiceCollection.AddRedaction(services, null);

    [TestMethod]
    public void Test_AddRedaction_002() => Test(nameof(_Test_AddRedaction_002));
    static void _Test_AddRedaction_002(object? services) =>
        PluginServiceCollection.AddRedaction(services, Test1.DummyAction);
}
