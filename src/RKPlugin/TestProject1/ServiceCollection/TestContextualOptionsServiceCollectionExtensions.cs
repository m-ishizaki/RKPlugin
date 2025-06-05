using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin.DependencyInjection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestContextualOptionsServiceCollectionExtensions
{
    static Object _lock = new Object();
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);
    static List<string> Invoked = ContextualOptionsServiceCollectionExtensions.Invoked;

    [TestMethod]
    public void Test_AddContextualOptions_001() => Test(nameof(_Test_AddContextualOptions_001));
    static void _Test_AddContextualOptions_001(object? services) =>
        PluginServiceCollection.AddContextualOptions(services);

    [TestMethod]
    public void Test_Configure_001() => Test(nameof(_Test_Configure_001));
    static void _Test_Configure_001(object? services) =>
        PluginServiceCollection.Configure<Object>(services, loadOptions: null);

    [TestMethod]
    public void Test_Configure_002() => Test(nameof(_Test_Configure_002));
    static void _Test_Configure_002(object? services) =>
        PluginServiceCollection.Configure<Object>(services, name: null, loadOptions: null);

    [TestMethod]
    public void Test_Configure_003() => Test(nameof(_Test_Configure_003));
    static void _Test_Configure_003(object? services) =>
        PluginServiceCollection.Configure<Object>(services, configure: null);

    [TestMethod]
    public void Test_Configure_004() => Test(nameof(_Test_Configure_004));
    static void _Test_Configure_004(object? services) =>
        PluginServiceCollection.Configure<Object>(services, name: null, configure: null);

    [TestMethod]
    public void Test_ConfigureAll_001() => Test(nameof(_Test_ConfigureAll_001));
    static void _Test_ConfigureAll_001(object? services) =>
        PluginServiceCollection.ConfigureAll<Object>(services, loadOptions: null);

    [TestMethod]
    public void Test_ConfigureAll_002() => Test(nameof(_Test_ConfigureAll_002));
    static void _Test_ConfigureAll_002(object? services) =>
        PluginServiceCollection.ConfigureAll<Object>(services, configure: null);
}
