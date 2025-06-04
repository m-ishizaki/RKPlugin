using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

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
    static void _Test_RegisterCheckpointNames_001(object? services, params string[] names) =>
        PluginServiceCollection.RegisterCheckpointNames(services, names);

    [TestMethod]
    public void Test_RegisterMeasureNames_001() =>
        Test(nameof(
            _Test_RegisterMeasureNames_001));
    static void _Test_RegisterMeasureNames_001(object? services, params string[] names) =>
        PluginServiceCollection.RegisterMeasureNames(services, names);

    [TestMethod]
    public void Test_RegisterTagNames_001() =>
        Test(nameof(
            _Test_RegisterTagNames_001));
    static void _Test_RegisterTagNames_001(object? services, params string[] names) =>
        PluginServiceCollection.RegisterTagNames(services, names);
}
