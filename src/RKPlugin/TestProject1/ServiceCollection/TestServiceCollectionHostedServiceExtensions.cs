using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestServiceCollectionHostedServiceExtensions
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

    static List<string> Invoked = ServiceCollectionHostedServiceExtensions.Invoked;

    public static object? AddHostedService<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] THostedService>(this object? services) where THostedService : class
        => Add("public static object? AddHostedService<[DynamicallyAccessedMemberTypes.PublicConstructors)] THostedService>(this object? services) where THostedService : class");

    public static object? AddHostedService<THostedService>(this object? services, Func<IServiceProvider, THostedService> implementationFactory) where THostedService : class
        => Add("public static object? AddHostedService<THostedService>(this object? services, Func<IServiceProvider, THostedService> implementationFactory) where THostedService : class");
}
