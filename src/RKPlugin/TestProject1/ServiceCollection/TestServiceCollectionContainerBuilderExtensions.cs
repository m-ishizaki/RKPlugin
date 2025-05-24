using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestServiceCollectionContainerBuilderExtensions
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

    static List<string> Invoked = ServiceCollectionContainerBuilderExtensions.Invoked;
    [TestMethod]
    public void Test_BuildServiceProvider_001() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_BuildServiceProvider_001), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_BuildServiceProvider_001(object? services) =>
        ServiceCollectionContainerBuilderExtensions.BuildServiceProvider(services);

    [TestMethod]
    public void Test_BuildServiceProvider_002() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_BuildServiceProvider_002), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_BuildServiceProvider_002(object? services, object? options) =>
        ServiceCollectionContainerBuilderExtensions.BuildServiceProvider(services, options);

    [TestMethod]
    public void Test_BuildServiceProvider_003() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_BuildServiceProvider_003), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, false]));
    static void _Test_BuildServiceProvider_003(object? services, bool validateScopes) =>
        ServiceCollectionContainerBuilderExtensions.BuildServiceProvider(services, validateScopes);
}
