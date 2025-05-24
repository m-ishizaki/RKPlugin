using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
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
    public static object? AddTransient(this object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
        => Add("public static object? AddTransient(this object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)");

    [TestMethod]
    public static object? AddTransient(this object? services, Type serviceType, Func<IServiceProvider, object> implementationFactory)
        => Add("public static object? AddTransient(this object? services, Type serviceType, Func<IServiceProvider, object> implementationFactory)");

    [TestMethod]
    public static object? AddTransient<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services) where TService : class where TImplementation : class, TService
        => Add("public static object? AddTransient<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services) where TService : class where TImplementation : class, TService");

    [TestMethod]
    public static object? AddTransient(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType)
        => Add("public static object? AddTransient(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType)");

    [TestMethod]
    public static object? AddTransient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services) where TService : class
        => Add("public static object? AddTransient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services) where TService : class");

    [TestMethod]
    public static object? AddTransient<TService>(this object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class
        => Add("public static object? AddTransient<TService>(this object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class");

    [TestMethod]
    public static object? AddTransient<TService, TImplementation>(this object? services, Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService
        => Add("public static object? AddTransient<TService, TImplementation>(this object? services, Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService");

    [TestMethod]
    public static object? AddScoped(this object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
        => Add("public static object? AddScoped(this object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)");

    [TestMethod]
    public static object? AddScoped(this object? services, Type serviceType, Func<IServiceProvider, object> implementationFactory)
        => Add("public static object? AddScoped(this object? services, Type serviceType, Func<IServiceProvider, object> implementationFactory)");

    [TestMethod]
    public static object? AddScoped<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services) where TService : class where TImplementation : class, TService
        => Add("public static object? AddScoped<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services) where TService : class where TImplementation : class, TService");

    [TestMethod]
    public static object? AddScoped(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType)
        => Add("public static object? AddScoped(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType)");

    [TestMethod]
    public static object? AddScoped<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services) where TService : class
        => Add("public static object? AddScoped<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services) where TService : class");

    [TestMethod]
    public static object? AddScoped<TService>(object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class
        => Add("public static object? AddScoped<TService>(object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class");

    [TestMethod]
    public static object? AddScoped<TService, TImplementation>(this object? services, Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService
        => Add("public static object? AddScoped<TService, TImplementation>(this object? services, Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService");

    [TestMethod]
    public static object? AddSingleton(this object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
        => Add("public static object? AddSingleton(this object? services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)");

    [TestMethod]
    public static object? AddSingleton(this object? services, Type serviceType, Func<IServiceProvider, object> implementationFactory)
        => Add("public static object? AddSingleton(this object? services, Type serviceType, Func<IServiceProvider, object> implementationFactory)");

    [TestMethod]
    public static object? AddSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services) where TService : class where TImplementation : class, TService
        => Add("public static object? AddSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services) where TService : class where TImplementation : class, TService");

    [TestMethod]
    public static object? AddSingleton(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType)
        => Add("public static object? AddSingleton(this object? services, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType)");

    [TestMethod]
    public static object? AddSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services) where TService : class
        => Add("public static object? AddSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services) where TService : class");

    [TestMethod]
    public static object? AddSingleton<TService>(this object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class
        => Add("public static object? AddSingleton<TService>(this object? services, Func<IServiceProvider, TService> implementationFactory) where TService : class");

    [TestMethod]
    public static object? AddSingleton<TService, TImplementation>(this object? services, Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService
        => Add("public static object? AddSingleton<TService, TImplementation>(this object? services, Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService");

    [TestMethod]
    public static object? AddSingleton(this object? services, Type serviceType, object implementationInstance)
        => Add("public static object? AddSingleton(this object? services, Type serviceType, object implementationInstance)");

    [TestMethod]
    public static object? AddSingleton<TService>(this object? services, TService implementationInstance) where TService : class
        => Add("public static object? AddSingleton<TService>(this object? services, TService implementationInstance) where TService : class");
}
