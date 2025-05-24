using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using RkSoftware.RKPlugin.DependencyInjection.Internals;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestServiceCollectionDescriptorExtensions
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

    static List<string> Invoked = ServiceCollectionDescriptorExtensions.Invoked;

    [TestMethod]
    public void Test_Add_001() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_Add_001), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_Add_001( object? collection, object? descriptor)
        => ServiceCollectionDescriptorExtensions.Add(collection, descriptor);

    [TestMethod]
    public void Test_Add_002() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_Add_002), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_Add_002( object? collection, IEnumerable<object?> descriptors)
        => ServiceCollectionDescriptorExtensions.Add(collection, descriptors);

    [TestMethod]
    public void Test_RemoveAll_003() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_RemoveAll_003), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_RemoveAll_003( object? collection, Type serviceType)
        => ServiceCollectionDescriptorExtensions.RemoveAll(collection, serviceType);

    [TestMethod]
    public void Test_RemoveAll_004() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_RemoveAll_004), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_RemoveAll_004<T>( object? collection)
        => ServiceCollectionDescriptorExtensions.RemoveAll<object>(collection);

    [TestMethod]
    public void Test_RemoveAllKeyed_005() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_RemoveAllKeyed_005), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_RemoveAllKeyed_005<T>( object? collection, object? serviceKey)
        => ServiceCollectionDescriptorExtensions.RemoveAllKeyed<object>(collection, serviceKey);

    [TestMethod]
    public void Test_RemoveAllKeyed_006() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_RemoveAllKeyed_006), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_RemoveAllKeyed_006( object? collection, Type serviceType, object? serviceKey)
        => ServiceCollectionDescriptorExtensions.RemoveAllKeyed(collection, serviceType, serviceKey);

    [TestMethod]
    public void Test_Replace_007() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_Replace_007), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_Replace_007( object? collection, object? descriptor)
        => ServiceCollectionDescriptorExtensions.Replace(collection, descriptor);

    [TestMethod]
    public void Test_TryAdd_008() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAdd_008), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_TryAdd_008( object? collection, object? descriptor)
        => ServiceCollectionDescriptorExtensions.TryAdd(collection, descriptor);

    [TestMethod]
    public void Test_TryAdd_009() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAdd_009), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_TryAdd_009( object? collection, IEnumerable<object?> descriptors)
        => ServiceCollectionDescriptorExtensions.TryAdd(collection, descriptors);

    [TestMethod]
    public void Test_TryAddEnumerable_011() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddEnumerable_011), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_TryAddEnumerable_011( object? services, IEnumerable<object?> descriptors)
        => ServiceCollectionDescriptorExtensions.TryAddEnumerable(services, descriptors);

    [TestMethod]
    public void Test_TryAddKeyedScoped_012() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddKeyedScoped_012), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_TryAddKeyedScoped_012<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>( object? collection, object? serviceKey) where TService : class where TImplementation : class, TService
        => ServiceCollectionDescriptorExtensions.TryAddKeyedScoped<object>(collection, serviceKey);

    [TestMethod]
    public void Test_TryAddKeyedScoped_013() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddKeyedScoped_013), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_TryAddKeyedScoped_013<TService>( object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class
        => ServiceCollectionDescriptorExtensions.TryAddKeyedScoped<TService>(services, serviceKey, implementationFactory);

    [TestMethod]
    public void Test_TryAddKeyedScoped_014() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddKeyedScoped_014), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_TryAddKeyedScoped_014<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>( object? collection, object? serviceKey) where TService : class
        => ServiceCollectionDescriptorExtensions.TryAddKeyedScoped<object>(collection, serviceKey);

    [TestMethod]
    public void Test_TryAddKeyedScoped_015() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddKeyedScoped_015), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_TryAddKeyedScoped_015( object? collection, Type service, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory)
        => ServiceCollectionDescriptorExtensions.TryAddKeyedScoped(collection, service, serviceKey, implementationFactory);

    [TestMethod]
    public void Test_TryAddKeyedScoped_016() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddKeyedScoped_016), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_TryAddKeyedScoped_016( object? collection, Type service, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
        => ServiceCollectionDescriptorExtensions.TryAddKeyedScoped(collection, service, serviceKey, implementationType);

    [TestMethod]
    public void Test_TryAddKeyedScoped_017() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddKeyedScoped_017), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_TryAddKeyedScoped_017( object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service, object? serviceKey)
        => ServiceCollectionDescriptorExtensions.TryAddKeyedScoped(collection, service, serviceKey);

    [TestMethod]
    public void Test_TryAddKeyedSingleton_018() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddKeyedSingleton_018), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_TryAddKeyedSingleton_018<TService>( object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class
        => ServiceCollectionDescriptorExtensions.TryAddKeyedSingleton<object>(services, serviceKey, implementationFactory);

    [TestMethod]
    public void Test_TryAddKeyedSingleton_019() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddKeyedSingleton_019), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_TryAddKeyedSingleton_019<TService>( object? collection, object? serviceKey, TService instance) where TService : class
        => ServiceCollectionDescriptorExtensions.TryAddKeyedSingleton<object>(collection, serviceKey, instance);

    [TestMethod]
    public void Test_TryAddKeyedSingleton_020() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddKeyedSingleton_020), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_TryAddKeyedSingleton_020<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>( object? collection, object? serviceKey) where TService : class where TImplementation : class, TService
        => ServiceCollectionDescriptorExtensions.TryAddKeyedSingleton<object>(collection, serviceKey);

    [TestMethod]
    public void Test_TryAddKeyedSingleton_021() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddKeyedSingleton_021), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_TryAddKeyedSingleton_021<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>( object? collection, object? serviceKey) where TService : class
        => ServiceCollectionDescriptorExtensions.TryAddKeyedSingleton<object>(collection, serviceKey);

    [TestMethod]
    public void Test_TryAddKeyedSingleton_022() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddKeyedSingleton_022), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_TryAddKeyedSingleton_022( object? collection, Type service, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory)
        => ServiceCollectionDescriptorExtensions.TryAddKeyedSingleton(collection, service, serviceKey, implementationFactory);

    [TestMethod]
    public void Test_TryAddKeyedSingleton_023() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddKeyedSingleton_023), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_TryAddKeyedSingleton_023( object? collection, Type service, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
        => ServiceCollectionDescriptorExtensions.TryAddKeyedSingleton(collection, service, serviceKey, implementationType);

    [TestMethod]
    public void Test_TryAddKeyedSingleton_024() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddKeyedSingleton_024), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_TryAddKeyedSingleton_024( object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service, object? serviceKey)
        => ServiceCollectionDescriptorExtensions.TryAddKeyedSingleton(collection, service, serviceKey);

    [TestMethod]
    public void Test_TryAddKeyedTransient_025() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddKeyedTransient_025), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_TryAddKeyedTransient_025<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>( object? collection, object? serviceKey) where TService : class
        => ServiceCollectionDescriptorExtensions.TryAddKeyedTransient<object>(collection, serviceKey);

    [TestMethod]
    public void Test_TryAddKeyedTransient_026() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddKeyedTransient_026), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_TryAddKeyedTransient_026<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>( object? collection, object? serviceKey) where TService : class where TImplementation : class, TService
        => ServiceCollectionDescriptorExtensions.TryAddKeyedTransient<object>(collection, serviceKey);

    [TestMethod]
    public void Test_TryAddKeyedTransient_027() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddKeyedTransient_027), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_TryAddKeyedTransient_027( object? collection, Type service, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
        => ServiceCollectionDescriptorExtensions.TryAddKeyedTransient(collection, service, serviceKey, implementationType);

    [TestMethod]
    public void Test_TryAddKeyedTransient_028() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddKeyedTransient_028), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_TryAddKeyedTransient_028( object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service, object? serviceKey)
        => ServiceCollectionDescriptorExtensions.TryAddKeyedTransient(collection, service, serviceKey);

    [TestMethod]
    public void Test_TryAddKeyedTransient_029() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddKeyedTransient_029), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_TryAddKeyedTransient_029<TService>( object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class
        => ServiceCollectionDescriptorExtensions.TryAddKeyedTransient<TService>(services, serviceKey, implementationFactory);

    [TestMethod]
    public void Test_TryAddKeyedTransient_030() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddKeyedTransient_030), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_TryAddKeyedTransient_030( object? collection, Type service, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory)
        => ServiceCollectionDescriptorExtensions.TryAddKeyedTransient(collection, service, serviceKey, implementationFactory);

    [TestMethod]
    public void Test_TryAddScoped_031() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddScoped_031), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_TryAddScoped_031( object? collection, Type service, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
        => ServiceCollectionDescriptorExtensions.TryAddScoped(collection, service, implementationType);

    [TestMethod]
    public void Test_TryAddScoped_032() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddScoped_032), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_TryAddScoped_032( object? collection, Type service, Func<IServiceProvider, object> implementationFactory)
        => ServiceCollectionDescriptorExtensions.TryAddScoped(collection, service, implementationFactory);

    [TestMethod]
    public void Test_TryAddScoped_033() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddScoped_033), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_TryAddScoped_033<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>( object? collection) where TService : class
        => ServiceCollectionDescriptorExtensions.TryAddScoped<object>(collection);

    [TestMethod]
    public void Test_TryAddScoped_034() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddScoped_034), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_TryAddScoped_034<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>( object? collection) where TService : class where TImplementation : class, TService
        => ServiceCollectionDescriptorExtensions.TryAddScoped<TService>(collection);

    [TestMethod]
    public void Test_TryAddScoped_035() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddScoped_035), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_TryAddScoped_035<TService>( object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class
        => ServiceCollectionDescriptorExtensions.TryAddScoped<TService>(services, implementationFactory);

    [TestMethod]
    public void Test_TryAddScoped_036() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddScoped_036), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_TryAddScoped_036( object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service)
        => ServiceCollectionDescriptorExtensions.TryAddScoped(collection, service);

    [TestMethod]
    public void Test_TryAddSingleton_037() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddSingleton_037), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_TryAddSingleton_037<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(object? collection) where TService : class
        => ServiceCollectionDescriptorExtensions.TryAddSingleton<object>(collection);

    [TestMethod]
    public void Test_TryAddSingleton_038() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddSingleton_038), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_TryAddSingleton_038<TService>( object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class
        => ServiceCollectionDescriptorExtensions.TryAddSingleton<TService>(services, implementationFactory);

    [TestMethod]
    public void Test_TryAddSingleton_039() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddSingleton_039), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_TryAddSingleton_039<TService>( object? collection, TService instance) where TService : class
        => ServiceCollectionDescriptorExtensions.TryAddSingleton<TService>(collection, instance);

    [TestMethod]
    public void Test_TryAddSingleton_040() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddSingleton_040), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_TryAddSingleton_040<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(object? collection) where TService : class where TImplementation : class, TService
        => ServiceCollectionDescriptorExtensions.TryAddSingleton<object>(collection);

    [TestMethod]
    public void Test_TryAddSingleton_041() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddSingleton_041), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_TryAddSingleton_041( object? collection, Type service, Func<IServiceProvider, object> implementationFactory)
        => ServiceCollectionDescriptorExtensions.TryAddSingleton(collection, service, implementationFactory);

    [TestMethod]
    public void Test_TryAddSingleton_042() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddSingleton_042), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_TryAddSingleton_042( object? collection, Type service, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
        => ServiceCollectionDescriptorExtensions.TryAddSingleton(collection, service, implementationType);

    [TestMethod]
    public void Test_TryAddSingleton_043() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddSingleton_043), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_TryAddSingleton_043( object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service)
        => ServiceCollectionDescriptorExtensions.TryAddSingleton(collection, service);

    [TestMethod]
    public void Test_TryAddTransient_044() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddTransient_044), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_TryAddTransient_044( object? collection, Type service, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
        => ServiceCollectionDescriptorExtensions.TryAddTransient(collection, service, implementationType);

    [TestMethod]
    public void Test_TryAddTransient_045() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddTransient_045), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_TryAddTransient_045( object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service)
        => ServiceCollectionDescriptorExtensions.TryAddTransient(collection, service);

    [TestMethod]
    public void Test_TryAddTransient_046() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddTransient_046), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_TryAddTransient_046<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>( object? collection) where TService : class where TImplementation : class, TService
        => ServiceCollectionDescriptorExtensions.TryAddTransient<object>(collection);

    [TestMethod]
    public void Test_TryAddTransient_047() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddTransient_047), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_TryAddTransient_047<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>( object? collection) where TService : class
        => ServiceCollectionDescriptorExtensions.TryAddTransient<object>(collection);

    [TestMethod]
    public void Test_TryAddTransient_048() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddTransient_048), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_TryAddTransient_048<TService>( object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class
        => ServiceCollectionDescriptorExtensions.TryAddTransient<TService>(services, implementationFactory);

    [TestMethod]
    public void Test_TryAddTransient_049() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_TryAddTransient_049), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_TryAddTransient_049( object? collection, Type service, Func<IServiceProvider, object> implementationFactory)
            => ServiceCollectionDescriptorExtensions.TryAddTransient(collection, service, implementationFactory);
}