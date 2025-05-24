using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using RkSoftware.RKPlugin.DependencyInjection.Internals;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestAutoActivationExtensions
{
    static Object _lock = new Lock();
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
    public static object? ActivateSingleton<TService>(this object? services) where TService : class
        => Add("public static object? ActivateSingleton<TService>(this object? services) where TService : class");

    [TestMethod]
    public static object? ActivateSingleton(this object? services, Type serviceType)
        => Add("public static object? ActivateSingleton(this object? services, Type serviceType)");

    [TestMethod]
    public static object? AddActivatedSingleton<TService, TImplementation>(this object? services, Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService
        => Add("public static object? AddActivatedSingleton<TService, TImplementation>(this object? services, Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService");

    [TestMethod]
    public static object? AddActivatedSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services) where TService : class where TImplementation : class, TService
        => Add("public static object? AddActivatedSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services) where TService : class where TImplementation : class, TService");

    [TestMethod]
    public static object? AddActivatedSingleton<TService>(this object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class
        => Add("public static object? AddActivatedSingleton<TService>(this object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class");

    [TestMethod]
    public static object? AddActivatedSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services) where TService : class
        => Add("public static object? AddActivatedSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services) where TService : class");

    [TestMethod]
    public static object? AddActivatedSingleton(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType)
        => Add("public static object? AddActivatedSingleton(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType)");

    [TestMethod]
    public static object? AddActivatedSingleton(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType, Func<IServiceProvider, object> implementationFactory)
        => Add("public static object? AddActivatedSingleton(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType, Func<IServiceProvider, object> implementationFactory)");

    [TestMethod]
    public static object? AddActivatedSingleton(this object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
        => Add("public static object? AddActivatedSingleton(this object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)");

    [TestMethod]
    public static void TryAddActivatedSingleton(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType)
        => Add("public static void TryAddActivatedSingleton(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType)");

    [TestMethod]
    public static void TryAddActivatedSingleton(this object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
        => Add("public static void TryAddActivatedSingleton(this object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)");

    [TestMethod]
    public static void TryAddActivatedSingleton(this object? services, Type serviceType, Func<IServiceProvider, object> implementationFactory)
        => Add("public static void TryAddActivatedSingleton(this object? services, Type serviceType, Func<IServiceProvider, object> implementationFactory)");

    [TestMethod]
    public static void TryAddActivatedSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services) where TService : class
        => Add("public static void TryAddActivatedSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services) where TService : class");

    [TestMethod]
    public static void TryAddActivatedSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services) where TService : class where TImplementation : class, TService
        => Add("public static void TryAddActivatedSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services) where TService : class where TImplementation : class, TService");

    [TestMethod]
    public static void TryAddActivatedSingleton<TService>(this object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class
        => Add("public static void TryAddActivatedSingleton<TService>(this object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class");

    private static void TryAddAndActivate<TService>(this object? services, object? descriptor) where TService : class
        => Add("private static void TryAddAndActivate<TService>(this object? services, object? descriptor) where TService : class");

    private static void TryAddAndActivate(this object? services, object? descriptor)
        => Add("private static void TryAddAndActivate(this object? services, object? descriptor)");

    [TestMethod]
    public static object? ActivateKeyedSingleton<TService>(this object? services, object? serviceKey) where TService : class
        => Add("public static object? ActivateKeyedSingleton<TService>(this object? services, object? serviceKey) where TService : class");

    [TestMethod]
    public static object? ActivateKeyedSingleton(this object? services, Type serviceType, object? serviceKey)
        => Add("public static object? ActivateKeyedSingleton(this object? services, Type serviceType, object? serviceKey)");

    [TestMethod]
    public static object? AddActivatedKeyedSingleton<TService, TImplementation>(this object? services, object? serviceKey, Func<IServiceProvider, object?, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService
        => Add("public static object? AddActivatedKeyedSingleton<TService, TImplementation>(this object? services, object? serviceKey, Func<IServiceProvider, object?, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService");

    [TestMethod]
    public static object? AddActivatedKeyedSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services, object? serviceKey) where TService : class where TImplementation : class, TService
        => Add("public static object? AddActivatedKeyedSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services, object? serviceKey) where TService : class where TImplementation : class, TService");

    [TestMethod]
    public static object? AddActivatedKeyedSingleton<TService>(this object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class
        => Add("public static object? AddActivatedKeyedSingleton<TService>(this object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class");

    [TestMethod]
    public static object? AddActivatedKeyedSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services, object? serviceKey) where TService : class
        => Add("public static object? AddActivatedKeyedSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services, object? serviceKey) where TService : class");

    [TestMethod]
    public static object? AddActivatedKeyedSingleton(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType, object? serviceKey)
        => Add("public static object? AddActivatedKeyedSingleton(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType, object? serviceKey)");

    [TestMethod]
    public static object? AddActivatedKeyedSingleton(this object? services, Type serviceType, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory)
        => Add("public static object? AddActivatedKeyedSingleton(this object? services, Type serviceType, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory)");

    [TestMethod]
    public static object? AddActivatedKeyedSingleton(this object? services, Type serviceType, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
        => Add("public static object? AddActivatedKeyedSingleton(this object? services, Type serviceType, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)");

    [TestMethod]
    public static void TryAddActivatedKeyedSingleton(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType, object? serviceKey)
        => Add("public static void TryAddActivatedKeyedSingleton(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType, object? serviceKey)");

    [TestMethod]
    public static void TryAddActivatedKeyedSingleton(this object? services, Type serviceType, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
        => Add("public static void TryAddActivatedKeyedSingleton(this object? services, Type serviceType, object? serviceKey, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)");

    [TestMethod]
    public static void TryAddActivatedKeyedSingleton(this object? services, Type serviceType, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory)
        => Add("public static void TryAddActivatedKeyedSingleton(this object? services, Type serviceType, object? serviceKey, Func<IServiceProvider, object?, object> implementationFactory)");

    [TestMethod]
    public static void TryAddActivatedKeyedSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services, object? serviceKey) where TService : class
        => Add("public static void TryAddActivatedKeyedSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services, object? serviceKey) where TService : class");

    [TestMethod]
    public static void TryAddActivatedKeyedSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services, object? serviceKey) where TService : class where TImplementation : class, TService
        => Add("public static void TryAddActivatedKeyedSingleton<TService, [DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services, object? serviceKey) where TService : class where TImplementation : class, TService");

    [TestMethod]
    public static void TryAddActivatedKeyedSingleton<TService>(this object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class
        => Add("public static void TryAddActivatedKeyedSingleton<TService>(this object? services, object? serviceKey, Func<IServiceProvider, object?, TService> implementationFactory) where TService : class");

    private static void TryAddAndActivateKeyed<TService>(this object? services, object? descriptor) where TService : class
        => Add("private static void TryAddAndActivateKeyed<TService>(this object? services, object? descriptor) where TService : class");

    private static void TryAddAndActivateKeyed(this object? services, object? descriptor)
        => Add("private static void TryAddAndActivateKeyed(this object? services, object? descriptor)");
}
