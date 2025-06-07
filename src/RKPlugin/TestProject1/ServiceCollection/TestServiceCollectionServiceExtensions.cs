using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestServiceCollectionServiceExtensions
{
    static Object _lock = new Object();
    void Test(string methodName) { }// TODO => Test1.Test(methodName, this, _lock, Invoked);
    static List<string> Invoked = ServiceCollectionServiceExtensions.Invoked;

    [TestMethod]
    public void Test_AddTransient_000() => Test(nameof(_Test_AddTransient_000));
    static void _Test_AddTransient_000(object? services) =>
        PluginServiceCollection.AddTransient(services, serviceType: null, implementationType: null);

    [TestMethod]
    public void Test_AddTransient_001() => Test(nameof(_Test_AddTransient_001));
    static void _Test_AddTransient_001(object? services) =>
        PluginServiceCollection.AddTransient(services, serviceType: null, implementationFactory: null);

    [TestMethod]
    public void Test_AddTransient_002() => Test(nameof(_Test_AddTransient_002));
    static void _Test_AddTransient_002(object? services)
    => PluginServiceCollection.AddTransient<object, object>(services);

    [TestMethod]
    public void Test_AddTransient_003() => Test(nameof(_Test_AddTransient_003));
    static void _Test_AddTransient_003(object? services)
    => PluginServiceCollection.AddTransient(services, serviceType: null);


    [TestMethod]
    public void Test_AddTransient_004() => Test(nameof(_Test_AddTransient_004));
    static void _Test_AddTransient_004(object? services)
    => PluginServiceCollection.AddTransient<object>(services);

    [TestMethod]
    public void Test_AddTransient_005() => Test(nameof(_Test_AddTransient_005));
    static void _Test_AddTransient_005(object? services)
    => PluginServiceCollection.AddTransient(services, implementationFactory: Test1.DummyFunc);

    [TestMethod]
    public void Test_AddTransient_006() => Test(nameof(
       _Test_AddTransient_006));
    static void _Test_AddTransient_006(object? services)
    => PluginServiceCollection.AddTransient<object, object>(services, implementationFactory: null);


    [TestMethod]
    public void Test_AddScoped_007() => Test(nameof(_Test_AddScoped_007));
    static void _Test_AddScoped_007(object? services)
    => PluginServiceCollection.AddScoped(services, serviceType: null, implementationType: null);

    [TestMethod]
    public void Test_AddScoped_008() => Test(nameof(_Test_AddScoped_008));
    static void _Test_AddScoped_008(object? services)
    => PluginServiceCollection.AddScoped(services, serviceType:null, implementationFactory:null);

    [TestMethod]
    public void Test_AddScoped_009() => Test(nameof(_Test_AddScoped_009));
    static void _Test_AddScoped_009(object? services)
    => PluginServiceCollection.AddScoped<object,object>(services);

    [TestMethod]
    public void Test_AddScoped_010() => Test(nameof(_Test_AddScoped_010));
    static void _Test_AddScoped_010(object? services)
    => PluginServiceCollection.AddScoped(services, serviceType:null);

    [TestMethod]
    public void Test_AddScoped_011() => Test(nameof(_Test_AddScoped_011));
    static void _Test_AddScoped_011(object? services)
    => PluginServiceCollection.AddScoped<object>(services);

    [TestMethod]
    public void Test_AddScoped_012() => Test(nameof(_Test_AddScoped_012));
    static void _Test_AddScoped_012(object? services)
    => PluginServiceCollection.AddScoped<object>(services, implementationFactory:null);

    [TestMethod]
    public void Test_AddScoped_013() => Test(nameof(_Test_AddScoped_013));
    static void _Test_AddScoped_013(object? services)
    => PluginServiceCollection.AddScoped<object,object>(services, implementationFactory:null);

    [TestMethod]
    public void Test_AddSingleton_014() => Test(nameof(_Test_AddSingleton_014));
    static void _Test_AddSingleton_014(object? services)
    => PluginServiceCollection.AddSingleton(services, serviceType:null, implementationType:null);

    [TestMethod]
    public void Test_AddSingleton_015() => Test(nameof(_Test_AddSingleton_015));
    static void _Test_AddSingleton_015(object? services)
    => PluginServiceCollection.AddSingleton(services, serviceType:null, implementationFactory:null);

    [TestMethod]
    public void Test_AddSingleton_016() => Test(nameof(_Test_AddSingleton_016));
    static void _Test_AddSingleton_016(object? services)
    => PluginServiceCollection.AddSingleton<object, object>(services);

    [TestMethod]
    public void Test_AddSingleton_017() => Test(nameof(_Test_AddSingleton_017));
    static void _Test_AddSingleton_017(object? services)
    => PluginServiceCollection.AddSingleton(services, serviceType:null);

    [TestMethod]
    public void Test_AddSingleton_018() => Test(nameof(_Test_AddSingleton_018));
    static void _Test_AddSingleton_018(object? services)
    => PluginServiceCollection.AddSingleton<object>(services);

    [TestMethod]
    public void Test_AddSingleton_019() => Test(nameof(_Test_AddSingleton_019));
    static void _Test_AddSingleton_019(object? services)
    => PluginServiceCollection.AddSingleton<object>(services, implementationFactory:null);

    [TestMethod]
    public void Test_AddSingleton_020() => Test(nameof(_Test_AddSingleton_020));
    static void _Test_AddSingleton_020(object? services)
    => PluginServiceCollection.AddSingleton<object, object>(services, implementationFactory:null);

    [TestMethod]
    public void Test_AddSingleton_021() => Test(nameof(_Test_AddSingleton_021));
    static void _Test_AddSingleton_021(object? services)
    => PluginServiceCollection.AddSingleton(services, serviceType:null, implementationInstance:null);

    [TestMethod]
    public void Test_AddSingleton_022() => Test(nameof(_Test_AddSingleton_022));
    static void _Test_AddSingleton_022(object? services) =>
        PluginServiceCollection.AddSingleton<object>(services, implementationInstance:null);
}
