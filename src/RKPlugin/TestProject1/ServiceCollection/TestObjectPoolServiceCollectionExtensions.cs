using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestObjectPoolServiceCollectionExtensions
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

    static List<string> Invoked = ObjectPoolServiceCollectionExtensions.Invoked;

    public static object? AddPooled<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services, Action<object?>? configure = null) where TService : class
        => Add("public static object? AddPooled<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this object? services, Action<object?>? configure = null) where TService : class");

    public static object? AddPooled<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services, Action<object?>? configure = null) where TService : class where TImplementation : class, TService
        => Add("public static object? AddPooled<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services, Action<object?>? configure = null) where TService : class where TImplementation : class, TService");

    public static object? ConfigurePool<TService>(this object? services, Action<object?> configure) where TService : class
        => Add("public static object? ConfigurePool<TService>(this object? services, Action<object?> configure) where TService : class");

    public static object? ConfigurePools(this object? services, object?section)
        => Add("public static object? ConfigurePools(this object? services, object? section)");

    private static object? AddPooledInternal<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services, Action<object?>? configure) where TService : class where TImplementation : class, TService
        => Add("private static object? AddPooledInternal<TService, [DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this object? services, Action<object?>? configure) where TService : class where TImplementation : class, TService");
}
