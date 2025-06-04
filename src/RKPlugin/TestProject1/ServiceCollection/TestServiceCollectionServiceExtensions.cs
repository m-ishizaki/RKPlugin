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
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);
    static List<string> Invoked = ServiceCollectionServiceExtensions.Invoked;

    [TestMethod]
    public void Test_AddTransient_000() => Test(nameof(
        _Test_AddTransient_000));
    static void _Test_AddTransient_000(object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) =>
        PluginServiceCollection.AddTransient(services, serviceType, implementationType);

    [TestMethod]
    public void Test_AddTransient_001() => Test(nameof(
        _Test_AddTransient_001));
    static void _Test_AddTransient_001(object? services, Type serviceType, Func<IServiceProvider, object> implementationFactory) =>
        PluginServiceCollection.AddTransient(services, serviceType, implementationFactory);

    [TestMethod]
    public void Test_AddTransient_002() => Test(nameof(
        _Test_AddTransient_002));
    static void _Test_AddTransient_002<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services) where TService : class where TImplementation : class, TService
    => PluginServiceCollection.AddTransient<object>(services);

    [TestMethod]
    public void Test_AddTransient_003() => Test(nameof(
        _Test_AddTransient_003));
    static void _Test_AddTransient_003(object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType)
    => PluginServiceCollection.AddTransient(services, serviceType);


    [TestMethod]
    public void Test_AddTransient_004() => Test(nameof(
        _Test_AddTransient_004));
    static void _Test_AddTransient_004<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(object? services) where TService : class
    => PluginServiceCollection.AddTransient<object>(services);

    [TestMethod]
    public void Test_AddTransient_005() => Test(nameof(
        _Test_AddTransient_005));
    static void _Test_AddTransient_005<TService>(object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class
    => PluginServiceCollection.AddTransient(services, implementationFactory);

    [TestMethod]
    public void Test_AddTransient_006() => Test(nameof(
       _Test_AddTransient_006));
    static void _Test_AddTransient_006<TService, TImplementation>(object? services, Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService
    => PluginServiceCollection.AddTransient<TService, TImplementation>(services, implementationFactory);


    [TestMethod]
    public void Test_AddScoped_007() => Test(nameof(
        _Test_AddScoped_007));
    static void _Test_AddScoped_007( object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
    => PluginServiceCollection.AddScoped(services, serviceType, implementationType);

    [TestMethod]
    public void Test_AddScoped_008() => Test(nameof(
     _Test_AddScoped_008));
    static void _Test_AddScoped_008(object? services, Type serviceType, Func<IServiceProvider, object> implementationFactory)
    => PluginServiceCollection.AddScoped(services, serviceType, implementationFactory);

    [TestMethod]
    public void Test_AddScoped_009() => Test(nameof(
        _Test_AddScoped_009));
    static void _Test_AddScoped_009<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services) where TService : class where TImplementation : class, TService
    => PluginServiceCollection.AddScoped<object>(services);

    [TestMethod]
    public void Test_AddScoped_010() => Test(nameof(
        _Test_AddScoped_010));
    static void _Test_AddScoped_010(object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType)
    => PluginServiceCollection.AddScoped(services, serviceType);

    [TestMethod]
    public void Test_AddScoped_011() => Test(nameof(
       _Test_AddScoped_011));
    static void _Test_AddScoped_011<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(object? services) where TService : class
    => PluginServiceCollection.AddScoped<object>(services);

    [TestMethod]
    public void Test_AddScoped_012() => Test(nameof(
        _Test_AddScoped_012));
    static void _Test_AddScoped_012<TService>(object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class
    => PluginServiceCollection.AddScoped<TService>(services, implementationFactory);

    [TestMethod]
    public void Test_AddScoped_013() => Test(nameof(
        _Test_AddScoped_013));
    static void _Test_AddScoped_013<TService, TImplementation>(object? services, Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService
    => PluginServiceCollection.AddScoped(services, implementationFactory);

    [TestMethod]
    public void Test_AddSingleton_014() => Test(nameof(
        _Test_AddSingleton_014));
    static void _Test_AddSingleton_014(object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
    => PluginServiceCollection.AddSingleton(services, serviceType, implementationType);

    [TestMethod]
    public void Test_AddSingleton_015() => Test(nameof(
       _Test_AddSingleton_015));
    static void _Test_AddSingleton_015(object? services, Type serviceType, Func<IServiceProvider, object> implementationFactory)
    => PluginServiceCollection.AddSingleton(services, serviceType, implementationFactory);

    [TestMethod]
    public void Test_AddSingleton_016() => Test(nameof(
       _Test_AddSingleton_016));
    static void _Test_AddSingleton_016<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services) where TService : class where TImplementation : class, TService
    => PluginServiceCollection.AddSingleton<object>(services);

    [TestMethod]
    public void Test_AddSingleton_017() => Test(nameof(
       _Test_AddSingleton_017));
    static void _Test_AddSingleton_017(object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType)
    => PluginServiceCollection.AddSingleton(services, serviceType);

    [TestMethod]
    public void Test_AddSingleton_018() => Test(nameof(
        _Test_AddSingleton_018));
    static void _Test_AddSingleton_018<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(object? services) where TService : class
    => PluginServiceCollection.AddSingleton<object>(services);

    [TestMethod]
    public void Test_AddSingleton_019() => Test(nameof(
        _Test_AddSingleton_019));
    static void _Test_AddSingleton_019<TService>(object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class
    => PluginServiceCollection.AddSingleton<TService>(services, implementationFactory);

    [TestMethod]
    public void Test_AddSingleton_020() => Test(nameof(
        _Test_AddSingleton_020));
    static void _Test_AddSingleton_020<TService, TImplementation>(object? services, Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService
    => PluginServiceCollection.AddSingleton<TService, TImplementation>(services, implementationFactory);

    [TestMethod]
    public void Test_AddSingleton_021() => Test(nameof(
        _Test_AddSingleton_021));
    static void _Test_AddSingleton_021(object? services, Type serviceType, object implementationInstance)
    => PluginServiceCollection.AddSingleton(services, serviceType, implementationInstance);

    [TestMethod]
    public void Test_AddSingleton_022() =>
        Test(nameof(
            _Test_AddSingleton_022));
    static void _Test_AddSingleton_022<TService>(object? services, TService implementationInstance) where TService : class =>
        PluginServiceCollection.AddSingleton<TService>(services, implementationInstance);

}
