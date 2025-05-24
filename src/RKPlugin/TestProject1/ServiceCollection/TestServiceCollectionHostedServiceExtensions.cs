using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
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

    [TestMethod]
    public void Test_AddHostedService_001() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddHostedService_001), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddHostedService_001<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] THostedService>(object? services) where THostedService : class =>
        PluginServiceCollection.AddHostedService<THostedService>(services);

    [TestMethod]
    public void Test_AddHostedService_002() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddHostedService_002), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddHostedService_002<THostedService>(object? services, Func<IServiceProvider, THostedService> implementationFactory) where THostedService : class =>
        PluginServiceCollection.AddHostedService<THostedService>(services, implementationFactory);
}
