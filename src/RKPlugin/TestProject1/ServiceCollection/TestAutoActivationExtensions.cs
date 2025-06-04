using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using RkSoftware.RKPlugin.DependencyInjection.Internals;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

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
    static void _Test_ActivateSingleton_002(object? services, Type serviceType) =>
        PluginServiceCollection.ActivateSingleton(services, serviceType);

    [TestMethod]
    public void Test_AddActivatedSingleton_001() => Test(nameof(_Test_AddActivatedSingleton_001));
    static void _Test_AddActivatedSingleton_001<TService, TImplementation>(object? services, Func<IServiceProvider, TImplementation> implementationFactory)
        where TService : class where TImplementation : class, TService =>
        PluginServiceCollection.AddActivatedSingleton<TService, TImplementation>(services, implementationFactory);

    [TestMethod]
    public void Test_AddActivatedSingleton_002() =>
        Test(nameof(
            _Test_AddActivatedSingleton_002));
    static void _Test_AddActivatedSingleton_002<TService, TImplementation>(object? services)
        where TService : class where TImplementation : class, TService =>
        PluginServiceCollection.AddActivatedSingleton<TService, TImplementation>(services);

    [TestMethod]
    public void Test_AddActivatedSingleton_003() =>
        Test(nameof(
            _Test_AddActivatedSingleton_003));
    static void _Test_AddActivatedSingleton_003<TService>(object? services, Func<IServiceProvider, TService> implementationFactory)
        where TService : class =>
        PluginServiceCollection.AddActivatedSingleton<TService>(services, implementationFactory);

    [TestMethod]
    public void Test_AddActivatedSingleton_004() =>
        Test(nameof(
            _Test_AddActivatedSingleton_004));
    static void _Test_AddActivatedSingleton_004(object? services, Action<object?> configure) =>
        PluginServiceCollection.AddActivatedSingleton_<object>(services);

    [TestMethod]
    public void Test_AddActivatedSingleton_005() =>
        Test(nameof(
            _Test_AddActivatedSingleton_005));
    static void _Test_AddActivatedSingleton_005(object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType) =>
        PluginServiceCollection.AddActivatedSingleton(services, serviceType);

    [TestMethod]
    public void Test_AddActivatedSingleton_006() =>
        Test(nameof(
            _Test_AddActivatedSingleton_006));
    static void _Test_AddActivatedSingleton_006(object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType, Func<IServiceProvider, object> implementationFactory) =>
        PluginServiceCollection.AddActivatedSingleton(services, serviceType, implementationFactory);

    [TestMethod]
    public void Test_AddActivatedSingleton_007() =>
        Test(nameof(
            _Test_AddActivatedSingleton_007));
    static void _Test_AddActivatedSingleton_007(object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) =>
        PluginServiceCollection.AddActivatedSingleton(services, serviceType, implementationType);

    [TestMethod]
    public void Test_AddActivatedSingleton_008() =>
        Test(nameof(
            _Test_AddActivatedSingleton_008));
    static void _Test_AddActivatedSingleton_008(object? services, Type serviceType) =>
        PluginServiceCollection.AddActivatedSingleton(services, serviceType);

    [TestMethod]
    public void Test_TryAddActivatedSingleton_001() =>
        Test(nameof(
            _Test_TryAddActivatedSingleton_001));
    static void _Test_TryAddActivatedSingleton_001<TService>(object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) =>
        PluginServiceCollection.TryAddActivatedSingleton(services, serviceType, implementationType);

    [TestMethod]
    public void Test_TryAddActivatedSingleton_010() =>
        Test(nameof(
            _Test_TryAddActivatedSingleton_010));
    static void _Test_TryAddActivatedSingleton_010(object? services, Type serviceType, Func<IServiceProvider, object> implementationFactory) =>
           PluginServiceCollection.TryAddActivatedSingleton(services, serviceType, implementationFactory);

    [TestMethod]
    public void Test_TryAddActivatedSingleton_011() =>
        Test(nameof(
            _Test_TryAddActivatedSingleton_011));
    static void _Test_TryAddActivatedSingleton_011<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(object? services) where TService : class =>
           PluginServiceCollection.TryAddActivatedSingleton_<object>(services);

    [TestMethod]
    public void Test_TryAddActivatedSingleton_012() =>
        Test(nameof(
            _Test_TryAddActivatedSingleton_012));
    static void _Test_TryAddActivatedSingleton_012<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services) where TService : class where TImplementation : class, TService =>
           PluginServiceCollection.TryAddActivatedSingleton_<object>(services);

    [TestMethod]
    public void Test_TryAddActivatedSingleton_013() =>
        Test(nameof(
            _Test_TryAddActivatedSingleton_013));
    static void _Test_TryAddActivatedSingleton_013<TService>(object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class =>
           PluginServiceCollection.TryAddActivatedSingleton<TService>(services, implementationFactory);

    [TestMethod]
    public void Test_ActivateKeyedSingleton_014() =>
        Test(nameof(
            _Test_ActivateKeyedSingleton_014));
    static void _Test_ActivateKeyedSingleton_014<TService>(object? services, object? serviceKey) where TService : class =>
           PluginServiceCollection.ActivateKeyedSingleton<TService>(services, serviceKey);

    [TestMethod]
    public void Test_ActivateKeyedSingleton_015() =>
        Test(nameof(
            _Test_ActivateKeyedSingleton_015));
    static void _Test_ActivateKeyedSingleton_015(object? services, Type serviceType, object? serviceKey) =>
           PluginServiceCollection.ActivateKeyedSingleton(services, serviceType, serviceKey);

    [TestMethod]
    public void Test_AddActivatedKeyedSingleton_016() =>
        Test(nameof(
            _Test_AddActivatedKeyedSingleton_016));
    static void _Test_AddActivatedKeyedSingleton_016<TService, TImplementation>(object? services, object? serviceKey, Func<IServiceProvider, object?, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService =>
           PluginServiceCollection.AddActivatedKeyedSingleton<TService, TImplementation>(services, serviceKey, implementationFactory);

    [TestMethod]
    public void Test_AddActivatedKeyedSingleton_017() =>
        Test(nameof(
            _Test_AddActivatedKeyedSingleton_017));
    static void _Test_AddActivatedKeyedSingleton_017<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services, object? serviceKey) where TService : class where TImplementation : class, TService =>
           PluginServiceCollection.AddActivatedKeyedSingleton<object>(services, serviceKey);


    [TestMethod]
    public void Test_AddActivatedKeyedSingleton_018() =>
        Test(nameof(
            _Test_AddActivatedKeyedSingleton_018));
    static void _Test_AddActivatedKeyedSingleton_018<TService>(object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class =>
           PluginServiceCollection.AddActivatedKeyedSingleton<TService>(services, serviceKey, implementationFactory);

    [TestMethod]
    public void Test_AddActivatedKeyedSingleton_019() =>
        Test(nameof(
            _Test_AddActivatedKeyedSingleton_019));
    static void _Test_AddActivatedKeyedSingleton_019<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(object? services, object? serviceKey) where TService : class =>
           PluginServiceCollection.AddActivatedKeyedSingleton<object>(services, serviceKey);

    [TestMethod]
    public void Test_AddActivatedKeyedSingleton_020() =>
        Test(nameof(
            _Test_AddActivatedKeyedSingleton_020));
    static void _Test_AddActivatedKeyedSingleton_020(object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType, object? serviceKey) =>
           PluginServiceCollection.AddActivatedKeyedSingleton(services, serviceType, serviceKey);

    [TestMethod]
    public void Test_AddActivatedKeyedSingleton_021() =>
        Test(nameof(
            _Test_AddActivatedKeyedSingleton_021));
    static void _Test_AddActivatedKeyedSingleton_021(object? services, Type serviceType, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory) =>
           PluginServiceCollection.AddActivatedKeyedSingleton(services, serviceType, serviceKey, implementationFactory);

    [TestMethod]
    public void Test_AddActivatedKeyedSingleton_022() =>
        Test(nameof(
           _Test_AddActivatedKeyedSingleton_022));
    static void _Test_AddActivatedKeyedSingleton_022(object? services, Type serviceType, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) =>
           PluginServiceCollection.AddActivatedKeyedSingleton(services, serviceType, serviceKey, implementationType);

    [TestMethod]
    public void Test_TryAddActivatedKeyedSingleton_023() =>
        Test(nameof(
           _Test_TryAddActivatedKeyedSingleton_023));
    static void _Test_TryAddActivatedKeyedSingleton_023(object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType, object? serviceKey) =>
           PluginServiceCollection.TryAddActivatedKeyedSingleton(services, serviceType, serviceKey);

    [TestMethod]
    public void Test_TryAddActivatedKeyedSingleton_024() =>
        Test(nameof(
            _Test_TryAddActivatedKeyedSingleton_024));
    static void _Test_TryAddActivatedKeyedSingleton_024(object? services, Type serviceType, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) =>
           PluginServiceCollection.TryAddActivatedKeyedSingleton(services, serviceType, serviceKey, implementationType);

    [TestMethod]
    public void Test_TryAddActivatedKeyedSingleton_025() =>
        Test(nameof(
            _Test_TryAddActivatedKeyedSingleton_025));
    static void _Test_TryAddActivatedKeyedSingleton_025(object? services, Type serviceType, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory) =>
           PluginServiceCollection.TryAddActivatedKeyedSingleton(services, serviceType, serviceKey, implementationFactory);

    [TestMethod]
    public void Test_TryAddActivatedKeyedSingleton_026() =>
        Test(nameof(
            _Test_TryAddActivatedKeyedSingleton_026));
    static void _Test_TryAddActivatedKeyedSingleton_026<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(object? services, object? serviceKey) where TService : class =>
           PluginServiceCollection.TryAddActivatedKeyedSingleton<object>(services, serviceKey);

    [TestMethod]
    public void Test_TryAddActivatedKeyedSingleton_027() =>
        Test(nameof(
           _Test_TryAddActivatedKeyedSingleton_027));
    static void _Test_TryAddActivatedKeyedSingleton_027<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services, object? serviceKey) where TService : class where TImplementation : class, TService =>
           PluginServiceCollection.TryAddActivatedKeyedSingleton<object>(services, serviceKey);

    [TestMethod]
    public void Test_TryAddActivatedKeyedSingleton_028() =>
        Test(nameof(
           _Test_TryAddActivatedKeyedSingleton_028));
    static void _Test_TryAddActivatedKeyedSingleton_028<TService>(object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class =>
           PluginServiceCollection.TryAddActivatedKeyedSingleton<TService>(services, serviceKey, implementationFactory);
}