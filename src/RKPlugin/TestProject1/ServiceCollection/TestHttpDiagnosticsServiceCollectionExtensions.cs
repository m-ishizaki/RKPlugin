using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestHttpDiagnosticsServiceCollectionExtensions
{
    static Object _lock = new Object();
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);
    static List<string> Invoked = HttpDiagnosticsServiceCollectionExtensions.Invoked;

    [TestMethod]
    public void Test_AddDownstreamDependencyMetadata_001() =>
        Test(nameof(
            _Test_AddDownstreamDependencyMetadata_001));
    static void _Test_AddDownstreamDependencyMetadata_001(object? services, object? downstreamDependencyMetadata) =>
        PluginServiceCollection.AddDownstreamDependencyMetadata(services, downstreamDependencyMetadata);

    [TestMethod]
    public void Test_AddDownstreamDependencyMetadata_002() =>
        Test(nameof(
            _Test_AddDownstreamDependencyMetadata_002));
    static void _Test_AddDownstreamDependencyMetadata_002(object? services) =>
        PluginServiceCollection.AddDownstreamDependencyMetadata<object>(services);
}
