using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin.DependencyInjection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestKubernetesProbesExtensions
{
    static Object _lock = new Object();
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);
    static List<string> Invoked = KubernetesProbesExtensions.Invoked;

    [TestMethod]
    public void Test_AddKubernetesProbes_001() =>
        Test(nameof(
            _Test_AddKubernetesProbes_001));
    static void _Test_AddKubernetesProbes_001(object? services) =>
        PluginServiceCollection.AddKubernetesProbes_(services);

    [TestMethod]
    public void Test_AddKubernetesProbes_002() =>
        Test(nameof(
            _Test_AddKubernetesProbes_002));
    static void _Test_AddKubernetesProbes_002(object? services) =>
        PluginServiceCollection.AddKubernetesProbes(services, section: null);

    [TestMethod]
    public void Test_AddKubernetesProbes_003() =>
        Test(nameof(
            _Test_AddKubernetesProbes_003));
    static void _Test_AddKubernetesProbes_003(object? services) =>
        PluginServiceCollection.AddKubernetesProbes(services, configure: Test1.DummyAction);
}
