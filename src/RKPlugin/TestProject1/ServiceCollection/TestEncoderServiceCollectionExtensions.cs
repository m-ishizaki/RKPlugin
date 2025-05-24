using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestEncoderServiceCollectionExtensions
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

    static List<string> Invoked = EncoderServiceCollectionExtensions.Invoked;

    [TestMethod]
    public void Test_AddWebEncoders_001() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddWebEncoders_001), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null]));
    static void _Test_AddWebEncoders_001(object? services) =>
        EncoderServiceCollectionExtensions.AddWebEncoders(services);

    [TestMethod]
    public void Test_AddWebEncoders_002() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddWebEncoders_002), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddWebEncoders_002(object? services, Action<object?> setupAction) =>
        EncoderServiceCollectionExtensions.AddWebEncoders(services, setupAction);
}