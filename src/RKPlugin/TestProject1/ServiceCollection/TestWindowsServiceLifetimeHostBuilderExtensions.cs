using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestWindowsServiceLifetimeHostBuilderExtensions
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

    static List<string> Invoked = WindowsServiceLifetimeHostBuilderExtensions.Invoked;

    [TestMethod]
    public void Test_AddWindowsService_001() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddWindowsService_001), BindingFlags.NonPublic | BindingFlags.Static)!, null, []));
    static void _Test_AddWindowsService_001(object? services) =>
        WindowsServiceLifetimeHostBuilderExtensions.AddWindowsService(services);

    [TestMethod]
    public void Test_AddWindowsService_002() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddWindowsService_002), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddWindowsService_002(object? services, Action<object?> configure) =>
        WindowsServiceLifetimeHostBuilderExtensions.AddWindowsService(services, configure);
}