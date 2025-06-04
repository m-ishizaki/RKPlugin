using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestHttpClientLoggingServiceCollectionExtensions
{
    static Object _lock = new Object();
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);
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

    static List<string> Invoked = HttpClientLoggingServiceCollectionExtensions.Invoked;

    [TestMethod]
    public void Test_AddExtendedHttpClientLogging_001() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddExtendedHttpClientLogging_001), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddExtendedHttpClientLogging_001(object? services) =>
        PluginServiceCollection.AddExtendedHttpClientLogging_(services);

    [TestMethod]
    public void Test_AddExtendedHttpClientLogging_002() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddExtendedHttpClientLogging_002), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddExtendedHttpClientLogging_002(object? services, object? section) =>
        PluginServiceCollection.AddExtendedHttpClientLogging(services, section);

    [TestMethod]
    public void Test_AddExtendedHttpClientLogging_003() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddExtendedHttpClientLogging_003), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddExtendedHttpClientLogging_003(object? services, Action<object?> configure) =>
        PluginServiceCollection.AddExtendedHttpClientLogging(services, configure);

    [TestMethod]
    public void Test_AddHttpClientLogEnricher_001() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddHttpClientLogEnricher_001), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddHttpClientLogEnricher_001(object? services) =>
        PluginServiceCollection.AddHttpClientLogEnricher<object>(services);
}
