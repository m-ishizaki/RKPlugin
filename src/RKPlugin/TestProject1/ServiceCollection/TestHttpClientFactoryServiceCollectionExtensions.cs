using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestHttpClientFactoryServiceCollectionExtensions
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

    static List<string> Invoked = HttpClientFactoryServiceCollectionExtensions.Invoked;

    [TestMethod]
    public void Test_AddHttpClient_001() => Test(nameof(_Test_AddHttpClient_001));
    static void _Test_AddHttpClient_001(object? services)
        => PluginServiceCollection.AddHttpClient(services);

    [TestMethod]
    public void Test_ConfigureHttpClientDefaults_002() => Test(nameof(_Test_ConfigureHttpClientDefaults_002));
    static void _Test_ConfigureHttpClientDefaults_002(object? services)
        => PluginServiceCollection.ConfigureHttpClientDefaults(services, configure: (Action<object?>)Test1.DummyAction);

    [TestMethod]
    public void Test_AddHttpClient_003() =>Test(nameof(_Test_AddHttpClient_003));
    static void _Test_AddHttpClient_003(object? services)
        => PluginServiceCollection.AddHttpClient(services, name: "");

    [TestMethod]
    public void Test_AddHttpClient_004() => Test(nameof(_Test_AddHttpClient_004));
    static void _Test_AddHttpClient_004(object? services)
        => PluginServiceCollection.AddHttpClient(services, name: "", configureClient: Test1.DummyAction);

    [TestMethod]
    public void Test_AddHttpClient_005() => Test(nameof(_Test_AddHttpClient_005));
    static void _Test_AddHttpClient_005(object? services)
    => PluginServiceCollection.AddHttpClient(services, name: "", configureClient: (_, __) => { });

    [TestMethod]
    public void Test_AddHttpClient_006() => Test(nameof(_Test_AddHttpClient_006));
    static void _Test_AddHttpClient_006(object? services)
    => PluginServiceCollection.AddHttpClient<object>(services);

    [TestMethod]
    public void Test_AddHttpClient_007() => Test(nameof(_Test_AddHttpClient_007));
    static void _Test_AddHttpClient_007(object? services)
    => PluginServiceCollection.AddHttpClient<object, object>(services);

    [TestMethod]
    public void Test_AddHttpClient_008() => Test(nameof(_Test_AddHttpClient_008));
    static void _Test_AddHttpClient_008(object? services)
    => PluginServiceCollection.AddHttpClient<object>(services, name: "");

    [TestMethod]
    public void Test_AddHttpClient_009() => Test(nameof(_Test_AddHttpClient_009));
    static void _Test_AddHttpClient_009(object? services)
    => PluginServiceCollection.AddHttpClient<object, object>(services, name: "");

    [TestMethod]
    public void Test_AddHttpClient_010() => Test(nameof(_Test_AddHttpClient_010));
    static void _Test_AddHttpClient_010(object? services)
    => PluginServiceCollection.AddHttpClient<object>(services, configureClient: Test1.DummyAction);

    [TestMethod]
    public void Test_AddHttpClient_011() => Test(nameof(_Test_AddHttpClient_011));
    static void _Test_AddHttpClient_011(object? services)
    => PluginServiceCollection.AddHttpClient<object>(services, (_, __) => { });

    [TestMethod]
    public void Test_AddHttpClient_012() => Test(nameof(_Test_AddHttpClient_012));
    static void _Test_AddHttpClient_012(object? services)
    => PluginServiceCollection.AddHttpClient<object, object>(services, configureClient: Test1.DummyAction);

    [TestMethod]
    public void Test_AddHttpClient_013() => Test(nameof(_Test_AddHttpClient_013));
    static void _Test_AddHttpClient_013(object? services)
    => PluginServiceCollection.AddHttpClient<object, object>(services, (_, __) => { });

    [TestMethod]
    public void Test_AddHttpClient_014() => Test(nameof(_Test_AddHttpClient_014));
    static void _Test_AddHttpClient_014(object? services)
    => PluginServiceCollection.AddHttpClient<object>(services, name: "", configureClient: Test1.DummyAction);

    [TestMethod]
    public void Test_AddHttpClient_015() => Test(nameof(_Test_AddHttpClient_015));
    static void _Test_AddHttpClient_015(object? services)
    => PluginServiceCollection.AddHttpClient<object>(services, name: "", configureClient: (_, __) => { });

    [TestMethod]
    public void Test_AddHttpClient_016() => Test(nameof(_Test_AddHttpClient_016));
    static void _Test_AddHttpClient_016(object? services)
    => PluginServiceCollection.AddHttpClient<object, object>(services, name: "", configureClient: Test1.DummyAction);

    [TestMethod]
    public void Test_AddHttpClient_017() => Test(nameof(_Test_AddHttpClient_017));
    static void _Test_AddHttpClient_017(object? services)
    => PluginServiceCollection.AddHttpClient<object, object>(services, name: "", configureClient: (_, __) => { });

    [TestMethod]
    public void Test_AddHttpClient_018() => Test(nameof(_Test_AddHttpClient_018));
    static void _Test_AddHttpClient_018(object? services)
    => PluginServiceCollection.AddHttpClient<object, object>(services, factory: _ => new object());

    [TestMethod]
    public void Test_AddHttpClient_019() => Test(nameof(_Test_AddHttpClient_019));
    static void _Test_AddHttpClient_019(object? services)
    => PluginServiceCollection.AddHttpClient<object, object>(services, name: "", factory: _ => new object());

    [TestMethod]
    public void Test_AddHttpClient_020() => Test(nameof(_Test_AddHttpClient_020));
    static void _Test_AddHttpClient_020(object? services)
    => PluginServiceCollection.AddHttpClient<object, object>(services, factory: (_, __) => new object());

    [TestMethod]
    public void Test_AddHttpClient_021() => Test(nameof(_Test_AddHttpClient_021));
    static void _Test_AddHttpClient_021(object? services)
    => PluginServiceCollection.AddHttpClient<object, object>(services, name: "", factory: (_, __) => new object());

}

