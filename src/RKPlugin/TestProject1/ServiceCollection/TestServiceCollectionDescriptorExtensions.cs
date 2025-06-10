using Microsoft.Extensions.DependencyInjection.Extensions;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestServiceCollectionDescriptorExtensions
{
    static Object _lock = new Object();
    //void Test(string methodName) { }// TODO => Test1.Test(methodName, this, _lock, Invoked);
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);
    static List<string> Invoked = ServiceCollectionDescriptorExtensions.Invoked;

    [TestMethod]
    public void Test_Add_001() => Test(nameof(_Test_Add_001));
    static void _Test_Add_001(object? collection)
        => PluginServiceCollection.Add(collection, descriptor: null);

    [TestMethod]
    public void Test_Add_002() => Test(nameof(_Test_Add_002));
    static void _Test_Add_002(object? collection)
        => PluginServiceCollection.Add(collection, descriptors: Enumerable.Empty<object>());

    [TestMethod]
    public void Test_RemoveAll_003() => Test(nameof(_Test_RemoveAll_003));
    static void _Test_RemoveAll_003(object? collection)
        => PluginServiceCollection.RemoveAll(collection, serviceType: null);

    [TestMethod]
    public void Test_RemoveAll_004() => Test(nameof(_Test_RemoveAll_004));
    static void _Test_RemoveAll_004(object? collection)
        => PluginServiceCollection.RemoveAll_<object>(collection);

    [TestMethod]
    public void Test_RemoveAllKeyed_005() => Test(nameof(_Test_RemoveAllKeyed_005));
    static void _Test_RemoveAllKeyed_005(object? collection)
        => PluginServiceCollection.RemoveAllKeyed<object>(collection, serviceKey: null);

    [TestMethod]
    public void Test_RemoveAllKeyed_006() =>
        Test(nameof(
            _Test_RemoveAllKeyed_006));
    static void _Test_RemoveAllKeyed_006(object? collection)
        => PluginServiceCollection.RemoveAllKeyed(collection, serviceType: null, serviceKey: null);

    [TestMethod]
    public void Test_Replace_007() =>
        Test(nameof(
            _Test_Replace_007));
    static void _Test_Replace_007(object? collection)
        => PluginServiceCollection.Replace(collection, descriptor: null);

    [TestMethod]
    public void Test_TryAdd_008() =>
        Test(nameof(
            _Test_TryAdd_008));
    static void _Test_TryAdd_008(object? collection)
        => PluginServiceCollection.TryAdd(collection, descriptor: null);

    [TestMethod]
    public void Test_TryAdd_009() =>
        Test(nameof(
            _Test_TryAdd_009));
    static void _Test_TryAdd_009(object? collection)
        => PluginServiceCollection.TryAdd(collection, descriptors: Test1.Enumerable);

    [TestMethod]
    public void Test_TryAddEnumerable_011() =>
        Test(nameof(
            _Test_TryAddEnumerable_011));
    static void _Test_TryAddEnumerable_011(object? services)
        => PluginServiceCollection.TryAddEnumerable_(services, descriptors: Test1.Enumerable);

    [TestMethod]
    public void Test_TryAddKeyedScoped_012() => Test(nameof(_Test_TryAddKeyedScoped_012));
    static void _Test_TryAddKeyedScoped_012(object? collection)
        => PluginServiceCollection.TryAddKeyedScoped<object>(collection, serviceKey: null);

    [TestMethod]
    public void Test_TryAddKeyedScoped_013() => Test(nameof(_Test_TryAddKeyedScoped_013));
    static void _Test_TryAddKeyedScoped_013(object? services)
        => PluginServiceCollection.TryAddKeyedScoped_<object>(services, serviceKey: null, implementationFactory: null);

    [TestMethod]
    public void Test_TryAddKeyedScoped_015() => Test(nameof(_Test_TryAddKeyedScoped_015));
    static void _Test_TryAddKeyedScoped_015(object? collection)
        => PluginServiceCollection.TryAddKeyedScoped(collection, service: null, serviceKey: null, implementationFactory: null);

    [TestMethod]
    public void Test_TryAddKeyedScoped_016() => Test(nameof(_Test_TryAddKeyedScoped_016));
    static void _Test_TryAddKeyedScoped_016(object? collection)
        => PluginServiceCollection.TryAddKeyedScoped(collection, service: null, serviceKey: null, implementationType: null);

    [TestMethod]
    public void Test_TryAddKeyedScoped_017() => Test(nameof(_Test_TryAddKeyedScoped_017));
    static void _Test_TryAddKeyedScoped_017(object? collection)
        => PluginServiceCollection.TryAddKeyedScoped(collection, service: null, serviceKey: null);

    [TestMethod]
    public void Test_TryAddKeyedSingleton_018() => Test(nameof(_Test_TryAddKeyedSingleton_018));
    static void _Test_TryAddKeyedSingleton_018(object? services)
        => PluginServiceCollection.TryAddKeyedSingleton_<object>(services, serviceKey: "", implementationFactory: null);

    [TestMethod]
    public void Test_TryAddKeyedSingleton_019() => Test(nameof(_Test_TryAddKeyedSingleton_019));
    static void _Test_TryAddKeyedSingleton_019(object? collection)
        => PluginServiceCollection.TryAddKeyedSingleton<object>(collection, serviceKey: null, instance: null);

    [TestMethod]
    public void Test_TryAddKeyedSingleton_020() => Test(nameof(_Test_TryAddKeyedSingleton_020));
    static void _Test_TryAddKeyedSingleton_020(object? collection)
        => PluginServiceCollection.TryAddKeyedSingleton<object>(collection, serviceKey: null);

    [TestMethod]
    public void Test_TryAddKeyedSingleton_022() => Test(nameof(_Test_TryAddKeyedSingleton_022));
    static void _Test_TryAddKeyedSingleton_022(object? collection)
        => PluginServiceCollection.TryAddKeyedSingleton(collection, service: null, serviceKey: null, implementationFactory: null);

    [TestMethod]
    public void Test_TryAddKeyedSingleton_023() => Test(nameof(_Test_TryAddKeyedSingleton_023));
    static void _Test_TryAddKeyedSingleton_023(object? collection)
        => PluginServiceCollection.TryAddKeyedSingleton(collection, service: null, serviceKey: null, implementationType: null);

    [TestMethod]
    public void Test_TryAddKeyedSingleton_024() => Test(nameof(_Test_TryAddKeyedSingleton_024));
    static void _Test_TryAddKeyedSingleton_024(object? collection)
        => PluginServiceCollection.TryAddKeyedSingleton(collection, service: null, serviceKey: null);

    [TestMethod]
    public void Test_TryAddKeyedTransient_025() => Test(nameof(_Test_TryAddKeyedTransient_025));
    static void _Test_TryAddKeyedTransient_025(object? collection)
        => PluginServiceCollection.TryAddKeyedTransient<object>(collection, serviceKey: null);

    [TestMethod]
    public void Test_TryAddKeyedTransient_026() => Test(nameof(_Test_TryAddKeyedTransient_026));
    static void _Test_TryAddKeyedTransient_026(object? collection)
        => PluginServiceCollection.TryAddKeyedTransient<object, object>(collection, serviceKey: null);

    [TestMethod]
    public void Test_TryAddKeyedTransient_027() => Test(nameof(_Test_TryAddKeyedTransient_027));
    static void _Test_TryAddKeyedTransient_027(object? collection)
        => PluginServiceCollection.TryAddKeyedTransient(collection, service: null, serviceKey: null, implementationType: null);

    [TestMethod]
    public void Test_TryAddKeyedTransient_028() => Test(nameof(_Test_TryAddKeyedTransient_028));
    static void _Test_TryAddKeyedTransient_028(object? collection)
        => PluginServiceCollection.TryAddKeyedTransient(collection, service: null, serviceKey: null);

    [TestMethod]
    public void Test_TryAddKeyedTransient_029() => Test(nameof(_Test_TryAddKeyedTransient_029));
    static void _Test_TryAddKeyedTransient_029(object? services)
        => PluginServiceCollection.TryAddKeyedTransient_<object>(services, serviceKey: null, implementationFactory: null);

    [TestMethod]
    public void Test_TryAddKeyedTransient_030() => Test(nameof(_Test_TryAddKeyedTransient_030));
    static void _Test_TryAddKeyedTransient_030(object? collection)
        => PluginServiceCollection.TryAddKeyedTransient(collection, service: null, serviceKey: null, implementationFactory: null);

    [TestMethod]
    public void Test_TryAddScoped_031() =>
        Test(nameof(
            _Test_TryAddScoped_031));
    static void _Test_TryAddScoped_031(object? collection)
        => PluginServiceCollection.TryAddScoped(collection, service: null, implementationType: null);

    [TestMethod]
    public void Test_TryAddScoped_032() =>
        Test(nameof(
            _Test_TryAddScoped_032));
    static void _Test_TryAddScoped_032(object? collection)
        => PluginServiceCollection.TryAddScoped(collection, service: null, implementationFactory: null);

    [TestMethod]
    public void Test_TryAddScoped_033() =>
        Test(nameof(
            _Test_TryAddScoped_033));
    static void _Test_TryAddScoped_033(object? collection)
        => PluginServiceCollection.TryAddScoped_<object>(collection);

    [TestMethod]
    public void Test_TryAddScoped_034() =>
        Test(nameof(
            _Test_TryAddScoped_034));
    static void _Test_TryAddScoped_034(object? collection)
        => PluginServiceCollection.TryAddScoped_<object, object>(collection);

    [TestMethod]
    public void Test_TryAddScoped_035() =>
        Test(nameof(
            _Test_TryAddScoped_035));
    static void _Test_TryAddScoped_035(object? services)
        => PluginServiceCollection.TryAddScoped_<object>(services, implementationFactory: null);

    [TestMethod]
    public void Test_TryAddScoped_036() =>
        Test(nameof(
            _Test_TryAddScoped_036));
    static void _Test_TryAddScoped_036(object? collection)
        => PluginServiceCollection.TryAddScoped(collection, service: null);

    [TestMethod]
    public void Test_TryAddSingleton_037() =>
        Test(nameof(
            _Test_TryAddSingleton_037));
    static void _Test_TryAddSingleton_037(object? collection)
        => PluginServiceCollection.TryAddSingleton_<object>(collection);

    [TestMethod]
    public void Test_TryAddSingleton_038() =>
        Test(nameof(
            _Test_TryAddSingleton_038));
    static void _Test_TryAddSingleton_038(object? services)
        => PluginServiceCollection.TryAddSingleton_<object>(services, implementationFactory: null);

    [TestMethod]
    public void Test_TryAddSingleton_039() =>
        Test(nameof(
            _Test_TryAddSingleton_039));
    static void _Test_TryAddSingleton_039(object? collection)
        => PluginServiceCollection.TryAddSingleton<object>(collection, instance: null);

    [TestMethod]
    public void Test_TryAddSingleton_040() =>
        Test(nameof(
            _Test_TryAddSingleton_040));
    static void _Test_TryAddSingleton_040(object? collection)
        => PluginServiceCollection.TryAddSingleton_<object, object>(collection);

    [TestMethod]
    public void Test_TryAddSingleton_041() =>
        Test(nameof(
            _Test_TryAddSingleton_041));
    static void _Test_TryAddSingleton_041(object? collection)
        => PluginServiceCollection.TryAddSingleton(collection, service: null, implementationFactory: null);

    [TestMethod]
    public void Test_TryAddSingleton_042() =>
        Test(nameof(
            _Test_TryAddSingleton_042));
    static void _Test_TryAddSingleton_042(object? collection)
        => PluginServiceCollection.TryAddSingleton(collection, service: null, implementationType: null);

    [TestMethod]
    public void Test_TryAddSingleton_043() =>
        Test(nameof(
            _Test_TryAddSingleton_043));
    static void _Test_TryAddSingleton_043(object? collection)
        => PluginServiceCollection.TryAddSingleton(collection, service: null);

    [TestMethod]
    public void Test_TryAddTransient_044() =>
        Test(nameof(
            _Test_TryAddTransient_044));
    static void _Test_TryAddTransient_044(object? collection)
        => PluginServiceCollection.TryAddTransient(collection, service: null, implementationType: null);

    [TestMethod]
    public void Test_TryAddTransient_045() =>
        Test(nameof(
            _Test_TryAddTransient_045));
    static void _Test_TryAddTransient_045(object? collection)
        => PluginServiceCollection.TryAddTransient(collection, service: null);

    [TestMethod]
    public void Test_TryAddTransient_046() =>
        Test(nameof(
            _Test_TryAddTransient_046));
    static void _Test_TryAddTransient_046(object? collection)
        => PluginServiceCollection.TryAddTransient_<object, object>(collection);

    [TestMethod]
    public void Test_TryAddTransient_047() =>
        Test(nameof(
            _Test_TryAddTransient_047));
    static void _Test_TryAddTransient_047(object? collection)
        => PluginServiceCollection.TryAddTransient_<object>(collection);

    [TestMethod]
    public void Test_TryAddTransient_048() =>
        Test(nameof(
            _Test_TryAddTransient_048));
    static void _Test_TryAddTransient_048(object? services)
        => PluginServiceCollection.TryAddTransient_<object>(services, implementationFactory: null);

    [TestMethod]
    public void Test_TryAddTransient_049() => Test(nameof(_Test_TryAddTransient_049));
    static void _Test_TryAddTransient_049(object? collection)
            => PluginServiceCollection.TryAddTransient(collection, service: null, implementationFactory: null);
}