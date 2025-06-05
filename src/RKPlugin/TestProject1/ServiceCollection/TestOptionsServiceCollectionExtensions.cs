using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestOptionsServiceCollectionExtensions
{
    static Object _lock = new Object();
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);
    static List<string> Invoked = OptionsServiceCollectionExtensions.Invoked;

    [TestMethod]
    public void Test_AddOptions_001() => Test(nameof(_Test_AddOptions_001));
    static void _Test_AddOptions_001(object? services)
=> PluginServiceCollection.AddOptions(services);

    [TestMethod]
    public void Test_AddOptions_002() => Test(nameof(_Test_AddOptions_002));
    static void _Test_AddOptions_002(object? services)
=> PluginServiceCollection.AddOptions<Object>(services);

    [TestMethod]
    public void Test_AddOptions_003() => Test(nameof(_Test_AddOptions_003));
    static void _Test_AddOptions_003(object? services)
    => PluginServiceCollection.AddOptions<Object>(services, name: null);

    [TestMethod]
    public void Test_AddOptionsWithValidateOnStart_004() => Test(nameof(_Test_AddOptionsWithValidateOnStart_004));
    static void _Test_AddOptionsWithValidateOnStart_004(object? services)
    => PluginServiceCollection.AddOptionsWithValidateOnStart<object>(services, name: null);

    [TestMethod]
    public void Test_AddOptionsWithValidateOnStart_005() => Test(nameof(_Test_AddOptionsWithValidateOnStart_005));
    static void _Test_AddOptionsWithValidateOnStart_005(object? services)
    => PluginServiceCollection.AddOptionsWithValidateOnStart<object, object>(services, name: null);

    [TestMethod]
    public void Test_Configure_006() =>
        Test(nameof(
             _Test_Configure_006));
    static void _Test_Configure_006(object? services)
    => PluginServiceCollection.Configure<Object>(services, configureOptions: Test1.DummyAction);

    [TestMethod]
    public void Test_Configure_007() =>
        Test(nameof(
             _Test_Configure_007));
    static void _Test_Configure_007(object? services)
    => PluginServiceCollection.Configure<Object>(services, name: null, configureOptions: Test1.DummyAction);

    [TestMethod]
    public void Test_ConfigureAll_008() =>
        Test(nameof(
             _Test_ConfigureAll_008));
    static void _Test_ConfigureAll_008(object? services)
    => PluginServiceCollection.ConfigureAll<Object>(services, configureOptions: Test1.DummyAction);

    [TestMethod]
    public void Test_ConfigureOptions_009() =>
        Test(nameof(
             _Test_ConfigureOptions_009));
    static void _Test_ConfigureOptions_009(object? services)
    => PluginServiceCollection.ConfigureOptions<object>(services);

    [TestMethod]
    public void Test_ConfigureOptions_010() =>
        Test(nameof(
             _Test_ConfigureOptions_010));
    static void _Test_ConfigureOptions_010(object? services)
    => PluginServiceCollection.ConfigureOptions(services, configureType: null);

    [TestMethod]
    public void Test_ConfigureOptions_011() =>
        Test(nameof(
             _Test_ConfigureOptions_011));
    static void _Test_ConfigureOptions_011(object? services)
    => PluginServiceCollection.ConfigureOptions(services, configureInstance: null);

    [TestMethod]
    public void Test_PostConfigure_012() =>
        Test(nameof(
             _Test_PostConfigure_012));
    static void _Test_PostConfigure_012(object? services)
    => PluginServiceCollection.PostConfigure<Object>(services, configureOptions: Test1.DummyAction);

    [TestMethod]
    public void Test_PostConfigure_013() =>
        Test(nameof(
             _Test_PostConfigure_013));
    static void _Test_PostConfigure_013(object? services)
    => PluginServiceCollection.PostConfigure<Object>(services, name: null, configureOptions: Test1.DummyAction);

    [TestMethod]
    public void Test_PostConfigureAll_014() =>
        Test(nameof(
             _Test_PostConfigureAll_014));
    static void _Test_PostConfigureAll_014(object? services)
    => PluginServiceCollection.PostConfigureAll<Object>(services, configureOptions: Test1.DummyAction);
}