using Microsoft.Extensions.AmbientMetadata.Application;
using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestApplicationMetadataServiceCollectionExtensions
{
    static Object _lock = new Object();
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);

    static List<string> Invoked = ApplicationMetadataServiceCollectionExtensions.Invoked;

    [TestMethod]
    public void Test_AddApplicationMetadata_001() => Test(nameof(_Test_AddApplicationMetadata_001));
    static void _Test_AddApplicationMetadata_001(object? services) =>
        PluginServiceCollection.AddApplicationMetadata(services, section: null);

    [TestMethod]
    public void Test_AddApplicationMetadata_002() => Test(nameof(_Test_AddApplicationMetadata_002));
    static void _Test_AddApplicationMetadata_002(object? services) =>
        PluginServiceCollection.AddApplicationMetadata(services, configure: Test1.DummyAction);
}