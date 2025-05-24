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

    static List<string> Invoked = AutoActivationExtensions.Invoked;

    [TestMethod]
    public void Test_ActivateSingleton_001() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_ActivateSingleton_001), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_ActivateSingleton_001(object? services) =>
        AutoActivationExtensions.ActivateSingleton<object>(services);


    [TestMethod]
    public void Test_ActivateSingleton_002() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_ActivateSingleton_002), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, typeof(object)]));
    static void _Test_ActivateSingleton_002(object? services, Type serviceType) =>
        AutoActivationExtensions.ActivateSingleton(services, serviceType);

    [TestMethod]
    public void Test_AddActivatedSingleton_001() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddActivatedSingleton_001), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddActivatedSingleton_001<TService, TImplementation>(object? services, Func<IServiceProvider, TImplementation> implementationFactory)
        where TService : class where TImplementation : class, TService =>
        AutoActivationExtensions.AddActivatedSingleton<TService, TImplementation>(services, implementationFactory);

    [TestMethod]
    public void Test_AddActivatedSingleton_002() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddActivatedSingleton_002), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddActivatedSingleton_002<TService, TImplementation>(object? services)
        where TService : class where TImplementation : class, TService =>
        AutoActivationExtensions.AddActivatedSingleton<TService, TImplementation>(services);

    [TestMethod]
    public void Test_AddActivatedSingleton_003() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddActivatedSingleton_003), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddActivatedSingleton_003<TService>(object? services, Func<IServiceProvider, TService> implementationFactory)
        where TService : class =>
        AutoActivationExtensions.AddActivatedSingleton<TService>(services, implementationFactory);

    [TestMethod]
    public void Test_AddActivatedSingleton_004() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddActivatedSingleton_004), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddActivatedSingleton_004(object? services, Action<object?> configure) =>
        AutoActivationExtensions.AddActivatedSingleton<object>(services);

    [TestMethod]
    public void Test_AddActivatedSingleton_005() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddActivatedSingleton_005), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddActivatedSingleton_005(object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType) =>
        AutoActivationExtensions.AddActivatedSingleton(services, serviceType);

    [TestMethod]
    public void Test_AddActivatedSingleton_006() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddActivatedSingleton_006), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddActivatedSingleton_006(object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType, Func<IServiceProvider, object> implementationFactory) =>
        AutoActivationExtensions.AddActivatedSingleton(services, serviceType, implementationFactory);

    [TestMethod]
    public void Test_AddActivatedSingleton_007() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddActivatedSingleton_007), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddActivatedSingleton_007(object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) =>
        AutoActivationExtensions.AddActivatedSingleton(services, serviceType, implementationType);

    [TestMethod]
    public void Test_AddActivatedSingleton_008() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddActivatedSingleton_008), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddActivatedSingleton_008(object? services, Type serviceType) =>
        AutoActivationExtensions.AddActivatedSingleton(services, serviceType);

    [TestMethod]
    public void Test_TryAddActivatedSingleton_001() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddActivatedSingleton_001), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_TryAddActivatedSingleton_001<TService>(object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) =>
        AutoActivationExtensions.TryAddActivatedSingleton(services, serviceType, implementationType);

    [TestMethod]
    public void Test_TryAddActivatedSingleton_010() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddActivatedSingleton_010), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_TryAddActivatedSingleton_010(object? services, Type serviceType, Func<IServiceProvider, object> implementationFactory) =>
           AutoActivationExtensions.TryAddActivatedSingleton(services, serviceType, implementationFactory);

    [TestMethod]
    public void Test_TryAddActivatedSingleton_011() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddActivatedSingleton_011), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_TryAddActivatedSingleton_011<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(object? services) where TService : class =>
           AutoActivationExtensions.TryAddActivatedSingleton<object>(services);

    [TestMethod]
    public void Test_TryAddActivatedSingleton_012() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddActivatedSingleton_012), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_TryAddActivatedSingleton_012<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services) where TService : class where TImplementation : class, TService =>
           AutoActivationExtensions.TryAddActivatedSingleton<object>(services);

    [TestMethod]
    public void Test_TryAddActivatedSingleton_013() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddActivatedSingleton_013), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_TryAddActivatedSingleton_013<TService>(object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class =>
           AutoActivationExtensions.TryAddActivatedSingleton<TService>(services, implementationFactory);

    [TestMethod]
    public void Test_ActivateKeyedSingleton_014() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_ActivateKeyedSingleton_014), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_ActivateKeyedSingleton_014<TService>(object? services, object? serviceKey) where TService : class =>
           AutoActivationExtensions.ActivateKeyedSingleton<TService>(services, serviceKey);

    [TestMethod]
    public void Test_ActivateKeyedSingleton_015() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_ActivateKeyedSingleton_015), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_ActivateKeyedSingleton_015(object? services, Type serviceType, object? serviceKey) =>
           AutoActivationExtensions.ActivateKeyedSingleton(services, serviceType, serviceKey);

    [TestMethod]
    public void Test_AddActivatedKeyedSingleton_016() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddActivatedKeyedSingleton_016), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddActivatedKeyedSingleton_016<TService, TImplementation>(object? services, object? serviceKey, Func<IServiceProvider, object?, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService =>
           AutoActivationExtensions.AddActivatedKeyedSingleton<TService, TImplementation>(services, serviceKey, implementationFactory);

    [TestMethod]
    public void Test_AddActivatedKeyedSingleton_017() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddActivatedKeyedSingleton_017), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddActivatedKeyedSingleton_017<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services, object? serviceKey) where TService : class where TImplementation : class, TService =>
           AutoActivationExtensions.AddActivatedKeyedSingleton<object>(services, serviceKey);


    [TestMethod]
    public void Test_AddActivatedKeyedSingleton_018() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddActivatedKeyedSingleton_018), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddActivatedKeyedSingleton_018<TService>(object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class =>
           AutoActivationExtensions.AddActivatedKeyedSingleton<TService>(services, serviceKey, implementationFactory);

    [TestMethod]
    public void Test_AddActivatedKeyedSingleton_019() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddActivatedKeyedSingleton_019), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddActivatedKeyedSingleton_019<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(object? services, object? serviceKey) where TService : class =>
           AutoActivationExtensions.AddActivatedKeyedSingleton<object>(services, serviceKey);

    [TestMethod]
    public void Test_AddActivatedKeyedSingleton_020() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddActivatedKeyedSingleton_020), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddActivatedKeyedSingleton_020(object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType, object? serviceKey) =>
           AutoActivationExtensions.AddActivatedKeyedSingleton(services, serviceType, serviceKey);

    [TestMethod]
    public void Test_AddActivatedKeyedSingleton_021() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddActivatedKeyedSingleton_021), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddActivatedKeyedSingleton_021(object? services, Type serviceType, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory) =>
           AutoActivationExtensions.AddActivatedKeyedSingleton(services, serviceType, serviceKey, implementationFactory);

    [TestMethod]
    public void Test_AddActivatedKeyedSingleton_022() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
           _Test_AddActivatedKeyedSingleton_022), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddActivatedKeyedSingleton_022(object? services, Type serviceType, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) =>
           AutoActivationExtensions.AddActivatedKeyedSingleton(services, serviceType, serviceKey, implementationType);

    [TestMethod]
    public void Test_TryAddActivatedKeyedSingleton_023() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
           _Test_TryAddActivatedKeyedSingleton_023), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_TryAddActivatedKeyedSingleton_023(object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType, object? serviceKey) =>
           AutoActivationExtensions.TryAddActivatedKeyedSingleton(services, serviceType, serviceKey);

    [TestMethod]
    public void Test_TryAddActivatedKeyedSingleton_024() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddActivatedKeyedSingleton_024), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_TryAddActivatedKeyedSingleton_024(object? services, Type serviceType, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) =>
           AutoActivationExtensions.TryAddActivatedKeyedSingleton(services, serviceType, serviceKey, implementationType);

    [TestMethod]
    public void Test_TryAddActivatedKeyedSingleton_025() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddActivatedKeyedSingleton_025), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_TryAddActivatedKeyedSingleton_025(object? services, Type serviceType, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory) =>
           AutoActivationExtensions.TryAddActivatedKeyedSingleton(services, serviceType, serviceKey, implementationFactory);

    [TestMethod]
    public void Test_TryAddActivatedKeyedSingleton_026() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddActivatedKeyedSingleton_026), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_TryAddActivatedKeyedSingleton_026<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(object? services, object? serviceKey) where TService : class =>
           AutoActivationExtensions.TryAddActivatedKeyedSingleton<object>(services, serviceKey);

    [TestMethod]
    public void Test_TryAddActivatedKeyedSingleton_027() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
           _Test_TryAddActivatedKeyedSingleton_027), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_TryAddActivatedKeyedSingleton_027<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services, object? serviceKey) where TService : class where TImplementation : class, TService =>
           AutoActivationExtensions.TryAddActivatedKeyedSingleton<object>(services, serviceKey);

    [TestMethod]
    public void Test_TryAddActivatedKeyedSingleton_028() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
           _Test_TryAddActivatedKeyedSingleton_028), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_TryAddActivatedKeyedSingleton_028<TService>(object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class =>
           AutoActivationExtensions.TryAddActivatedKeyedSingleton<TService>(services, serviceKey, implementationFactory);
}