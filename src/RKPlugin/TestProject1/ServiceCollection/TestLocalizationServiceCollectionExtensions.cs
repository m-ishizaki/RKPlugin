using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestLocalizationServiceCollectionExtensions
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

    static List<string> Invoked = LocalizationServiceCollectionExtensions.Invoked;

    [TestMethod]
    public void Test_AddLocalization_001() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddLocalization_001), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddLocalization_001(object? services) =>
        PluginServiceCollection.AddLocalization(services);

    [TestMethod]
    public void Test_AddLocalization_002() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddLocalization_002), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddLocalization_002(object? services, Action<object?> setupAction) =>
        PluginServiceCollection.AddLocalization(services, setupAction);
}
