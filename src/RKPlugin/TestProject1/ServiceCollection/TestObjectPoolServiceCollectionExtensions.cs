using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestObjectPoolServiceCollectionExtensions
{
    static Object _lock = new Object();
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);

    static List<string> Invoked = ObjectPoolServiceCollectionExtensions.Invoked;

    [TestMethod]
    public void Test_AddPooled_001() => Test(nameof(_Test_AddPooled_001));
    static void _Test_AddPooled_001(object? services, Action<object?>? configure = null) =>
        ObjectPoolServiceCollectionExtensions.AddPooled<object>(services, configure);

    [TestMethod]
    public void Test_AddPooled_002() => Test(nameof(_Test_AddPooled_002));
    static void _Test_AddPooled_002(object? services, Action<object?>? configure = null) =>
        ObjectPoolServiceCollectionExtensions.AddPooled<object, object>(services, configure);

    [TestMethod]
    public void Test_ConfigurePool_001() => Test(nameof(_Test_ConfigurePool_001));
    static void _Test_ConfigurePool_001(object? services, Action<object?> configure) =>
        ObjectPoolServiceCollectionExtensions.ConfigurePool<object>(services, configure);

    [TestMethod]
    public void Test_ConfigurePools_001() => Test(nameof(_Test_ConfigurePools_001));
    static void _Test_ConfigurePools_001(object? services, object? section) =>
        ObjectPoolServiceCollectionExtensions.ConfigurePools(services, section);
}