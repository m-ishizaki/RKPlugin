using Microsoft.Extensions.DependencyInjection;
using RkSoftware.RKPlugin;
using RkSoftware.RKPlugin.DependencyInjection;
using System.Reflection;

namespace TestProject1.ServiceCollection;

[TestClass]
public sealed class TestLocalizationServiceCollectionExtensions
{
    static Object _lock = new Object();
    void Test(string methodName) => Test1.Test(methodName, this, _lock, Invoked);

    static List<string> Invoked = LocalizationServiceCollectionExtensions.Invoked;

    [TestMethod]
    public void Test_AddLocalization_001() => Test(nameof(_Test_AddLocalization_001));
    static void _Test_AddLocalization_001(object? services) =>
        PluginServiceCollection.AddLocalization(services);

    [TestMethod]
    public void Test_AddLocalization_002() => Test(nameof(_Test_AddLocalization_002));
    static void _Test_AddLocalization_002(object? services, Action<object?> setupAction) =>
        PluginServiceCollection.AddLocalization(services, setupAction);
}