using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestResilienceServiceCollectionExtensions
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

    static List<string> Invoked = ResilienceServiceCollectionExtensions.Invoked;

    [TestMethod]
    public void Test_AddResilienceEnricher_001() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddResilienceEnricher_001), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddResilienceEnricher_001(object? services) =>
        ResilienceServiceCollectionExtensions.AddResilienceEnricher(services);
}
