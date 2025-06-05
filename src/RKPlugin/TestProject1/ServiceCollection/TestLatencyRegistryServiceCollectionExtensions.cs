using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin.DependencyInjection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestLatencyRegistryServiceCollectionExtensions
{
    static Object _lock = new Object();
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);
    static List<string> Invoked = LatencyRegistryServiceCollectionExtensions.Invoked;

    [TestMethod]
    public void Test_RegisterCheckpointNames_001() =>
        Test(nameof(
            _Test_RegisterCheckpointNames_001));
    static void _Test_RegisterCheckpointNames_001(object? services) =>
        PluginServiceCollection.RegisterCheckpointNames(services, names: null);

    [TestMethod]
    public void Test_RegisterMeasureNames_001() =>
        Test(nameof(
            _Test_RegisterMeasureNames_001));
    static void _Test_RegisterMeasureNames_001(object? services) =>
        PluginServiceCollection.RegisterMeasureNames(services, names: null);

    [TestMethod]
    public void Test_RegisterTagNames_001() =>
        Test(nameof(
            _Test_RegisterTagNames_001));
    static void _Test_RegisterTagNames_001(object? services) =>
        PluginServiceCollection.RegisterTagNames(services, names: null);
}
