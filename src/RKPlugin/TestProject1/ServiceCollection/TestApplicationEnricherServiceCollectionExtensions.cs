using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestApplicationEnricherServiceCollectionExtensions
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

    static List<string> Invoked = ApplicationEnricherServiceCollectionExtensions.Invoked;

    [TestMethod]
    public void Test_AddServiceLogEnricher_001() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddServiceLogEnricher_001), BindingFlags.NonPublic | BindingFlags.Static)!, null, []));
    static void _Test_AddServiceLogEnricher_001(object? services) =>
        PluginServiceCollection.AddServiceLogEnricher(services);

    [TestMethod]
    public void Test_AddServiceLogEnricher_002() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddServiceLogEnricher_002), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddServiceLogEnricher_002(object? services, Action<object?> configure) =>
        PluginServiceCollection.AddServiceLogEnricher(services, configure);

    [TestMethod]
    public void Test_AddServiceLogEnricher_003() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddServiceLogEnricher_003), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddServiceLogEnricher_003(object? services, object? section) =>
        PluginServiceCollection.AddServiceLogEnricher_(services, section);    
}
