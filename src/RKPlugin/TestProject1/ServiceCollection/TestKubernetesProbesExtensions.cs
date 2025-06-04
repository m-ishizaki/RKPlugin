using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestKubernetesProbesExtensions
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

    static List<string> Invoked = KubernetesProbesExtensions.Invoked;

    [TestMethod]
    public void Test_AddKubernetesProbes_001() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddKubernetesProbes_001), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddKubernetesProbes_001(object? services) =>
        PluginServiceCollection.AddKubernetesProbes_(services);

    [TestMethod]
    public void Test_AddKubernetesProbes_002() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddKubernetesProbes_002), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddKubernetesProbes_002(object? services, object? section) =>
        PluginServiceCollection.AddKubernetesProbes(services, section);

    [TestMethod]
    public void Test_AddKubernetesProbes_003() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddKubernetesProbes_003), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddKubernetesProbes_003(object? services, Action<object?> configure) =>
        PluginServiceCollection.AddKubernetesProbes(services, configure);
}
