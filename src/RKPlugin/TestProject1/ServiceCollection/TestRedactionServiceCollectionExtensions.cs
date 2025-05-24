using Microsoft.Extensions.Compliance.Redaction;
using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestRedactionServiceCollectionExtensions
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

    static List<string> Invoked = RedactionServiceCollectionExtensions.Invoked;

    [TestMethod]
    public void Test_AddRedaction_001() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddRedaction_001), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddRedaction_001(object? services, object? section) =>
        RedactionServiceCollectionExtensions.AddRedaction(services, section);

    [TestMethod]
    public void Test_AddRedaction_002() =>
        Test(Invoked, () => PluginLoadContext.Invoke(new object(), this.GetType().GetMethod(nameof(
            _Test_AddRedaction_002), BindingFlags.NonPublic | BindingFlags.Static)!, null, [null, null]));
    static void _Test_AddRedaction_002(object? services, Action<object?> configure) =>
        RedactionServiceCollectionExtensions.AddRedaction(services, configure);
}
