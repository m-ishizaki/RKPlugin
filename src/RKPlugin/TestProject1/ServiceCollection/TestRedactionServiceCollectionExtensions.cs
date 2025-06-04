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
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);

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
    public void Test_AddRedaction_001() => Test(nameof(_Test_AddRedaction_001));
    static void _Test_AddRedaction_001(object? services) =>
        PluginServiceCollection.AddRedaction(services, null);

    [TestMethod]
    public void Test_AddRedaction_002() => Test(nameof(_Test_AddRedaction_002));
    static void _Test_AddRedaction_002(object? services) =>
        PluginServiceCollection.AddRedaction(services, (obj) => { });
}
