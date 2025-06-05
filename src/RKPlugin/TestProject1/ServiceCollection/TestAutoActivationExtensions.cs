using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin.DependencyInjection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestAutoActivationExtensions
{
    static Object _lock = new Object();
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);
    static List<string> Invoked = AutoActivationExtensions.Invoked;

    [TestMethod]
    public void Test_ActivateSingleton_001() => Test(nameof(_Test_ActivateSingleton_001));
    static void _Test_ActivateSingleton_001(object? services) =>
        PluginServiceCollection.ActivateSingleton<object>(services);


    [TestMethod]
    public void Test_ActivateSingleton_002() => Test(nameof(_Test_ActivateSingleton_002));
    static void _Test_ActivateSingleton_002(object? services) =>
        PluginServiceCollection.ActivateSingleton(services, serviceType: null);

    [TestMethod]
    public void Test_AddActivatedSingleton_001() => Test(nameof(_Test_AddActivatedSingleton_001));
    static void _Test_AddActivatedSingleton_001(object? services) =>
        PluginServiceCollection.AddActivatedSingleton<object, object>(services, implementationFactory: null);

    [TestMethod]
    public void Test_AddActivatedSingleton_002() =>
        Test(nameof(
            _Test_AddActivatedSingleton_002));
    static void _Test_AddActivatedSingleton_002(object? services) =>
        PluginServiceCollection.AddActivatedSingleton<object, object>(services);

    [TestMethod]
    public void Test_AddActivatedSingleton_003() =>
        Test(nameof(
            _Test_AddActivatedSingleton_003));
    static void _Test_AddActivatedSingleton_003<TService>(object? services)
        where TService : class =>
        PluginServiceCollection.AddActivatedSingleton<object>(services, implementationFactory: null);

    [TestMethod]
    public void Test_AddActivatedSingleton_004() =>
        Test(nameof(
            _Test_AddActivatedSingleton_004));
    static void _Test_AddActivatedSingleton_004(object? services) =>
        PluginServiceCollection.AddActivatedSingleton_<object>(services);

    [TestMethod]
    public void Test_AddActivatedSingleton_005() =>
        Test(nameof(
            _Test_AddActivatedSingleton_005));
    static void _Test_AddActivatedSingleton_005(object? services) =>
        PluginServiceCollection.AddActivatedSingleton(services, serviceType: null);

    [TestMethod]
    public void Test_AddActivatedSingleton_006() =>
        Test(nameof(
            _Test_AddActivatedSingleton_006));
    static void _Test_AddActivatedSingleton_006(object? services) =>
        PluginServiceCollection.AddActivatedSingleton(services, serviceType: null, implementationFactory: null);

    [TestMethod]
    public void Test_AddActivatedSingleton_007() =>
        Test(nameof(
            _Test_AddActivatedSingleton_007));
    static void _Test_AddActivatedSingleton_007(object? services) =>
        PluginServiceCollection.AddActivatedSingleton(services, serviceType: null, implementationType: null);

    [TestMethod]
    public void Test_AddActivatedSingleton_008() =>
        Test(nameof(
            _Test_AddActivatedSingleton_008));
    static void _Test_AddActivatedSingleton_008(object? services) =>
        PluginServiceCollection.AddActivatedSingleton(services, serviceType: null);

    [TestMethod]
    public void Test_TryAddActivatedSingleton_001() =>
        Test(nameof(
            _Test_TryAddActivatedSingleton_001));
    static void _Test_TryAddActivatedSingleton_001<TService>(object? services) =>
        PluginServiceCollection.TryAddActivatedSingleton(services, serviceType: null, implementationType: null);

    [TestMethod]
    public void Test_TryAddActivatedSingleton_010() =>
        Test(nameof(
            _Test_TryAddActivatedSingleton_010));
    static void _Test_TryAddActivatedSingleton_010(object? services) =>
           PluginServiceCollection.TryAddActivatedSingleton(services, serviceType: null, implementationFactory: null);

    [TestMethod]
    public void Test_TryAddActivatedSingleton_011() =>
        Test(nameof(
            _Test_TryAddActivatedSingleton_011));
    static void _Test_TryAddActivatedSingleton_011(object? services) =>
           PluginServiceCollection.TryAddActivatedSingleton_<object>(services);

    [TestMethod]
    public void Test_TryAddActivatedSingleton_012() =>
        Test(nameof(
            _Test_TryAddActivatedSingleton_012));
    static void _Test_TryAddActivatedSingleton_012(object? services) =>
           PluginServiceCollection.TryAddActivatedSingleton_<object>(services);

    [TestMethod]
    public void Test_TryAddActivatedSingleton_013() =>
        Test(nameof(
            _Test_TryAddActivatedSingleton_013));
    static void _Test_TryAddActivatedSingleton_013(object? services) =>
           PluginServiceCollection.TryAddActivatedSingleton<object>(services, implementationFactory: null);

    [TestMethod]
    public void Test_ActivateKeyedSingleton_014() =>
        Test(nameof(
            _Test_ActivateKeyedSingleton_014));
    static void _Test_ActivateKeyedSingleton_014(object? services) =>
           PluginServiceCollection.ActivateKeyedSingleton<object>(services, serviceKey: null);

    [TestMethod]
    public void Test_ActivateKeyedSingleton_015() =>
        Test(nameof(
            _Test_ActivateKeyedSingleton_015));
    static void _Test_ActivateKeyedSingleton_015(object? services) =>
           PluginServiceCollection.ActivateKeyedSingleton(services, serviceType: null, serviceKey: null);

    [TestMethod]
    public void Test_AddActivatedKeyedSingleton_016() =>
        Test(nameof(
            _Test_AddActivatedKeyedSingleton_016));
    static void _Test_AddActivatedKeyedSingleton_016(object? services) =>
           PluginServiceCollection.AddActivatedKeyedSingleton<object, object>(services, serviceKey: null, implementationFactory: null);

    [TestMethod]
    public void Test_AddActivatedKeyedSingleton_017() =>
        Test(nameof(
            _Test_AddActivatedKeyedSingleton_017));
    static void _Test_AddActivatedKeyedSingleton_017(object? services) =>
           PluginServiceCollection.AddActivatedKeyedSingleton<object>(services, serviceKey: null);

    [TestMethod]
    public void Test_AddActivatedKeyedSingleton_018() =>
        Test(nameof(
            _Test_AddActivatedKeyedSingleton_018));
    static void _Test_AddActivatedKeyedSingleton_018(object? services) =>
           PluginServiceCollection.AddActivatedKeyedSingleton<object>(services, serviceKey: null, implementationFactory: null);

    [TestMethod]
    public void Test_AddActivatedKeyedSingleton_019() =>
        Test(nameof(
            _Test_AddActivatedKeyedSingleton_019));
    static void _Test_AddActivatedKeyedSingleton_019(object? services) =>
           PluginServiceCollection.AddActivatedKeyedSingleton<object>(services, serviceKey: null);

    [TestMethod]
    public void Test_AddActivatedKeyedSingleton_020() =>
        Test(nameof(
            _Test_AddActivatedKeyedSingleton_020));
    static void _Test_AddActivatedKeyedSingleton_020(object? services) =>
           PluginServiceCollection.AddActivatedKeyedSingleton(services, serviceType: null, serviceKey: null);

    [TestMethod]
    public void Test_AddActivatedKeyedSingleton_021() =>
        Test(nameof(
            _Test_AddActivatedKeyedSingleton_021));
    static void _Test_AddActivatedKeyedSingleton_021(object? services) =>
           PluginServiceCollection.AddActivatedKeyedSingleton(services, serviceType: null, serviceKey: null, implementationFactory: null);

    [TestMethod]
    public void Test_AddActivatedKeyedSingleton_022() =>
        Test(nameof(
           _Test_AddActivatedKeyedSingleton_022));
    static void _Test_AddActivatedKeyedSingleton_022(object? services) =>
           PluginServiceCollection.AddActivatedKeyedSingleton(services, serviceType: null, serviceKey: null, implementationType: null);

    [TestMethod]
    public void Test_TryAddActivatedKeyedSingleton_023() =>
        Test(nameof(
           _Test_TryAddActivatedKeyedSingleton_023));
    static void _Test_TryAddActivatedKeyedSingleton_023(object? services) =>
           PluginServiceCollection.TryAddActivatedKeyedSingleton(services, serviceType: null, serviceKey: null);

    [TestMethod]
    public void Test_TryAddActivatedKeyedSingleton_024() =>
        Test(nameof(
            _Test_TryAddActivatedKeyedSingleton_024));
    static void _Test_TryAddActivatedKeyedSingleton_024(object? services) =>
           PluginServiceCollection.TryAddActivatedKeyedSingleton(services, serviceType: null, serviceKey: null, implementationType: null);

    [TestMethod]
    public void Test_TryAddActivatedKeyedSingleton_025() =>
        Test(nameof(
            _Test_TryAddActivatedKeyedSingleton_025));
    static void _Test_TryAddActivatedKeyedSingleton_025(object? services) =>
           PluginServiceCollection.TryAddActivatedKeyedSingleton(services, serviceType: null, serviceKey: null, implementationFactory: null);

    [TestMethod]
    public void Test_TryAddActivatedKeyedSingleton_026() =>
        Test(nameof(
            _Test_TryAddActivatedKeyedSingleton_026));
    static void _Test_TryAddActivatedKeyedSingleton_026(object? services) =>
           PluginServiceCollection.TryAddActivatedKeyedSingleton<object>(services, serviceKey: null);

    [TestMethod]
    public void Test_TryAddActivatedKeyedSingleton_027() =>
        Test(nameof(
           _Test_TryAddActivatedKeyedSingleton_027));
    static void _Test_TryAddActivatedKeyedSingleton_027(object? services) =>
           PluginServiceCollection.TryAddActivatedKeyedSingleton<object>(services, serviceKey: null);

    [TestMethod]
    public void Test_TryAddActivatedKeyedSingleton_028() =>
        Test(nameof(
           _Test_TryAddActivatedKeyedSingleton_028));
    static void _Test_TryAddActivatedKeyedSingleton_028(object? services) =>
           PluginServiceCollection.TryAddActivatedKeyedSingleton<object>(services, serviceKey: null, implementationFactory: null);
}