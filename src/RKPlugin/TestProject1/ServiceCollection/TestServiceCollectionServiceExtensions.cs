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

    static List<string> Invoked = ServiceCollectionServiceExtensions.Invoked;

    [TestMethod]
    public void Test_AddTransient_000() => Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _Test_AddTransient_000), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddTransient_000(object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType) =>
        PluginServiceCollection.AddTransient(services, serviceType, implementationType);

    [TestMethod]
    public void Test_AddTransient_001() => Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _Test_AddTransient_001), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddTransient_001(object? services, Type serviceType, Func<IServiceProvider, object> implementationFactory) =>
        PluginServiceCollection.AddTransient(services, serviceType, implementationFactory);

    [TestMethod]
    public void Test_AddTransient_002() => Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _Test_AddTransient_002), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddTransient_002<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services) where TService : class where TImplementation : class, TService
    => PluginServiceCollection.AddTransient<object>(services);

    [TestMethod]
    public void Test_AddTransient_003() => Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _Test_AddTransient_003), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddTransient_003(object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType)
    => PluginServiceCollection.AddTransient(services, serviceType);


    [TestMethod]
    public void Test_AddTransient_004() => Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _Test_AddTransient_004), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddTransient_004<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(object? services) where TService : class
    => PluginServiceCollection.AddTransient<object>(services);

    [TestMethod]
    public void Test_AddTransient_005() => Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _Test_AddTransient_005), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddTransient_005<TService>(object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class
    => PluginServiceCollection.AddTransient(services, implementationFactory);

    [TestMethod]
    public void Test_AddTransient_006() => Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
       _Test_AddTransient_006), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddTransient_006<TService, TImplementation>(object? services, Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService
    => PluginServiceCollection.AddTransient<TService, TImplementation>(services, implementationFactory);


    [TestMethod]
    public void Test_AddScoped_007() => Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _Test_AddScoped_007), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddScoped_007( object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
    => PluginServiceCollection.AddScoped(services, serviceType, implementationType);

    [TestMethod]
    public void Test_AddScoped_008() => Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
     _Test_AddScoped_008), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddScoped_008(object? services, Type serviceType, Func<IServiceProvider, object> implementationFactory)
    => PluginServiceCollection.AddScoped(services, serviceType, implementationFactory);

    [TestMethod]
    public void Test_AddScoped_009() => Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _Test_AddScoped_009), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddScoped_009<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services) where TService : class where TImplementation : class, TService
    => PluginServiceCollection.AddScoped<object>(services);

    [TestMethod]
    public void Test_AddScoped_010() => Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _Test_AddScoped_010), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddScoped_010(object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType)
    => PluginServiceCollection.AddScoped(services, serviceType);

    [TestMethod]
    public void Test_AddScoped_011() => Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
       _Test_AddScoped_011), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddScoped_011<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(object? services) where TService : class
    => PluginServiceCollection.AddScoped<object>(services);

    [TestMethod]
    public void Test_AddScoped_012() => Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _Test_AddScoped_012), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddScoped_012<TService>(object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class
    => PluginServiceCollection.AddScoped<TService>(services, implementationFactory);

    [TestMethod]
    public void Test_AddScoped_013() => Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _Test_AddScoped_013), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddScoped_013<TService, TImplementation>(object? services, Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService
    => PluginServiceCollection.AddScoped(services, implementationFactory);

    [TestMethod]
    public void Test_AddSingleton_014() => Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _Test_AddSingleton_014), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddSingleton_014(object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
    => PluginServiceCollection.AddSingleton(services, serviceType, implementationType);

    [TestMethod]
    public void Test_AddSingleton_015() => Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
       _Test_AddSingleton_015), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddSingleton_015(object? services, Type serviceType, Func<IServiceProvider, object> implementationFactory)
    => PluginServiceCollection.AddSingleton(services, serviceType, implementationFactory);

    [TestMethod]
    public void Test_AddSingleton_016() => Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
       _Test_AddSingleton_016), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddSingleton_016<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? services) where TService : class where TImplementation : class, TService
    => PluginServiceCollection.AddSingleton<object>(services);

    [TestMethod]
    public void Test_AddSingleton_017() => Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
       _Test_AddSingleton_017), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddSingleton_017(object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType)
    => PluginServiceCollection.AddSingleton(services, serviceType);

    [TestMethod]
    public void Test_AddSingleton_018() => Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _Test_AddSingleton_018), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddSingleton_018<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(object? services) where TService : class
    => PluginServiceCollection.AddSingleton<object>(services);

    [TestMethod]
    public void Test_AddSingleton_019() => Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _Test_AddSingleton_019), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddSingleton_019<TService>(object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class
    => PluginServiceCollection.AddSingleton<TService>(services, implementationFactory);

    [TestMethod]
    public void Test_AddSingleton_020() => Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _Test_AddSingleton_020), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddSingleton_020<TService, TImplementation>(object? services, Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService
    => PluginServiceCollection.AddSingleton<TService, TImplementation>(services, implementationFactory);

    [TestMethod]
    public void Test_AddSingleton_021() => Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
        _Test_AddSingleton_021), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddSingleton_021(object? services, Type serviceType, object implementationInstance)
    => PluginServiceCollection.AddSingleton(services, serviceType, implementationInstance);

    [TestMethod]
    public void Test_AddSingleton_022() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddSingleton_022), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddSingleton_022<TService>(object? services, TService implementationInstance) where TService : class =>
        PluginServiceCollection.AddSingleton<TService>(services, implementationInstance);

}
