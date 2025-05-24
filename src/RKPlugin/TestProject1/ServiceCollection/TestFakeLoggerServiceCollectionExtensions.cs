using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestFakeLoggerServiceCollectionExtensions
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

    static List<string> Invoked = FakeLoggerServiceCollectionExtensions.Invoked;

    [TestMethod]
    public void Test_AddFakeLogging_001() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddFakeLogging_001), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddFakeLogging_001(object? services, object? section) =>
        FakeLoggerServiceCollectionExtensions.AddFakeLogging(services, section);

    [TestMethod]
    public void Test_AddFakeLogging_002() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddFakeLogging_002), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, (Action<object?>)(_ => { })]));
    static void _Test_AddFakeLogging_002(object? services, Action<object?> configure) =>
        FakeLoggerServiceCollectionExtensions.AddFakeLogging(services, configure);

    [TestMethod]
    public void Test_AddFakeLogging_003() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddFakeLogging_003), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddFakeLogging_003(object? services) =>
        FakeLoggerServiceCollectionExtensions.AddFakeLogging(services);
}
