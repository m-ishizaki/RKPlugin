using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestLatencyRegistryServiceCollectionExtensions
{
    static Object _lock = new Object();
    void Test(List<string> args, Action act)
    {
        lock (_lock)
        {
            int count = args.Count;
            act();
            Assert.AreEqual(count + 1, args.Count);
            Assert.IsTrue(!args.Reverse<string>().Skip(1).Any(x => x == args.LastOrDefault()));
        }
    }

    static List<string> Invoked = LatencyRegistryServiceCollectionExtensions.Invoked;

    [TestMethod]
    public void Test_RegisterCheckpointNames_001() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_RegisterCheckpointNames_001), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_RegisterCheckpointNames_001(object? services, params string[] names) =>
        LatencyRegistryServiceCollectionExtensions.RegisterCheckpointNames(services, names);

    [TestMethod]
    public void Test_RegisterMeasureNames_001() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_RegisterMeasureNames_001), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_RegisterMeasureNames_001(object? services, params string[] names) =>
        LatencyRegistryServiceCollectionExtensions.RegisterMeasureNames(services, names);

    [TestMethod]
    public void Test_RegisterTagNames_001() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_RegisterTagNames_001), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_RegisterTagNames_001(object? services, params string[] names) =>
        LatencyRegistryServiceCollectionExtensions.RegisterTagNames(services, names);

    private static void ConfigureOption(this object? services, Action<object?> action)
        => Add("private static void ConfigureOption(this object? services, Action<object?> action)");
}
