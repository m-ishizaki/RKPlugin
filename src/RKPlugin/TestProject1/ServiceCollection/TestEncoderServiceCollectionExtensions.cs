using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin.DependencyInjection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestEncoderServiceCollectionExtensions
{
    static Object _lock = new Object();
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);
    static List<string> Invoked = EncoderServiceCollectionExtensions.Invoked;

    [TestMethod]
    public void Test_AddWebEncoders_001() => Test(nameof(_Test_AddWebEncoders_001));
    static void _Test_AddWebEncoders_001(object? services) =>
        PluginServiceCollection.AddWebEncoders(services);

    [TestMethod]
    public void Test_AddWebEncoders_002() => Test(nameof(_Test_AddWebEncoders_002));
    static void _Test_AddWebEncoders_002(object? services) =>
        PluginServiceCollection.AddWebEncoders(services, setupAction: Test1.DummyAction);
}