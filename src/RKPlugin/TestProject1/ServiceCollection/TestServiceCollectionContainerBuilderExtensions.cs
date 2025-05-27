using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestServiceCollectionContainerBuilderExtensions
{
    static Object _lock = new Object();
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);

    static List<string> Invoked = ServiceCollectionContainerBuilderExtensions.Invoked;
    [TestMethod]
    public void Test_BuildServiceProvider_001() => Test(nameof(_Test_BuildServiceProvider_001));
    static void _Test_BuildServiceProvider_001(object? services) =>
        ServiceCollectionContainerBuilderExtensions.BuildServiceProvider(services);

    [TestMethod]
    public void Test_BuildServiceProvider_002() => Test(nameof(_Test_BuildServiceProvider_002));
    static void _Test_BuildServiceProvider_002(object? services) =>
        ServiceCollectionContainerBuilderExtensions.BuildServiceProvider(services, null);

    [TestMethod]
    public void Test_BuildServiceProvider_003() => Test(nameof(_Test_BuildServiceProvider_003));
    static void _Test_BuildServiceProvider_003(object? services) =>
        ServiceCollectionContainerBuilderExtensions.BuildServiceProvider(services, false);
}
