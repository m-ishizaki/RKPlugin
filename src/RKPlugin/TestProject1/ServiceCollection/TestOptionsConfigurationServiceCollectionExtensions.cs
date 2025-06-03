using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestOptionsConfigurationServiceCollectionExtensions
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

    static List<string> Invoked = OptionsConfigurationServiceCollectionExtensions.Invoked;

    [TestMethod]
    public void Test_Configure_001() => Test(nameof(_Test_Configure_001));
    static void _Test_Configure_001(object? services) =>
        OptionsConfigurationServiceCollectionExtensions.Configure<object>(services, null);

    [TestMethod]
    public void Test_Configure_002() => Test(nameof(_Test_Configure_002));
    static void _Test_Configure_002(object? services) =>
        OptionsConfigurationServiceCollectionExtensions.Configure<object>(services, name: "", config: null);

    [TestMethod]
    public void Test_Configure_003() => Test(nameof(_Test_Configure_003));
    static void _Test_Configure_003(object? services) =>
        OptionsConfigurationServiceCollectionExtensions.Configure<object>(services, config: null, configureBinder: null);

    [TestMethod]
    public void Test_Configure_004() => Test(nameof(_Test_Configure_004));
    static void _Test_Configure_004(object? services) =>
        OptionsConfigurationServiceCollectionExtensions.Configure<object>(services, name: "", config: null, configureBinder: null);
}
