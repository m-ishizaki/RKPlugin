using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using RkSoftware.RKPlugin.DependencyInjection.Internals;
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
    public static object? Add(this object? collection, object? descriptor)
        => Add("public static object? Add(this object? collection, object? descriptor)");

    [TestMethod]
    public static object? Add(this object? collection, IEnumerable<object?> descriptors)
        => Add("public static object? Add(this object? collection, IEnumerable<object?> descriptors)");

    [TestMethod]
    public static object? RemoveAll(this object? collection, Type serviceType)
        => Add("public static object? RemoveAll(this object? collection, Type serviceType)");

    [TestMethod]
    public static object? RemoveAll<T>(this object? collection)
        => Add("public static object? RemoveAll<T>(this object? collection)");

    [TestMethod]
    public static object? RemoveAllKeyed<T>(this object? collection, object? serviceKey)
        => Add("public static object? RemoveAllKeyed<T>(this object? collection, object? serviceKey)");

    [TestMethod]
    public static object? RemoveAllKeyed(this object? collection, Type serviceType, object? serviceKey)
        => Add("public static object? RemoveAllKeyed(this object? collection, Type serviceType, object? serviceKey)");

    [TestMethod]
    public static object? Replace(this object? collection, object? descriptor)
        => Add("public static object? Replace(this object? collection, object? descriptor)");

    [TestMethod]
    public static void TryAdd(this object? collection, object? descriptor)
        => Add("public static void TryAdd(this object? collection, object? descriptor)");

    [TestMethod]
    public static void TryAdd(this object? collection, IEnumerable<object?> descriptors)
        => Add("public static void TryAdd(this object? collection, IEnumerable<object?> descriptors)");

    [TestMethod]
    public static void TryAddEnumerable(this object? services, object? descriptor)
        => Add("public static void TryAddEnumerable(this object? services, object? descriptor)");

    [TestMethod]
    public static void TryAddEnumerable(this object? services, IEnumerable<object?> descriptors)
        => Add("public static void TryAddEnumerable(this object? services, IEnumerable<object?> descriptors)");

    [TestMethod]
    public static void TryAddKeyedScoped<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection, object? serviceKey) where TService : class where TImplementation : class, TService
        => Add("public static void TryAddKeyedScoped<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection, object? serviceKey) where TService : class where TImplementation : class, TService");

    [TestMethod]
    public static void TryAddKeyedScoped<TService>(this object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class
        => Add("public static void TryAddKeyedScoped<TService>(this object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class");

    [TestMethod]
    public static void TryAddKeyedScoped<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection, object? serviceKey) where TService : class
        => Add("public static void TryAddKeyedScoped<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection, object? serviceKey) where TService : class");

    [TestMethod]
    public static void TryAddKeyedScoped(this object? collection, Type service, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory)
        => Add("public static void TryAddKeyedScoped(this object? collection, Type service, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory)");

    [TestMethod]
    public static void TryAddKeyedScoped(this object? collection, Type service, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
        => Add("public static void TryAddKeyedScoped(this object? collection, Type service, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)");

    [TestMethod]
    public static void TryAddKeyedScoped(this object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service, object? serviceKey)
        => Add("public static void TryAddKeyedScoped(this object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service, object? serviceKey)");

    [TestMethod]
    public static void TryAddKeyedSingleton<TService>(this object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class
        => Add("public static void TryAddKeyedSingleton<TService>(this object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class");

    [TestMethod]
    public static void TryAddKeyedSingleton<TService>(this object? collection, object? serviceKey, TService instance) where TService : class
        => Add("public static void TryAddKeyedSingleton<TService>(this object? collection, object? serviceKey, TService instance) where TService : class");

    [TestMethod]
    public static void TryAddKeyedSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection, object? serviceKey) where TService : class where TImplementation : class, TService
        => Add("public static void TryAddKeyedSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection, object? serviceKey) where TService : class where TImplementation : class, TService");

    [TestMethod]
    public static void TryAddKeyedSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection, object? serviceKey) where TService : class
        => Add("public static void TryAddKeyedSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection, object? serviceKey) where TService : class");

    [TestMethod]
    public static void TryAddKeyedSingleton(this object? collection, Type service, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory)
        => Add("public static void TryAddKeyedSingleton(this object? collection, Type service, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory)");

    [TestMethod]
    public static void TryAddKeyedSingleton(this object? collection, Type service, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
        => Add("public static void TryAddKeyedSingleton(this object? collection, Type service, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)");

    [TestMethod]
    public static void TryAddKeyedSingleton(this object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service, object? serviceKey)
        => Add("public static void TryAddKeyedSingleton(this object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service, object? serviceKey)");

    [TestMethod]
    public static void TryAddKeyedTransient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection, object? serviceKey) where TService : class
        => Add("public static void TryAddKeyedTransient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection, object? serviceKey) where TService : class");

    [TestMethod]
    public static void TryAddKeyedTransient<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection, object? serviceKey) where TService : class where TImplementation : class, TService
        => Add("public static void TryAddKeyedTransient<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection, object? serviceKey) where TService : class where TImplementation : class, TService");

    [TestMethod]
    public static void TryAddKeyedTransient(this object? collection, Type service, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
        => Add("public static void TryAddKeyedTransient(this object? collection, Type service, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)");

    [TestMethod]
    public static void TryAddKeyedTransient(this object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service, object? serviceKey)
        => Add("public static void TryAddKeyedTransient(this object? collection, [DynamicallyAccessedMemberTypes.PublicConstructors)] Type service, object? serviceKey)");

    [TestMethod]
    public static void TryAddKeyedTransient<TService>(this object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class
        => Add("public static void TryAddKeyedTransient<TService>(this object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class");

    [TestMethod]
    public static void TryAddKeyedTransient(this object? collection, Type service, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory)
        => Add("public static void TryAddKeyedTransient(this object? collection, Type service, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory)");

    [TestMethod]
    public static void TryAddScoped(this object? collection, Type service, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
        => Add("public static void TryAddScoped(this object? collection, Type service, [DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)");

    [TestMethod]
    public static void TryAddScoped(this object? collection, Type service, Func<IServiceProvider, object> implementationFactory)
        => Add("public static void TryAddScoped(this object? collection, Type service, Func<IServiceProvider, object> implementationFactory)");

    [TestMethod]
    public static void TryAddScoped<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection) where TService : class
        => Add("public static void TryAddScoped<[DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection) where TService : class");

    [TestMethod]
    public static void TryAddScoped<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection) where TService : class where TImplementation : class, TService
        => Add("public static void TryAddScoped<TService, [DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection) where TService : class where TImplementation : class, TService");

    [TestMethod]
    public static void TryAddScoped<TService>(this object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class
        => Add("public static void TryAddScoped<TService>(this object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class");

    [TestMethod]
    public static void TryAddScoped(this object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service)
        => Add("public static void TryAddScoped(this object? collection, [DynamicallyAccessedMemberTypes.PublicConstructors)] Type service)");

    [TestMethod]
    public static void TryAddSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection) where TService : class
        => Add("public static void TryAddSingleton<[DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection) where TService : class");

    [TestMethod]
    public static void TryAddSingleton<TService>(this object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class
        => Add("public static void TryAddSingleton<TService>(this object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class");

    [TestMethod]
    public static void TryAddSingleton<TService>(this object? collection, TService instance) where TService : class
        => Add("public static void TryAddSingleton<TService>(this object? collection, TService instance) where TService : class");

    [TestMethod]
    public static void TryAddSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection) where TService : class where TImplementation : class, TService
        => Add("public static void TryAddSingleton<TService, [DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection) where TService : class where TImplementation : class, TService");

    [TestMethod]
    public static void TryAddSingleton(this object? collection, Type service, Func<IServiceProvider, object> implementationFactory)
        => Add("public static void TryAddSingleton(this object? collection, Type service, Func<IServiceProvider, object> implementationFactory)");

    [TestMethod]
    public static void TryAddSingleton(this object? collection, Type service, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
        => Add("public static void TryAddSingleton(this object? collection, Type service, [DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)");

    [TestMethod]
    public static void TryAddSingleton(this object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service)
        => Add("public static void TryAddSingleton(this object? collection, [DynamicallyAccessedMemberTypes.PublicConstructors)] Type service)");

    [TestMethod]
    public static void TryAddTransient(this object? collection, Type service, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
        => Add("public static void TryAddTransient(this object? collection, Type service, [DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)");

    [TestMethod]
    public static void TryAddTransient(this object? collection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type service)
        => Add("public static void TryAddTransient(this object? collection, [DynamicallyAccessedMemberTypes.PublicConstructors)] Type service)");

    [TestMethod]
    public static void TryAddTransient<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection) where TService : class where TImplementation : class, TService
        => Add("public static void TryAddTransient<TService, [DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? collection) where TService : class where TImplementation : class, TService");

    [TestMethod]
    public static void TryAddTransient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection) where TService : class
        => Add("public static void TryAddTransient<[DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? collection) where TService : class");

    [TestMethod]
    public static void TryAddTransient<TService>(this object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class
        => Add("public static void TryAddTransient<TService>(this object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class");

    [TestMethod]
    public static void TryAddTransient(this object? collection, Type service, Func<IServiceProvider, object> implementationFactory)
        => Add("public static void TryAddTransient(this object? collection, Type service, Func<IServiceProvider, object> implementationFactory)");
}